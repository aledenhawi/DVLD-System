using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Properties;
using DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Controls;
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

namespace DVDL_Driving_License_Management_WindowsForm.Screens.TestAppointments
{
    public partial class frmTestsAppointments : Form
    {
        int _LocalDrivingLicenseApplicationID = 0;

        DataTable _AppointmentsTestDataTable;


        clsTestType.enTestType _TestType;

        public frmTestsAppointments(int ApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = ApplicationID;
            this._TestType = TestType;
        }

        private void _FullDataGridView() 
        {

             _AppointmentsTestDataTable = clsTestAppointment.GetApplicatoinTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID,(int)_TestType);

            if (_AppointmentsTestDataTable.Rows.Count == 0) 
            {
                dgvTestAppointments.DataSource = null;
                lblTotalRecords.Text = "0";
                return; 
            }

            dgvTestAppointments.DataSource = _AppointmentsTestDataTable;

            if (dgvTestAppointments.Rows.Count > 0)
            {
                dgvTestAppointments.Columns["TestAppointmentID"].HeaderText = "Appointment ID";
                dgvTestAppointments.Columns["TestAppointmentID"].Width = 140;

                dgvTestAppointments.Columns["AppointmentDate"].HeaderText = "Appointment Date";
                dgvTestAppointments.Columns["AppointmentDate"].Width = 220;

                dgvTestAppointments.Columns["PaidFees"].HeaderText = "Paid Fees";
                dgvTestAppointments.Columns["PaidFees"].Width = 150;

                dgvTestAppointments.Columns["IsLocked"].HeaderText = "Is Locked";
                dgvTestAppointments.Columns["IsLocked"].Width = 120;
            }

            lblTotalRecords.Text = dgvTestAppointments.Rows.Count.ToString();
        }

        private void _SetPictureBoxImage() 
        {

            switch (_TestType)
            {
                case clsTestType.enTestType.Vision:
                    pictureBox1.Image = Resources.Vision_512;
                    break;
                case clsTestType.enTestType.Written:
                    pictureBox1.Image = Resources.Written_Test_512;
                    break;
                case clsTestType.enTestType.Street:
                    pictureBox1.Image = Resources.driving_test_512;
                    break;
                default:
                    break;
            }
        }

        private void frmTestsAppointments_Load(object sender, EventArgs e)
        {
            ctrLocalDrivingLicenseApplicationFullDetails1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);

            _FullDataGridView();
            _SetPictureBoxImage();

            this.Text = _TestType.ToString() + " Test Appointments";
            lblTitle.Text = _TestType.ToString() + " Test Appointments";


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            if (localDrivingLicenseApplication.IsThereAnActiveSchduledTest(_TestType))
            {
                MessageBox.Show("Person already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (localDrivingLicenseApplication.DoesPassedTestType(_TestType)) 
            {
                MessageBox.Show("Person already passed this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmSchedualTest addNewTestAppointment = new frmSchedualTest(_LocalDrivingLicenseApplicationID, _TestType);
            addNewTestAppointment.ShowDialog();
            _FullDataGridView();
        }

        private void tsEdit_Click(object sender, EventArgs e)
        {
            frmSchedualTest schedualTest = new frmSchedualTest(_LocalDrivingLicenseApplicationID, _TestType, (int) dgvTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value);
            schedualTest.ShowDialog();
            _FullDataGridView();
        }
    }
}
