namespace EventVisualizer
{
    partial class TransactionStat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionStat));
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.groupBoxLogs = new System.Windows.Forms.GroupBox();
            this.dataGridViewTran = new System.Windows.Forms.DataGridView();
            this.groupBoxControl.SuspendLayout();
            this.groupBoxLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTran)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.labelType);
            this.groupBoxControl.Controls.Add(this.comboBoxType);
            this.groupBoxControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxControl.Location = new System.Drawing.Point(0, 0);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(334, 63);
            this.groupBoxControl.TabIndex = 1;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "Control";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(14, 25);
            this.labelType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(44, 15);
            this.labelType.TabIndex = 6;
            this.labelType.Text = "Select:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(69, 22);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(248, 23);
            this.comboBoxType.TabIndex = 5;
            // 
            // groupBoxLogs
            // 
            this.groupBoxLogs.Controls.Add(this.dataGridViewTran);
            this.groupBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLogs.Location = new System.Drawing.Point(0, 63);
            this.groupBoxLogs.Name = "groupBoxLogs";
            this.groupBoxLogs.Size = new System.Drawing.Size(334, 519);
            this.groupBoxLogs.TabIndex = 2;
            this.groupBoxLogs.TabStop = false;
            this.groupBoxLogs.Text = "Trabsaction Statistics";
            // 
            // dataGridViewTran
            // 
            this.dataGridViewTran.AllowUserToAddRows = false;
            this.dataGridViewTran.AllowUserToDeleteRows = false;
            this.dataGridViewTran.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTran.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTran.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewTran.Name = "dataGridViewTran";
            this.dataGridViewTran.ReadOnly = true;
            this.dataGridViewTran.RowHeadersVisible = false;
            this.dataGridViewTran.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTran.Size = new System.Drawing.Size(328, 499);
            this.dataGridViewTran.TabIndex = 0;
            // 
            // TransactionStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 582);
            this.Controls.Add(this.groupBoxLogs);
            this.Controls.Add(this.groupBoxControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 620);
            this.Name = "TransactionStat";
            this.Text = "TransactionStat";
            this.Load += new System.EventHandler(this.TransactionStat_Load);
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxControl.PerformLayout();
            this.groupBoxLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTran)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.GroupBox groupBoxLogs;
        private System.Windows.Forms.DataGridView dataGridViewTran;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxType;
    }
}