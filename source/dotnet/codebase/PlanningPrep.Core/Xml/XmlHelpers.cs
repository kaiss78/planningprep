﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using PlanningPrep.Core.Exceptions;

namespace PlanningPrep.Core.Xml
{
    /// <summary>
    /// 
    /// </summary>
    public static class XmlHelper
    {
        public static XmlNamespaceManager CreateNsMgr(XmlDocument doc)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            foreach (XmlAttribute attr in doc.SelectSingleNode("/*").Attributes.Cast<XmlAttribute>().Where(attr => attr.Prefix == "xmlns"))
            {
                nsmgr.AddNamespace(attr.LocalName, attr.Value);
            }
            return nsmgr;
        }

        /// <summary>
        /// Generic method for deserializing an object from a XmlDocument
        /// </summary>
        /// <param name="source">XmlDocument containing the Xml to deserialize.</param>
        /// <returns></returns>
        public static object DeserializeWorkflow(XmlNodeReader source)
        {
            WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();

            return serializer.Deserialize(source);
        }

        /// <summary>
        /// Generic method for deserializing an object from a XmlDocument
        /// </summary>
        /// <param name="source">XmlDocument containing the Xml to deserialize.</param>
        /// <returns></returns>
        public static object DeserializeWorkflow(XmlDocument source)
        {
            if (source == null)
                return null;

            XmlNodeReader nr = new XmlNodeReader(source);

            return DeserializeWorkflow(nr);
        }

        /// <summary>
        /// Generic method for deserializing an object from a XmlDocument
        /// </summary>
        /// <param name="t">Type to deserialize</param>
        /// <param name="source">XmlDocument containing the Xml to deserialize.</param>
        /// <returns></returns>
        public static object Deserialize(Type t, XmlReader source)
        {
            XmlSerializer serializer = new XmlSerializer(t);
            object result = serializer.Deserialize(source);
            source.Close();

            return result;
        }


        /// <summary>
        /// Generic method for deserializing an object from a XmlDocument
        /// </summary>
        /// <param name="t">Type to deserialize</param>
        /// <param name="source">XmlDocument containing the Xml to deserialize.</param>
        /// <returns></returns>
        public static object Deserialize(Type t, XmlDocument source)
        {
            return source == null ? null : Deserialize(t, new XmlNodeReader(source));
        }

        /// <summary>
        /// Generic method for deserializing an object from a Xml file and Xsd file 
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="xmlPath">Path to the Xml document containing the Xml to deserialize</param>
        /// <param name="schemaPath">Optional Xsd schema to use to validate Xml</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlPath, string schemaPath)
        {
            return (T)Deserialize(typeof(T), xmlPath, schemaPath);
        }

