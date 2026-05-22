namespace DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Release_License
{
    partial class frmManageDetainedLicenses
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowLicenseDetials = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsReleaseDeatinedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.lblTotalDetainedLicenses = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIsReleased = new System.Windows.Forms.ComboBox();
            this.txbFiltringDetainedLicenses = new System.Windows.Forms.TextBox();
            this.cmbDetainedLicensesFiltring = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsShowPersonDetails,
            this.tsShowLicenseDetials,
            this.tsShowPersonLicenseHistory,
            this.toolStripSeparator1,
            this.tsReleaseDeatinedLicense});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(281, 162);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsShowPersonDetails
            // 
            this.tsShowPersonDetails.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.PersonDetails_32;
            this.tsShowPersonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsShowPersonDetails.Name = "tsShowPersonDetails";
            this.tsShowPersonDetails.Size = new System.Drawing.Size(280, 38);
            this.tsShowPersonDetails.Text = "Show Person Details";
            this.tsShowPersonDetails.Click += new System.EventHandler(this.tsShowPersonDetails_Click);
            // 
            // tsShowLicenseDetials
            // 
            this.tsShowLicenseDetials.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.License_View_32;
            this.tsShowLicenseDetials.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsShowLicenseDetials.Name = "tsShowLicenseDetials";
            this.tsShowLicenseDetials.Size = new System.Drawing.Size(280, 38);
            this.tsShowLicenseDetials.Text = "Show License Details";
            this.tsShowLicenseDetials.Click += new System.EventHandler(this.tsShowLicenseDetials_Click);
            // 
            // tsShowPersonLicenseHistory
            // 
            this.tsShowPersonLicenseHistory.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.PersonLicenseHistory_32;
            this.tsShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsShowPersonLicenseHistory.Name = "tsShowPersonLicenseHistory";
            this.tsShowPersonLicenseHistory.Size = new System.Drawing.Size(280, 38);
            this.tsShowPersonLicenseHistory.Text = "Show Person Licenes History";
            this.tsShowPersonLicenseHistory.Click += new System.EventHandler(this.tsShowPersonLicenseHistory_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(277, 6);
            // 
            // tsReleaseDeatinedLicense
            // 
            this.tsReleaseDeatinedLicense.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Release_Detained_License_32;
            this.tsReleaseDeatinedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsReleaseDeatinedLicense.Name = "tsReleaseDeatinedLicense";
            this.tsReleaseDeatinedLicense.Size = new System.Drawing.Size(280, 38);
            this.tsReleaseDeatinedLicense.Text = "Release Detaied License";
            this.tsReleaseDeatinedLicense.Click += new System.EventHandler(this.tsReleaseDeatinedLicense_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTitle.Location = new System.Drawing.Point(428, 259);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(486, 57);
            this.lblTitle.TabIndex = 68;
            this.lblTitle.Text = "List Detained License";
            // 
            // dgvDetainedLicenses
            // 
            this.dgvDetainedLicenses.AllowUserToAddRows = false;
            this.dgvDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvDetainedLicenses.AllowUserToResizeColumns = false;
            this.dgvDetainedLicenses.AllowUserToResizeRows = false;
            this.dgvDetainedLicenses.BackgroundColor = System.Drawing.Color.SlateGray;
            this.dgvDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainedLicenses.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDetainedLicenses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDetainedLicenses.Location = new System.Drawing.Point(-1, 381);
            this.dgvDetainedLicenses.Name = "dgvDetainedLicenses";
            this.dgvDetainedLicenses.RowHeadersWidth = 51;
            this.dgvDetainedLicenses.RowTemplate.Height = 26;
            this.dgvDetainedLicenses.Size = new System.Drawing.Size(1353, 316);
            this.dgvDetainedLicenses.TabIndex = 69;
            // 
            // lblTotalDetainedLicenses
            // 
            this.lblTotalDetainedLicenses.AutoSize = true;
            this.lblTotalDetainedLicenses.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lblTotalDetainedLicenses.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDetainedLicenses.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalDetainedLicenses.Location = new System.Drawing.Point(126, 713);
            this.lblTotalDetainedLicenses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDetainedLicenses.Name = "lblTotalDetainedLicenses";
            this.lblTotalDetainedLicenses.Size = new System.Drawing.Size(21, 24);
            this.lblTotalDetainedLicenses.TabIndex = 80;
            this.lblTotalDetainedLicenses.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(28, 713);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 79;
            this.label1.Text = "Records :";
            // 
            // cmbIsReleased
            // 
            this.cmbIsReleased.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsReleased.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbIsReleased.FormattingEnabled = true;
            this.cmbIsReleased.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cmbIsReleased.Location = new System.Drawing.Point(370, 338);
            this.cmbIsReleased.Name = "cmbIsReleased";
            this.cmbIsReleased.Size = new System.Drawing.Size(95, 32);
            this.cmbIsReleased.TabIndex = 85;
            this.cmbIsReleased.Visible = false;
            this.cmbIsReleased.SelectedIndexChanged += new System.EventHandler(this.cmbIsReleased_SelectedIndexChanged);
            this.cmbIsReleased.VisibleChanged += new System.EventHandler(this.cmbIsReleased_VisibleChanged);
            // 
            // txbFiltringDetainedLicenses
            // 
            this.txbFiltringDetainedLicenses.Location = new System.Drawing.Point(370, 346);
            this.txbFiltringDetainedLicenses.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txbFiltringDetainedLicenses.Name = "txbFiltringDetainedLicenses";
            this.txbFiltringDetainedLicenses.Size = new System.Drawing.Size(234, 24);
            this.txbFiltringDetainedLicenses.TabIndex = 84;
            this.txbFiltringDetainedLicenses.Visible = false;
            this.txbFiltringDetainedLicenses.TextChanged += new System.EventHandler(this.txbFiltringUsers_TextChanged);
            this.txbFiltringDetainedLicenses.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbFiltringDetainedLicenses_KeyPress);
            // 
            // cmbDetainedLicensesFiltring
            // 
            this.cmbDetainedLicensesFiltring.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetainedLicensesFiltring.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbDetainedLicensesFiltring.FormattingEnabled = true;
            this.cmbDetainedLicensesFiltring.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No.",
            "Full Name",
            "Release Application ID"});
            this.cmbDetainedLicensesFiltring.Location = new System.Drawing.Point(107, 341);
            this.cmbDetainedLicensesFiltring.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cmbDetainedLicensesFiltring.Name = "cmbDetainedLicensesFiltring";
            this.cmbDetainedLicensesFiltring.Size = new System.Drawing.Size(234, 29);
            this.cmbDetainedLicensesFiltring.TabIndex = 83;
            this.cmbDetainedLicensesFiltring.SelectedIndexChanged += new System.EventHandler(this.cmbDetainedLicensesFiltring_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(5, 346);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 82;
            this.label2.Text = "Filter By :";
            // 
            // btnRelease
            // 
            this.btnRelease.BackgroundImage = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Release_Detained_License_64;
            this.btnRelease.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRelease.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelease.Location = new System.Drawing.Point(1138, 302);
            this.btnRelease.Margin = new System.Windows.Forms.Padding(4);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(87, 72);
            this.btnRelease.TabIndex = 87;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.BackgroundImage = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Detain_642;
            this.btnDetain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetain.Location = new System.Drawing.Point(1254, 302);
            this.btnDetain.Margin = new System.Windows.Forms.Padding(4);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(87, 72);
            this.btnDetain.TabIndex = 86;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkCyan;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1138, 704);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(203, 49);
            this.btnClose.TabIndex = 81;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(538, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 244);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1353, 757);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.cmbIsReleased);
            this.Controls.Add(this.txbFiltringDetainedLicenses);
            this.Controls.Add(this.cmbDetainedLicensesFiltring);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTotalDetainedLicenses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDetainedLicenses);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Detained Licenses";
            this.Load += new System.EventHandler(this.frmManageDetainedLicenses_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem tsShowLicenseDetials;
        private System.Windows.Forms.ToolStripMenuItem tsShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsReleaseDeatinedLicense;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvDetainedLicenses;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalDetainedLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.ComboBox cmbIsReleased;
        private System.Windows.Forms.TextBox txbFiltringDetainedLicenses;
        private System.Windows.Forms.ComboBox cmbDetainedLicensesFiltring;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRelease;
    }
}