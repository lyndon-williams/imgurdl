namespace imgurdl
{
    partial class SettingsForm
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
            this.pgData = new System.Windows.Forms.PropertyGrid();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pgData
            // 
            this.pgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgData.Location = new System.Drawing.Point(0, 0);
            this.pgData.Name = "pgData";
            this.pgData.Size = new System.Drawing.Size(277, 248);
            this.pgData.TabIndex = 0;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveClose.Location = new System.Drawing.Point(0, 225);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(277, 23);
            this.btnSaveClose.TabIndex = 3;
            this.btnSaveClose.Text = "Close";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 248);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.pgData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgData;
        private System.Windows.Forms.Button btnSaveClose;
    }
}