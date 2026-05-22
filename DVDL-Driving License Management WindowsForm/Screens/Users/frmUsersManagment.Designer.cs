namespace DVDL_Driving_License_Management_WindowsForm.Screens
{
    partial class frmUsersManagment
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
            this.dgvUsersList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.stEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUsersManagment = new System.Windows.Forms.Label();
            this.cmbUsersFiltring = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbFiltringUsers = new System.Windows.Forms.TextBox();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalUsers = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsersList
            // 
            this.dgvUsersList.AllowUserToAddRows = false;
            this.dgvUsersList.BackgroundColor = System.Drawing.Color.SlateGray;
            this.dgvUsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvUsersList.GridColor = System.Drawing.Color.DarkSlateGray;
            this.dgvUsersList.Location = new System.Drawing.Point(44, 353);
            this.dgvUsersList.MultiSelect = false;
            this.dgvUsersList.Name = "dgvUsersList";
            this.dgvUsersList.RowHeadersWidth = 51;
            this.dgvUsersList.RowTemplate.Height = 26;
            this.dgvUsersList.Size = new System.Drawing.Size(883, 407);
            this.dgvUsersList.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsShowDetails,
            this.toolStripSeparator1,
            this.tsAdd,
            this.stEdit,
            this.tsDelete,
            this.tsChangePassword,
            this.toolStripSeparator2,
            this.tsSendEmail,
            this.tsPhoneCall});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(198, 198);
            // 
            // tsShowDetails
            // 
            this.tsShowDetails.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.CurrentUserInfo;
            this.tsShowDetails.Name = "tsShowDetails";
            this.tsShowDetails.Size = new System.Drawing.Size(197, 26);
            this.tsShowDetails.Text = "Show Details";
            this.tsShowDetails.Click += new System.EventHandler(this.tsShowDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // tsAdd
            // 
            this.tsAdd.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.add_user;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(197, 26);
            this.tsAdd.Text = "Add New User";
            this.tsAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // stEdit
            // 
            this.stEdit.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.transaction;
            this.stEdit.Name = "stEdit";
            this.stEdit.Size = new System.Drawing.Size(197, 26);
            this.stEdit.Text = "Edit";
            this.stEdit.Click += new System.EventHandler(this.stEdit_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.remove_user;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(197, 26);
            this.tsDelete.Text = "Delete";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // tsChangePassword
            // 
            this.tsChangePassword.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Changepassword;
            this.tsChangePassword.Name = "tsChangePassword";
            this.tsChangePassword.Size = new System.Drawing.Size(197, 26);
            this.tsChangePassword.Text = "Change Password";
            this.tsChangePassword.Click += new System.EventHandler(this.tsChangePassword_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(194, 6);
            // 
            // tsSendEmail
            // 
            this.tsSendEmail.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.email1;
            this.tsSendEmail.Name = "tsSendEmail";
            this.tsSendEmail.Size = new System.Drawing.Size(197, 26);
            this.tsSendEmail.Text = "Send Email";
            this.tsSendEmail.Click += new System.EventHandler(this.tsSendEmail_Click);
            // 
            // tsPhoneCall
            // 
            this.tsPhoneCall.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.phone_call;
            this.tsPhoneCall.Name = "tsPhoneCall";
            this.tsPhoneCall.Size = new System.Drawing.Size(197, 26);
            this.tsPhoneCall.Text = "Phone Call";
            this.tsPhoneCall.Click += new System.EventHandler(this.tsPhoneCall_Click);
            // 
            // lblUsersManagment
            // 
            this.lblUsersManagment.AutoSize = true;
            this.lblUsersManagment.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersManagment.ForeColor = System.Drawing.Color.SlateGray;
            this.lblUsersManagment.Location = new System.Drawing.Point(345, 259);
            this.lblUsersManagment.Name = "lblUsersManagment";
            this.lblUsersManagment.Size = new System.Drawing.Size(275, 37);
            this.lblUsersManagment.TabIndex = 2;
            this.lblUsersManagment.Text = "Users Managment";
            // 
            // cmbUsersFiltring
            // 
            this.cmbUsersFiltring.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsersFiltring.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbUsersFiltring.FormattingEnabled = true;
            this.cmbUsersFiltring.Items.AddRange(new object[] {
            "None",
            "User ID",
            "Person ID",
            "Full Name",
            "Username",
            "Is Active"});
            this.cmbUsersFiltring.Location = new System.Drawing.Point(150, 314);
            this.cmbUsersFiltring.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cmbUsersFiltring.Name = "cmbUsersFiltring";
            this.cmbUsersFiltring.Size = new System.Drawing.Size(182, 29);
            this.cmbUsersFiltring.TabIndex = 7;
            this.cmbUsersFiltring.SelectedIndexChanged += new System.EventHandler(this.cmbUsersFiltring_SelectedIndexChanged);
            this.cmbUsersFiltring.SelectedValueChanged += new System.EventHandler(this.cmbUsersFiltring_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(48, 319);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filter By :";
            // 
            // txbFiltringUsers
            // 
            this.txbFiltringUsers.Location = new System.Drawing.Point(356, 323);
            this.txbFiltringUsers.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txbFiltringUsers.Name = "txbFiltringUsers";
            this.txbFiltringUsers.Size = new System.Drawing.Size(234, 24);
            this.txbFiltringUsers.TabIndex = 8;
            this.txbFiltringUsers.Visible = false;
            this.txbFiltringUsers.TextChanged += new System.EventHandler(this.txbFiltringUsers_TextChanged);
            this.txbFiltringUsers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbFiltringUsers_KeyPress);
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cmbIsActive.Location = new System.Drawing.Point(356, 316);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(95, 32);
            this.cmbIsActive.TabIndex = 9;
            this.cmbIsActive.Visible = false;
            this.cmbIsActive.SelectedIndexChanged += new System.EventHandler(this.cmbIsActive_SelectedIndexChanged);
            this.cmbIsActive.VisibleChanged += new System.EventHandler(this.cmbIsActive_VisibleChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(40, 775);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Records :";
            // 
            // lblTotalUsers
            // 
            this.lblTotalUsers.AutoSize = true;
            this.lblTotalUsers.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lblTotalUsers.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUsers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalUsers.Location = new System.Drawing.Point(138, 775);
            this.lblTotalUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalUsers.Name = "lblTotalUsers";
            this.lblTotalUsers.Size = new System.Drawing.Size(21, 24);
            this.lblTotalUsers.TabIndex = 11;
            this.lblTotalUsers.Text = "0";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkCyan;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(724, 765);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(203, 49);
            this.btnClose.TabIndex = 78;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.BackgroundImage = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.add_user;
            this.btnAddNewUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewUser.FlatAppearance.BorderSize = 0;
            this.btnAddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewUser.Location = new System.Drawing.Point(849, 281);
            this.btnAddNewUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(78, 62);
            this.btnAddNewUser.TabIndex = 12;
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.Usermanagement;
            this.pictureBox1.Location = new System.Drawing.Point(338, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(295, 245);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmUsersManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(967, 822);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.lblTotalUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbIsActive);
            this.Controls.Add(this.txbFiltringUsers);
            this.Controls.Add(this.cmbUsersFiltring);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUsersManagment);
            this.Controls.Add(this.dgvUsersList);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUsersManagment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users Managment";
            this.Load += new System.EventHandler(this.frmUsersManagment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvUsersList;
        private System.Windows.Forms.Label lblUsersManagment;
        private System.Windows.Forms.ComboBox cmbUsersFiltring;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbFiltringUsers;
        private System.Windows.Forms.ComboBox cmbIsActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsAdd;
        private System.Windows.Forms.ToolStripMenuItem stEdit;
        private System.Windows.Forms.ToolStripMenuItem tsDelete;
        private System.Windows.Forms.ToolStripMenuItem tsChangePassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsSendEmail;
        private System.Windows.Forms.ToolStripMenuItem tsPhoneCall;
        private System.Windows.Forms.Button btnClose;
    }
}