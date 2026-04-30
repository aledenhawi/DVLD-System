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

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Applications
{
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {
        private enum enMode { Add = 1, Update = 2 }

        enMode _Mode;

        bool _IsPersonFound = false;

        int _LDLApplicationID = -1;

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;

        public frmAddEditLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }

        public frmAddEditLocalDrivingLicenseApplication(int ID)
        {
            InitializeComponent();
            _LDLApplicationID = ID;
            _Mode = enMode.Update;
        }

        private void _FullLicenseClassInCombobox()
        {
            cmbLicenseClasses.DataSource = clsLicenseClasses.GetAllLicenseClasses();
            cmbLicenseClasses.DisplayMember = "ClassName";
            cmbLicenseClasses.ValueMember = "LicenseClassID";
        }

        private void _ResetDefaultValues()
        {
            _FullLicenseClassInCombobox();

            if (_Mode == enMode.Add)
            {
                lblTitle.Text = "Add New Local Driving License Application";
                this.Text = "Add New Local Driving License Application";

                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                _IsPersonFound = false;
                ctrPersonDetailsWithFilter1.FilterEnable = true;
                tbApplicationInfo.Enabled = false;
                btnReset.Visible = true;
                ctrPersonDetailsWithFilter1.FilterFocus();
                
                cmbLicenseClasses.SelectedIndex = 2;
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewLocalDrivingLicense).Fees.ToString();
                lblCreatedByUser.Text = clsGlobal.CurrentUser.Username;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                ctrPersonDetailsWithFilter1.FilterEnable = false;
                tbApplicationInfo.Enabled = true;
                btnReset.Visible = false;
                _IsPersonFound = true;
            }
            
            


        }

        private void _LoadData() 
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LDLApplicationID);
            
            if (_LocalDrivingLicenseApplication == null)
            {
                 MessageBox.Show("The selected Local Driving License Application was not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 this.Close();
                 return;
            }

            ctrPersonDetailsWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblCreatedByUser.Text = _LocalDrivingLicenseApplication.CreatedByUserInfo.Username;
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.ApplicationTypeInfo.Fees.ToString();
            lblApplicationID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            cmbLicenseClasses.SelectedIndex = cmbLicenseClasses.FindString(_LocalDrivingLicenseApplication.LicenseClassInfo.Name);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                tabControl1.SelectedTab = tbApplicationInfo;
                tbApplicationInfo.Enabled = true;
                return;
            }


            if (_IsPersonFound)
            {
                tbApplicationInfo.Enabled = true;
                tabControl1.SelectedTab = tbApplicationInfo;
                ctrPersonDetailsWithFilter1.FilterEnable = false;
            }
            else
            {
                MessageBox.Show("Please select a person to proceed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrPersonDetailsWithFilter1.FilterFocus();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            ctrPersonDetailsWithFilter1.ResetPersonInfo();
          
        }

        private void frmAddEditLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void ctrPersonDetailsWithFilter1_OnPersonSelected(int obj)
        {
            _IsPersonFound = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            short Age = clsPerson.Find(ctrPersonDetailsWithFilter1.PersonID).CalculateAge();



            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(ctrPersonDetailsWithFilter1.PersonID, clsApplication.enApplicationType.NewLocalDrivingLicense, Convert.ToInt32(cmbLicenseClasses.SelectedValue));

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("The selected person already has an active application for the same license class.", "Duplicate Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close(); 
                return;
            }
            // Check (Add Checking if the person has a Driving license already)


            _LocalDrivingLicenseApplication.LicenseClassID = Convert.ToInt32(cmbLicenseClasses.SelectedValue);
            if (_Mode == enMode.Add)
            {
                _LocalDrivingLicenseApplication.ApplicantPersonID = ctrPersonDetailsWithFilter1.PersonID;
                _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewLocalDrivingLicense;
                _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
                _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
                _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
                _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
                _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.ID;
            }

            _LocalDrivingLicenseApplication.LicenseClassInfo = clsLicenseClasses.Find(_LocalDrivingLicenseApplication.LicenseClassID);

            if (Age < _LocalDrivingLicenseApplication.LicenseClassInfo.MinAllowedAge)
            {
                MessageBox.Show($"The selected person does not meet the minimum age requirement for the selected license class. Minimum age is {_LocalDrivingLicenseApplication.LicenseClassInfo.MinAllowedAge} years.", "Age Requirement Not Met", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_LocalDrivingLicenseApplication.Save())
            {
                lblApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                // change mode to update after saving the new user
                btnReset.Visible = false;
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                MessageBox.Show("Application has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR : Application hasn't been saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frmAddEditLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrPersonDetailsWithFilter1.FilterFocus();
        }
    }
}
