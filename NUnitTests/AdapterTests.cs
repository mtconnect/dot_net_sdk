/*
 * Copyright Copyright 2012, System Insights, Inc.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *       http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 */

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using NUnit.Framework.Constraints;

namespace NUnit.AdapterLabTests
{
    using MTConnect;
    using NUnit.Framework;

    [TestFixture]
    public class AdapterTests
    {
        Adapter adapter;
        ASCIIEncoding encoder = new ASCIIEncoding();
        Stream stream;

        [SetUp]
        public void initialize()
        {
            stream = new MemoryStream(2048);
            adapter = new Adapter(0);
            adapter.Start();
            while (!adapter.Running) Thread.Sleep(10);
        }

        [TearDown]
        public void cleanup()
        {
            adapter.Stop();
        }

        [Test]
        public void should_have_a_non_zero_port()
        {
            Assert.AreNotEqual(0, adapter.ServerPort);
        }

        [Test]
        public void should_receive_initial_data_when_connected()
        {
            Event avail = new Event("avail");
            adapter.AddDataItem(avail);
            avail.Value = "AVAILABLE";

            adapter.addClientStream(stream);
            stream.Seek(0, SeekOrigin.Begin);
            
            byte[] buffer = new byte[1024];
            int count = stream.Read(buffer, 0, 1024);

            String line = encoder.GetString(buffer, 0, count);
            Assert.IsTrue(line.EndsWith("avail|AVAILABLE\n"));
        }

        [Test]
        public void should_receive_updates_when_data_item_changes()
        {
            Event avail = new Event("avail");
            adapter.AddDataItem(avail);
            avail.Value = "AVAILABLE";
            adapter.SendChanged();

            adapter.addClientStream(stream);
            long pos = stream.Position;

            avail.Value = "AVAILABLE";
            adapter.SendChanged();

            avail.Value = "UNAVAILABLE";
            adapter.SendChanged();

            byte[] buffer = new byte[1024];
            stream.Seek(pos, SeekOrigin.Begin);
            int count = stream.Read(buffer, 0, 1024);
            string line = encoder.GetString(buffer, 0, count);

            Assert.IsTrue(line.EndsWith("avail|UNAVAILABLE\n"));
        }

        [Test]
        public void should_combine_multiple_data_items_on_one_line()
        {
            Event avail = new Event("avail");
            adapter.AddDataItem(avail);
            avail.Value = "AVAILABLE";

            Event estop = new Event("estop");
            adapter.AddDataItem(estop);
            estop.Value = "ARMED";
            adapter.SendChanged();

            adapter.addClientStream(stream);
            stream.Seek(0, SeekOrigin.Begin);

            byte[] buffer = new byte[1024];
            int count = stream.Read(buffer, 0, 1024);

            String line = encoder.GetString(buffer, 0, count);
            Assert.IsTrue(line.EndsWith("avail|AVAILABLE|estop|ARMED\n"));
        }

        [Test]
        public void should_put_messages_on_separate_lines()
        {
            Event avail = new Event("avail");
            adapter.AddDataItem(avail);
            avail.Value = "AVAILABLE";

            Message msg = new Message("message");
            adapter.AddDataItem(msg);
            msg.Value = "Message";
            msg.Code = "123";
            adapter.SendChanged();

            adapter.addClientStream(stream);

            stream.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[1024];
            int count = stream.Read(buffer, 0, 1024);

            String s = encoder.GetString(buffer, 0, count);
            string[] lines = s.Split('\n');
            Assert.AreEqual(3, lines.Length);
            Assert.IsTrue(lines[0].EndsWith("avail|AVAILABLE"));
            Assert.IsTrue(lines[1].EndsWith("message|123|Message"));
            Assert.AreEqual(0, lines[2].Length);
        }

