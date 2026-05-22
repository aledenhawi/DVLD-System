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

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Controls
{
    public partial class ctrInternationalLicenseApplicartionDetails : UserControl
    {

        private int _LocalLicenseID;

        public int LocalLicenseID
        {
            get => _LocalLicenseID;
            set 
            {
                lblLocalLicenseID.Text = value.ToString();
                _LocalLicenseID = value; 
            }
        }

        public ctrInternationalLicenseApplicartionDetails()
        {
            InitializeComponent();
        }

        public void ResetDefualtValues()
        {
            lblCreatedBy.Text = clsGlobal.CurrentUser.ID.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblExprationDate.Text = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblApplicationID.Text = "[???]";
            lblInternationalLicenseID.Text = "[???]";
            lblLocalLicenseID.Text = "[???]";
            
        }

        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            clsInternationalLicense internationalLicense = clsInternationalLicense.Find(InternationalLicenseID);
            if (internationalLicense != null)
            {
                lblApplicationID.Text = internationalLicense.ApplicationID.ToString();
                lblInternationalLicenseID.Text = internationalLicense.InternationalLicenseID.ToString();
            }
            else
            {
                MessageBox.Show("Error: International License not found.");
            }
        }

        private void ctrInternationalLicenseApplicartionDetails_Load(object sender, EventArgs e)
        {
        }
    }
}
