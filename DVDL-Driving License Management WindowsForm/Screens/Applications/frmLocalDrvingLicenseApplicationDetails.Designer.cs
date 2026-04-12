namespace DVDL_Driving_License_Management_WindowsForm.Screens.Applications
{
    partial class frmLocalDrvingLicenseApplicationDetails
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
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrLocalDrivingLicenseApplicationFullDetails1 = new DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Controls.ctrLocalDrivingLicenseApplicationFullDetails();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkCyan;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(805, 413);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(176, 47);
            this.btnClose.TabIndex = 105;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            // frmLocalDrvingLicenseApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1004, 472);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrLocalDrivingLicenseApplicationFullDetails1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmLocalDrvingLicenseApplicationDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Details";
            this.Load += new System.EventHandler(this.frmLocalDrvingLicenseApplicationDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrLocalDrivingLicenseApplicationFullDetails ctrLocalDrivingLicenseApplicationFullDetails1;
        private System.Windows.Forms.Button btnClose;
    }
}