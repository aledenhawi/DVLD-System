namespace DVDL_Driving_License_Management_WindowsForm.Screens.Applications
{
    partial class frmLocalDrivingLicenseApplications
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
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.txbFiltringLDLApplications = new System.Windows.Forms.TextBox();
            this.cmbLDLApplicationsFiltring = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalDrivingLicenseApplicationsList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsCancleApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSechduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.visionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writtenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsIssueDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.Separeotr = new System.Windows.Forms.ToolStripSeparator();
            this.tsShowPersonLicenseHistroy = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAddNewLDLApplication = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplicationsList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Perpetua", 16F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(0, 799);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 31);
            this.label3.TabIndex = 18;
            this.label3.Text = "Records :";
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRecords.Font = new System.Drawing.Font("Perpetua", 16F);
            this.lblTotalRecords.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalRecords.Location = new System.Drawing.Point(114, 799);
            this.lblTotalRecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(26, 31);
            this.lblTotalRecords.TabIndex = 16;
            this.lblTotalRecords.Text = "0";
            // 
            // txbFiltringLDLApplications
            // 
            this.txbFiltringLDLApplications.Location = new System.Drawing.Point(310, 343);
            this.txbFiltringLDLApplications.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txbFiltringLDLApplications.Name = "txbFiltringLDLApplications";
            this.txbFiltringLDLApplications.Size = new System.Drawing.Size(196, 24);
            this.txbFiltringLDLApplications.TabIndex = 15;
            this.txbFiltringLDLApplications.Visible = false;
            this.txbFiltringLDLApplications.TextChanged += new System.EventHandler(this.txbFiltringLDLApplications_TextChanged);
            this.txbFiltringLDLApplications.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbFiltringLDLApplications_KeyPress);
            // 
            // cmbLDLApplicationsFiltring
            // 
            this.cmbLDLApplicationsFiltring.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLDLApplicationsFiltring.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbLDLApplicationsFiltring.FormattingEnabled = true;
            this.cmbLDLApplicationsFiltring.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "Driving Class",
            "National No.",
            "Full Name",
            "Passed Tests",
            "Status"});
            this.cmbLDLApplicationsFiltring.Location = new System.Drawing.Point(104, 339);
            this.cmbLDLApplicationsFiltring.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cmbLDLApplicationsFiltring.Name = "cmbLDLApplicationsFiltring";
            this.cmbLDLApplicationsFiltring.Size = new System.Drawing.Size(182, 29);
            this.cmbLDLApplicationsFiltring.TabIndex = 14;
            this.cmbLDLApplicationsFiltring.SelectedIndexChanged += new System.EventHandler(this.cmbLDLApplicationsFiltring_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(2, 339);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Filter By :";
            // 
            // dgvLocalDrivingLicenseApplicationsList
            // 
            this.dgvLocalDrivingLicenseApplicationsList.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplicationsList.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplicationsList.BackgroundColor = System.Drawing.Color.SlateGray;
            this.dgvLocalDrivingLicenseApplicationsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplicationsList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalDrivingLicenseApplicationsList.GridColor = System.Drawing.Color.SlateGray;
            this.dgvLocalDrivingLicenseApplicationsList.Location = new System.Drawing.Point(-4, 376);
            this.dgvLocalDrivingLicenseApplicationsList.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvLocalDrivingLicenseApplicationsList.Name = "dgvLocalDrivingLicenseApplicationsList";
            this.dgvLocalDrivingLicenseApplicationsList.ReadOnly = true;
            this.dgvLocalDrivingLicenseApplicationsList.RowHeadersWidth = 51;
            this.dgvLocalDrivingLicenseApplicationsList.RowTemplate.Height = 26;
            this.dgvLocalDrivingLicenseApplicationsList.Size = new System.Drawing.Size(1276, 421);
            this.dgvLocalDrivingLicenseApplicationsList.TabIndex = 12;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(50, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.tsEditApplication,
            this.tsDeleteApplication,
            this.toolStripSeparator2,
            this.tsCancleApplication,
            this.toolStripSeparator4,
            this.tsSechduleTest,
            this.toolStripSeparator3,
            this.tsIssueDrivingLicense,
            this.toolStripSeparator5,
            this.tsShowLicense,
            this.Separeotr,
            this.tsShowPersonLicenseHistroy});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(365, 436);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.BackColor = System.Drawing.Color.DarkSlateGray;
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.PersonDetails_32;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(364, 46);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.tsShowApplicationDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(361, 6);
            // 
            // tsEditApplication
            // 
            this.tsEditApplication.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tsEditApplication.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.edit_32;
            this.tsEditApplication.Name = "tsEditApplication";
            this.tsEditApplication.Size = new System.Drawing.Size(364, 46);
            this.tsEditApplication.Text = "Edit Application";
            this.tsEditApplication.Click += new System.EventHandler(this.tsEditApplicatoin_Click);
            // 
            // tsDeleteApplication
            // 
            this.tsDeleteApplication.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tsDeleteApplication.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.close__1_;
            this.tsDeleteApplication.Name = "tsDeleteApplication";
            this.tsDeleteApplication.Size = new System.Drawing.Size(364, 46);
            this.tsDeleteApplication.Text = "Delete Application";
            this.tsDeleteApplication.Click += new System.EventHandler(this.tsDeleteApplication_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(361, 6);
            // 
            // tsCancleApplication
            // 
            this.tsCancleApplication.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tsCancleApplication.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Delete_32;
            this.tsCancleApplication.Name = "tsCancleApplication";
            this.tsCancleApplication.Size = new System.Drawing.Size(364, 46);
            this.tsCancleApplication.Text = "Cancle Application";
            this.tsCancleApplication.Click += new System.EventHandler(this.cancleApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(361, 6);
            // 
            // tsSechduleTest
            // 
            this.tsSechduleTest.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tsSechduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionTestToolStripMenuItem,
            this.writtenTestToolStripMenuItem,
            this.streetTestToolStripMenuItem});
            this.tsSechduleTest.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Schedule_Test_32;
            this.tsSechduleTest.Name = "tsSechduleTest";
            this.tsSechduleTest.Size = new System.Drawing.Size(364, 46);
            this.tsSechduleTest.Text = "Sechdule Test";
            // 
            // visionTestToolStripMenuItem
            // 
            this.visionTestToolStripMenuItem.BackColor = System.Drawing.Color.DarkSlateGray;
            this.visionTestToolStripMenuItem.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Vision_Test_32;
            this.visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            this.visionTestToolStripMenuItem.Size = new System.Drawing.Size(215, 46);
            this.visionTestToolStripMenuItem.Text = "Vision Test";
            this.visionTestToolStripMenuItem.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // writtenTestToolStripMenuItem
            // 
            this.writtenTestToolStripMenuItem.BackColor = System.Drawing.Color.DarkSlateGray;
            this.writtenTestToolStripMenuItem.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Written_Test_32_Sechdule;
            this.writtenTestToolStripMenuItem.Name = "writtenTestToolStripMenuItem";
            this.writtenTestToolStripMenuItem.Size = new System.Drawing.Size(215, 46);
            this.writtenTestToolStripMenuItem.Text = "Written Test";
            this.writtenTestToolStripMenuItem.Click += new System.EventHandler(this.writtenTestToolStripMenuItem_Click);
            // 
            // streetTestToolStripMenuItem
            // 
            this.streetTestToolStripMenuItem.BackColor = System.Drawing.Color.DarkSlateGray;
            this.streetTestToolStripMenuItem.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Street_Test_32;
            this.streetTestToolStripMenuItem.Name = "streetTestToolStripMenuItem";
            this.streetTestToolStripMenuItem.Size = new System.Drawing.Size(215, 46);
            this.streetTestToolStripMenuItem.Text = "Street Test";
            this.streetTestToolStripMenuItem.Click += new System.EventHandler(this.streetTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(361, 6);
            // 
            // tsIssueDrivingLicense
            // 
            this.tsIssueDrivingLicense.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tsIssueDrivingLicense.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.IssueDrivingLicense_32;
            this.tsIssueDrivingLicense.Name = "tsIssueDrivingLicense";
            this.tsIssueDrivingLicense.Size = new System.Drawing.Size(364, 46);
            this.tsIssueDrivingLicense.Text = "Issue Driving License (First  Time)";
            this.tsIssueDrivingLicense.Click += new System.EventHandler(this.tsIssueDrivingLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(361, 6);
            // 
            // tsShowLicense
            // 
            this.tsShowLicense.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.License_View_321;
            this.tsShowLicense.Name = "tsShowLicense";
            this.tsShowLicense.Size = new System.Drawing.Size(364, 46);
            this.tsShowLicense.Text = "Show License Info";
            this.tsShowLicense.Click += new System.EventHandler(this.tsShowLicense_Click);
            // 
            // Separeotr
            // 
            this.Separeotr.Name = "Separeotr";
            this.Separeotr.Size = new System.Drawing.Size(361, 6);
            // 
            // tsShowPersonLicenseHistroy
            // 
            this.tsShowPersonLicenseHistroy.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.PersonLicenseHistory_32;
            this.tsShowPersonLicenseHistroy.Name = "tsShowPersonLicenseHistroy";
            this.tsShowPersonLicenseHistroy.Size = new System.Drawing.Size(364, 46);
            this.tsShowPersonLicenseHistroy.Text = "Show Person License Histroy";
            this.tsShowPersonLicenseHistroy.Click += new System.EventHandler(this.tsShowPersonLicenseHistroy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(359, 259);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(669, 49);
            this.label1.TabIndex = 11;
            this.label1.Text = "Local Driving License Applications";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Local_321;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(743, 100);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(87, 64);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // btnAddNewLDLApplication
            // 
            this.btnAddNewLDLApplication.BackgroundImage = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.New_Application_64;
            this.btnAddNewLDLApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewLDLApplication.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewLDLApplication.FlatAppearance.BorderSize = 0;
            this.btnAddNewLDLApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewLDLApplication.Location = new System.Drawing.Point(1185, 308);
            this.btnAddNewLDLApplication.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNewLDLApplication.Name = "btnAddNewLDLApplication";
            this.btnAddNewLDLApplication.Size = new System.Drawing.Size(78, 62);
            this.btnAddNewLDLApplication.TabIndex = 17;
            this.btnAddNewLDLApplication.UseVisualStyleBackColor = true;
            this.btnAddNewLDLApplication.Click += new System.EventHandler(this.btnAddNewLDLApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Applications1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(493, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(337, 255);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // frmLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1268, 852);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNewLDLApplication);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.txbFiltringLDLApplications);
            this.Controls.Add(this.cmbLDLApplicationsFiltring);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvLocalDrivingLicenseApplicationsList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLocalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplicationsList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddNewLDLApplication;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.TextBox txbFiltringLDLApplications;
        private System.Windows.Forms.ComboBox cmbLDLApplicationsFiltring;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplicationsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsDeleteApplication;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsEditApplication;
        private System.Windows.Forms.ToolStripMenuItem tsCancleApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsSechduleTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsIssueDrivingLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsShowLicense;
        private System.Windows.Forms.ToolStripSeparator Separeotr;
        private System.Windows.Forms.ToolStripMenuItem tsShowPersonLicenseHistroy;
        private System.Windows.Forms.ToolStripMenuItem visionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writtenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streetTestToolStripMenuItem;
    }
}