namespace imgurdl
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslRunning = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslStats = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslRuntime = new System.Windows.Forms.ToolStripStatusLabel();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doneDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.downloadedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skippedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentPageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subredditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnToggle = new System.Windows.Forms.ToolStripButton();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subredditBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnToggle,
            this.toolStripSeparator1,
            this.btnSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(577, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.AllowUserToDeleteRows = false;
            this.dgData.AutoGenerateColumns = false;
            this.dgData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.doneDataGridViewCheckBoxColumn,
            this.downloadedDataGridViewTextBoxColumn,
            this.skippedDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.currentPageDataGridViewTextBoxColumn});
            this.dgData.DataSource = this.subredditBindingSource;
            this.dgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgData.Location = new System.Drawing.Point(0, 25);
            this.dgData.Name = "dgData";
            this.dgData.ReadOnly = true;
            this.dgData.RowHeadersVisible = false;
            this.dgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgData.Size = new System.Drawing.Size(577, 275);
            this.dgData.TabIndex = 1;
            this.dgData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgData_CellDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslRunning,
            this.tslStats,
            this.tslRuntime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 278);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(577, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslRunning
            // 
            this.tslRunning.Image = global::imgurdl.Properties.Resources.cross;
            this.tslRunning.Name = "tslRunning";
            this.tslRunning.Size = new System.Drawing.Size(88, 17);
            this.tslRunning.Text = "Not running";
            // 
            // tslStats
            // 
            this.tslStats.Image = global::imgurdl.Properties.Resources.chart_line;
            this.tslStats.Name = "tslStats";
            this.tslStats.Size = new System.Drawing.Size(198, 17);
            this.tslStats.Text = "Downloaded: - Skipped: - Total: -";
            // 
            // tslRuntime
            // 
            this.tslRuntime.Image = global::imgurdl.Properties.Resources.hourglass;
            this.tslRuntime.Name = "tslRuntime";
            this.tslRuntime.Size = new System.Drawing.Size(76, 17);
            this.tslRuntime.Text = "0min 0sec";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Subreddit";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // doneDataGridViewCheckBoxColumn
            // 
            this.doneDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.doneDataGridViewCheckBoxColumn.DataPropertyName = "Done";
            this.doneDataGridViewCheckBoxColumn.HeaderText = "Done";
            this.doneDataGridViewCheckBoxColumn.Name = "doneDataGridViewCheckBoxColumn";
            this.doneDataGridViewCheckBoxColumn.ReadOnly = true;
            this.doneDataGridViewCheckBoxColumn.Width = 50;
            // 
            // downloadedDataGridViewTextBoxColumn
            // 
            this.downloadedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.downloadedDataGridViewTextBoxColumn.DataPropertyName = "Downloaded";
            this.downloadedDataGridViewTextBoxColumn.HeaderText = "Downloaded";
            this.downloadedDataGridViewTextBoxColumn.MinimumWidth = 60;
            this.downloadedDataGridViewTextBoxColumn.Name = "downloadedDataGridViewTextBoxColumn";
            this.downloadedDataGridViewTextBoxColumn.ReadOnly = true;
            this.downloadedDataGridViewTextBoxColumn.Width = 60;
            // 
            // skippedDataGridViewTextBoxColumn
            // 
            this.skippedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.skippedDataGridViewTextBoxColumn.DataPropertyName = "Skipped";
            this.skippedDataGridViewTextBoxColumn.HeaderText = "Skipped";
            this.skippedDataGridViewTextBoxColumn.MinimumWidth = 60;
            this.skippedDataGridViewTextBoxColumn.Name = "skippedDataGridViewTextBoxColumn";
            this.skippedDataGridViewTextBoxColumn.ReadOnly = true;
            this.skippedDataGridViewTextBoxColumn.Width = 60;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 60;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.Width = 60;
            // 
            // currentPageDataGridViewTextBoxColumn
            // 
            this.currentPageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.currentPageDataGridViewTextBoxColumn.DataPropertyName = "CurrentPage";
            this.currentPageDataGridViewTextBoxColumn.HeaderText = "Page";
            this.currentPageDataGridViewTextBoxColumn.MinimumWidth = 60;
            this.currentPageDataGridViewTextBoxColumn.Name = "currentPageDataGridViewTextBoxColumn";
            this.currentPageDataGridViewTextBoxColumn.ReadOnly = true;
            this.currentPageDataGridViewTextBoxColumn.Width = 60;
            // 
            // subredditBindingSource
            // 
            this.subredditBindingSource.DataSource = typeof(imgurdl.Subreddit);
            // 
            // btnToggle
            // 
            this.btnToggle.Image = global::imgurdl.Properties.Resources.control_play_blue;
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(51, 22);
            this.btnToggle.Text = "Start";
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Image = global::imgurdl.Properties.Resources.cog;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(69, 22);
            this.btnSettings.Text = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(577, 300);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgData);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Imgur Subreddit Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subredditBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgData;
        private System.Windows.Forms.ToolStripButton btnToggle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSettings;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.BindingSource subredditBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn doneDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn downloadedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skippedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentPageDataGridViewTextBoxColumn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslRunning;
        private System.Windows.Forms.ToolStripStatusLabel tslStats;
        private System.Windows.Forms.ToolStripStatusLabel tslRuntime;
    }
}