        /// <summary>
        /// Generic method for deserializing an object from a Xml file 
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="xmlPath">Path to the Xml document containing the Xml to deserialize</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlPath)
        {
            return (T)Deserialize(typeof(T), xmlPath, null);
        }

        /// <summary>
        /// Generic method for deserializing an object from a XmlDocument
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="source">XmlDocument containing the Xml to deserialize.</param>
        /// <returns></returns>
        public static T Deserialize<T>(XmlDocument source)
        {
            return (T)Deserialize(typeof(T), source);
        }

        /// <summary>
        /// Generic method for deserializing an object from a XmlDocument
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="source">XmlDocument containing the Xml to deserialize.</param>
        /// <returns></returns>
        public static T Deserialize<T>(XmlReader source)
        {
            return (T)Deserialize(typeof(T), source);
        }


        /// <summary>
        /// Generic method for deserializing an object from a XmlElement
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="source">XmlElement containing the Xml to deserialize.</param>
        /// <returns></returns>
        public static T Deserialize<T>(XmlElement source)
        {
            XmlNodeReader nr = new XmlNodeReader(source);
            return (T)Deserialize(typeof(T), nr);
        }

        /// <summary>
        /// Generic method for deserializing an object from a XmlDocument
        /// </summary>
        /// <param name="t">Type to deserialize</param>
        /// <param name="xmlPath">Path to the Xml document containing the Xml to deserialize</param>
        /// <param name="schemaPath">Optional Xsd schema to use to validate Xml</param>
        /// <returns></returns>
        public static object Deserialize(Type t, string xmlPath, string schemaPath)
        {
            XmlDocument source = new XmlDocument();
            XmlReader xr = CreateReader(xmlPath, schemaPath);
            source.Load(xr);
            xr.Close();

            //Deserialize from the xmlreader
            object result = Deserialize(t, source);
            return result;
        }

        public static XmlReader CreateReader(string xmlPath, string schemaPath)
        {
            XmlReader xr;

            if (schemaPath != null)
            {
                //Create a new XmlReader to read the Schema file defined by the schemapath
                XmlReaderSettings xrs = new XmlReaderSettings();

                //Read the schema into a XmlSchema variable - throw any errors to callback method
                XmlSchema xs = LoadSchemaFromFile(schemaPath);

                //Throw any voilations when loading the xmlfile and verifying it conforms to the schema to the callback method
                xrs.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

                //Validate the xml file conforms to the schema
                xrs.ValidationType = ValidationType.Schema;

                //Add the schema we loaded from the file above to the schemacollection for the reader we're about to create
                xrs.Schemas.Add(xs);

                //Create a reader for the xmlfile specified - add the schema we loaded to validate it.
                xr = XmlReader.Create(File.OpenRead(xmlPath), xrs);
            }
            else
                //Create a reader for the xmlfile specified with no schema
                xr = XmlReader.Create(File.OpenRead(xmlPath));

            return xr;
        }

        public static XmlSchema LoadSchemaFromFile(string path)
        {
            XmlReader xr = XmlReader.Create(File.OpenRead(path));

            //Read the schema into a XmlSchema variable - throw any errors to callback method
            XmlSchema xs = XmlSchema.Read(xr, ValidationCallBack);

            return xs;
        }

        /// <summary>
        /// Convert a XmlSchema into a byte array
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public static string GetStringFromSchema(XmlSchema schema)
        {
            //Get the bytes from the schema
            StringBuilder sb = new StringBuilder();
            using(StringWriter sw = new StringWriter(sb))
            {
                schema.Write(sw);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Convert a XmlSchema into a byte array
        /// </summary>

        /// <returns></returns>
        public static XmlSchema GetSchemaFromString(string source)
        {
            //Get the bytes from the schema
            return XmlSchema.Read(new StringReader(source), ValidationCallBack);
        }


        /// <summary>
        /// This method will take an object and serialize it into xml and write it to the specified file.
        /// </summary>
        /// <param name="source">The object to serialize</param>
        /// <param name="xmlPath">The path in the filesystem to write a new xml file containing serialized xml from the object.</param>
        public static void Serialize(object source, string xmlPath)
        {
            XmlDocument doc = Serialize(source);
            using (XmlWriter xw = XmlWriter.Create(xmlPath))
            {
                doc.Save(xw);
                xw.Flush();
                xw.Close();
            }
        }

        /// <summary>
        /// This method will take an object and serialize it in memory into a XmlDocument.
        /// </summary>
        /// <param name="source">The object to serialize into Xml.</param>
        /// <returns>A XmlDocument containing the serialized Xml from the specified object.</returns>
        public static XmlDocument Serialize(object source)
        {
            return source == null ? null : Serialize(source, source.GetType());
        }

        /// <summary>
        /// This method will take an object and serialize it in memory into a XmlDocument.
        /// </summary>
        /// <param name="source">The object to serialize into Xml.</param>
        /// <param name="t"></param>
        /// <returns>A XmlDocument containing the serialized Xml from the specified object.</returns>
        public static XmlDocument Serialize(object source, Type t)
        {
            if (source == null)
                return null;

            //Initialize the XmlDocument we're going to load the serialized object into
            XmlDocument result = new XmlDocument();

            //Initialize the serializer for the object's type
            XmlSerializer serializer = new XmlSerializer(t);

            //We need a place for the XmlWriter to write the serialized Xml - use a memorystream because we're going to do this 
            //in memory and return a xmldocument
            using (MemoryStream memstream = new MemoryStream())
            {
                //Create a XmlWriter and point it at the stringbuilder for the location to write the serialized Xml
                using (XmlWriter xw = XmlWriter.Create(memstream))
                {
                    //Serialize the object into Xml and write the Xml to the in memory stringbuilder
                    if (xw == null)
                        return null;

                    serializer.Serialize(xw, source);
                }
                memstream.Position = 0;
                //Load the Xml from memory to the XmlDocument and return
                result.Load(memstream);
            }

            return result;
        }

        /// <summary>
        /// This method will take an object and serialize it in memory into a XmlDocument.
        /// </summary>
        /// <param name="source">The object to serialize into Xml.</param>
        /// <returns>A XmlDocument containing the serialized Xml from the specified object.</returns>
        public static XmlDocument SerializeWorkflow(Activity source)
        {
            if (source == null)
                return null;

            //Initialize the XmlDocument we're going to load the serialized object into
            XmlDocument result = new XmlDocument();

            //Initialize the serializer for the object's type
            WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();

            //We need a place for the XmlWriter to write the serialized Xml - use a memorystream because we're going to do this 
            //in memory and return a xmldocument
            using (MemoryStream memstream = new MemoryStream())
            {
                //Create a XmlWriter and point it at the stringbuilder for the location to write the serialized Xml
                using (XmlWriter xw = XmlWriter.Create(memstream))
                {
                    //Serialize the object into Xml and write the Xml to the in memory stringbuilder
                    serializer.Serialize(xw, source);
                }
                memstream.Position = 0;

                //Load the Xml from memory to the XmlDocument and return
                result.Load(memstream);
            }
            return result;
        }

        /// <summary>
        /// Callback for Xml/Xsd validation errors - this should travel with the generic deserialization function above.
        /// </summary>
        /// <param name="sender">Object which caused the validation event</param>
        /// <param name="args"></param>
        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            throw args.Severity == XmlSeverityType.Warning
                      ? new PanthException(string.Format("\tWarning: Matching schema not found.  No validation occurred.{0}", args.Message))
                      : new PanthException(string.Format("\tValidation error: {0}", args.Message));
        }
    }
}
