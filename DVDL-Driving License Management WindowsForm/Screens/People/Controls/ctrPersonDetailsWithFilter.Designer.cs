namespace DVDL_Driving_License_Management_WindowsForm.User_Controls
{
    partial class ctrPersonDetailsWithFilter
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.btnAddPeson = new System.Windows.Forms.Button();
            this.txbFilterText = new System.Windows.Forms.TextBox();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrPersonDetails2 = new DVDL_Driving_License_Management_WindowsForm.User_Controls.ctrPersonDetails();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindPerson);
            this.groupBox1.Controls.Add(this.btnAddPeson);
            this.groupBox1.Controls.Add(this.txbFilterText);
            this.groupBox1.Controls.Add(this.cmbFilterType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox1.Location = new System.Drawing.Point(0, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1023, 83);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.BackgroundImage = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.search_Pesron;
            this.btnFindPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPerson.Location = new System.Drawing.Point(781, 18);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(80, 59);
            this.btnFindPerson.TabIndex = 4;
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // btnAddPeson
            // 
            this.btnAddPeson.BackgroundImage = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.add_newPerson;
            this.btnAddPeson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPeson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPeson.Location = new System.Drawing.Point(905, 18);
            this.btnAddPeson.Name = "btnAddPeson";
            this.btnAddPeson.Size = new System.Drawing.Size(80, 59);
            this.btnAddPeson.TabIndex = 3;
            this.btnAddPeson.UseVisualStyleBackColor = true;
            this.btnAddPeson.Click += new System.EventHandler(this.btnAddPeson_Click);
            // 
            // txbFilterText
            // 
            this.txbFilterText.Location = new System.Drawing.Point(345, 35);
            this.txbFilterText.Name = "txbFilterText";
            this.txbFilterText.Size = new System.Drawing.Size(284, 32);
            this.txbFilterText.TabIndex = 2;
            this.txbFilterText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbFilterText_KeyPress);
            this.txbFilterText.Validating += new System.ComponentModel.CancelEventHandler(this.txbFilterText_Validating);
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Items.AddRange(new object[] {
            "PersonID",
            "NationalNumber"});
            this.cmbFilterType.Location = new System.Drawing.Point(109, 35);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(216, 32);
            this.cmbFilterType.TabIndex = 1;
            this.cmbFilterType.SelectedIndexChanged += new System.EventHandler(this.cmbFilterType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find By :";
            // 
            // ctrPersonDetails2
            // 
            this.ctrPersonDetails2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ctrPersonDetails2.Location = new System.Drawing.Point(0, 108);
            this.ctrPersonDetails2.Name = "ctrPersonDetails2";
            this.ctrPersonDetails2.Size = new System.Drawing.Size(1031, 377);
            this.ctrPersonDetails2.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrPersonDetailsWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrPersonDetails2);
            this.Name = "ctrPersonDetailsWithFilter";
            this.Size = new System.Drawing.Size(1032, 497);
            this.Load += new System.EventHandler(this.ctrPersonDetailsWithFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrPersonDetails ctrPersonDetails2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbFilterText;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPeson;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