        [Test]
        public void should_send_condition_on_fault()
        {
            Event avail = new Event("avail");
            adapter.AddDataItem(avail);
            avail.Value = "AVAILABLE";

            Condition cond = new Condition("cond");
            cond.Normal();
            adapter.AddDataItem(cond);
            adapter.SendChanged();

            adapter.addClientStream(stream);
            long pos = stream.Position;

            adapter.Begin();
            cond.Add(Condition.Level.FAULT, "A Fault", "111");
            adapter.SendChanged();

            stream.Seek(pos, SeekOrigin.Begin);
            byte[] buffer = new byte[1024];
            int count = stream.Read(buffer, 0, 1024);
            String line = encoder.GetString(buffer, 0, count);
            Assert.IsTrue(line.EndsWith("cond|FAULT|111|||A Fault\n"));
        }

        [Test]
        public void should_send_normal_when_fault_is_not_reasserted()
        {
            Event avail = new Event("avail");
            adapter.AddDataItem(avail);
            avail.Value = "AVAILABLE";

            Condition cond = new Condition("cond");
            cond.Normal();
            adapter.AddDataItem(cond);
            adapter.SendChanged();

            adapter.addClientStream(stream);

            adapter.Begin();
            cond.Add(Condition.Level.FAULT, "A Fault", "111");
            adapter.SendChanged();
            long pos = stream.Position;

            adapter.Begin();
            adapter.SendChanged();

            stream.Seek(pos, SeekOrigin.Begin);
            byte[] buffer = new byte[1024];
            int count = stream.Read(buffer, 0, 1024);
            String line = encoder.GetString(buffer, 0, count);
            Assert.IsTrue(line.EndsWith("cond|NORMAL||||\n"));
        }

        [Test]
        public void should_send_normal_for_single_fault_when_more_than_one_are_active()
        {
            Event avail = new Event("avail");
            adapter.AddDataItem(avail);
            avail.Value = "AVAILABLE";

            Condition cond = new Condition("cond");
            cond.Normal();
            adapter.AddDataItem(cond);
            adapter.SendChanged();

            adapter.addClientStream(stream);

            adapter.Begin();
            cond.Add(Condition.Level.FAULT, "A Fault", "111");
            cond.Add(Condition.Level.FAULT, "Another Fault", "112");
            adapter.SendChanged();
            long pos = stream.Position;

            adapter.Begin();
            cond.Add(Condition.Level.FAULT, "Another Fault", "112");
            adapter.SendChanged();

            stream.Seek(pos, SeekOrigin.Begin);
            byte[] buffer = new byte[1024];
            int count = stream.Read(buffer, 0, 1024);
            String line = encoder.GetString(buffer, 0, count);
            Assert.IsTrue(line.EndsWith("cond|NORMAL|111|||\n"));
        }

        [Test]
        public void should_send_normal_when_last_active_condition_is_cleared()
        {
            Event avail = new Event("avail");
            adapter.AddDataItem(avail);
            avail.Value = "AVAILABLE";

            Condition cond = new Condition("cond");
            cond.Normal();
            adapter.AddDataItem(cond);
            adapter.SendChanged();

            adapter.addClientStream(stream);

            adapter.Begin();
            cond.Add(Condition.Level.FAULT, "A Fault", "111");
            cond.Add(Condition.Level.FAULT, "Another Fault", "112");
            adapter.SendChanged();

            adapter.Begin();
            cond.Add(Condition.Level.FAULT, "Another Fault", "112");
            adapter.SendChanged();
            long pos = stream.Position;

            adapter.Begin();
            adapter.SendChanged();
            
            stream.Seek(pos, SeekOrigin.Begin);
            byte[] buffer = new byte[1024];
            int count = stream.Read(buffer, 0, 1024);
            String line = encoder.GetString(buffer, 0, count);
            Assert.IsTrue(line.EndsWith("cond|NORMAL||||\n"));
        }

