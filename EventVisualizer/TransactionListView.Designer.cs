namespace EventVisualizer
{
    partial class TransactionListView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionListView));
            this.panelControl = new System.Windows.Forms.Panel();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.panelButtonControl = new System.Windows.Forms.Panel();
            this.buttonExport = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBoxTransactionList = new System.Windows.Forms.GroupBox();
            this.listBoxTXNList = new System.Windows.Forms.ListBox();
            this.SaveFileDialogTXN = new System.Windows.Forms.SaveFileDialog();
            this.panelControl.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
            this.panelButtonControl.SuspendLayout();
            this.groupBoxTransactionList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.groupBoxControl);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(0, 352);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(862, 100);
            this.panelControl.TabIndex = 3;
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.panelButtonControl);
            this.groupBoxControl.Controls.Add(this.textBox1);
            this.groupBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxControl.Location = new System.Drawing.Point(0, 0);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(862, 100);
            this.groupBoxControl.TabIndex = 0;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "Controls";
            // 
            // panelButtonControl
            // 
            this.panelButtonControl.Controls.Add(this.buttonExport);
            this.panelButtonControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtonControl.Location = new System.Drawing.Point(592, 38);
            this.panelButtonControl.Name = "panelButtonControl";
            this.panelButtonControl.Size = new System.Drawing.Size(267, 59);
            this.panelButtonControl.TabIndex = 3;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(141, 27);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(100, 23);
            this.buttonExport.TabIndex = 1;
            this.buttonExport.Text = "Export To File";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(3, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(856, 21);
            this.textBox1.TabIndex = 0;
            // 
            // groupBoxTransactionList
            // 
            this.groupBoxTransactionList.Controls.Add(this.listBoxTXNList);
            this.groupBoxTransactionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTransactionList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTransactionList.Name = "groupBoxTransactionList";
            this.groupBoxTransactionList.Size = new System.Drawing.Size(862, 452);
            this.groupBoxTransactionList.TabIndex = 4;
            this.groupBoxTransactionList.TabStop = false;
            this.groupBoxTransactionList.Text = "Transaction List";
            // 
            // listBoxTXNList
            // 
            this.listBoxTXNList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTXNList.FormattingEnabled = true;
            this.listBoxTXNList.ItemHeight = 15;
            this.listBoxTXNList.Location = new System.Drawing.Point(3, 17);
            this.listBoxTXNList.Name = "listBoxTXNList";
            this.listBoxTXNList.Size = new System.Drawing.Size(856, 432);
            this.listBoxTXNList.TabIndex = 2;
            // 
            // SaveFileDialogTXN
            // 
            this.SaveFileDialogTXN.Filter = "Text File|*.txt";
            this.SaveFileDialogTXN.Title = "Select File Location";
            // 
            // TransactionListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 452);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.groupBoxTransactionList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(878, 490);
            this.Name = "TransactionListView";
            this.Text = "TransactionListView";
            this.Load += new System.EventHandler(this.TransactionListView_Load);
            this.panelControl.ResumeLayout(false);
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxControl.PerformLayout();
            this.panelButtonControl.ResumeLayout(false);
            this.groupBoxTransactionList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.Panel panelButtonControl;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBoxTransactionList;
        private System.Windows.Forms.ListBox listBoxTXNList;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogTXN;
    }
}