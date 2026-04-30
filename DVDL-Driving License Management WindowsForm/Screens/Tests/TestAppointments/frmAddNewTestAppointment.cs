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
using static DVDL_BusinessLayer.clsPerson;
using static DVDL_BusinessLayer.clsTestType;

namespace DVDL_Driving_License_Management_WindowsForm.Screens.TestAppointments
{
    public partial class frmSchedualTest : Form
    {
        private clsTestType.enTestType _TestType;

        private int _LocalDrivingLicenceApplicationID = 0;

        private int _AppointmentID = -1;
        public frmSchedualTest(int LocalDrivingLicenseID, clsTestType.enTestType TestType, int AppointmentID = -1)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _LocalDrivingLicenceApplicationID = LocalDrivingLicenseID;
            _TestType = TestType;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSchedualTest_Load(object sender, EventArgs e)
        {
            ctrScheduleTest1.TestTypeID = _TestType;
            ctrScheduleTest1.LoadData(_LocalDrivingLicenceApplicationID,_AppointmentID);
        }
    }
}
