namespace DVDL_Driving_License_Management_WindowsForm.Screens.TestAppointments
{
    partial class frmSchedualTest
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
            this.ctrScheduleTest1 = new DVDL_Driving_License_Management_WindowsForm.Screens.TestAppointments.UserControls.ctrScheduleTest();
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
            this.btnClose.Location = new System.Drawing.Point(251, 723);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(176, 47);
            this.btnClose.TabIndex = 104;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrScheduleTest1
            // 
            this.ctrScheduleTest1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ctrScheduleTest1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ctrScheduleTest1.Location = new System.Drawing.Point(14, 13);
            this.ctrScheduleTest1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ctrScheduleTest1.Name = "ctrScheduleTest1";
            this.ctrScheduleTest1.Size = new System.Drawing.Size(660, 703);
            this.ctrScheduleTest1.TabIndex = 105;
            this.ctrScheduleTest1.TestTypeID = DVDL_BusinessLayer.clsTestType.enTestType.Vision;
            // 
            // frmSchedualTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(680, 781);
            this.Controls.Add(this.ctrScheduleTest1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmSchedualTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedual Test";
            this.Load += new System.EventHandler(this.frmSchedualTest_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private UserControls.ctrScheduleTest ctrScheduleTest1;
    }
}