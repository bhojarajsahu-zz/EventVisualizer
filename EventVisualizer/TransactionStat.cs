using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventVisualizer
{
    public partial class TransactionStat : Form
    {
        List<LogObject> LogsData;
        public TransactionStat()
        {
            InitializeComponent();
        }
        public void SetLogsData(List<LogObject> data)
        {
            LogsData = data;
        }
        private void TransactionStat_Load(object sender, EventArgs e)
        {
            LoadType();
            comboBoxType.SelectedIndexChanged += ComboBoxType_SelectedIndexChanged;
        }

        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadType()
        {
            comboBoxType.Items.Add("Transaction View");
            comboBoxType.Items.Add("View By Teller");
        }
        public void LoadData()
        {
            int selIndex = comboBoxType.SelectedIndex;
            switch(selIndex)
            {
                case 0:
                    LoadTransactionDate();
                    break;

                case 1:
                    LoadTransactionByTeller();
                    break;
                default:
                    break;
            }
            
        }
        public void LoadTransactionDate()
        {
            try
            {
                Dictionary<string, int> tranStat = new Dictionary<string, int>();
                foreach (LogObject obj in LogsData)
                {
                    int val;
                    if (tranStat.TryGetValue(obj.LogDetails.Transaction, out val))
                        tranStat[obj.LogDetails.Transaction] = val + 1;
                    else
                        tranStat.Add(obj.LogDetails.Transaction, 1);
                }
                var newValue = (from tran in tranStat orderby tran.Value descending select tran).ToList();



                if (dataGridViewTran.Rows.Count > 0)
                    dataGridViewTran.Rows.Clear();

                if (dataGridViewTran.Columns.Count > 0)
                    dataGridViewTran.Columns.Clear();

                dataGridViewTran.Columns.Add("Transaction", "Transaction");
                dataGridViewTran.Columns.Add("Count", "Count");

                foreach (KeyValuePair<string, int> sObj in newValue)
                    dataGridViewTran.Rows.Add(sObj.Key, sObj.Value);
            }
            catch (Exception ex) { }
        }
        public void LoadTransactionByTeller()
        {
            try
            {
                
                Dictionary<string, int> tranStat = new Dictionary<string, int>();
                foreach (LogObject obj in LogsData)
                {
                    int val;
                    string tellerTran = obj.LogDetails.Teller + "*" + obj.LogDetails.Transaction;
                    if (tranStat.TryGetValue(tellerTran, out val))
                        tranStat[tellerTran] = val + 1;
                    else
                        tranStat.Add(tellerTran, 1);
                }


                var newValue = (from tran in tranStat orderby tran.Value descending select tran).ToList();



                if (dataGridViewTran.Rows.Count > 0)
                    dataGridViewTran.Rows.Clear();

                if (dataGridViewTran.Columns.Count > 0)
                    dataGridViewTran.Columns.Clear();

                dataGridViewTran.Columns.Add("Teller", "Teller");
                dataGridViewTran.Columns.Add("Transaction", "Transaction");
                dataGridViewTran.Columns.Add("Count", "Count");

                foreach (KeyValuePair<string, int> sObj in newValue)
                    dataGridViewTran.Rows.Add(sObj.Key.Split('*')[0], sObj.Key.Split('*')[1], sObj.Value);
            }
            catch (Exception ex) { }
        }
    }
}
