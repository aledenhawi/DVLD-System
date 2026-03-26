using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_Classes;

namespace DVDL_Driving_License_Management_WindowsForm.Screens.PeopleScreens
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender , int ID);
        
        public event DataBackEventHandler DataBack;

        private enum enMode { AddNew = 0 , Update = 1 }

        private enMode _Mode;

        private int _PersonID;

        private clsPerson _Person;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePerson(int PersonID) 
        {
            InitializeComponent();
            _Mode = enMode.Update;
            this._PersonID = PersonID;

        }

        private bool _HandleImagePath() 
        {
            if(pbPersonImage.ImageLocation != _Person.ImagePath) 
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            if (pbPersonImage.ImageLocation != null) 
            {
                string SourceFile = pbPersonImage.ImageLocation.ToString();
                if(clsUtil.CopyImageToProjectImagesFile(ref SourceFile))
                {
                    _Person.ImagePath = SourceFile;
                    return true;
                }
                else 
                {
                    MessageBox.Show("Image was not Saved Seccessfully","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true; 
        }

        private void _FullCmbWithCountries() 
        {
            DataTable dt = clsCountry.GetAllCountries();

            foreach (DataRow row in dt.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }

        }

        private void _ResetDefualtValues() 
        {
            _FullCmbWithCountries();

            if (_Mode == enMode.AddNew) 
            {
                _Person = new clsPerson();
                lblTitle.Text = "Add New Person";
            }
            else
                lblTitle.Text = "Update Person";

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male;
            else
                pbPersonImage.Image = Resources.Female;

            llblRemove.Visible = (pbPersonImage.ImageLocation != null);

            dtbDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtbDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtbDateOfBirth.Value = dtbDateOfBirth.MaxDate;

            rbMale.Checked = true;
            txbAddress.Text = "";
            txbEmail.Text = "";
            txbFirstName.Text = "";
            txbLastName.Text = "";
            txbThirdName.Text = "";
            txbNationalNo.Text = "";
            txbPhone.Text = "";

            cbCountries.SelectedIndex = cbCountries.FindString("Syria");

        }

        private void _LoadData() 
        {
            _Person = clsPerson.Find(_PersonID);

            if(_Person == null) 
            {
                MessageBox.Show($"Person With ID = {_PersonID} , wasn't found.","Person Wasn't Exist",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            llblRemove.Visible = (pbPersonImage.Location != null);

            dtbDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gender == clsPerson.GenderType.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            lblPersonID.Text = _Person.ID.ToString();
            txbAddress.Text = _Person.Address;
            txbEmail.Text = _Person.Email;
            txbFirstName.Text = _Person.FirstName;
            txbSecondName.Text = _Person.SecondName;
            txbLastName.Text = _Person.LastName;
            txbThirdName.Text = _Person.ThirdName;
            txbNationalNo.Text = _Person.NationalNo;
            txbPhone.Text = _Person.Phone;
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo.CountryName);

            if(_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }

            llblRemove.Visible = (_Person.ImagePath != "");
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void llblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            pbPersonImage.Image = rbFemale.Checked ? Resources.Female : Resources.Male;

            llblRemove.Visible = false;
        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = openFileDialog1.FileName;

                pbPersonImage.ImageLocation = ImagePath;

                llblRemove.Visible = true;
            }

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null) 
            {
                pbPersonImage.Image = rbFemale.Checked ? Resources.Female : Resources.Male;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check Validation
            if (!this.ValidateChildren()) 
            {
                MessageBox.Show("Some failds are not valid , put the mouse over the red icon to see details", "Not Valid Failds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_HandleImagePath())
                return;

            // Full Person Object With Info 
            int NationalityCountryID = clsCountry.Find(cbCountries.Text.ToString()).ID;

            _Person.Address = txbAddress.Text.Trim();
            _Person.FirstName = txbFirstName.Text.Trim();
            _Person.SecondName = txbSecondName.Text.Trim();
            _Person.ThirdName = txbThirdName.Text.Trim();
            _Person.LastName = txbLastName.Text.Trim();
            _Person.Email = txbEmail.Text.Trim();
            _Person.Phone = txbPhone.Text.Trim();
            _Person.NationalNo = txbNationalNo.Text.Trim();
            _Person.DateOfBirth = dtbDateOfBirth.Value;
            _Person.NationalityCountryID = NationalityCountryID;

            _Person.Gender = rbFemale.Checked ? clsPerson.GenderType.Female : clsPerson.GenderType.Male;



            if (_Person.Save())
            {
                if(_Mode == enMode.AddNew) 
                {
                    lblPersonID.Text = _Person.ID.ToString();
                    // Change Form Mode to Update
                    _Mode = enMode.Update;
                    lblTitle.Text = "Update Person Info";
                }

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Person.ID);
            }
            else
                MessageBox.Show("Error : data is not saved successfully.", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotNull_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                errorProvider1.SetError(textBox, "This Field Can't be Empty!");
            }
            else
            {
                errorProvider1.SetError(textBox, null);
            }
        }

        private void txbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txbEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") && !string.IsNullOrEmpty(txbEmail.Text))
            {
                errorProvider1.SetError(txbEmail, "Invalid Email Format!");
            }
            else
            {
                errorProvider1.SetError(txbEmail, null);
            }
        }

        private void txbPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbPhone.Text))
            {
                errorProvider1.SetError(txbPhone, "Phone Number Can't be Empty!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txbPhone.Text, @"^\d+$"))
            {
                errorProvider1.SetError(txbPhone, "Phone Number Must Contain Only Digits!");
            }
            else
            {
                errorProvider1.SetError(txbPhone, null);
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNationalNo.Text))
            {
                errorProvider1.SetError(txbNationalNo, "This Field Can't be Empty!");
            }
            else
            {
                errorProvider1.SetError(txbNationalNo, null);
            }

            if (clsPerson.IsPersonExists(txbNationalNo.Text.ToString()) && txbNationalNo.Text.Trim() != _Person.NationalNo)
            {
                e.Cancel = true;
                txbNationalNo.Focus();
                errorProvider1.SetError(txbNationalNo, "This National Number is already exists.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbNationalNo, null);
            }
        }
    }
}
