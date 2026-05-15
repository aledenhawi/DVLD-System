namespace DVDL_Driving_License_Management_WindowsForm.Screens
{
    partial class frmIssueDrivingLicenseForTheFirstTime
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
            this.ctrLocalDrivingLicenseApplicationFullDetails1 = new DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Controls.ctrLocalDrivingLicenseApplicationFullDetails();
            this.label1 = new System.Windows.Forms.Label();
            this.txbNotes = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrLocalDrivingLicenseApplicationFullDetails1
            // 
            this.ctrLocalDrivingLicenseApplicationFullDetails1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ctrLocalDrivingLicenseApplicationFullDetails1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ctrLocalDrivingLicenseApplicationFullDetails1.Location = new System.Drawing.Point(14, 13);
            this.ctrLocalDrivingLicenseApplicationFullDetails1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ctrLocalDrivingLicenseApplicationFullDetails1.Name = "ctrLocalDrivingLicenseApplicationFullDetails1";
            this.ctrLocalDrivingLicenseApplicationFullDetails1.Size = new System.Drawing.Size(981, 407);
            this.ctrLocalDrivingLicenseApplicationFullDetails1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(19, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Notes : ";
            // 
            // txbNotes
            // 
            this.txbNotes.Location = new System.Drawing.Point(136, 436);
            this.txbNotes.Multiline = true;
            this.txbNotes.Name = "txbNotes";
            this.txbNotes.Size = new System.Drawing.Size(845, 173);
            this.txbNotes.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Notes_32;
            this.pictureBox1.Location = new System.Drawing.Point(96, 436);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 32);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkCyan;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(715, 615);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 46);
            this.btnClose.TabIndex = 76;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.Teal;
            this.btnIssue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIssue.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.IssueDrivingLicense_32;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(860, 615);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(121, 46);
            this.btnIssue.TabIndex = 77;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // frmIssueDrivingLicenseForTheFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1004, 669);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txbNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrLocalDrivingLicenseApplicationFullDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmIssueDrivingLicenseForTheFirstTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIssueDrivingLicenseForTheFirstTime";
            this.Load += new System.EventHandler(this.frmIssueDrivingLicenseForTheFirstTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.Controls.ctrLocalDrivingLicenseApplicationFullDetails ctrLocalDrivingLicenseApplicationFullDetails1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbNotes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
    }
}