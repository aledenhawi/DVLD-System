using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.Local_Licenses.Controls
{
    public partial class ctrLicenseInfo : UserControl
    {
        private int _LicenseID;
        private clsLicense _License;

        public int LicenseID { get => _LicenseID; }

        public clsLicense SelectedLicenseInfo { get => _License; }
        public ctrLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage() 
        {

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;
            if (!String.IsNullOrEmpty(ImagePath))
            {
                if (File.Exists(ImagePath)) 
                {
                    pbPersonPic.ImageLocation = ImagePath;
                    return;
                }
                else
                    MessageBox.Show("Person image not found, showing default image", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                pbPersonPic.Image = (_License.DriverInfo.PersonInfo.Gender == clsPerson.GenderType.Male) ? Resources.Male : Resources.Female;
        }

        public void LoadLicenseData(int LicenseID) 
        {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(LicenseID);

            if (_License == null)
            {
                MessageBox.Show("License not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            lblClass.Text = _License.LicenseClassInfo.Name;
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblGender.Text = _License.DriverInfo.PersonInfo.Gender.ToString();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblName.Text = _License.DriverInfo.PersonInfo.GetFullName();
            lblNotes.Text = (string.IsNullOrEmpty(_License.Notes)) ? "Nothing" : _License.Notes;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;

            // Check it later Detained

            lblIsDetained.Text = "false";
            lblIssueReason.Text = _License.IssueReasonText;
            lblLicenseID.Text = _License.LicenseID.ToString();

            _LoadPersonImage();
        }
    }
}
