using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventVisualizer
{
    public partial class TransactionListView : Form
    {
        List<LogObject> LogsData;
        string fileListLocation = string.Empty;
        public TransactionListView()
        {
            InitializeComponent();
        }
        public void SetLogsData(List<LogObject> data)
        {
            LogsData = data;
        }
        private void TransactionListView_Load(object sender, EventArgs e)
        {
            buttonExport.Click += ButtonExport_Click;
            listBoxTXNList.SelectedIndexChanged += ListBoxTXNList_SelectedIndexChanged;
            LoadData();
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            DialogResult result = SaveFileDialogTXN.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                fileListLocation = SaveFileDialogTXN.FileName + ".txt";
                try
                {
                    if (!File.Exists(fileListLocation))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(fileListLocation))
                        {
                            foreach (LogObject tranData in LogsData)
                                sw.WriteLine(tranData.LogDetails.MsgType + "#" + tranData.LogDetails.Transaction + "# Message: \"" + tranData.LogDetails.Message + "\"");
                        }
                    }
                    else
                    {
                        MessageBox.Show("File already exists. Please choose another name.");
                    }
                }
                catch { }
            }
        }

        private void ListBoxTXNList_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBoxTXNList.Text;
        }

        public void LoadData()
        {
            foreach (LogObject tranData in LogsData)
                listBoxTXNList.Items.Add(tranData.LogDetails.Message);
        }
    }
}
