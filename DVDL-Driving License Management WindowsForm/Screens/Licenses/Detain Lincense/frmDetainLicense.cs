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
    public partial class frmDetainLicense : Form
    {

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void txbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            btnDetain.Enabled = false;
            llblShowLicenseInfo.Enabled = false;
            llblShowlicenseHistory.Enabled = false;
            lblDetainDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = clsGlobal.CurrentUser.Username;
            
        }

        private void ctrLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int LicenseID = obj;

            btnDetain.Enabled = false;
            llblShowLicenseInfo.Enabled = false;
            llblShowlicenseHistory.Enabled = false;

            if (LicenseID == -1)
                return;

            llblShowLicenseInfo.Enabled = true;
            llblShowlicenseHistory.Enabled = true;
            lblLicenseID.Text = ctrLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
            
            if (ctrLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained) 
            {
                MessageBox.Show("This license is already detained !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ctrLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive) 
            {
                MessageBox.Show("This license is deactivated , you can't detained an inactive license", "Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txbFineFees.Focus();
            btnDetain.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm detaining", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (string.IsNullOrEmpty(txbFineFees.Text) || (Convert.ToSingle(txbFineFees.Text) < 0))
            {
                MessageBox.Show("Fine Fees field can not be empty or negative number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int DetainID = ctrLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(clsGlobal.CurrentUser.ID, Convert.ToSingle(txbFineFees.Text));

            if (DetainID == -1)
            {
                MessageBox.Show("Error : error ocured while detaining license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("License detained seccessfully." , "Success",MessageBoxButtons.OK,MessageBoxIcon.Information);

            lblDetainID.Text = DetainID.ToString();
            btnDetain.Enabled = false;
            ctrLicenseInfoWithFilter1.FilterEnable = false;

        }

        private void txbFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txbFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(this.txbFineFees, "This faild is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(this.txbFineFees, null);
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
