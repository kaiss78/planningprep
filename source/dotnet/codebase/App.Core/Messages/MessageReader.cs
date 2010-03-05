#region History

/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: App.Core
 * Name: MessageReader.cs
 * Purpose: Message reader class from XML file
 *                   
 * Author: AFS
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    AFS  09/26/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */

#endregion

#region References

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;

#endregion

#region Class

namespace App.Core.Messages
{
    /// <summary>
    /// Reads messages from XML file
    /// </summary>
    public class MessageReader
    {

        #region Constructor

        public MessageReader()
        {
            
        }

        #endregion

        #region Instance

        
        #endregion
        
        private static XDocument messageXML;
        public static bool MessageXMSInitialized
        {
            get
            {
                return messageXML == null? false:true;
            }
        }
        #region Methods

        /// <summary>
        /// Initializes the message XML.
        /// </summary>
        /// <param name="xmlFileLocation">The XML file location.</param>
        public static void InitializeMessageXML(string xmlFileLocation)
        {
            if (File.Exists(xmlFileLocation))
            {
                try
                {
                    messageXML = XDocument.Load(xmlFileLocation);
                }
                catch (Exception)
                {
                    //Handle exception here
                }
            }
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <param name="messageKey">The message key.</param>
        /// <returns></returns>
        public static string GetMessage(string messageKey)
        {
            var query = from c in messageXML.Elements("Messages").Elements("Message")
                        where c.Attribute("Key").Value == messageKey
                        select c;
            
            string message = string.Empty;
            try
            {
                foreach (XElement messageElement in query)
                {
                    message = messageElement.Value.ToString();
                }
            }
            catch { }

            return message.Trim();
        }

        #endregion
    }
}

#endregion