        [Test]
        public void should_not_clear_a_simple_condition()
        {
            Event avail = new Event("avail");
            adapter.AddDataItem(avail);
            avail.Value = "AVAILABLE";

            Condition cond = new Condition("cond", true);
            cond.Normal();
            adapter.AddDataItem(cond);
            adapter.SendChanged();

            adapter.addClientStream(stream);

            adapter.Begin();
            cond.Add(Condition.Level.FAULT, "A Fault", "111");
            adapter.SendChanged();
            long pos = stream.Position;

            adapter.Begin();
            adapter.SendChanged();

            Assert.AreEqual(pos, stream.Position);
        }

        [Test]
        public void should_manually_clear_condition()
        {
            Event avail = new Event("avail");
            adapter.AddDataItem(avail);
            avail.Value = "AVAILABLE";

            Condition cond = new Condition("cond", true);
            cond.Normal();
            adapter.AddDataItem(cond);
            adapter.SendChanged();

            adapter.addClientStream(stream);

            adapter.Begin();
            cond.Add(Condition.Level.FAULT, "A Fault", "111");
            adapter.SendChanged();
            long pos = stream.Position;

            adapter.Begin();
            cond.Clear("111");
            adapter.SendChanged();

            stream.Seek(pos, SeekOrigin.Begin);
            byte[] buffer = new byte[1024];
            int count = stream.Read(buffer, 0, 1024);
            String line = encoder.GetString(buffer, 0, count);
            Assert.IsTrue(line.EndsWith("cond|NORMAL||||\n"));
        }

        [Test]
        public void shoud_manually_clear_one_condition_when_multiple_are_present()
        {
            Event avail = new Event("avail");
            adapter.AddDataItem(avail);
            avail.Value = "AVAILABLE";

            Condition cond = new Condition("cond", true);
            cond.Normal();
            adapter.AddDataItem(cond);
            adapter.SendChanged();

            adapter.addClientStream(stream);

            adapter.Begin();
            cond.Add(Condition.Level.FAULT, "A Fault", "111");
            cond.Add(Condition.Level.FAULT, "Another Fault", "112");
            adapter.SendChanged();
            long pos = stream.Position;

            adapter.Begin();
            cond.Clear("111");
            adapter.SendChanged();

            stream.Seek(pos, SeekOrigin.Begin);
            byte[] buffer = new byte[1024];
            int count = stream.Read(buffer, 0, 1024);
            String line = encoder.GetString(buffer, 0, count);
            Assert.IsTrue(line.EndsWith("cond|NORMAL|111|||\n"));
        }

        [Test]
        public void should_send_cutting_tool()
        {
            Event avail = new Event("avail");
            adapter.AddDataItem(avail);
            avail.Value = "AVAILABLE";
            adapter.SendChanged();

            adapter.addClientStream(stream);
            long pos = stream.Position;

            CuttingTool tool = new CuttingTool("12345", "AAAA", "12345");
            tool.Description = "A tool description";
            tool.AddProperty("ProcessSpindleSpeed",
                            new string[] { "minimum", "1000", "maximum", "10000", },
                            "2500");
            tool.AddStatus(new string[] { "USED", "MEASURED" });

            adapter.AddAsset(tool);

            stream.Seek(pos, SeekOrigin.Begin);
            byte[] buffer = new byte[1024];
            int count = stream.Read(buffer, 0, 1024);
            String line = encoder.GetString(buffer, 0, count);
            Assert.IsTrue(line.EndsWith("|@ASSET@|12345|CuttingTool|--multiline--ABCD\n<CuttingTool toolId=\"AAAA\" serialNumber=\"12345\" assetId=\"12345\"><Description>A tool description</Description><CuttingToolLifeCycle><ProcessSpindleSpeed minimum=\"1000\" maximum=\"10000\">2500</ProcessSpindleSpeed><CutterStatus><Status>USED</Status><Status>MEASURED</Status></CutterStatus></CuttingToolLifeCycle></CuttingTool>\n--multiline--ABCD\n"));
        }
    }
}
