using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Screens.Licenses;
using DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.Local_Licenses;
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

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Release_License
{
    public partial class frmManageDetainedLicenses : Form
    {
        DataTable DetainedLicensesTable = null;

        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            cmbDetainedLicensesFiltring.SelectedIndex = 0;

            DetainedLicensesTable = clsDetainedLicense.GetAllDetainedLicense();

            dgvDetainedLicenses.DataSource = DetainedLicensesTable;

            lblTotalDetainedLicenses.Text = dgvDetainedLicenses.Rows.Count.ToString();

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 90;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 90;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 160;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 110;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 110;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 160;

                dgvDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[6].Width = 90;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 330;

                dgvDetainedLicenses.Columns[8].HeaderText = "Rlease App.ID";
                dgvDetainedLicenses.Columns[8].Width = 150;

            }



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense();
            releaseDetainedLicense.ShowDialog();
        }

        private void cmbDetainedLicensesFiltring_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDetainedLicensesFiltring.Text == "Is Released")
            {
                txbFiltringDetainedLicenses.Visible = false;
                cmbIsReleased.Visible = true;
                cmbIsReleased.SelectedText = "All";
                cmbIsReleased.Focus();
            }
            else
            {
                txbFiltringDetainedLicenses.Visible = (cmbDetainedLicensesFiltring.Text != "None");
                cmbIsReleased.Visible = false;
                txbFiltringDetainedLicenses.Text = string.Empty;
                txbFiltringDetainedLicenses.Focus();
            }
        }

        private void txbFiltringUsers_TextChanged(object sender, EventArgs e)
        {
            if (DetainedLicensesTable == null) return;

            // sanitize single quotes for DataView expressions
            string term = txbFiltringDetainedLicenses.Text?.Replace("'", "''") ?? string.Empty;
            string FilterColumn = default;

            switch (cmbDetainedLicensesFiltring.Text)
            {
                case "None":
                    FilterColumn = "";
                    break;
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                default:
                    break;
            }

            if (txbFiltringDetainedLicenses.Text == "" || cmbDetainedLicensesFiltring.Text == "None")
            {
                DetainedLicensesTable.DefaultView.RowFilter = "";
                lblTotalDetainedLicenses.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "NationalNo" || FilterColumn == "FullName")
                DetainedLicensesTable.DefaultView.RowFilter = $"{FilterColumn} LIKE '{term}%'";
            else
                DetainedLicensesTable.DefaultView.RowFilter = $"{FilterColumn} = {int.Parse(term)}";

            lblTotalDetainedLicenses.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void cmbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbIsReleased.Text)
            {
                case "All":
                    DetainedLicensesTable.DefaultView.RowFilter = "";
                    lblTotalDetainedLicenses.Text = dgvDetainedLicenses.Rows.Count.ToString();
                    return;
                case "Yes":
                    DetainedLicensesTable.DefaultView.RowFilter = $"IsReleased = 1";
                    lblTotalDetainedLicenses.Text = dgvDetainedLicenses.Rows.Count.ToString();
                    break;
                case "No":
                    DetainedLicensesTable.DefaultView.RowFilter = $"IsReleased = 0";
                    lblTotalDetainedLicenses.Text = dgvDetainedLicenses.Rows.Count.ToString();
                    break;
                default:
                    break;
            }
        }

        private void txbFiltringDetainedLicenses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbDetainedLicensesFiltring.SelectedIndex == 1 || cmbDetainedLicensesFiltring.SelectedIndex == 5) // DetainID and ApplicationID should only accept digits
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbIsReleased_VisibleChanged(object sender, EventArgs e)
        {
            cmbIsReleased.SelectedIndex = 0;
        }

        private void tsShowPersonDetails_Click(object sender, EventArgs e)
        {
            clsLicense License = clsLicense.Find((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);

            frmPersonDetails frm = new frmPersonDetails(License.DriverInfo.PersonID);
            frm.ShowDialog();
            frmManageDetainedLicenses_Load(null,null);
        }

        private void tsShowLicenseDetials_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            frmManageDetainedLicenses_Load(null, null);
        }

        private void tsShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            clsLicense License = clsLicense.Find((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);

            frmShowPersonDrivingLicensesHistory frm = new frmShowPersonDrivingLicensesHistory(License.DriverInfo.PersonID);
            frm.ShowDialog();
            frmManageDetainedLicenses_Load(null, null);
        }

        private void tsReleaseDeatinedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

            frmManageDetainedLicenses_Load(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
                tsReleaseDeatinedLicense.Enabled = !(Convert.ToBoolean(dgvDetainedLicenses.CurrentRow.Cells["IsReleased"].Value));
        }
    }
}
