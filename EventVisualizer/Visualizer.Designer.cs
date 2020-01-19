namespace EventVisualizer
{
    partial class Visualizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visualizer));
            this.panelSettings = new System.Windows.Forms.Panel();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.labelSystem = new System.Windows.Forms.Label();
            this.labelLog = new System.Windows.Forms.Label();
            this.comboBoxSystem = new System.Windows.Forms.ComboBox();
            this.comboBoxLogs = new System.Windows.Forms.ComboBox();
            this.labelInstance = new System.Windows.Forms.Label();
            this.comboBoxInstance = new System.Windows.Forms.ComboBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelServer = new System.Windows.Forms.Label();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.textBoxTransaction = new System.Windows.Forms.TextBox();
            this.textBoxBranch = new System.Windows.Forms.TextBox();
            this.textBoxTeller = new System.Windows.Forms.TextBox();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelTransaction = new System.Windows.Forms.Label();
            this.labelBranch = new System.Windows.Forms.Label();
            this.labelTeller = new System.Windows.Forms.Label();
            this.groupBoxControls = new System.Windows.Forms.GroupBox();
            this.buttonClearLogs = new System.Windows.Forms.Button();
            this.checkBoxTransactionView = new System.Windows.Forms.CheckBox();
            this.checkBoxFilter = new System.Windows.Forms.CheckBox();
            this.buttonFlowTXNStat = new System.Windows.Forms.Button();
            this.buttonSync = new System.Windows.Forms.Button();
            this.statusStripStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelTransactionNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxLogs = new System.Windows.Forms.GroupBox();
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.groupBoxTransactionView = new System.Windows.Forms.GroupBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.groupBoxTextView = new System.Windows.Forms.GroupBox();
            this.textBoxTextView = new System.Windows.Forms.TextBox();
            this.panelSettings.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.groupBoxFilters.SuspendLayout();
            this.groupBoxControls.SuspendLayout();
            this.statusStripStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxLogs.SuspendLayout();
            this.groupBoxTransactionView.SuspendLayout();
            this.groupBoxTextView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.groupBoxSettings);
            this.panelSettings.Controls.Add(this.groupBoxFilters);
            this.panelSettings.Controls.Add(this.groupBoxControls);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(1199, 204);
            this.panelSettings.TabIndex = 0;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.labelSystem);
            this.groupBoxSettings.Controls.Add(this.labelLog);
            this.groupBoxSettings.Controls.Add(this.comboBoxSystem);
            this.groupBoxSettings.Controls.Add(this.comboBoxLogs);
            this.groupBoxSettings.Controls.Add(this.labelInstance);
            this.groupBoxSettings.Controls.Add(this.comboBoxInstance);
            this.groupBoxSettings.Controls.Add(this.labelPath);
            this.groupBoxSettings.Controls.Add(this.labelServer);
            this.groupBoxSettings.Controls.Add(this.comboBoxServer);
            this.groupBoxSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSettings.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(448, 204);
            this.groupBoxSettings.TabIndex = 6;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // labelSystem
            // 
            this.labelSystem.AutoSize = true;
            this.labelSystem.Location = new System.Drawing.Point(20, 145);
            this.labelSystem.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelSystem.Name = "labelSystem";
            this.labelSystem.Size = new System.Drawing.Size(87, 15);
            this.labelSystem.TabIndex = 9;
            this.labelSystem.Text = "System Name:";
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(20, 112);
            this.labelLog.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(68, 15);
            this.labelLog.TabIndex = 9;
            this.labelLog.Text = "Log Name:";
            // 
            // comboBoxSystem
            // 
            this.comboBoxSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSystem.FormattingEnabled = true;
            this.comboBoxSystem.Location = new System.Drawing.Point(136, 142);
            this.comboBoxSystem.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxSystem.Name = "comboBoxSystem";
            this.comboBoxSystem.Size = new System.Drawing.Size(299, 23);
            this.comboBoxSystem.TabIndex = 8;
            // 
            // comboBoxLogs
            // 
            this.comboBoxLogs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLogs.FormattingEnabled = true;
            this.comboBoxLogs.Location = new System.Drawing.Point(136, 109);
            this.comboBoxLogs.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxLogs.Name = "comboBoxLogs";
            this.comboBoxLogs.Size = new System.Drawing.Size(299, 23);
            this.comboBoxLogs.TabIndex = 8;
            // 
            // labelInstance
            // 
            this.labelInstance.AutoSize = true;
            this.labelInstance.Location = new System.Drawing.Point(20, 79);
            this.labelInstance.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelInstance.Name = "labelInstance";
            this.labelInstance.Size = new System.Drawing.Size(56, 15);
            this.labelInstance.TabIndex = 7;
            this.labelInstance.Text = "Instance:";
            // 
            // comboBoxInstance
            // 
            this.comboBoxInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInstance.FormattingEnabled = true;
            this.comboBoxInstance.Location = new System.Drawing.Point(136, 76);
            this.comboBoxInstance.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxInstance.Name = "comboBoxInstance";
            this.comboBoxInstance.Size = new System.Drawing.Size(299, 23);
            this.comboBoxInstance.TabIndex = 6;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(133, 54);
            this.labelPath.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(32, 15);
            this.labelPath.TabIndex = 5;
            this.labelPath.Text = "Path";
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(20, 26);
            this.labelServer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(45, 15);
            this.labelServer.TabIndex = 4;
            this.labelServer.Text = "Server:";
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Location = new System.Drawing.Point(136, 23);
            this.comboBoxServer.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(299, 23);
            this.comboBoxServer.TabIndex = 3;
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.textBoxTransaction);
            this.groupBoxFilters.Controls.Add(this.textBoxBranch);
            this.groupBoxFilters.Controls.Add(this.textBoxTeller);
            this.groupBoxFilters.Controls.Add(this.dateTimePickerEnd);
            this.groupBoxFilters.Controls.Add(this.dateTimePickerStart);
            this.groupBoxFilters.Controls.Add(this.labelEndTime);
            this.groupBoxFilters.Controls.Add(this.labelStart);
            this.groupBoxFilters.Controls.Add(this.labelTransaction);
            this.groupBoxFilters.Controls.Add(this.labelBranch);
            this.groupBoxFilters.Controls.Add(this.labelTeller);
            this.groupBoxFilters.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxFilters.Location = new System.Drawing.Point(448, 0);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(381, 204);
            this.groupBoxFilters.TabIndex = 5;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filters";
            // 
            // textBoxTransaction
            // 
            this.textBoxTransaction.Location = new System.Drawing.Point(168, 92);
            this.textBoxTransaction.MaxLength = 6;
            this.textBoxTransaction.Name = "textBoxTransaction";
            this.textBoxTransaction.Size = new System.Drawing.Size(104, 21);
            this.textBoxTransaction.TabIndex = 22;
            // 
            // textBoxBranch
            // 
            this.textBoxBranch.Location = new System.Drawing.Point(168, 59);
            this.textBoxBranch.MaxLength = 4;
            this.textBoxBranch.Name = "textBoxBranch";
            this.textBoxBranch.Size = new System.Drawing.Size(104, 21);
            this.textBoxBranch.TabIndex = 21;
            // 
            // textBoxTeller
            // 
            this.textBoxTeller.Location = new System.Drawing.Point(168, 26);
            this.textBoxTeller.MaxLength = 5;
            this.textBoxTeller.Name = "textBoxTeller";
            this.textBoxTeller.Size = new System.Drawing.Size(104, 21);
            this.textBoxTeller.TabIndex = 10;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "dd / MM / yyyy hh: mm: ss tt";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(168, 150);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(204, 21);
            this.dateTimePickerEnd.TabIndex = 20;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "dd / MM / yyyy hh: mm: ss tt";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(168, 123);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(204, 21);
            this.dateTimePickerStart.TabIndex = 4;
            // 
            // labelEndTime
            // 
            this.labelEndTime.AutoSize = true;
            this.labelEndTime.Location = new System.Drawing.Point(52, 155);
            this.labelEndTime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Size = new System.Drawing.Size(63, 15);
            this.labelEndTime.TabIndex = 19;
            this.labelEndTime.Text = "End Time:";
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(52, 128);
            this.labelStart.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(66, 15);
            this.labelStart.TabIndex = 17;
            this.labelStart.Text = "Start Time:";
            // 
            // labelTransaction
            // 
            this.labelTransaction.AutoSize = true;
            this.labelTransaction.Location = new System.Drawing.Point(52, 95);
            this.labelTransaction.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTransaction.Name = "labelTransaction";
            this.labelTransaction.Size = new System.Drawing.Size(74, 15);
            this.labelTransaction.TabIndex = 14;
            this.labelTransaction.Text = "Transaction:";
            // 
            // labelBranch
            // 
            this.labelBranch.AutoSize = true;
            this.labelBranch.Location = new System.Drawing.Point(52, 62);
            this.labelBranch.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelBranch.Name = "labelBranch";
            this.labelBranch.Size = new System.Drawing.Size(49, 15);
            this.labelBranch.TabIndex = 15;
            this.labelBranch.Text = "Branch:";
            // 
            // labelTeller
            // 
            this.labelTeller.AutoSize = true;
            this.labelTeller.Location = new System.Drawing.Point(52, 29);
            this.labelTeller.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTeller.Name = "labelTeller";
            this.labelTeller.Size = new System.Drawing.Size(41, 15);
            this.labelTeller.TabIndex = 11;
            this.labelTeller.Text = "Teller:";
            // 
            // groupBoxControls
            // 
            this.groupBoxControls.Controls.Add(this.buttonClearLogs);
            this.groupBoxControls.Controls.Add(this.checkBoxTransactionView);
            this.groupBoxControls.Controls.Add(this.checkBoxFilter);
            this.groupBoxControls.Controls.Add(this.buttonFlowTXNStat);
            this.groupBoxControls.Controls.Add(this.buttonSync);
            this.groupBoxControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxControls.Location = new System.Drawing.Point(829, 0);
            this.groupBoxControls.Name = "groupBoxControls";
            this.groupBoxControls.Size = new System.Drawing.Size(370, 204);
            this.groupBoxControls.TabIndex = 3;
            this.groupBoxControls.TabStop = false;
            this.groupBoxControls.Text = "Controls";
            // 
            // buttonClearLogs
            // 
            this.buttonClearLogs.Location = new System.Drawing.Point(26, 76);
            this.buttonClearLogs.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearLogs.Name = "buttonClearLogs";
            this.buttonClearLogs.Size = new System.Drawing.Size(150, 44);
            this.buttonClearLogs.TabIndex = 15;
            this.buttonClearLogs.Text = "Clear Logs";
            this.buttonClearLogs.UseVisualStyleBackColor = true;
            // 
            // checkBoxTransactionView
            // 
            this.checkBoxTransactionView.AutoSize = true;
            this.checkBoxTransactionView.Location = new System.Drawing.Point(26, 166);
            this.checkBoxTransactionView.Name = "checkBoxTransactionView";
            this.checkBoxTransactionView.Size = new System.Drawing.Size(181, 19);
            this.checkBoxTransactionView.TabIndex = 14;
            this.checkBoxTransactionView.Text = "Show Transaction List Panel";
            this.checkBoxTransactionView.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilter
            // 
            this.checkBoxFilter.AutoSize = true;
            this.checkBoxFilter.Checked = true;
            this.checkBoxFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFilter.Location = new System.Drawing.Point(26, 141);
            this.checkBoxFilter.Name = "checkBoxFilter";
            this.checkBoxFilter.Size = new System.Drawing.Size(59, 19);
            this.checkBoxFilter.TabIndex = 7;
            this.checkBoxFilter.Text = "Filters";
            this.checkBoxFilter.UseVisualStyleBackColor = true;
            // 
            // buttonFlowTXNStat
            // 
            this.buttonFlowTXNStat.Location = new System.Drawing.Point(196, 25);
            this.buttonFlowTXNStat.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFlowTXNStat.Name = "buttonFlowTXNStat";
            this.buttonFlowTXNStat.Size = new System.Drawing.Size(150, 44);
            this.buttonFlowTXNStat.TabIndex = 6;
            this.buttonFlowTXNStat.Text = "Transaction Statistics";
            this.buttonFlowTXNStat.UseVisualStyleBackColor = true;
            // 
            // buttonSync
            // 
            this.buttonSync.Location = new System.Drawing.Point(26, 25);
            this.buttonSync.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSync.Name = "buttonSync";
            this.buttonSync.Size = new System.Drawing.Size(150, 44);
            this.buttonSync.TabIndex = 5;
            this.buttonSync.Text = "Sync";
            this.buttonSync.UseVisualStyleBackColor = true;
            // 
            // statusStripStatus
            // 
            this.statusStripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTransactionNumber});
            this.statusStripStatus.Location = new System.Drawing.Point(0, 620);
            this.statusStripStatus.Name = "statusStripStatus";
            this.statusStripStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStripStatus.Size = new System.Drawing.Size(1199, 22);
            this.statusStripStatus.TabIndex = 2;
            this.statusStripStatus.Text = "Status";
            // 
            // toolStripStatusLabelTransactionNumber
            // 
            this.toolStripStatusLabelTransactionNumber.Name = "toolStripStatusLabelTransactionNumber";
            this.toolStripStatusLabelTransactionNumber.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabelTransactionNumber.Text = "Status";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 204);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxLogs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxTransactionView);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxTextView);
            this.splitContainer1.Size = new System.Drawing.Size(1199, 416);
            this.splitContainer1.SplitterDistance = 398;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBoxLogs
            // 
            this.groupBoxLogs.Controls.Add(this.listBoxLogs);
            this.groupBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLogs.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLogs.Name = "groupBoxLogs";
            this.groupBoxLogs.Size = new System.Drawing.Size(398, 416);
            this.groupBoxLogs.TabIndex = 0;
            this.groupBoxLogs.TabStop = false;
            this.groupBoxLogs.Text = "Logs";
            // 
            // listBoxLogs
            // 
            this.listBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLogs.FormattingEnabled = true;
            this.listBoxLogs.ItemHeight = 15;
            this.listBoxLogs.Location = new System.Drawing.Point(3, 17);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.Size = new System.Drawing.Size(392, 396);
            this.listBoxLogs.TabIndex = 0;
            // 
            // groupBoxTransactionView
            // 
            this.groupBoxTransactionView.Controls.Add(this.textBoxOutput);
            this.groupBoxTransactionView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTransactionView.Location = new System.Drawing.Point(0, 123);
            this.groupBoxTransactionView.Name = "groupBoxTransactionView";
            this.groupBoxTransactionView.Size = new System.Drawing.Size(796, 293);
            this.groupBoxTransactionView.TabIndex = 2;
            this.groupBoxTransactionView.TabStop = false;
            this.groupBoxTransactionView.Text = "Transaction View";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutput.Location = new System.Drawing.Point(3, 17);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(790, 273);
            this.textBoxOutput.TabIndex = 1;
            // 
            // groupBoxTextView
            // 
            this.groupBoxTextView.Controls.Add(this.textBoxTextView);
            this.groupBoxTextView.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTextView.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTextView.Name = "groupBoxTextView";
            this.groupBoxTextView.Size = new System.Drawing.Size(796, 123);
            this.groupBoxTextView.TabIndex = 1;
            this.groupBoxTextView.TabStop = false;
            this.groupBoxTextView.Text = "Text View";
            // 
            // textBoxTextView
            // 
            this.textBoxTextView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTextView.Location = new System.Drawing.Point(3, 17);
            this.textBoxTextView.Multiline = true;
            this.textBoxTextView.Name = "textBoxTextView";
            this.textBoxTextView.ReadOnly = true;
            this.textBoxTextView.Size = new System.Drawing.Size(790, 103);
            this.textBoxTextView.TabIndex = 0;
            // 
            // Visualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 642);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStripStatus);
            this.Controls.Add(this.panelSettings);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1215, 680);
            this.Name = "Visualizer";
            this.Text = "Visualizer";
            this.Load += new System.EventHandler(this.Visualizer_Load);
            this.panelSettings.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxFilters.PerformLayout();
            this.groupBoxControls.ResumeLayout(false);
            this.groupBoxControls.PerformLayout();
            this.statusStripStatus.ResumeLayout(false);
            this.statusStripStatus.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxLogs.ResumeLayout(false);
            this.groupBoxTransactionView.ResumeLayout(false);
            this.groupBoxTransactionView.PerformLayout();
            this.groupBoxTextView.ResumeLayout(false);
            this.groupBoxTextView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.GroupBox groupBoxControls;
        private System.Windows.Forms.StatusStrip statusStripStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.ComboBox comboBoxLogs;
        private System.Windows.Forms.Label labelInstance;
        private System.Windows.Forms.ComboBox comboBoxInstance;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.ComboBox comboBoxServer;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.Button buttonSync;
        private System.Windows.Forms.Button buttonFlowTXNStat;
        private System.Windows.Forms.GroupBox groupBoxLogs;
        private System.Windows.Forms.ListBox listBoxLogs;
        private System.Windows.Forms.GroupBox groupBoxTransactionView;
        private System.Windows.Forms.GroupBox groupBoxTextView;
        private System.Windows.Forms.TextBox textBoxTextView;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTransactionNumber;
		private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Label labelSystem;
        private System.Windows.Forms.ComboBox comboBoxSystem;
        private System.Windows.Forms.Label labelTransaction;
        private System.Windows.Forms.Label labelBranch;
        private System.Windows.Forms.Label labelTeller;
        private System.Windows.Forms.CheckBox checkBoxFilter;
        private System.Windows.Forms.CheckBox checkBoxTransactionView;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEndTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.TextBox textBoxTransaction;
        private System.Windows.Forms.TextBox textBoxBranch;
        private System.Windows.Forms.TextBox textBoxTeller;
        private System.Windows.Forms.Button buttonClearLogs;
    }
}