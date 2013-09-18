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
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;


namespace MTConnect
{

    /// <summary>
    /// An abstraction around an XML Generator for a cutting tool asset
    /// </summary>
    public class CuttingTool : Asset
    {
        public const double CT_NULL = Double.NaN;
        /// <summary>
        /// The cutting tool or cutting item life
        /// </summary>
        public enum LifeType
        {
            MINUTES,
            PART_COUNT,
            WEAR
        };
        /// <summary>
        /// The cutting tool direction.
        /// </summary>
        public enum Direction
        {
            UP,
            DOWN
        };

        /// <summary>
        /// A cutting tool or cutting item property.
        /// </summary>
        public class Property
        {
            public class Attribute
            {
                public string Name { set; get; }
                public string Value { set; get; }

                public Attribute(string name, string value)
                {
                    Name = name; Value = value;
                }
            }

            public string Name { set; get; }
            public string Value { set; get; }
            public ArrayList mAttributes;

            public Property(string name, Attribute[] arguments = null, string value = null)
            {
                Name = name;
                Value = value;
                if (arguments != null)
                {
                    mAttributes = new ArrayList();
                    mAttributes = new ArrayList(arguments);
                }
            }

            public Property(string name, string[] arguments, string value = "")
            {
                Name = name;
                if (arguments != null)
                {
                    mAttributes = new ArrayList();
                    for (int i = 0; i < arguments.Length; i += 2)
                        mAttributes.Add(new Attribute(arguments[i], arguments[i + 1]));
                }
                Value = value;
            }

            public Property(string name, string value)
            {
                Name = name;
                Value = value;
            }

            /// <summary>
            /// Add a argument to this property
            /// </summary>
            /// <param name="argument">The argumnet</param>
            public void AddAttribute(Attribute argument)
            {
                if (mAttributes == null) mAttributes = new ArrayList();
                mAttributes.Add(argument);
            }

            public override bool Equals(object obj)
            {
                if (obj is Property)
                    return Name.Equals(((Property)obj).Name);
                else
                    return Name.Equals(obj);
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }

            public virtual XmlWriter ToXml(XmlWriter writer)
            {
                writer.WriteStartElement(Name);

                if (mAttributes != null)
                {
                    foreach (Attribute arg in mAttributes)
                    {
                        writer.WriteAttributeString(arg.Name, arg.Value);
                    }
                }

                if (Value != null)
                    writer.WriteValue(Value);

                writer.WriteEndElement();

                return writer;
            }
        }

        /// <summary>
        /// A property representing the cutter status
        /// </summary>
        public class CutterStatus : Property
        {
            public HashSet<string> mStatus;

            public CutterStatus(string[] status)
                : base("CutterStatus")
            {
                mStatus = new HashSet<string>();
                foreach (string s in status)
                    mStatus.Add(s);
            }

            /// <summary>
            /// Add a status
            /// </summary>
            /// <param name="s">The status to add</param>
            public void Add(string s)
            {
                mStatus.Add(s);
            }

            /// <summary>
            /// Remove a status
            /// </summary>
            /// <param name="s">The status to remove</param>
            public void Remove(string s)
            {
                mStatus.Remove(s);
            }

            /// <summary>
            /// Generate the xml for the status
            /// </summary>
            /// <param name="writer">The generator</param>
            /// <returns>The writer</returns>
            public override XmlWriter ToXml(XmlWriter writer)
            {
                writer.WriteStartElement(Name);

                foreach (string s in mStatus)
                    writer.WriteElementString("Status", s);

                writer.WriteEndElement();

                return writer;
            }
        }

        /// <summary>
        /// A cutting tool or cutting item measurement
        /// </summary>
        public class Measurement : Property
        {           
            public Measurement(string name, string code, double value = CT_NULL, double nominal = CT_NULL,
                double min = CT_NULL, double max = CT_NULL, string native = null, string units = null)
                : base(name)
            {
                AddAttribute(new Attribute("code", code));
                if (!Double.IsNaN(value))
                    Value = value.ToString();

                if (!Double.IsNaN(nominal))
                    AddAttribute(new Attribute("nominal", nominal.ToString()));
                if (!Double.IsNaN(min))
                    AddAttribute(new Attribute("minimum", min.ToString()));
                if (!Double.IsNaN(max))
                    AddAttribute(new Attribute("maximum", max.ToString()));
                if (native != null)
                    AddAttribute(new Attribute("nativeUnits", native));
                if (units != null)
                    AddAttribute(new Attribute("units", units));
            }
        }

        /// <summary>
        /// A cutting item
        /// </summary>
        public class CuttingItem
        {
            protected HashSet<Property> mProperties = new HashSet<Property>();
            protected HashSet<Measurement> mMeasurements = new HashSet<Measurement>();

