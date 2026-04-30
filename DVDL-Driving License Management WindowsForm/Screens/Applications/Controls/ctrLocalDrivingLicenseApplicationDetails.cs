using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Screens.PeopleScreens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Controls
{
    public partial class ctrLocalDrivingLicenseApplicationFullDetails : UserControl
    {


        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;

        private int _LocalDrivinglicenseAppID = -1;

        private int _LicenseID;

        public int LocalDrivinglicenseAppID { get { return _LocalDrivinglicenseAppID; } }


        public ctrLocalDrivingLicenseApplicationFullDetails()
        {
            InitializeComponent();
        }

        private void _ResetLocalDrivingLicenseApplicationInfo() 
        {
            _LocalDrivingLicenseApplicationInfo = null;
            _LocalDrivinglicenseAppID = -1;
            lblDLApplicationID.Text = "[???]";
            lblPassedTest.Text = "[???]";
            lblAppliedForLicense.Text = "[???]";
            lblID.Text = "[???]";
            lblApplicant.Text = "[???]";
            lblCreatedBy.Text = "[???]";
            lblDate.Text = "[???]";
            lblStatusDate.Text = "[???]";
            lblType.Text = "[???]";
            lblStatus.Text = "[???]";
            lblFees.Text = "[???]";
        }

        private void LoadApplicationInfoByApplicatoinID(int ApplicationID)
        {
            LoadApplicationInfoByLocalDrivingAppID(clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID).LocalDrivingLicenseApplicationID);
        }

        private void _FillLocalDrivingLicenseApplicationInfo() 
        {
            // Check it add here function to get LicenseID 
            linkLabel1.Enabled = ( _LicenseID !=-1);

             lblDLApplicationID.Text = _LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID.ToString();
             lblPassedTest.Text = "3/" + _LocalDrivingLicenseApplicationInfo.PassedTest.ToString();
             lblAppliedForLicense.Text = _LocalDrivingLicenseApplicationInfo.LicenseClassInfo.Name;
             lblID.Text = _LocalDrivingLicenseApplicationInfo.ApplicationID.ToString();
             lblApplicant.Text = _LocalDrivingLicenseApplicationInfo.PersonInfo.GetFullName();
             lblCreatedBy.Text = _LocalDrivingLicenseApplicationInfo.CreatedByUserInfo.Username.ToString();
             lblDate.Text = _LocalDrivingLicenseApplicationInfo.ApplicationDate.ToShortDateString();
             lblStatusDate.Text = _LocalDrivingLicenseApplicationInfo.LastStatusDate.ToShortDateString();
             lblType.Text = _LocalDrivingLicenseApplicationInfo.ApplicationTypeInfo.Title;
             lblStatus.Text = _LocalDrivingLicenseApplicationInfo.ApplicationStatus.ToString();
             lblFees.Text = _LocalDrivingLicenseApplicationInfo.PaidFees.ToString();
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivinglicenseAppID) 
        {


            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.Find(LocalDrivinglicenseAppID);

            if(_LocalDrivingLicenseApplicationInfo != null) 
            {
                _FillLocalDrivingLicenseApplicationInfo();
            }
            else 
            {
                _ResetLocalDrivingLicenseApplicationInfo();

            MessageBox.Show("Local Driving License Application With ID = " + LocalDrivinglicenseAppID + " is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void llblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_LocalDrivingLicenseApplicationInfo.ApplicantPersonID);
            frm.ShowDialog();
        }
    }
}
