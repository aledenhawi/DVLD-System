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

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Release_License
{
    public partial class frmReleaseDetainedLicense : Form
    {
        private int _LicenseID = -1;
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }
        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            btnRelease.Enabled = false;
            llblShowlicenseHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;

            if(_LicenseID != -1)
            {
                ctrLicenseInfoWithFilter1.LoadLicenseInfo(_LicenseID);
                ctrLicenseInfoWithFilter1.FilterEnable = false;
            }
        }

        private void ctrLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int LicenseID = obj;

            btnRelease.Enabled = false;
            llblShowLicenseInfo.Enabled = false;
            llblShowlicenseHistory.Enabled = false;

            if (LicenseID == -1)
                return;

            _LicenseID = LicenseID;
            llblShowLicenseInfo.Enabled = true;
            llblShowlicenseHistory.Enabled = true;


            lblLicenseID.Text = ctrLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
            

            if (!ctrLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("This license is not detained !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ctrLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("This license is deactivated , you can't detained an inactive license", "Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblCreatedBy.Text = ctrLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.CreatedByUserInfo.Username;
            lblFineFees.Text = ctrLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();
            lblDetainDate.Text = ctrLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.DetainDate.ToString("dd/MM/yyyy");
            lblDetainID.Text = ctrLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.DetainID.ToString();

            btnRelease.Enabled = true;
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(ctrLicenseInfoWithFilter1.LicenseID);
            frm.ShowDialog();
        }

        private void llblShowlicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDrivingLicensesHistory frm = new frmShowPersonDrivingLicensesHistory(ctrLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this license?", "Confirm releasing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;

            if(!ctrLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseLicense(clsGlobal.CurrentUser.ID,ref ApplicationID)) 
            {
                MessageBox.Show("Error : error ocured while releasing license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("License released seccessfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            ctrLicenseInfoWithFilter1.FilterEnable = false;
            lblApplicationID.Text = ApplicationID.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
