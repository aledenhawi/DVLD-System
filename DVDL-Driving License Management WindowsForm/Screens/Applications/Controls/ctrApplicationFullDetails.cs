using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Screens.PeopleScreens;
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
    public partial class ctrApplicationBasicInfo : UserControl
    {
        private clsApplication _Application = null;

        private int _ApplicationID = -1;
        
        public int ApplicationID { get { return _ApplicationID; } }
        public clsApplication Application { get { return _Application; } }

        public ctrApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.FindBaseApplication(ApplicationID);

            if (_Application != null)
            {
                _ApplicationID = ApplicationID;
                lblID.Text = _Application.ApplicationID.ToString();
                lblApplicant.Text = _Application.PersonInfo.GetFullName();
                lblCreatedBy.Text = _Application.CreatedByUserInfo.Username.ToString();
                lblDate.Text = _Application.ApplicationDate.ToShortDateString();
                lblStatusDate.Text = _Application.LastStatusDate.ToShortDateString();
                lblType.Text = _Application.ApplicationTypeInfo.Title;
                lblStatus.Text = _Application.ApplicationStatus.ToString();
                lblFees.Text = _Application.PaidFees.ToString();
            }
            else
            {
                MessageBox.Show("Application With ID = " + ApplicationID + " is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_Application.ApplicantPersonID);
            frm.ShowDialog();
        }

    }
}
