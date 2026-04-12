namespace DVDL_Driving_License_Management_WindowsForm
{
    partial class frmManagePeople
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPeopleList = new System.Windows.Forms.DataGridView();
            this.cmsPeopleList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPeopleFiltring = new System.Windows.Forms.ComboBox();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.txbFiltringPeople = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeopleList)).BeginInit();
            this.cmsPeopleList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(638, 254);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 49);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage People";
            // 
            // dgvPeopleList
            // 
            this.dgvPeopleList.AllowUserToAddRows = false;
            this.dgvPeopleList.AllowUserToDeleteRows = false;
            this.dgvPeopleList.BackgroundColor = System.Drawing.Color.SlateGray;
            this.dgvPeopleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeopleList.ContextMenuStrip = this.cmsPeopleList;
            this.dgvPeopleList.GridColor = System.Drawing.Color.SlateGray;
            this.dgvPeopleList.Location = new System.Drawing.Point(-4, 314);
            this.dgvPeopleList.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvPeopleList.Name = "dgvPeopleList";
            this.dgvPeopleList.ReadOnly = true;
            this.dgvPeopleList.RowHeadersWidth = 51;
            this.dgvPeopleList.RowTemplate.Height = 26;
            this.dgvPeopleList.Size = new System.Drawing.Size(1432, 356);
            this.dgvPeopleList.TabIndex = 2;
            // 
            // cmsPeopleList
            // 
            this.cmsPeopleList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPeopleList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsShowDetails,
            this.tsAddNew,
            this.tsEdit,
            this.tsDelete,
            this.tsSendEmail,
            this.tsPhoneCall});
            this.cmsPeopleList.Name = "cmsPeopleList";
            this.cmsPeopleList.Size = new System.Drawing.Size(165, 160);
            // 
            // tsShowDetails
            // 
            this.tsShowDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsShowDetails.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.file;
            this.tsShowDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsShowDetails.Name = "tsShowDetails";
            this.tsShowDetails.Size = new System.Drawing.Size(164, 26);
            this.tsShowDetails.Text = "ShowDetails";
            this.tsShowDetails.Click += new System.EventHandler(this.tsShowDetails_Click);
            // 
            // tsAddNew
            // 
            this.tsAddNew.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.add_newPerson;
            this.tsAddNew.Name = "tsAddNew";
            this.tsAddNew.Size = new System.Drawing.Size(164, 26);
            this.tsAddNew.Text = "AddNew";
            this.tsAddNew.Click += new System.EventHandler(this.tsAddNew_Click);
            // 
            // tsEdit
            // 
            this.tsEdit.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.transaction;
            this.tsEdit.Name = "tsEdit";
            this.tsEdit.Size = new System.Drawing.Size(164, 26);
            this.tsEdit.Text = "Edit";
            this.tsEdit.Click += new System.EventHandler(this.tsEdit_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.remove_user;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(164, 26);
            this.tsDelete.Text = "Delete";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // tsSendEmail
            // 
            this.tsSendEmail.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.email;
            this.tsSendEmail.Name = "tsSendEmail";
            this.tsSendEmail.Size = new System.Drawing.Size(164, 26);
            this.tsSendEmail.Text = "Send Email";
            // 
            // tsPhoneCall
            // 
            this.tsPhoneCall.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.phone_call;
            this.tsPhoneCall.Name = "tsPhoneCall";
            this.tsPhoneCall.Size = new System.Drawing.Size(164, 26);
            this.tsPhoneCall.Text = "Phone Call";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(2, 277);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter By :";
            // 
            // cmbPeopleFiltring
            // 
            this.cmbPeopleFiltring.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeopleFiltring.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbPeopleFiltring.FormattingEnabled = true;
            this.cmbPeopleFiltring.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "National No.",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Country Name",
            "Gender",
            "Gmail",
            "Phone"});
            this.cmbPeopleFiltring.Location = new System.Drawing.Point(104, 277);
            this.cmbPeopleFiltring.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cmbPeopleFiltring.Name = "cmbPeopleFiltring";
            this.cmbPeopleFiltring.Size = new System.Drawing.Size(182, 29);
            this.cmbPeopleFiltring.TabIndex = 4;
            this.cmbPeopleFiltring.SelectedValueChanged += new System.EventHandler(this.cmbPeopleFiltring_SelectedValueChanged);
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRecords.Font = new System.Drawing.Font("Perpetua", 16F);
            this.lblTotalRecords.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalRecords.Location = new System.Drawing.Point(114, 672);
            this.lblTotalRecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(26, 31);
            this.lblTotalRecords.TabIndex = 7;
            this.lblTotalRecords.Text = "0";
            // 
            // txbFiltringPeople
            // 
            this.txbFiltringPeople.Location = new System.Drawing.Point(310, 281);
            this.txbFiltringPeople.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txbFiltringPeople.Name = "txbFiltringPeople";
            this.txbFiltringPeople.Size = new System.Drawing.Size(196, 24);
            this.txbFiltringPeople.TabIndex = 5;
            this.txbFiltringPeople.Visible = false;
            this.txbFiltringPeople.TextChanged += new System.EventHandler(this.txbFiltringPeople_TextChanged);
            this.txbFiltringPeople.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbFiltringPeople_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Perpetua", 16F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(0, 672);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "Records :";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackgroundImage = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.add_newPerson;
            this.btnAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewPerson.FlatAppearance.BorderSize = 0;
            this.btnAddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1334, 246);
            this.btnAddNewPerson.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(78, 62);
            this.btnAddNewPerson.TabIndex = 8;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.PeoplePic;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(618, -3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(337, 255);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1425, 742);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.txbFiltringPeople);
            this.Controls.Add(this.cmbPeopleFiltring);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPeopleList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmManagePeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "People";
            this.Load += new System.EventHandler(this.frmPeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeopleList)).EndInit();
            this.cmsPeopleList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPeopleList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPeopleFiltring;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.ContextMenuStrip cmsPeopleList;
        private System.Windows.Forms.ToolStripMenuItem tsShowDetails;
        private System.Windows.Forms.ToolStripMenuItem tsAddNew;
        private System.Windows.Forms.ToolStripMenuItem tsEdit;
        private System.Windows.Forms.ToolStripMenuItem tsDelete;
        private System.Windows.Forms.ToolStripMenuItem tsSendEmail;
        private System.Windows.Forms.ToolStripMenuItem tsPhoneCall;
        private System.Windows.Forms.TextBox txbFiltringPeople;
        private System.Windows.Forms.Label label3;
    }
}