using DVDL_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Users
{
    public partial class frmAddUpdateUser : Form
    {
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }

        public frmAddUpdateUser(int ID) 
        {
            InitializeComponent();
            _UserID = ID;
            _Mode = enMode.Update;

           
        }

        private bool _IsPersonFound = false;
        private bool _IsValidated = false;

        int _UserID = -1;

        clsUser _User  = null;

        private enum enMode { Add= 1, Update=2 }

        enMode _Mode;

        private void _ResetDefaultValues() 
        {
            if (_Mode == enMode.Add)
            {
                _IsPersonFound = false;
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();

                tbLoginInfo.Enabled = false;
                btnReset.Visible = true;
                ctrPersonDetailsWithFilter1.FilterFocus();
            }
            else 
            {
                _IsPersonFound = true;
                lblTitle.Text = "Update User";
                this.Text = "Update User";

                btnReset.Visible = false;
            }

            txbConfirmPasswrod.Text = "";
            txbPassword.Text = "";
            txbUsername.Text = "";
            cbIsActive.Checked = true;
        }

        private void _LoadData() 
        {
            _User = clsUser.Find(_UserID);

            ctrPersonDetailsWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
               MessageBox.Show("Error : User with ID = " + _UserID.ToString() + " is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblUserID.Text = _User.ID.ToString();
            txbUsername.Text = _User.Username;
            cbIsActive.Checked = _User.IsActive;
            ctrPersonDetailsWithFilter1.LoadPersonInfo(_User.PersonInfo.ID);

        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if(_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                tbLoginInfo.Enabled = true;
                tabControl.SelectedTab = tbLoginInfo;
                return;
            }


            if (_IsPersonFound) 
            {
                if (clsUser.IsExistsUsingPersonID(ctrPersonDetailsWithFilter1.PersonID))
                {
                    MessageBox.Show("This person is already has a user!,Choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnReset.PerformClick();
                    return;
                }
                else 
                {
                    tbLoginInfo.Enabled = true;
                    tabControl.SelectedTab = tbLoginInfo;
                    ctrPersonDetailsWithFilter1.FilterEnabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please select a person to proceed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrPersonDetailsWithFilter1.FilterFocus();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsValidated)
            {
                MessageBox.Show("Please correct the errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            _User.PersonID = ctrPersonDetailsWithFilter1.PersonID;
            _User.Username = txbUsername.Text.Trim();
            _User.Password = txbPassword.Text.Trim();
            _User.IsActive = cbIsActive.Checked;
            

            if (_User.Save())
            {

                lblUserID.Text = _User.ID.ToString();
                // chage mode to update after saving the new user
                _Mode = enMode.Update;
                lblTitle.Text = "Update User";
                this.Text = "Update User";
                MessageBox.Show("User has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR : User hasn't been saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txbConfirmPasswrod_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbConfirmPasswrod.Text.Trim()))
            {
                _IsValidated = false;
                errorProvider1.SetError(txbConfirmPasswrod, "This Faild Cann't be null!");
            }
            else
            {
                _IsValidated = true;
                errorProvider1.SetError(txbConfirmPasswrod, null);
            }

            if (txbConfirmPasswrod.Text.Trim() != txbPassword.Text.Trim())
            {
                _IsValidated = false;
                errorProvider1.SetError(txbConfirmPasswrod, "Make sure the two password is matched!");
            }
            else
            {
                _IsValidated = true;
                errorProvider1.SetError(txbConfirmPasswrod, null);
            }
        }

        private void UserExistsValidation(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                _IsValidated = false;
                errorProvider1.SetError(textBox, "This Faild Cann't be null.");
            }
            else if (clsUser.IsExists(txbUsername.Text.Trim())&&_User.Username.ToString() != txbUsername.Text.Trim()) 
            {
                _IsValidated = false;
                errorProvider1.SetError(textBox, "Username is already exists , try another one.");
            }
            else
            {
                _IsValidated = true;
                errorProvider1.SetError(textBox, null);
            }
        }

        private void ctrPersonDetailsWithFilter1_OnPersonSelected(int obj)
        {
            _IsPersonFound = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _IsPersonFound = false;
            ctrPersonDetailsWithFilter1.FilterEnabled = true;
            ctrPersonDetailsWithFilter1.ResetPersonInfo();
            txbConfirmPasswrod.Text = "";
            txbPassword.Text = "";
            txbUsername.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
