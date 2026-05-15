namespace DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.Local_Licenses.Controls
{
    partial class ctrLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrLicenseInfo1 = new DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.Local_Licenses.Controls.ctrLicenseInfo();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFindLicense = new System.Windows.Forms.Button();
            this.txbLicenseID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrLicenseInfo1
            // 
            this.ctrLicenseInfo1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ctrLicenseInfo1.Location = new System.Drawing.Point(0, 112);
            this.ctrLicenseInfo1.Name = "ctrLicenseInfo1";
            this.ctrLicenseInfo1.Size = new System.Drawing.Size(1086, 474);
            this.ctrLicenseInfo1.TabIndex = 0;
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFindLicense);
            this.gbFilter.Controls.Add(this.txbLicenseID);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(765, 109);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.BackgroundImage = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.LicenseView_400;
            this.btnFindLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindLicense.Location = new System.Drawing.Point(635, 26);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.Size = new System.Drawing.Size(91, 62);
            this.btnFindLicense.TabIndex = 5;
            this.btnFindLicense.UseVisualStyleBackColor = true;
            this.btnFindLicense.Click += new System.EventHandler(this.btnFindLicense_Click);
            // 
            // txbLicenseID
            // 
            this.txbLicenseID.Location = new System.Drawing.Point(164, 40);
            this.txbLicenseID.Name = "txbLicenseID";
            this.txbLicenseID.Size = new System.Drawing.Size(412, 32);
            this.txbLicenseID.TabIndex = 1;
            this.txbLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbLicenseID_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "License ID : ";
            // 
            // ctrLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ctrLicenseInfo1);
            this.Name = "ctrLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(1084, 586);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrLicenseInfo ctrLicenseInfo1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbLicenseID;
        private System.Windows.Forms.Button btnFindLicense;
    }
}
