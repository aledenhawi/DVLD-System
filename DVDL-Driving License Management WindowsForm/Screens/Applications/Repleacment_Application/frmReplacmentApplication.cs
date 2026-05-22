using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Screens.Licenses;
using DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.Local_Licenses;
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

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Repleacment_Application
{
    public partial class frmReplacmentApplication : Form
    {
        private clsApplication.enApplicationType _ApplicationType = clsApplication.enApplicationType.ReplacementforDamagedDrivingLicense;
        
        private int _NewLicenseID = -1;

        public frmReplacmentApplication()
        {
            InitializeComponent();
        }

        private void rbForDamaged_CheckedChanged(object sender, EventArgs e)
        {
            _ApplicationType = (rbForDamaged.Checked) ? clsApplication.enApplicationType.ReplacementforDamagedDrivingLicense
                : clsApplication.enApplicationType.ReplacementforLostDrivingLicense;
            lblTitle.Text = (rbForDamaged.Checked) ? "Replacement for Damaged License" : "Replacement for Lost License";
            this.Text = lblTitle.Text;
            lblApplicationFees.Text = clsApplicationType.Find((int)_ApplicationType).Fees.ToString();
        }

        private void btnIssueRepleacment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to repleace this license?", "Confirm repleacing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicense = ctrLicenseInfoWithFilter1.SelectedLicenseInfo.RepleaceLicense(clsGlobal.CurrentUser.ID,(int)_ApplicationType);

            if (NewLicense != null)
            {
                MessageBox.Show("License repleaced successfully.", "Repleaced Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Show the new license info in form
                lblRepleacedLicenseID.Text = NewLicense.LicenseID.ToString();
                lblRepleacmentApplicationID.Text = NewLicense.ApplicationID.ToString();
                _NewLicenseID = NewLicense.LicenseID;

                gbRepleacmentFor.Enabled = false;
                btnIssueRepleacment.Enabled = false;
                ctrLicenseInfoWithFilter1.FilterEnable = false;
                llblShowNewLicenseInfo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error : error ocured while repleacing license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReplacmentApplication_Load(object sender, EventArgs e)
        {
            ctrLicenseInfoWithFilter1.TxbLicenseIDFocus();
            llblShowlicenseHistory.Enabled = false;
            llblShowNewLicenseInfo.Enabled = false;
            btnIssueRepleacment.Enabled = false;

            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblApplicationFees.Text = clsApplicationType.Find((int)_ApplicationType).Fees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.Username;
        }

        private void llblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDrivingLicensesHistory frm = new frmShowPersonDrivingLicensesHistory(ctrLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llblShowlicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_NewLicenseID == -1)
                return;

            frmLicenseInfo frm = new frmLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void ctrLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int LicenseID = obj;

            llblShowlicenseHistory.Enabled = false;
            llblShowNewLicenseInfo.Enabled = false;
            btnIssueRepleacment.Enabled = false;

            if (LicenseID == -1)
                return;

            // add the license info to the form after checking if the license exists
            llblShowlicenseHistory.Enabled = true;
            lblOldLicenseID.Text = LicenseID.ToString();

            if (!ctrLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected license is not active. You can only repleace active licenses.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIssueRepleacment.Enabled = true;
        }
    }
}
