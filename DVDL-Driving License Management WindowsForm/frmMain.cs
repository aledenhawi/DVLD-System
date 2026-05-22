using DVDL_Driving_License_Management_WindowsForm.Screens;
using DVDL_Driving_License_Management_WindowsForm.Screens.Applications;
using DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Internatinoal_License;
using DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Release_License;
using DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Repleacment_Application;
using DVDL_Driving_License_Management_WindowsForm.Screens.ApplicationsType;
using DVDL_Driving_License_Management_WindowsForm.Screens.Basic;
using DVDL_Driving_License_Management_WindowsForm.Screens.Drivers;
using DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.International_Licenses;
using DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.Local_Licenses;
using DVDL_Driving_License_Management_WindowsForm.Screens.Tests.TestTypes;
using DVDL_Driving_License_Management_WindowsForm.Screens.Users;
using DVDL_Driving_License_Management_WindowsForm.Screens.Users.Controls;
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

namespace DVDL_Driving_License_Management_WindowsForm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        internal bool IsSignOut = false;


        private void sdPeople_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmManagePeople)
                {
                    form.Activate();
                    return;
                }
            }

            frmManagePeople frmPeople = new frmManagePeople();
            frmPeople.MdiParent = this;
            frmPeople.Show();
        }

        private void tsSingOut_Click(object sender, EventArgs e)
        {
            IsSignOut = true;
            clsGlobal.CurrentUser = null;
            this.Close();
        }

        private void tsCurrentUserInfo_Click(object sender, EventArgs e)
        {
            frmUserDetails UserDetailsForm = new frmUserDetails(clsGlobal.CurrentUser.ID);
            UserDetailsForm.MdiParent = this;
            UserDetailsForm.Show();
        }

        private void tsChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword  = new frmChangePassword(clsGlobal.CurrentUser.ID);
            changePassword.MdiParent = this;
            changePassword.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmUsersManagment UsersManagment = new frmUsersManagment();
            UsersManagment.MdiParent = this;
            UsersManagment.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications localDrivingLicenseApplications = new frmLocalDrivingLicenseApplications();
            localDrivingLicenseApplications.MdiParent = this;
            localDrivingLicenseApplications.Show();
        }

        private void tsLocalDrivingLicense_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication addEditLocalDrivingLicenseApplication = new frmAddEditLocalDrivingLicenseApplication();
            addEditLocalDrivingLicenseApplication.Show();
        }

        private void tsManageApplicationTypes_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes manageApplicationTypes = new frmManageApplicationTypes();
            manageApplicationTypes.MdiParent = this;
            manageApplicationTypes.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmTestTypesManagment frmTestTypesManagment = new frmTestTypesManagment();
            frmTestTypesManagment.MdiParent = this;
            frmTestTypesManagment.Show();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications localDrivingLicenseApplications = new frmLocalDrivingLicenseApplications();
            localDrivingLicenseApplications.MdiParent = this;
            localDrivingLicenseApplications.Show();
        }

        private void sdDriver_Click(object sender, EventArgs e)
        {
            frmManageDrivers Drivers = new frmManageDrivers();
            Drivers.MdiParent = this;
            Drivers.Show();
        }

        private void tsIssueNewInternationalLicense_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense newInternationalLicense = new frmAddNewInternationalLicense();
            newInternationalLicense.ShowDialog();
            
        }

        private void tsInternationalDrivingLicenseList_Click(object sender, EventArgs e)
        {
            frmListInt_LicenseApplicatrions internationalLicenseInfo = new frmListInt_LicenseApplicatrions();
            internationalLicenseInfo.MdiParent = this;
            internationalLicenseInfo.Show();
        }

        private void tsRenewDrivingLicense_Click(object sender, EventArgs e)
        {
            frmRenewDrivingLicense renewDrivingLicense = new frmRenewDrivingLicense();
            renewDrivingLicense.ShowDialog();
        }

        private void tsReplacementforlostordamaged_Click(object sender, EventArgs e)
        {
            frmReplacmentApplication replacmentApplication = new frmReplacmentApplication();
            replacmentApplication.ShowDialog();
        }

        private void tsDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
        }

        private void tsReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void tsManageDetainLicense_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
