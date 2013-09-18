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
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;

namespace NUnit.AdapterLabTests
{
    using MTConnect;
    using NUnit.Framework;

    [TestFixture]
    public class CuttingToolTests
    {
        UTF8Encoding encoder = new UTF8Encoding();
        StringBuilder result;
        XmlWriter writer;

        [SetUp]
        public void initialize()
        {
            result = new StringBuilder();
            writer = XmlWriter.Create(result);
            writer.WriteStartDocument();
        }

        [Test]
        public void should_create_xml_document()
        {
            CuttingTool tool = new CuttingTool("12345", "AAAA", "12345");
            tool.Description = "A tool description";
            tool.Manufacturers = "SMPY";

            tool.ToXml(writer);
            writer.WriteEndDocument();
            writer.Close();

            XElement cuttingTool = XElement.Parse(result.ToString());
            Assert.AreEqual("CuttingTool", cuttingTool.Name.ToString());
            Assert.AreEqual("12345", cuttingTool.Attributes("assetId").First().Value);
            Assert.AreEqual("A tool description", cuttingTool.XPathSelectElement("//Description").Value);
            Assert.AreEqual("SMPY", cuttingTool.Attributes("manufactures").First().Value);
        }

        [Test]
        public void should_add_a_generic_property()
        {
            CuttingTool tool = new CuttingTool("12345", "AAAA", "12345");
            tool.Description = "A tool description";
            tool.AddProperty("ProcessSpindleSpeed",
                            new string[] { "minimum", "1000", "maximum", "10000", },
                            "2500");

            tool.ToXml(writer);
            writer.WriteEndDocument();
            writer.Close();

            XElement cuttingTool = XElement.Parse(result.ToString());
            XElement life = cuttingTool.Element("CuttingToolLifeCycle");
            Assert.IsNotNull(life);
            XElement prop = life.Element("ProcessSpindleSpeed");
            Assert.IsNotNull(prop);
            Assert.AreEqual("1000", prop.Attribute("minimum").Value);
            Assert.AreEqual("10000", prop.Attribute("maximum").Value);
            Assert.AreEqual("2500", prop.Value);
        }

        [Test]
        public void should_add_a_status()
        {
            CuttingTool tool = new CuttingTool("12345", "AAAA", "12345");
            tool.Description = "A tool description";
            tool.AddStatus(new string[] { "USED", "MEASURED" });

            tool.ToXml(writer);
            writer.WriteEndDocument();
            writer.Close();

            XElement cuttingTool = XElement.Parse(result.ToString());
            XElement life = cuttingTool.Element("CuttingToolLifeCycle");
            Assert.IsNotNull(life);
            XElement status = life.Element("CutterStatus");
            Assert.IsNotNull(status);
            XNode child = status.FirstNode;
            Assert.AreEqual("USED", ((XElement)child).Value);
            XNode next = child.NextNode;
            Assert.AreEqual("MEASURED", ((XElement)next).Value);
        }

        [Test]
        public void should_add_a_measurement()
        {
            CuttingTool tool = new CuttingTool("12345", "AAAA", "12345");
            tool.Description = "A tool description";
            tool.AddStatus(new string[] { "USED", "MEASURED" });

            tool.AddMeasurement("BodyDiameterMax", "BDX", 120.65, 120.60, 120.25, 120.70);

            tool.ToXml(writer);
            writer.WriteEndDocument();
            writer.Close();


            XElement cuttingTool = XElement.Parse(result.ToString());
            XElement life = cuttingTool.Element("CuttingToolLifeCycle");
            Assert.IsNotNull(life);
            XElement measurements = life.Element("Measurements");
            Assert.IsNotNull(measurements);
            XElement bdx = measurements.Element("BodyDiameterMax");
            Assert.IsNotNull(bdx);
            Assert.AreEqual("120.6", bdx.Attribute("nominal").Value);
            Assert.AreEqual("120.25", bdx.Attribute("minimum").Value);
            Assert.AreEqual("120.7", bdx.Attribute("maximum").Value);
            Assert.AreEqual("120.65", bdx.Value);            
        }

        [Test]
        public void should_add_tool_life()
        {
            CuttingTool tool = new CuttingTool("12345", "AAAA", "12345");
            tool.Description = "A tool description";
            tool.AddStatus(new string[] { "USED", "MEASURED" });

            tool.AddLife(CuttingTool.LifeType.MINUTES, CuttingTool.Direction.UP, "100", "0", "200", "175");

            tool.ToXml(writer);
            writer.WriteEndDocument();
            writer.Close();

            XElement cuttingTool = XElement.Parse(result.ToString());
            XElement cycle = cuttingTool.Element("CuttingToolLifeCycle");
            Assert.IsNotNull(cycle);
            XElement life = cycle.Element("ToolLife");
            Assert.IsNotNull(life);
            Assert.AreEqual("0", life.Attribute("initial").Value);
            Assert.AreEqual("200", life.Attribute("limit").Value);
            Assert.AreEqual("175", life.Attribute("warning").Value);
            Assert.AreEqual("100", life.Value);
            Assert.AreEqual("MINUTES", life.Attribute("type").Value);
            Assert.AreEqual("UP", life.Attribute("countDirection").Value);
        }

        [Test]
        public void should_add_cutting_item()
        {
            CuttingTool tool = new CuttingTool("12345", "AAAA", "12345");
            tool.Description = "A tool description";
            tool.AddStatus(new string[] { "USED", "MEASURED" });

            CuttingTool.CuttingItem item = new CuttingTool.CuttingItem("1-10", null, "440", "KMT");
            item.Description = "An insert";
            item.AddProperty("Locus", "22");
            item.AddLife(CuttingTool.LifeType.MINUTES, CuttingTool.Direction.UP, "100", "0", "150");
            item.AddMeasurement("FunctionalLength", "LF", 100);
            tool.AddItem(item);

            tool.ToXml(writer);
            writer.WriteEndDocument();
            writer.Close();

            XElement cuttingTool = XElement.Parse(result.ToString());
            XElement cycle = cuttingTool.Element("CuttingToolLifeCycle");
            Assert.IsNotNull(cycle);
            XElement cuttingItems = cycle.Element("CuttingItems");
            Assert.IsNotNull(cuttingItems);
            XElement cuttingItem = cuttingItems.Element("CuttingItem");
            Assert.IsNotNull(cuttingItem);

            Assert.AreEqual("1-10", cuttingItem.Attribute("indices").Value);
            Assert.AreEqual("440", cuttingItem.Attribute("grade").Value);
            Assert.AreEqual("KMT", cuttingItem.Attribute("manufacturers").Value);

            XElement desc = cuttingItem.Element("Description");
            Assert.IsNotNull(desc);
            Assert.AreEqual("An insert", desc.Value);

            XElement locus = cuttingItem.Element("Locus");
            Assert.IsNotNull(locus);
            Assert.AreEqual("22", locus.Value);


            XElement life = cuttingItem.Element("ItemLife");
            Assert.IsNotNull(life);
            Assert.AreEqual("MINUTES", life.Attribute("type").Value);
            Assert.AreEqual("100", life.Value);

            XElement measurements = cuttingItem.Element("Measurements");
            Assert.IsNotNull(measurements);
            XElement lf = measurements.Element("FunctionalLength");
            Assert.IsNotNull(lf);
            Assert.IsNull(lf.Attribute("warning"));
            Assert.IsNull(lf.Attribute("initial"));
            Assert.IsNull(lf.Attribute("limit"));
            Assert.AreEqual("100", lf.Value);
        }
    }
}