            public string Indices { set; get; }
            public string ItemId { set; get; }
            public string Grade { set; get; }
            public string Manufacturers { set; get; }
            public string Description { set; get; }
            
            /// <summary>
            /// Create a cutting item with identity info
            /// </summary>
            /// <param name="indices">The index range</param>
            /// <param name="id">The id (if indices are not used)</param>
            /// <param name="grade">The cutting item material grade</param>
            /// <param name="manufacturers">The manufacturers of this item</param>
            public CuttingItem(string indices, string id = null, string grade = null,
                string manufacturers = null)
            {
                Indices = indices;
                ItemId = id;
                Grade = grade;
                Manufacturers = manufacturers;
            }

            /// <summary>
            /// Add a property to the cutting tool
            /// </summary>
            /// <param name="name">Name of the property</param>
            /// <param name="arguments">Attributes</param>
            /// <param name="value">The CData value</param>
            /// <returns></returns>
            public Property AddProperty(string name, string[] arguments, string value = null)
            {
                Property property = new Property(name, arguments, value);
                mProperties.Add(property);
                return property;
            }

            /// <summary>
            /// Add a simple property to the item
            /// </summary>
            /// <param name="name">The name of the property</param>
            /// <param name="value">The value</param>
            /// <returns></returns>
            public Property AddProperty(string name, string value)
            {
                Property property = new Property(name,  value);
                mProperties.Add(property);
                return property;
            }

            /// <summary>
            /// Add a measurement to the cutting item
            /// </summary>
            /// <param name="name">The name of the measurement</param>
            /// <param name="code">The ISO 13399 code</param>
            /// <param name="value">The value for the measurement</param>
            /// <param name="nominal">The nominal value</param>
            /// <param name="min">The minimum constraint</param>
            /// <param name="max">The maximum constraint</param>
            /// <param name="native">The native units</param>
            /// <param name="units">Must be the standard units</param>
            /// <returns>The measurement</returns>
            public Measurement AddMeasurement(string name, string code,
                    double value = CT_NULL, double nominal = CT_NULL,
                    double min = CT_NULL, double max = CT_NULL,
                    string native = null, string units = null)
            {
                Measurement meas = new Measurement(name, code, value, nominal, min, max, native, units);
                mMeasurements.Add(meas);
                return meas;
            }

            public Property AddLife(LifeType type, Direction direction, string value = null,
                                    string initial = null,
                                    string limit = null, string warning = null)
            {
                Property life = new Property("ItemLife");
                life.Value = value;
                life.AddAttribute(new Property.Attribute("type", type.ToString()));
                life.AddAttribute(new Property.Attribute("countDirection", direction.ToString()));
                if (initial != null)
                    life.AddAttribute(new Property.Attribute("initial", initial));
                if (limit != null)
                    life.AddAttribute(new Property.Attribute("limit", limit));
                if (warning != null)
                    life.AddAttribute(new Property.Attribute("warning", warning));
                mProperties.Add(life);
                return life;
            }

            public XmlWriter ToXml(XmlWriter writer)
            {
                writer.WriteStartElement("CuttingItem");
                    writer.WriteAttributeString("indices", Indices);
                    if (ItemId != null)
                        writer.WriteAttributeString("itemId", ItemId);
                    if (Grade != null)
                        writer.WriteAttributeString("grade", Grade);
                    if (Manufacturers != null)
                        writer.WriteAttributeString("manufacturers", Manufacturers);
                    
                    if (Description != null)
                        writer.WriteElementString("Description", Description);

                    foreach (Property prop in mProperties)
                        prop.ToXml(writer);

                    if (mMeasurements.Count > 0)
                    {
                        writer.WriteStartElement("Measurements");
                            foreach (Measurement meas in mMeasurements)
                                meas.ToXml(writer);
                        writer.WriteEndElement();
                    }
                writer.WriteEndElement();

                return writer;
            }
        }

        public string SerialNumber { set; get; }
        public string ToolId { set; get; }
        public string Description { set; get; }
        public string Manufacturers { set; get; }

        protected HashSet<Property> mProperties = new HashSet<Property>();
        protected HashSet<Measurement> mMeasurements = new HashSet<Measurement>();
        protected ArrayList mItems = new ArrayList();

        /// <summary>
        /// Creates a new cutting tool asset
        /// </summary>
        /// <param name="assetId">The asset id</param>
        /// <param name="toolId">The tool id</param>
        /// <param name="serialNumber">The serial number of the tool</param>
        public CuttingTool(string assetId, string toolId, string serialNumber)
            : base(assetId)
        {
            ToolId = toolId;
            SerialNumber = serialNumber;
        }

