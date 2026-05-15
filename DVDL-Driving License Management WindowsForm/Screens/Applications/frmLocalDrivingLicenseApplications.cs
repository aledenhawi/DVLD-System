using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.Local_Licenses;
using DVDL_Driving_License_Management_WindowsForm.Screens.TestAppointments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Applications
{
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        DataTable LocalDrivingLicenseDataTable;

        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            LocalDrivingLicenseDataTable = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicenseApplicationsList.DataSource = LocalDrivingLicenseDataTable;
            cmbLDLApplicationsFiltring.SelectedIndex = 0;

            lblTotalRecords.Text = dgvLocalDrivingLicenseApplicationsList.Rows.Count.ToString();

            if (dgvLocalDrivingLicenseApplicationsList.Rows.Count > 0)
            {

                dgvLocalDrivingLicenseApplicationsList.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplicationsList.Columns["LocalDrivingLicenseApplicationID"].Width = 110;

                dgvLocalDrivingLicenseApplicationsList.Columns["ClassName"].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplicationsList.Columns["ClassName"].Width = 240;

                dgvLocalDrivingLicenseApplicationsList.Columns["NationalNo"].HeaderText = "National No.";
                dgvLocalDrivingLicenseApplicationsList.Columns["NationalNo"].Width = 110;

                dgvLocalDrivingLicenseApplicationsList.Columns["FullName"].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplicationsList.Columns["FullName"].Width = 300;

                dgvLocalDrivingLicenseApplicationsList.Columns["ApplicationDate"].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplicationsList.Columns["ApplicationDate"].Width = 170;

                dgvLocalDrivingLicenseApplicationsList.Columns["PassedTestCount"].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplicationsList.Columns["PassedTestCount"].Width = 130;

                dgvLocalDrivingLicenseApplicationsList.Columns["Status"].Width = 150;

            }
        }

        private void btnAddNewLDLApplication_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication addEditLocalDrivingLicenseApplication = new frmAddEditLocalDrivingLicenseApplication();
            addEditLocalDrivingLicenseApplication.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void cmbLDLApplicationsFiltring_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LocalDrivingLicenseDataTable == null) return;


            txbFiltringLDLApplications.Visible = (cmbLDLApplicationsFiltring.Text == "None") ? false : true;

            if (txbFiltringLDLApplications.Visible)
            {
                txbFiltringLDLApplications.Text = string.Empty;
                txbFiltringLDLApplications.Focus();
            }
        }

        private void txbFiltringLDLApplications_TextChanged(object sender, EventArgs e)
        {

            

            if (LocalDrivingLicenseDataTable == null) return;

            // sanitize single quotes for DataView expressions
            string term = txbFiltringLDLApplications.Text?.Replace("'", "''") ?? string.Empty;
            string FilterColumn = default;

            switch (cmbLDLApplicationsFiltring.Text)
            {
                case "None":
                    FilterColumn = "";
                    break;
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Driving Class":
                    FilterColumn = "ClassName";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Passed Tests":
                    FilterColumn = "PassedTestCount";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                    break;
            }

            if (txbFiltringLDLApplications.Text == "")
            {
                LocalDrivingLicenseDataTable.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvLocalDrivingLicenseApplicationsList.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "LocalDrivingLicenseApplicationID" || FilterColumn == "PassedTestCount")
            {
                LocalDrivingLicenseDataTable.DefaultView.RowFilter = $"{FilterColumn} = {term}";
            }
            else
            {
                LocalDrivingLicenseDataTable.DefaultView.RowFilter = $"{FilterColumn} LIKE '{term}%'";
            }

            lblTotalRecords.Text = dgvLocalDrivingLicenseApplicationsList.Rows.Count.ToString();
        }

        private void txbFiltringLDLApplications_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cmbLDLApplicationsFiltring.SelectedIndex == 1 || cmbLDLApplicationsFiltring.SelectedIndex == 5) // PersonID should only accept digits
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void tsDeleteApplication_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this application?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication((int)dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value))
                {
                    MessageBox.Show("Application deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                    MessageBox.Show("Failed to delete the application. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cancleApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancle this application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsLocalDrivingLicenseApplication clsLocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find((int)dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
                if (clsLocalDrivingLicenseApplication.Cancle(clsLocalDrivingLicenseApplication.ApplicationID))
                {
                    MessageBox.Show("Application has been canclled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to cancle the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsShowApplicationDetails_Click(object sender, EventArgs e)
        {
            frmLocalDrvingLicenseApplicationDetails frm = new frmLocalDrvingLicenseApplicationDetails((int)dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            frm.ShowDialog();
        }

        private void tsEditApplicatoin_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;

            if (clsLocalDrivingLicenseApplication.GetPassedTestCount(LocalDrivingLicenseApplicationID) > 0) 
            {
                MessageBox.Show("You can't edit an application with passed tests","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            frmAddEditLocalDrivingLicenseApplication frmAddEditLocalDrivingLicenseApplication = new frmAddEditLocalDrivingLicenseApplication();
            frmAddEditLocalDrivingLicenseApplication.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);

            byte totalPassedTests = localDrivingLicenseApplication.GetPassedTestCount();


            bool LicenseIssued = localDrivingLicenseApplication.IsLicenseIssued();


            tsDeleteApplication.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            tsShowLicense.Enabled = LicenseIssued;

            tsCancleApplication.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New) && !LicenseIssued;

            tsEditApplication.Enabled = !LicenseIssued && (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            tsIssueDrivingLicense.Enabled = !LicenseIssued && (totalPassedTests == 3);
            tsSechduleTest.Enabled = !LicenseIssued;

            bool VisionTestPassed = localDrivingLicenseApplication.DoesPassedTestType(clsTestType.enTestType.Vision);
            bool WrittenTestPassed = localDrivingLicenseApplication.DoesPassedTestType(clsTestType.enTestType.Written);
            bool StreetTestPassed = localDrivingLicenseApplication.DoesPassedTestType(clsTestType.enTestType.Street);

            if (tsSechduleTest.Enabled) 
            {
                visionTestToolStripMenuItem.Enabled = !VisionTestPassed;
                writtenTestToolStripMenuItem.Enabled = VisionTestPassed && !WrittenTestPassed;
                streetTestToolStripMenuItem.Enabled =  VisionTestPassed && WrittenTestPassed && !StreetTestPassed;
            }



        }

        private void tsIssueDrivingLicense_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicenseForTheFirstTime issueDrivingLicenseForTheFirstTime = new frmIssueDrivingLicenseForTheFirstTime((int)dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            issueDrivingLicenseForTheFirstTime.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void tsShowLicense_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells[0].Value;

            int LicenseID = clsLocalDrivingLicenseApplication.Find(
               LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void tsShowPersonLicenseHistroy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestsAppointments schedualTest = new frmTestsAppointments((int)dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value, clsTestType.enTestType.Vision);
            schedualTest.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestsAppointments schedualTest = new frmTestsAppointments((int)dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value, clsTestType.enTestType.Written);
            schedualTest.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestsAppointments schedualTest = new frmTestsAppointments((int)dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value, clsTestType.enTestType.Street);
            schedualTest.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

    }
}
