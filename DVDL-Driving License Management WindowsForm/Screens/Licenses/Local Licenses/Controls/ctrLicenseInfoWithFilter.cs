using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.Local_Licenses.Controls
{
    public partial class ctrLicenseInfoWithFilter : UserControl
    {
        public ctrLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public Action<int> OnLicenseSelected;

        protected virtual void LicenseSelected(int LicenseID) 
        {
            Action<int> Handler = OnLicenseSelected;
           
            if (Handler != null)
                Handler(LicenseID);
        }

        bool _FilterEnable = true;

        public bool FilterEnable 
        {
            get => _FilterEnable; 
            set 
            { 
                _FilterEnable = value;
                gbFilter.Enabled = value; 
            } 
        }

         public int LicenseID { get => ctrLicenseInfo1.LicenseID; }
         public clsLicense SelectedLicenseInfo { get => ctrLicenseInfo1.SelectedLicenseInfo; }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            ctrLicenseInfo1.LoadLicenseData(int.Parse(txbLicenseID.Text));

            if (OnLicenseSelected != null && FilterEnable)
                // Raise the event with a parameter
                OnLicenseSelected(ctrLicenseInfo1.LicenseID);
        }
        private void txbLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter) 
            {
                btnFindLicense.PerformClick();
                return;
            }

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


    }
}
