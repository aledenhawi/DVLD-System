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
            this.cancleApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.cancleApplicationToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(250, 90);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.BackColor = System.Drawing.Color.DarkSlateGray;
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.PersonDetails_32;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(246, 6);
            // 
            // cancleApplicationToolStripMenuItem
            // 
            this.cancleApplicationToolStripMenuItem.BackColor = System.Drawing.Color.DarkSlateGray;
            this.cancleApplicationToolStripMenuItem.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Delete_32;
            this.cancleApplicationToolStripMenuItem.Name = "cancleApplicationToolStripMenuItem";
            this.cancleApplicationToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.cancleApplicationToolStripMenuItem.Text = "Cancle Application";
            this.cancleApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancleApplicationToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem cancleApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}