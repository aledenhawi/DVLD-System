using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Properties;
using DVLD_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVDL_Driving_License_Management_WindowsForm.Global_Classes;

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Basic
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

   
        private bool IsTextboxValid()
        {
            if (string.IsNullOrWhiteSpace(txbUsername.Text))
            {
                errorProvider1.SetError(txbUsername, "Username can't be empty");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbPassword.Text))
            {
                errorProvider1.SetError(txbPassword, "Password can't be empty");
                return false;
            }

            return true;

        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txbPassword.PasswordChar == '*')
            {
                btnShowPassword.BackgroundImage = Resources.eye;
                txbPassword.PasswordChar = '\0';
            }
            else
            {
                btnShowPassword.BackgroundImage = Resources.hiddenEye;
                txbPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            clsUser User = clsUser.Find(txbUsername.Text.Trim(),txbPassword.Text.Trim());

            if (User != null)
            {
                if (txbPassword.Text.Trim() == User.Password)
                {
                    if (User.IsActive == true)
                        clsGlobal.CurrentUser = User;
                    else
                        MessageBox.Show("User Is not Active .", "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {

                MessageBox.Show("Invalid Password/Username .", "Wrong Credintial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbRememberMe.Checked)
                clsGlobal.RememberUsernameAndPassword(txbUsername.Text.Trim(), txbPassword.Text.Trim());
            else
                clsGlobal.RememberUsernameAndPassword("","");


            this.Hide();

            frmMain mainForm = new frmMain();

            try
            {
                mainForm.ShowDialog();
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Application Couldn't be Oppened secessfully .", ex);

                MessageBox.Show("You Have to leave the app", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            if (!mainForm.IsSignOut)
            {
                this.Close(); 
            }
            else
            {
                this.Show();
            }
        }
           
        private void LoadLoginInfo() 
        {
            string password = "" , username = "";
            if(clsGlobal.RestoreUsernameAndPassword(ref username, ref password)) 
            {
                txbUsername.Text = username;
                txbPassword.Text = password;
                cbRememberMe.Checked = true;
            }
            else
            cbRememberMe.Checked = false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadLoginInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
