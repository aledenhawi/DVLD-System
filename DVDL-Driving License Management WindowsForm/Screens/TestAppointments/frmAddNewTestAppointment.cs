using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Properties;
using DVLD_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVDL_BusinessLayer.clsTestType;

namespace DVDL_Driving_License_Management_WindowsForm.Screens.TestAppointments
{
    public partial class frmSchedualTest : Form
    {
        clsTestType.enTestType _TestType;



        enum enMode { AddNew , Update }
        enMode _Mode;
        
        static int Trial =0;

        bool FailedBefore = false;

        float RetakeApplicationFees = 0;

        float TestFees = 0;

        public int _LocalDrivingLicenceApplicationID { set; get; }

        clsLocalDrivingLicenseApplication _AppointmentsApplication;
        public frmSchedualTest(int LocalDrivingLicenseID,clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenceApplicationID = LocalDrivingLicenseID;
            _TestType = TestType;
        }

        public frmSchedualTest(int LocalDrivingLicenseID, clsTestType.enTestType TestType,int TestAppointmentID)
        {
            InitializeComponent();
            _LocalDrivingLicenceApplicationID = LocalDrivingLicenseID;
            _TestType = TestType;
        }



        private void _LoadData() 
        {

            _AppointmentsApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenceApplicationID);

            if (_AppointmentsApplication != null)
            {
                TestFees = clsTestType.Find(_TestType).Fees;
                lblDrivingLicenseAppID.Text = _LocalDrivingLicenceApplicationID.ToString();
                lblDrivingLicenseClass.Text = _AppointmentsApplication.LicenseClass.Name;
                lblFees.Text = TestFees.ToString();
                lblName.Text = _AppointmentsApplication.PersonInfo.GetFullName();
                lblTrial.Text = Trial.ToString();
                lblRetakeTestID.Text = "N/A";

                if (!FailedBefore)
                {
                    gbRetakeExam.Enabled = false;
                    lblRetakeApplicationFees.Text = "0";
                    lblTotalFees.Text = lblFees.Text;
                }
                else 
                {
                    RetakeApplicationFees = clsApplicationType.Find(8).Fees;
                    gbRetakeExam.Enabled = true;
                    lblRetakeApplicationFees.Text = "0";
                    lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + RetakeApplicationFees).ToString();
                }
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (FailedBefore)
                {
                    clsApplication RetakeApplication = new clsApplication();
                    RetakeApplication.ApplicationTypeID = 8;
                    RetakeApplication.ApplicantPersonID = _AppointmentsApplication.ApplicantPersonID;
                    RetakeApplication.ApplicationDate = DateTime.Now;
                    RetakeApplication.CreatedByUserID = clsGlobal.CurrentUser.ID;
                    RetakeApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
                    RetakeApplication.LastStatusDate = DateTime.Now;
                    RetakeApplication.PaidFees = RetakeApplicationFees;
                    RetakeApplication.Save();
                
                }
                else 
                {
                    clsTestAppointment testAppointment = new clsTestAppointment();
                    testAppointment.PaidFees = TestFees;
                    testAppointment.AppoitmentDate = dtpAppointmentDate.Value;
                    testAppointment.CreatedByUserID = clsGlobal.CurrentUser.ID;
                    testAppointment.IsLocked = false;
                    testAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenceApplicationID;
                    testAppointment.TestTypeID = (int)_TestType;

                    if (testAppointment.Save()) 
                    {
                        _Mode = enMode.Update;
                        MessageBox.Show("Appointment saved successfully .", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        MessageBox.Show("Appointment Did not save successfully .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }

                }
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _SetPictureBoxImage()
        {

            switch (_TestType)
            {
                case clsTestType.enTestType.Vision:
                    pbTestType.Image = Resources.Vision_512;
                    break;
                case clsTestType.enTestType.Written:
                    pbTestType.Image = Resources.Written_Test_512;
                    break;
                case clsTestType.enTestType.Street:
                    pbTestType.Image = Resources.driving_test_512;
                    break;
                default:
                    break;
            }
        }

        private void frmAddNewTestAppointment_Load(object sender, EventArgs e)
        {
            FailedBefore = clsLocalDrivingLicenseApplication.DoesPassedTestType(_LocalDrivingLicenceApplicationID,_TestType);
            groupBox1.Text = _TestType.ToString() + " Test";
            _SetPictureBoxImage();
            _LoadData();
        }
    }
}
