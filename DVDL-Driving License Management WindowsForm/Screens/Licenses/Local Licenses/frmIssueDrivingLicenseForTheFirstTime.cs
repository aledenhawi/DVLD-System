using DVDL_BusinessLayer;
using DVLD_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL_Driving_License_Management_WindowsForm.Screens
{
    public partial class frmIssueDrivingLicenseForTheFirstTime : Form
    {
        int _LocalDrivingLicenseApplicationID;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmIssueDrivingLicenseForTheFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmIssueDrivingLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            txbNotes.Focus();

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Failed to Load Local Driving License Application Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if(_LocalDrivingLicenseApplication.PassedAllTests() == false)
            {
                MessageBox.Show("Cannot Issue License, Applicant has not passed all required tests", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
             if(_LocalDrivingLicenseApplication.IsLicenseIssued())
            {
                MessageBox.Show("License is already issued for this application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrLocalDrivingLicenseApplicationFullDetails1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int licenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirstTime(txbNotes.Text.Trim(),clsGlobal.CurrentUser.ID);
            if (licenseID != -1)
            { 
                MessageBox.Show($"License Issued Successfully with License ID = {licenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else 
                MessageBox.Show("Failed to Issue License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
