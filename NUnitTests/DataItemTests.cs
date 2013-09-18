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
using NUnit.Framework.Constraints;


namespace NUnit.AdapterLabTests
{
    using MTConnect;
    using NUnit.Framework;

    [TestFixture]
    public class DataItemTests
    {
        Event e;
        Message m;

        [SetUp]
        public void setup()
        {
            e = new Event("test");
            m = new Message("m");
        }

        [Test]
        public void should_track_changed_state()
        {
            Assert.AreEqual(true, e.Changed);
            Assert.AreEqual("UNAVAILABLE", e.Value);

            e.Cleanup();
            Assert.AreEqual(false, e.Changed);

            e.Value = "AAA";
            Assert.AreEqual(true, e.Changed);
            Assert.AreEqual("AAA", e.Value);
        }

        [Test]
        public void should_format_text()
        {
            Assert.AreEqual("test|UNAVAILABLE", e.ToString());

            Sample s = new Sample("s");
            s.Value = 12.34;
            Assert.AreEqual("s|12.34", s.ToString());
        }

        [Test]
        public void newline_should_be_false_for_an_event()
        {
            Assert.AreEqual(false, e.NewLine);
        }

        [Test]
        public void message_should_be_on_a_new_line()
        {
            Assert.AreEqual(true, m.NewLine);
        }

        [Test]
        public void message_should_have_code_and_value()
        {
            m.Code = "XXX";
            m.Value = "text";

            Assert.AreEqual("m|XXX|text", m.ToString());
        }

        [Test]
        public void time_series_should_have_rate_count_and_values()
        {
            TimeSeries s = new TimeSeries("ts", 100);
            s.Values = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Assert.AreEqual("ts|10|100|1 2 3 4 5 6 7 8 9 10", s.ToString());
        }


        [Test]
        public void time_series_should_have_count_and_values_without_rate()
        {
            TimeSeries s = new TimeSeries("ts");
            s.Values = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Assert.AreEqual("ts|10||1 2 3 4 5 6 7 8 9 10", s.ToString());
        }

        [Test]
        public void time_series_should_be_on_a_new_line()
        {
            TimeSeries s = new TimeSeries("ts");
            Assert.IsTrue(s.NewLine);
        }
    }
}
