using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EventVisualizer
{
    public class ServerObject
    {
        public string ServerName;
        public string TransactionPath;
        public List<string> Instancename;
    }
    public enum MessageType
    {
        TX,
        RX,
        NONE
    }
    public class LogObject
    {
        public string LogName;
        public string LogMessage;
        public string LogSource;
        public long LogEventId;
        public long LogIndexId;
        public EventLogEntryType LogLevel;
        public DateTime LogTime;
        public string LogComputer;
        public HeaderObject LogDetails;
    }
    public class SearchObject
    {
        public string LogName;
        public string LogMessageText;
        public string LogSource;
        public EventLogEntryType LogLevel;
        public DateTime StartTime;
        public DateTime EndTime;
        public string LogComputer;
        public string Teller;
        public string Transaction;
        public string Branch;
    }
    public class HeaderObject
    {
        public string Message;
        public MessageType MsgType;
        public string Transaction;
        public string Teller;
        public string Branch;
    }
    public class UtilityClass
    {
		private bool m_bAddIncludes = false;
		private int m_RXHostPosPointer = 78;
		private int m_RXHostMesgLength = 0;
		private string m_byteStream = null;
        private LogObject SelectedObject = null;
        //private SettingsModel m_Settings = null;
        //private CobolFormatLibrary cobolLibrary = new CobolFormatLibrary();
        XmlDocument rxXMLDoc = null;
        public List<ServerObject> GetServerConfigs()
        {
            List<ServerObject> environmentSettings = new List<ServerObject>();
            try
            {
                XmlDocument config = new XmlDocument();
                config.Load("Config.xml");
                XmlNodeList configList = config.ChildNodes[1].ChildNodes;
                foreach (XmlNode item in configList)
                {
                    if(item.Name == "SERVERConfig")
                    {
                        XmlNodeList serverList = item.ChildNodes;
                        foreach (XmlNode server in serverList)
                        {
                            ServerObject newServer = new ServerObject();
                            newServer.ServerName = server.Attributes["Name"].Value;
                            newServer.TransactionPath = server.Attributes["TXNPath"].Value;
                            newServer.Instancename = new List<string>();
                            XmlNodeList instanceList = server.ChildNodes;
                            foreach (XmlNode instance in instanceList)
                                newServer.Instancename.Add(instance.InnerText);

                            environmentSettings.Add(newServer);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return environmentSettings;
        }
        public List<string> GetLogConfigs()
        {
            List<string> logSettings = new List<string>();
            try
            {
                XmlDocument config = new XmlDocument();
                config.Load("Config.xml");
                XmlNodeList configList = config.ChildNodes[1].ChildNodes;
                foreach (XmlNode item in configList)
                {
                    if (item.Name == "LOGConfig")
                    {
                        XmlNodeList logList = item.ChildNodes;
                        foreach (XmlNode source in logList)
                            logSettings.Add(source.InnerText);
                    }
                }
            }
            catch (Exception ex) { }
            return logSettings;
        }
        public string GetSystemSource(string systemName)
        {
            string sysSource = string.Empty;
            try
            {
                XmlDocument config = new XmlDocument();
                config.Load("Config.xml");
                XmlNodeList configList = config.ChildNodes[1].ChildNodes;
                foreach (XmlNode item in configList)
                {
                    if (item.Name == "SourceConfig")
                    {
                        XmlNodeList systemList = item.ChildNodes;
                        foreach (XmlNode system in systemList)
                        {
                            if (system.Attributes["Name"].Value == systemName)
                                sysSource = system.InnerText;
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return sysSource;
        }
        public List<string> GetAllSystems()
        {
            List<string> allSystems = new List<string>();
            try
            {
                XmlDocument config = new XmlDocument();
                config.Load("Config.xml");
                XmlNodeList configList = config.ChildNodes[1].ChildNodes;
                foreach (XmlNode item in configList)
                {
                    if (item.Name == "SourceConfig")
                    {
                        XmlNodeList systemList = item.ChildNodes;
                        foreach (XmlNode system in systemList)
                            allSystems.Add(system.Attributes["Name"].Value);
                    }
                }
            }
            catch (Exception ex) { }
            return allSystems;
        }
        public XmlDocument GetFormattedOutput(string actualMessage, string transactionNumber, string path, LogObject selectedObject)
        {
            SelectedObject = selectedObject;
            string TXNFilePath = string.Empty;
            XmlDocument transactionXML = null;
            //path = Path.Combine()
            TXNFilePath = Path.Combine(path,"xml", "Transactions", transactionNumber + ".xml");

            try
            {
                XmlDocument rxDoc = new XmlDocument();

                if (File.Exists(TXNFilePath))
                {
                    transactionXML = new XmlDocument();
                    transactionXML.Load(TXNFilePath);

                }
                else
                {
                    //Set the error model and return to main
                    throw new Exception("Settings model not found");
                }


                XmlDocument outputXml = new XmlDocument();
                XmlElement xmlOuterElement = outputXml.CreateElement("MessageGroup");
                outputXml.AppendChild(xmlOuterElement);


                //XmlDocument rxXMLDoc = null;
                if (selectedObject.LogDetails.MsgType == MessageType.TX)
                {
                    m_RXHostPosPointer = 78;
                }
                if (selectedObject.LogDetails.MsgType == MessageType.RX)
                {
                    m_RXHostPosPointer = 80;
                }

                //AddHeaderNodeToTXNxml(transactionXML);

                rxXMLDoc = ProcessRXXML(transactionXML, actualMessage, outputXml);
            }
            catch { }
            return rxXMLDoc;
        }
        public string Beautify(XmlDocument doc)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t",
                    NewLineChars = "\r\n",
                    NewLineHandling = NewLineHandling.Replace
                };
                using (XmlWriter writer = XmlWriter.Create(sb, settings))
                {
                    doc.Save(writer);
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
        /// <summary>
        /// Process XML
        /// </summary>
        /// <param name="transactionDefinition">transactionDefinition</param>
        /// <param name="responseByteStream">responseByteStream</param>
        /// <param name="outputXml">outputXml</param>
        /// <returns>XML Document</returns>
        public XmlDocument ProcessRXXML(XmlDocument transactionDefinition, string responseByteStream, XmlDocument outputXml)
        {
            try
            {
                m_byteStream = responseByteStream;
                m_RXHostMesgLength = Convert.ToInt32(m_byteStream.Substring(1, 4));

                //XmlDocument outputXml = new XmlDocument();
                //XmlElement xmlOuterElement = outputXml.CreateElement("MessageGroup");
                //outputXml.AppendChild(xmlOuterElement);

                XmlNode xmlOuterElement = outputXml.SelectSingleNode("MessageGroup");
                outputXml.AppendChild(xmlOuterElement);

                XmlElement xmlElement = outputXml.CreateElement("Message");
                xmlOuterElement.AppendChild(xmlElement);

                string tranNo = string.Empty;
                if (responseByteStream.Length > 60)
                    tranNo = responseByteStream.Substring(54, 6);

                XmlElement elem = outputXml.CreateElement("TranNo");
                elem.InnerText = tranNo;
                xmlElement.AppendChild(elem);

                XmlNode node = null;
                node = transactionDefinition.SelectSingleNode("/GROUP/" + SelectedObject.LogDetails.MsgType);
                if (node != null)
                {


                    IEnumerator enumerator = null;

                    enumerator = node.ChildNodes.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        XmlNode tranNode = (XmlNode)enumerator.Current;
                        this.ProcessNode(tranNode, xmlElement, xmlElement);
                    }
                }
                else
                {
                    //if (responseByteStream.IndexOf("O.K.") > 0)
                    //    textBoxEventLog.BackColor = Color.LightGreen;
                    //else if (responseByteStream.IndexOf("ERROR") > 0)
                    //    textBoxEventLog.BackColor = Color.OrangeRed;
                    //else
                    //    textBoxEventLog.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {

            }//finally
            return outputXml;
        }

        /// <summary>
        /// ProcessTXXML
        /// </summary>
        /// <param name="headerDoc">headerDoc</param>
        /// <param name="transactionDoc">transactionDoc</param>
        /// <param name="inputDataDoc">inputDataDoc</param>
        /// <returns>string</returns>
        public string ProcessTXXML(XmlDocument headerDoc, XmlDocument transactionDoc, XmlDocument inputDataDoc)
        {
            m_RXHostMesgLength = 0;
            //m_RXHostPosPointer = 78;
            m_byteStream = string.Empty;
            XmlNode node = headerDoc.SelectSingleNode("//GROUP[@ID='FNSTransactions73.CFNSHost']/" + SelectedObject.LogDetails.MsgType);
            XmlNode inputNode = inputDataDoc.SelectSingleNode("/" + SelectedObject.LogDetails.MsgType);
            IEnumerator enumerator = null;
            IEnumerator enumerator1 = null;
            IEnumerator enumerator2 = null;
            try
            {
                enumerator = node.ChildNodes.GetEnumerator();
                enumerator1 = inputNode.ChildNodes.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    enumerator1.MoveNext();
                    XmlNode tranNode = (XmlNode)enumerator.Current;
                    m_byteStream += this.ProcessTXField(tranNode, (XmlNode)enumerator1.Current);
                }

                node = transactionDoc.SelectSingleNode("/GROUP/" + SelectedObject.LogDetails.MsgType);

                enumerator2 = node.ChildNodes.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    XmlNode tranNode = (XmlNode)enumerator2.Current;
                    m_byteStream += this.ProcessTXField(tranNode, (XmlNode)enumerator1.Current);
                    enumerator1.MoveNext();
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    ((IDisposable)enumerator).Dispose();
                }
                if (enumerator2 is IDisposable)
                {
                    ((IDisposable)enumerator2).Dispose();
                }
                if (enumerator1 is IDisposable)
                {
                    ((IDisposable)enumerator1).Dispose();
                }
            }

            return m_byteStream;
        }

        /// <summary>
        /// ProcessTXField
        /// </summary>
        /// <param name="CurrentField">CurrentField</param>
        /// <param name="inputData">inputData</param>
        /// <returns>string</returns>
        private string ProcessTXField(XmlNode CurrentField, XmlNode inputData)
        {
            string result = string.Empty;
            CobolFormatLibrary cobolLibraryObj = new CobolFormatLibrary();
            try
            {
                XmlNode namedItem = CurrentField.Attributes.GetNamedItem("ID");
                XmlNode formatItem = CurrentField.Attributes.GetNamedItem("Format");
                XmlNode offsetItem = CurrentField.Attributes.GetNamedItem("Offset");
                if (formatItem != null && namedItem != null)
                {
                    string DataByte = cobolLibraryObj.ConvertToByteString(inputData.InnerXml, formatItem.InnerText);

                    if (offsetItem != null)
                    {
                        int offset = Convert.ToInt32(offsetItem.InnerText);
                        if (offset > 0)
                        {
                            string offsetBytes = new string('0', offset);
                            DataByte = offsetBytes + DataByte;
                        }
                    }
                    result += DataByte;
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("ProcessTXField: " + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// ProcessNode
        /// </summary>
        /// <param name="TranNode">TranNode</param>
        /// <param name="MesgNode">MesgNode</param>
        /// <param name="DataNode">DataNode</param>
        private void ProcessNode(XmlNode TranNode, XmlNode MesgNode, XmlNode DataNode)
        {
            string name = TranNode.Name;
            IEnumerator enumerator = null;
            if (String.Compare(name, "FIELD", false) == 0)
            {
                MesgNode.AppendChild(this.ProcessField(TranNode, DataNode));
            }
            else if (String.Compare(name, "SELECT", false) == 0)
            {
                XmlNode xmlNode = this.ProcessSelect(TranNode, MesgNode);
                if (xmlNode != null)
                {
                    try
                    {
                        enumerator = xmlNode.ChildNodes.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            XmlNode tranNode = (XmlNode)enumerator.Current;
                            this.ProcessNode(tranNode, MesgNode, DataNode);
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            ((IDisposable)enumerator).Dispose();
                        }
                    }
                }
            }
            else if (String.Compare(name, "COLLECTION", false) == 0)
            {
                this.ProcessCollection(TranNode, MesgNode, DataNode);
            }
            else if (String.Compare(name, "SELECTINCLUDE", false) == 0)
            {
                XmlNode xmlNode = this.ProcessSelectInclude(TranNode, MesgNode);
                IEnumerator enumerator2 = null;
                if (xmlNode != null)
                {
                    try
                    {
                        enumerator2 = xmlNode.ChildNodes.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            XmlNode tranNode = (XmlNode)enumerator2.Current;
                            this.ProcessNode(tranNode, MesgNode, DataNode);
                        }
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable)
                        {
                            ((IDisposable)enumerator2).Dispose();
                        }
                    }
                    if (this.m_bAddIncludes)
                    {
                        TranNode.ParentNode.InnerXml = xmlNode.InnerXml;
                    }
                }
            }
            else if (String.Compare(name, "INCLUDE", false) == 0)
            {
                XmlNode xmlNode = this.ProcessInclude(TranNode, MesgNode);
                IEnumerator enumerator3 = null;
                if (xmlNode != null)
                {
                    try
                    {
                        enumerator3 = xmlNode.ChildNodes.GetEnumerator();
                        while (enumerator3.MoveNext())
                        {
                            XmlNode tranNode = (XmlNode)enumerator3.Current;
                            this.ProcessNode(tranNode, MesgNode, DataNode);
                        }
                    }
                    finally
                    {
                        if (enumerator3 is IDisposable)
                        {
                            ((IDisposable)enumerator3).Dispose();
                        }
                    }
                    if (this.m_bAddIncludes)
                    {
                        TranNode.ParentNode.InnerXml = xmlNode.InnerXml;
                    }
                }
            }
            else if (String.Compare(name, "GROUP", false) == 0)
            {
                IEnumerator enumerator4 = null;
                try
                {
                    enumerator4 = TranNode.ChildNodes.GetEnumerator();
                    while (enumerator4.MoveNext())
                    {
                        XmlNode tranNode = (XmlNode)enumerator4.Current;
                        this.ProcessNode(tranNode, MesgNode, DataNode);
                    }
                }
                finally
                {
                    if (enumerator4 is IDisposable)
                    {
                        ((IDisposable)enumerator4).Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// ProcessField
        /// </summary>
        /// <param name="CurrentField">CurrentField</param>
        /// <param name="DataNode">DataNode</param>
        /// <returns>XmlNode</returns>
        private XmlNode ProcessField(XmlNode CurrentField, XmlNode DataNode)
        {
            XmlNode result;
            CobolFormatLibrary cobolLibraryObj = new CobolFormatLibrary();
            try
            {
                XmlNode namedItem = CurrentField.Attributes.GetNamedItem("ID");
                XmlNode formatItem = CurrentField.Attributes.GetNamedItem("Format");
                XmlNode offsetItem = CurrentField.Attributes.GetNamedItem("Offset");

                if (offsetItem != null)
                {
                    int offset = Convert.ToInt32(offsetItem.InnerText);
                    m_RXHostPosPointer += offset;
                }
                int txtLen = cobolLibraryObj.GetFormatStringLength(formatItem.InnerText);
                if (m_byteStream.Length < m_RXHostPosPointer + txtLen)
                {
                    int shortTxtLen = m_byteStream.Length - m_RXHostPosPointer;
                    int moreLength = txtLen - shortTxtLen;
                    CurrentField.InnerText = m_byteStream.Substring(m_RXHostPosPointer, shortTxtLen);

                    for (int i = 0; i < moreLength; i++)
                        CurrentField.InnerText = CurrentField.InnerText + " ";

                }
                else
                    CurrentField.InnerText = m_byteStream.Substring(m_RXHostPosPointer, txtLen);

                m_RXHostPosPointer += txtLen;

                XmlNode xmlNode2 = DataNode.OwnerDocument.CreateElement(namedItem.InnerText);
                xmlNode2.InnerText = CurrentField.InnerText;
                result = xmlNode2;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// ProcessCollection
        /// </summary>
        /// <param name="CurrentSelect">CurrentSelect</param>
        /// <param name="MesgNode">MesgNode</param>
        /// <param name="DataNode">DataNode</param>
        /// <returns>XmlNode</returns>
        private XmlNode ProcessCollection(XmlNode CurrentSelect, XmlNode MesgNode, XmlNode DataNode)
        {
            XmlNode result = null;
            checked
            {
                try
                {
                    XmlNode namedItem = CurrentSelect.Attributes.GetNamedItem("NumSubParts");
                    int num = int.Parse(namedItem.InnerText);
                    XmlNode namedItem2 = CurrentSelect.Attributes.GetNamedItem("ID");

                    for (int i = 0; i <= (num - 1); i++)
                    {
                        XmlNode xmlNode = MesgNode.OwnerDocument.CreateElement(namedItem2.InnerText);
                        if (this.m_RXHostPosPointer < this.m_RXHostMesgLength)
                        {
                            MesgNode.AppendChild(xmlNode);
                        }
                        IEnumerator enumerator2 = null;
                        try
                        {
                            enumerator2 = CurrentSelect.ChildNodes.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
                                this.ProcessNode(xmlNode2, xmlNode, DataNode);
                            }
                        }
                        finally
                        {
                            if (enumerator2 is IDisposable)
                            {
                                ((IDisposable)enumerator2).Dispose();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return result;
            }
        }

        /// <summary>
        /// ProcessSelect
        /// </summary>
        /// <param name="CurrentSelect">CurrentSelect</param>
        /// <param name="MesgNode">MesgNode</param>
        /// <returns>XmlNode</returns>
        private XmlNode ProcessSelect(XmlNode CurrentSelect, XmlNode MesgNode)
        {

            StringBuilder stringBuilder = new StringBuilder();
            XmlNode result;
            try
            {
                XmlNode namedItem = CurrentSelect.Attributes.GetNamedItem("switch");
                XmlNode xmlNode = MesgNode.SelectSingleNode(namedItem.InnerText);
                stringBuilder.Append("CASE[@*=\"");
                string switchVal = "";
                if (xmlNode == null)
                    if (namedItem.InnerText == "Flag2")
                        stringBuilder.Append(m_byteStream.Substring(75, 1));
                    else
                        stringBuilder.Append(xmlNode.InnerText);
                stringBuilder.Append("\"]");
                XmlNode xmlNode2 = CurrentSelect.SelectSingleNode(stringBuilder.ToString());
                if (xmlNode2 == null)
                {
                    xmlNode2 = CurrentSelect.SelectSingleNode("CASEELSE");
                }
                result = xmlNode2;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// ProcessSelectInclude
        /// </summary>
        /// <param name="CurrentInclude">CurrentInclude</param>
        /// <param name="MesgNode">MesgNode</param>
        /// <returns>xmlDocument</returns>
        private XmlNode ProcessSelectInclude(XmlNode CurrentInclude, XmlNode MesgNode)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode result  = null;
            try
            {
                XmlNode namedItem = CurrentInclude.Attributes.GetNamedItem("switch");
                XmlNode xmlNode = MesgNode.SelectSingleNode(namedItem.InnerText);
                string str = xmlNode.InnerText + ".xml";
                //if (File.Exists(Path.Combine(m_Settings.Settings[BancsProcessorConstants.TransactionDefinationPath], str)))
                //{
                //    xmlDocument.Load(Path.Combine(m_Settings.Settings[BancsProcessorConstants.TransactionDefinationPath], str));
                //}

                //if (xmlDocument == null)
                //{
                //    throw new Exception("could not find " + str);
                //}
                XmlNode xmlNode2 = xmlDocument.SelectSingleNode("//" + SelectedObject.LogDetails.MsgType);
                if (xmlNode2 == null)
                {
                    xmlNode2 = xmlDocument.SelectSingleNode("//" + SelectedObject.LogDetails.MsgType);
                    if (xmlNode2 == null)
                    {
                        throw new Exception("could not find TX/RX node");
                    }
                }

                result = xmlNode2;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// ProcessInclude
        /// </summary>
        /// <param name="CurrentInclude">CurrentInclude</param>
        /// <param name="MesgNode">MesgNode</param>
        /// <returns>XmlNode</returns>
        private XmlNode ProcessInclude(XmlNode CurrentInclude, XmlNode MesgNode)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode result;
            try
            {
                //if (File.Exists(Path.Combine(m_Settings.Settings[BancsProcessorConstants.TransactionDefinationPath], CurrentInclude.InnerText)))
                //{
                //    xmlDocument.Load(Path.Combine(m_Settings.Settings[BancsProcessorConstants.TransactionDefinationPath], CurrentInclude.InnerText));
                //}

                //if (xmlDocument == null)
                //{
                //    throw new Exception("could not find " + CurrentInclude.InnerText);
                //}
                XmlNode xmlNode = xmlDocument.SelectSingleNode("//" + SelectedObject.LogDetails.MsgType);
                if (xmlNode == null)
                {
                    xmlNode = xmlDocument.SelectSingleNode("//" + SelectedObject.LogDetails.MsgType);
                    if (xmlNode == null)
                    {
                        throw new Exception("could not find TX/RX node");
                    }
                }

                result = xmlNode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
