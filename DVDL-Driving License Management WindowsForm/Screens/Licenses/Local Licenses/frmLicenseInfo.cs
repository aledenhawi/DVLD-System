using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.Local_Licenses
{
    public partial class frmLicenseInfo : Form
    {
        private int _LicenseID;

        public frmLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrLicenseInfo1.LoadLicenseData(_LicenseID);
        }
    }
}
