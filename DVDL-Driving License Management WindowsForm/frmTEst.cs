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
    public partial class frmTEst : Form
    {
        public frmTEst()
        {
            InitializeComponent();
        }

        private void frmTEst_Load(object sender, EventArgs e)
        {
            ctrLocalDrivingLicenseApplicationFullDetails1.LoadLDLApplicationDetails(30);
        }
    }
}
