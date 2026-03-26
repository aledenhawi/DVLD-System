namespace DVDL_Driving_License_Management_WindowsForm.Screens.PeopleScreens
{
    partial class frmFindPerson
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
            this.ctrPersonDetailsWithFilter1 = new DVDL_Driving_License_Management_WindowsForm.User_Controls.ctrPersonDetailsWithFilter();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrPersonDetailsWithFilter1
            // 
            this.ctrPersonDetailsWithFilter1.AddNewVisablity = true;
            this.ctrPersonDetailsWithFilter1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ctrPersonDetailsWithFilter1.FilterEnable = true;
            this.ctrPersonDetailsWithFilter1.Location = new System.Drawing.Point(12, 109);
            this.ctrPersonDetailsWithFilter1.Name = "ctrPersonDetailsWithFilter1";
            this.ctrPersonDetailsWithFilter1.Size = new System.Drawing.Size(1032, 497);
            this.ctrPersonDetailsWithFilter1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(383, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 68);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find Person";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkCyan;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.button1.Image = global::DVDL_Driving_License_Management_WindowsForm.Properties.Resources.close__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(879, 606);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1048, 677);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrPersonDetailsWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFindPerson";
            this.Text = "frmFindPerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private User_Controls.ctrPersonDetailsWithFilter ctrPersonDetailsWithFilter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}