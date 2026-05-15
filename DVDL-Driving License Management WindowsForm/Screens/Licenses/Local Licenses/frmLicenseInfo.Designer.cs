namespace DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.Local_Licenses
{
    partial class frmLicenseInfo
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
            this.ctrLicenseInfo1 = new DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.Local_Licenses.Controls.ctrLicenseInfo();
            this.pbPersonPic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonPic)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrLicenseInfo1
            // 
            this.ctrLicenseInfo1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ctrLicenseInfo1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ctrLicenseInfo1.Location = new System.Drawing.Point(14, 219);
            this.ctrLicenseInfo1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ctrLicenseInfo1.Name = "ctrLicenseInfo1";
            this.ctrLicenseInfo1.Size = new System.Drawing.Size(1086, 474);
            this.ctrLicenseInfo1.TabIndex = 0;
            // 
            // pbPersonPic
            // 
            this.pbPersonPic.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.LicenseView_400;
            this.pbPersonPic.Location = new System.Drawing.Point(412, 3);
            this.pbPersonPic.Name = "pbPersonPic";
            this.pbPersonPic.Size = new System.Drawing.Size(205, 154);
            this.pbPersonPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonPic.TabIndex = 1;
            this.pbPersonPic.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(331, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Driving License Info ";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkCyan;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(903, 694);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(186, 55);
            this.btnClose.TabIndex = 76;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1101, 761);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbPersonPic);
            this.Controls.Add(this.ctrLicenseInfo1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmLicenseInfo";
            this.Text = "frmLicenseInfo";
            this.Load += new System.EventHandler(this.frmLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrLicenseInfo ctrLicenseInfo1;
        private System.Windows.Forms.PictureBox pbPersonPic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}