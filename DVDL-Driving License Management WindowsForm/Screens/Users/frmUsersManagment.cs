using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Screens.PeopleScreens;
using DVDL_Driving_License_Management_WindowsForm.Screens.Users;
using DVDL_Driving_License_Management_WindowsForm.Screens.Users.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL_Driving_License_Management_WindowsForm.Screens
{
    public partial class frmUsersManagment : Form
    {
        private static DataTable UsersDataTable = DVDL_BusinessLayer.clsUser.GetAllUsers();


        public frmUsersManagment()
        {
            InitializeComponent();
        }

        private void frmUsersManagment_Load(object sender, EventArgs e)
        {
            UsersDataTable = clsUser.GetAllUsers();
            dgvUsersList.DataSource = UsersDataTable;
            cmbUsersFiltring.SelectedIndex = 0;
            
            lblTotalUsers.Text = UsersDataTable.Rows.Count.ToString();

            if (dgvUsersList.Rows.Count > 0)
            {
                dgvUsersList.Columns["UserID"].HeaderText = "User ID";
                dgvUsersList.Columns["UserID"].Width = 110;

                dgvUsersList.Columns["PersonID"].HeaderText = "Person ID";
                dgvUsersList.Columns["PersonID"].Width = 110;

                dgvUsersList.Columns["FullName"].HeaderText = "Full Name";
                dgvUsersList.Columns["FullName"].Width = 320;

                dgvUsersList.Columns["Username"].HeaderText = "Username";
                dgvUsersList.Columns["Username"].Width = 120;

                dgvUsersList.Columns["IsActive"].HeaderText = "Is Active";
                dgvUsersList.Columns["IsActive"].Width = 110;

            }
        }

        private void cmbUsersFiltring_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbUsersFiltring.Text == "Is Active") 
            {
                txbFiltringUsers.Visible = false;
                cmbIsActive.Visible = true;
                cmbIsActive.SelectedText = "All";
                cmbIsActive.Focus();
            }
            else 
            {
                txbFiltringUsers.Visible = (cmbUsersFiltring.Text != "None");
                cmbIsActive.Visible = false;
                txbFiltringUsers.Text = string.Empty;
                txbFiltringUsers.Focus();
            }
        }

        private void txbFiltringUsers_TextChanged(object sender, EventArgs e)
        {
            if (UsersDataTable == null) return;

            // sanitize single quotes for DataView expressions
            string term = txbFiltringUsers.Text?.Replace("'", "''") ?? string.Empty;
            string FilterColumn = default;

            switch (cmbUsersFiltring.Text)
            {
                case "None":
                    FilterColumn = "";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Username":
                    FilterColumn = "Username";
                    break;
                default:
                    break;
            }

            if (txbFiltringUsers.Text == "" || cmbUsersFiltring.Text == "None")
            {
                UsersDataTable.DefaultView.RowFilter = "";
                lblTotalUsers.Text = dgvUsersList.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID" || FilterColumn == "UserID")
                UsersDataTable.DefaultView.RowFilter = $"{FilterColumn} = {int.Parse(term)}";
            else
                UsersDataTable.DefaultView.RowFilter = $"{FilterColumn} LIKE '{term}%'";

            lblTotalUsers.Text = dgvUsersList.Rows.Count.ToString();

        }

        private void cmbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbIsActive.Text)
            {
                case "All":
                    UsersDataTable.DefaultView.RowFilter = "";
                    lblTotalUsers.Text = dgvUsersList.Rows.Count.ToString();
                    return;
                case "Yes":
                    UsersDataTable.DefaultView.RowFilter = $"IsActive = 1";
                    lblTotalUsers.Text = dgvUsersList.Rows.Count.ToString();
                    break;
                case "No":
                    UsersDataTable.DefaultView.RowFilter = $"IsActive = 0";
                    lblTotalUsers.Text = dgvUsersList.Rows.Count.ToString();
                    break;
                default:
                    break;
            }
        }

        private void txbFiltringUsers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbUsersFiltring.SelectedIndex == 1 || cmbUsersFiltring.SelectedIndex == 2) // PersonID and UserID should only accept digits
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbIsActive_VisibleChanged(object sender, EventArgs e)
        {
            cmbIsActive.SelectedIndex = 0;
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser addUpdateUser = new frmAddUpdateUser();
            addUpdateUser.ShowDialog();
            frmUsersManagment_Load(null, null);
        }

        private void tsShowDetails_Click(object sender, EventArgs e)
        {
            frmUserDetails userDetails = new frmUserDetails(int.Parse(dgvUsersList.CurrentRow.Cells["UserID"].Value.ToString()));
            userDetails.ShowDialog();
            frmUsersManagment_Load(null,null);

        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser addUpdateUser = new frmAddUpdateUser();
            addUpdateUser.ShowDialog();
            frmUsersManagment_Load(null, null);

        }

        private void stEdit_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser addUpdateUser = new frmAddUpdateUser(int.Parse(dgvUsersList.CurrentRow.Cells["UserID"].Value.ToString()));
            addUpdateUser.ShowDialog();
            frmUsersManagment_Load(null, null);
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this user?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if(clsUser.Delete(int.Parse(dgvUsersList.CurrentRow.Cells["UserID"].Value.ToString())))                {
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmUsersManagment_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to delete user due to data conected to it .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(int.Parse(dgvUsersList.CurrentRow.Cells["UserID"].Value.ToString()));
            changePassword.ShowDialog();
        }

        private void tsSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
