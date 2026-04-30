using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Properties;
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
using static DVDL_BusinessLayer.clsTestType;

namespace DVDL_Driving_License_Management_WindowsForm.Screens.TestAppointments.UserControls
{
    public partial class ctrScheduleTest : UserControl
    {

        enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 }
        private enCreationMode _CreationMode;

        clsTestType.enTestType _TestTypeID;
        public clsTestType.enTestType TestTypeID 
        {
            get 
            {
            return _TestTypeID;
            }

            set 
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.Vision:
                        gbScheduleTest.Text = "Vision Test";
                        pbTestType.Image = Resources.Vision_512;
                        break;
                    case clsTestType.enTestType.Written:
                        gbScheduleTest.Text = "Written Test";
                        pbTestType.Image = Resources.Written_Test_512;
                        break;
                    case clsTestType.enTestType.Street:
                        gbScheduleTest.Text = "Street Test";
                        pbTestType.Image = Resources.driving_test_512;
                        break;
                    default:
                        break;
                }
            }
        }

        private int _LocalDrivingLicenseApplicationID = 0;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _TestAppointmentID = 0;
        private clsTestAppointment _TestAppointment;

        public void LoadData(int LocalDrivingLicenseApplicationID,int AppointmentID = -1) 
        {
            
            _Mode = (AppointmentID == -1) ? enMode.AddNew : enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: Local Driving License Application not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            // hadle creation mode ( first time schedule or retake test schedule)
            _CreationMode = (_LocalDrivingLicenseApplication.DoesAttentedTestType(TestTypeID))? enCreationMode.RetakeTestSchedule : enCreationMode.FirstTimeSchedule;

            if(_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblRetakeApplicationFees.Text = clsTestType.Find(TestTypeID).Fees.ToString();
                gbRetakeTest.Enabled = true;
                lblRetakeTestID.Text = "0";
                lblTitle.Text = "Schedule Retake Test";

                var newLoc = lblTitle.Location;
                newLoc.X = newLoc.X - 80;
                lblTitle.Location = newLoc;
            }
            else 
            {
                gbRetakeTest.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeApplicationFees.Text = "0";
                lblRetakeTestID.Text = "N/A";
            }

            // Display Local Driving License Application Info
            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingLicenseClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.Name;
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonInfo.GetFullName();
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(TestTypeID).ToString();
            dtpAppointmentDate.MinDate = DateTime.Now;

            if (_Mode == enMode.AddNew)
            {
                lblFees.Text = clsTestType.Find(TestTypeID).Fees.ToString();
                _TestAppointment = new clsTestAppointment();
            }
            else 
            {
                if (!_LoadTestAppointmentData())
                    return;
            }

            if (!_HandleActiveTestAppointmentConstraint())
                return;
            if (!_HadleLockedTestAppointmentConstraint())
                return;
            if (!_HandlePreviousTestConstraint())
                return;
        }

        private bool _LoadTestAppointmentData() 
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: Test Appointment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.PaidFees.ToString();

            dtpAppointmentDate.Value = (_TestAppointment.AppoitmentDate < dtpAppointmentDate.MinDate) ? dtpAppointmentDate.MinDate : _TestAppointment.AppoitmentDate;
            
            if(_TestAppointment.RetakeTestApplicationID != -1)
            {
                lblRetakeTestID.Text = _TestAppointment.RetakeTestApplication.PaidFees.ToString();
                lblRetakeApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
                gbRetakeTest.Enabled = true;
                lblTotalFees.Text = (_TestAppointment.PaidFees + _TestAppointment.RetakeTestApplication.PaidFees).ToString();

            }
            else
            {
                lblRetakeTestID.Text = "N/A";
                lblRetakeApplicationFees.Text = "0";
                gbRetakeTest.Enabled = false;
            }

            return true;
        }
        private bool _HandleActiveTestAppointmentConstraint() 
        {
            if(_Mode == enMode.AddNew&& clsLocalDrivingLicenseApplication.IsThereAnActiveSchduledTest(_LocalDrivingLicenseApplicationID,TestTypeID))
            {
                MessageBox.Show("Error: There is already an active test appointment for this test type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                dtpAppointmentDate.Enabled = false;
                return false;
            }

            return true;
        }
        private bool _HadleLockedTestAppointmentConstraint() 
        {
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for this test , appointment is locked.";
                btnSave.Enabled = false;
                dtpAppointmentDate.Enabled = false;
                return false;
            }
            return true;
        }
        private bool _HandlePreviousTestConstraint() 
        {
            if (_CreationMode == enCreationMode.FirstTimeSchedule)
                return true;
            if (!_LocalDrivingLicenseApplication.DoesPassedPreviousTestType(TestTypeID))
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person has not passed the previous test !!";
                btnSave.Enabled = false;
                dtpAppointmentDate.Enabled = false;
                return false;
            }

            lblUserMessage.Visible = false;
            btnSave.Enabled = true;
            dtpAppointmentDate.Enabled = true;
            return true;
        }   
        private bool _HandleRetakeTestConstraint() 
        {
            if(_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplication RetakeTestApplication = new clsApplication();
                RetakeTestApplication.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                RetakeTestApplication.ApplicationDate = DateTime.Now;
                RetakeTestApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                RetakeTestApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                RetakeTestApplication.LastStatusDate = DateTime.Now;
                RetakeTestApplication.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).Fees;
                RetakeTestApplication.CreatedByUserID = clsGlobal.CurrentUser.ID;


                if(!RetakeTestApplication.Save())
                {
                    MessageBox.Show("Error: Failed to create retake test application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _TestAppointment.RetakeTestApplicationID = -1;
                    return false;
                }
                _TestAppointment.RetakeTestApplicationID = RetakeTestApplication.ApplicationID;
            }
            return true;
        }

        public ctrScheduleTest()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeTestConstraint())
                return;

            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.ID;
            _TestAppointment.AppoitmentDate = dtpAppointmentDate.Value;
            _TestAppointment.TestTypeID = TestTypeID;
            _TestAppointment.IsLocked = false;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Test appointment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Failed to save test appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
