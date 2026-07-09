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
    public partial class frmChangePassword : Form
    {
        private clsUser _User;
        private int _UserID;
        private bool IsValid = false;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void _ResetDefaultValues() 
        {
            txbCurrentPassword.Text = "";
            txbConfirmPasswrod.Text = "";
            txbNewPassword.Text = "";
            txbCurrentPassword.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(IsValid == false)
            {
                MessageBox.Show("Please correct the errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (txbNewPassword.Text.Trim() == txbConfirmPasswrod.Text.Trim())
            {
                if (_User.ChangePassword(txbNewPassword.Text.Trim()))
                {
                    MessageBox.Show("Password changed successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ResetDefaultValues();
                }
                else
                    MessageBox.Show("An error occurred , password unchange.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txbNewPassword_Validation(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox) sender;

            if(string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                IsValid = false;
                errorProvider1.SetError(textBox, "This Faild Cann't be null.");
            }
            else 
            {
                IsValid = true;
                errorProvider1.SetError(textBox, null);
            }
        }

        private void txbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbCurrentPassword.Text.Trim()))
            {
                IsValid = false;
                errorProvider1.SetError(txbCurrentPassword, "This Faild Cann't be null!");
            }
            else
            {
                IsValid = true;
                errorProvider1.SetError(txbCurrentPassword, null);
            }
        }

        private void txbConfirmPasswrod_Validating(object sender, CancelEventArgs e)
        {
            if (txbConfirmPasswrod.Text.Trim() != txbNewPassword.Text.Trim())
            {
                IsValid = false;
                errorProvider1.SetError(txbConfirmPasswrod, "Make sure if the two password is matched!");
            }
            else
            {
                IsValid = true;
                errorProvider1.SetError(txbConfirmPasswrod, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            _User = clsUser.Find(_UserID);

            if(_User == null) 
            {
            MessageBox.Show("Error : User with ID = " + _UserID.ToString() + " is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrUserDetails1.LoadUserInfo(_UserID);
        }
    }
}
