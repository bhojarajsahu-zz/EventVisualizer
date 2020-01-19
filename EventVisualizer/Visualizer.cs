using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EventVisualizer
{
    public partial class Visualizer : Form
    {
        private readonly SynchronizationContext synchronizationContext;
        private DateTime previousTime = DateTime.Now;
        public List<string> logsSettings;
        public List<string> systemSettings;
        List<ServerObject> environmentSettings;
        static List<LogObject> Logs;
		XmlDocument rxXMLDoc = null;
        string systemSource = string.Empty;
        public Visualizer()
        {
            InitializeComponent();
            synchronizationContext = SynchronizationContext.Current;
        }

        private void Visualizer_Load(object sender, EventArgs e)
        {
            comboBoxServer.SelectedIndexChanged += ComboBoxServer_SelectedIndexChanged;
            buttonSync.Click += ButtonSync_Click;
            buttonFlowTXNStat.Click += ButtonFlowTXNStat_Click;
            listBoxLogs.SelectedIndexChanged += ListBoxLogs_SelectedIndexChanged;
            comboBoxSystem.SelectedIndexChanged += ComboBoxSystem_SelectedIndexChanged;
            checkBoxFilter.CheckedChanged += CheckBoxFilter_CheckedChanged;
            checkBoxTransactionView.CheckedChanged += CheckBoxTransactionView_CheckedChanged;
            buttonClearLogs.Click += ButtonClearLogs_Click;

            try
            {
                LoadSettings();
            }
            catch (Exception ex) { }
        }
        public bool CheckRequiredField()
        {
            if (!string.IsNullOrWhiteSpace(comboBoxInstance.Text) && !string.IsNullOrWhiteSpace(comboBoxServer.Text) && !string.IsNullOrWhiteSpace(comboBoxSystem.Text) && !string.IsNullOrWhiteSpace(comboBoxLogs.Text)) return true;
            else return false;
        }
        public void ClearFields()
        {
            Logs = new List<LogObject>();
            textBoxOutput.Text = "";
            textBoxTextView.Text = "";
            if (listBoxLogs.Items.Count > 0)
                listBoxLogs.Items.Clear();
        }
        private void ButtonClearLogs_Click(object sender, EventArgs e)
        {
            if (CheckRequiredField())
            {
                DialogResult result = MessageBox.Show("Do you want to clear the logs?", "Event Visualizer", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        EventLog logToClear = new EventLog(comboBoxLogs.Text, comboBoxInstance.Text, systemSource);
                        logToClear.Clear();
                        ClearFields();
                    }
                    catch (Exception ex) { }
                }
            }
            else
                MessageBox.Show("Please enter the required field values", "Event Visualizer");
        }

        private void CheckBoxTransactionView_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTransactionView.Checked)
            {
                checkBoxTransactionView.Checked = false;
                TransactionListView newView = new TransactionListView();
                newView.SetLogsData(Logs);
                newView.Show();
            }
        }

        private void CheckBoxFilter_CheckedChanged(object sender, EventArgs e)
        {
            //dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            //dateTimePickerStart.CustomFormat = "MM / dd / yyyy hh: mm: ss";

            //dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            //dateTimePickerEnd.CustomFormat = "MM / dd / yyyy hh: mm: ss";

            if (checkBoxFilter.Checked)
                groupBoxFilters.Visible = true;
            else
                groupBoxFilters.Visible = false;

        }

        private void ComboBoxSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilityClass newClass = new UtilityClass();
            systemSource = newClass.GetSystemSource(comboBoxSystem.Text);
        }

        private void ButtonFlowTXNStat_Click(object sender, EventArgs e)
        {
            if(Logs != null)
                if (Logs.Count > 0)
                {
                    TransactionStat newStat = new TransactionStat();
                    newStat.SetLogsData(Logs);
                    newStat.Show();
                }
                else
                    MessageBox.Show("No logs to show.", "Event Visualizer");
            else
                MessageBox.Show("No logs to show.", "Event Visualizer");
        }

        private void ListBoxLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxLogs.SelectedIndex;
            rxXMLDoc = new XmlDocument();
            UtilityClass newClass = new UtilityClass();

            if (Logs[selectedIndex].LogLevel == System.Diagnostics.EventLogEntryType.Information)
            {
                textBoxTextView.Text = Logs[selectedIndex].LogDetails.Message;
                rxXMLDoc = newClass.GetFormattedOutput(Logs[selectedIndex].LogDetails.Message, Logs[selectedIndex].LogDetails.Transaction, labelPath.Text, Logs[selectedIndex]);
                string formattedOutput = newClass.Beautify(rxXMLDoc);
                textBoxOutput.Text = formattedOutput;
                toolStripStatusLabelTransactionNumber.Text = "Transaction Number: " + Logs[selectedIndex].LogDetails.Transaction + "  | Date Time: " + Logs[selectedIndex].LogTime;
            }

            if (Logs[selectedIndex].LogLevel == System.Diagnostics.EventLogEntryType.Error)
            {
                textBoxTextView.Text = Logs[selectedIndex].LogMessage;
                textBoxOutput.Text = Logs[selectedIndex].LogMessage;
                toolStripStatusLabelTransactionNumber.Text = "Error Occured | Date Time: " + Logs[selectedIndex].LogTime;
            }
        }

        public void LoadLogs()
        {
            ClearFields();

            if(listBoxLogs.Items.Count >0)
                listBoxLogs.Items.Clear();
            foreach (LogObject obj in Logs)
            {
                if (obj.LogLevel == System.Diagnostics.EventLogEntryType.Information)
                    listBoxLogs.Items.Add(obj.LogDetails.MsgType + " # " + obj.LogDetails.Transaction + " # " + obj.LogTime + " # " + obj.LogDetails.Teller);

                if (obj.LogLevel == System.Diagnostics.EventLogEntryType.Error)
                    listBoxLogs.Items.Add(obj.LogDetails.MsgType + " # Error Occured # " + obj.LogTime);
            }
        }
        private void ButtonSync_Click(object sender, EventArgs e)
        {
            if (CheckRequiredField())
            {
                if (listBoxLogs.Items.Count > 0)
                    listBoxLogs.Items.Clear();

                ClearFields();

                Cursor.Current = Cursors.WaitCursor;
                UtilityClass newUtility = new UtilityClass();
                SearchObject InputObject = new SearchObject();
                Logs = new List<LogObject>();
                InputObject.LogName = comboBoxLogs.Text;
                InputObject.LogComputer = comboBoxInstance.Text;
                InputObject.LogSource = systemSource;

                if (checkBoxFilter.Checked)
                {
                    InputObject.StartTime = dateTimePickerStart.Value;
                    InputObject.EndTime = dateTimePickerEnd.Value;

                    InputObject.Teller = textBoxTeller.Text;
                    InputObject.Transaction = textBoxTransaction.Text;
                    InputObject.Branch = textBoxBranch.Text;
                }
                else
                {
                    InputObject.StartTime = DateTime.MinValue;
                    InputObject.EndTime = DateTime.MaxValue;
                }
                GetLogs(InputObject);
                //LoadLogs();
                Cursor.Current = Cursors.Default;
            }
            else
                MessageBox.Show("Please enter the required field values", "Event Visualizer");
        }
        public async void GetLogs(SearchObject InputData)
        {
            try
            {
                EventLog log = new EventLog(InputData.LogName, InputData.LogComputer, InputData.LogSource);
                
                await Task.Run(() =>
                {
                    for (int i = log.Entries.Count; i > 0; i--)
                    {
                        EventLogEntry entry = log.Entries[--i];
                        if (entry.Message.Length > 50 && entry.Source == InputData.LogSource && DateTime.Compare(entry.TimeWritten, InputData.StartTime) >= 0 && DateTime.Compare(InputData.EndTime, entry.TimeWritten) >= 0)
                        {
                            LogObject newLog = new LogObject();
                            newLog.LogName = InputData.LogName;
                            newLog.LogMessage = entry.Message;
                            newLog.LogSource = entry.Source;
                            newLog.LogEventId = entry.InstanceId;
                            newLog.LogIndexId = entry.Index;
                            newLog.LogLevel = entry.EntryType;
                            newLog.LogTime = Convert.ToDateTime(entry.TimeGenerated);
                            newLog.LogComputer = entry.MachineName;
                            newLog.LogDetails = new HeaderObject();
                            SetLogDetails(newLog);
                            ApplyFilters(InputData, ref newLog);
                            if (newLog != null)
                            {
                                if (newLog.LogLevel == System.Diagnostics.EventLogEntryType.Information || newLog.LogLevel == System.Diagnostics.EventLogEntryType.Information)
                                {
                                    Logs.Add(newLog);
                                    UpdateUI(newLog);
                                }
                            }
                        }
                    }
                });
            }
            catch (Exception ex) { }
        }
        public void ApplyFilters(SearchObject InputData, ref LogObject selectedLog)
        {
            if (!string.IsNullOrWhiteSpace(InputData.Teller))
                if (selectedLog != null)
                    if (InputData.Teller != selectedLog.LogDetails.Teller)
                        selectedLog = null;
            if (!string.IsNullOrWhiteSpace(InputData.Transaction))
                if (selectedLog != null)
                    if (InputData.Transaction != selectedLog.LogDetails.Transaction)
                        selectedLog = null;

            if (!string.IsNullOrWhiteSpace(InputData.Branch))
                if (selectedLog != null)
                    if (InputData.Branch != selectedLog.LogDetails.Branch)
                        selectedLog = null;
        }
        public static void SetLogDetails(LogObject InputObject)
        {
            InputObject.LogDetails = new HeaderObject();
            try
            {
                //Message
                if (InputObject.LogMessage.Length > 75)
                {
                    //TXorRX
                    if (InputObject.LogMessage.Contains("TX :"))
                        InputObject.LogDetails.MsgType = MessageType.TX;
                    else if (InputObject.LogMessage.Contains("RX :"))
                        InputObject.LogDetails.MsgType = MessageType.RX;
                    else
                        InputObject.LogDetails.MsgType = MessageType.NONE;

                    //Actual Message
                    int sIndex = InputObject.LogMessage.IndexOf(InputObject.LogDetails.MsgType.ToString());
                    int mLength = InputObject.LogMessage.Length - sIndex;
                    string actualMsg = InputObject.LogMessage.Substring(sIndex + 4, mLength - 4);
                    InputObject.LogDetails.Message = actualMsg;

                    //Branch
                    InputObject.LogDetails.Branch = actualMsg.Substring(42, 4);
                    //Teller
                    InputObject.LogDetails.Teller = actualMsg.Substring(49, 5);
                    //Transaction
                    InputObject.LogDetails.Transaction = actualMsg.Substring(54, 6);

                }
            }
            catch (Exception ex) { }

        }

        public void UpdateUI(LogObject obj)
        {
            //toolStripStatusLabelCounter.Text = Convert.ToString(Convert.ToInt32(toolStripStatusLabelCounter.Text) + 1);
            var timeNow = DateTime.Now;
            //if ((DateTime.Now - previousTime).Milliseconds <= 50) return;
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                    

                if (obj.LogLevel == System.Diagnostics.EventLogEntryType.Information)
                    listBoxLogs.Items.Add(obj.LogDetails.MsgType + " # " + obj.LogDetails.Transaction + " # " + obj.LogTime + " # " + obj.LogDetails.Teller);

                if (obj.LogLevel == System.Diagnostics.EventLogEntryType.Error)
                    listBoxLogs.Items.Add(obj.LogDetails.MsgType + " # Error Occured # " + obj.LogTime);
            }), obj);

            previousTime = timeNow;
            //toolStripStatusLabelCounter.Text = Convert.ToString(Convert.ToInt32(toolStripStatusLabelCounter.Text) + 1);
        }
        private void ComboBoxServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxInstance.Items.Count > 0)
                    comboBoxInstance.Items.Clear();

                foreach (ServerObject item in environmentSettings)
                    if (item.ServerName == comboBoxServer.Text)
                    {
                        labelPath.Text = item.TransactionPath;
                        foreach (string instance in item.Instancename)
                            comboBoxInstance.Items.Add(instance);
                    }
            }
            catch (Exception ex) { }
        }

        public void LoadSettings()
        {
            try
            {
                environmentSettings = new List<ServerObject>();
                logsSettings = new List<string>();
                systemSettings = new List<string>();
                UtilityClass newClass = new UtilityClass();
                environmentSettings = newClass.GetServerConfigs();
                logsSettings = newClass.GetLogConfigs();
                systemSettings = newClass.GetAllSystems();

                if (comboBoxServer.Items.Count > 0)
                    comboBoxServer.Items.Clear();

                foreach (ServerObject item in environmentSettings)
                    comboBoxServer.Items.Add(item.ServerName);

                if (comboBoxLogs.Items.Count > 0)
                    comboBoxLogs.Items.Clear();

                foreach (string logs in logsSettings)
                    comboBoxLogs.Items.Add(logs);

                if (comboBoxSystem.Items.Count > 0)
                    comboBoxSystem.Items.Clear();

                foreach (string sSystem in systemSettings)
                    comboBoxSystem.Items.Add(sSystem);


            }
            catch (Exception ex) { }
        }
		public void LoadFormattedTransaction()
		{
			//UtilityClass newClass = new UtilityClass();
			//newClass.GetFormattedOutput("", "");
		}
    }
}