        /// <summary>
        /// The MTConnect Asset Type.
        /// </summary>
        /// <returns>CuttingTool</returns>
        public override string GetMTCType()
        {
            return "CuttingTool";
        }

        /// <summary>
        /// Create a simple attribute
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static Property.Attribute CreateAttribute(string name, string value)
        {
            return new Property.Attribute(name, value);
        }

        /// <summary>
        /// Add a property to the cutting tool
        /// </summary>
        /// <param name="property">The property</param>
        public void AddProperty(Property property)
        {
            mProperties.Add(property);
        }

        /// <summary>
        /// Add a property to the cutting tool
        /// </summary>
        /// <param name="name">Name of the property</param>
        /// <param name="arguments">Attributes</param>
        /// <param name="value">The CData value</param>
        /// <returns></returns>
        public Property AddProperty(string name, string[] arguments, string value = null)
        {
            Property property = new Property(name, arguments, value);
            mProperties.Add(property);
            return property;
        }

        /// <summary>
        /// Add the list of current status to the cutting tool
        /// </summary>
        /// <param name="status">A string array of status</param>
        /// <returns></returns>
        public CutterStatus AddStatus(string[] status)
        {
            CutterStatus cs = new CutterStatus(status);
            mProperties.Add(cs);
            return cs;
        }

        /// <summary>
        /// Add a measurement to the cutting item
        /// </summary>
        /// <param name="name">The name of the measurement</param>
        /// <param name="code">The ISO 13399 code</param>
        /// <param name="value">The value for the measurement</param>
        /// <param name="nominal">The nominal value</param>
        /// <param name="min">The minimum constraint</param>
        /// <param name="max">The maximum constraint</param>
        /// <param name="native">The native units</param>
        /// <param name="units">Must be the standard units</param>
        /// <returns>The measurement</returns>
        public Measurement AddMeasurement(string name, string code, 
                double value = CT_NULL, double nominal = CT_NULL, 
                double min = CT_NULL, double max = CT_NULL, 
                string native = null, string units = null)
        {
            Measurement meas = new Measurement(name, code, value, nominal, min, max, native, units);
            mMeasurements.Add(meas);
            return meas;
        }

        /// <summary>
        /// Add the tool life
        /// </summary>
        /// <param name="type">MINUTES, PART_COUNT, or WEAR</param>
        /// <param name="direction">UP or DOWN</param>
        /// <param name="value">The current value</param>
        /// <param name="initial">The initial value for the range</param>
        /// <param name="limit">The limit</param>
        /// <param name="warning">A point where there will be a warning</param>
        /// <returns>The life property</returns>
        public Property AddLife(LifeType type, Direction direction, string value = null,
                                string initial = null,
                                string limit = null, string warning = null)
        {
            Property life = new Property("ToolLife");
            life.Value = value;
            life.AddAttribute(new Property.Attribute("type", type.ToString()));
            life.AddAttribute(new Property.Attribute("countDirection", direction.ToString()));
            if (initial != null) 
                life.AddAttribute(new Property.Attribute("initial", initial));
            if (limit != null)
                life.AddAttribute(new Property.Attribute("limit", limit));
            if (warning != null)
                life.AddAttribute(new Property.Attribute("warning", warning));
            mProperties.Add(life);
            return life;
        }

        /// <summary>
        /// Adds a cutting item
        /// </summary>
        /// <param name="item">The cutting item</param>
        public void AddItem(CuttingItem item)
        {
            mItems.Add(item);
        }

        /// <summary>
        /// Generate XML
        /// </summary>
        /// <param name="writer">The XML writer used to generate</param>
        /// <returns>The writer</returns>
        public override XmlWriter ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("CuttingTool");
                writer.WriteAttributeString("toolId", ToolId);
                writer.WriteAttributeString("serialNumber", SerialNumber);
                if (Manufacturers != null)
                    writer.WriteAttributeString("manufactures", Manufacturers);
                base.ToXml(writer);

                writer.WriteElementString("Description", Description);

                writer.WriteStartElement("CuttingToolLifeCycle");
                    foreach (Property prop in mProperties)
                        prop.ToXml(writer);
                    if (mMeasurements.Count > 0)
                    {
                        writer.WriteStartElement("Measurements");
                            foreach (Measurement meas in mMeasurements)
                                meas.ToXml(writer);
                        writer.WriteEndElement();
                    }

                    if (mItems.Count > 0)
                    {
                        writer.WriteStartElement("CuttingItems");
                            foreach (CuttingItem item in mItems)
                                item.ToXml(writer);
                        writer.WriteEndElement();
                    }
                writer.WriteEndElement();
            writer.WriteEndElement();

            return writer;
        }
    }
}
