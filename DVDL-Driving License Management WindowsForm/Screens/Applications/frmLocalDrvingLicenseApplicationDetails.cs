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
    public partial class frmLocalDrvingLicenseApplicationDetails : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        public frmLocalDrvingLicenseApplicationDetails(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void frmLocalDrvingLicenseApplicationDetails_Load(object sender, EventArgs e)
        {
           ctrLocalDrivingLicenseApplicationFullDetails1.LoadLDLApplicationDetails(_LocalDrivingLicenseApplicationID);
        }
    }
}
