using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Properties;
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
using System.IO;

namespace DVDL_Driving_License_Management_WindowsForm.User_Controls
{
    public partial class ctrPersonDetails : UserControl
    {

        private clsPerson _Person = new clsPerson();

        private int _PersonID = -1;

        public int PersonID 
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo 
        {
            get { return _Person; }
        }

        public ctrPersonDetails()
        {
            InitializeComponent();
        }
        
        public void ResetPersonInfo() 
        {
            lblPersonID.Text = "[????]";
            lblAddress.Text = "[????]";
            lblBirthOfDate.Text = "[????]";
            lblEmail.Text = "[????]";
            lblGender.Text = "[????]";
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblPhone.Text = "[????]";
            lblBirthOfDate.Text = "[????]";
            lblCountry.Text = "[????]";
            pbPersonImage.Image = Resources.Male;
        }

        private void _LoadPersonImage() 
        {

            string ImagePath = _Person.ImagePath;

            pbPersonImage.Image = (_Person.Gender == clsPerson.GenderType.Male) ? Resources.Male : Resources.Female;

            if (!string.IsNullOrEmpty(ImagePath))
            {
                if (File.Exists(_Person.ImagePath))
                    pbPersonImage.ImageLocation = _Person.ImagePath;
                else
                    MessageBox.Show("Could not Find This Image :" + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _FillPersonInfo()
        {
            _PersonID = _Person.ID;
            lblPersonID.Text = _Person.ID.ToString();
            lblAddress.Text = _Person.Address;
            lblBirthOfDate.Text = _Person.DateOfBirth.ToShortDateString();
            lblEmail.Text = _Person.Email;
            lblGender.Text = (_Person.Gender == clsPerson.GenderType.Female) ? "Female" : "Male";
            lblName.Text = _Person.GetFullName();
            lblNationalNo.Text = _Person.NationalNo;
            lblPhone.Text = _Person.Phone;
            lblBirthOfDate.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;

            _LoadPersonImage();
        }

        public void LoadPersonInfo(int ID) 
        {
            _Person = clsPerson.Find(ID);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show($"No Perosn With PersonID = {ID}" , "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNumber)
        {
            _Person = clsPerson.Find(NationalNumber);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show($"No Perosn With National Number = {NationalNumber}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frmEditPerson = new frmAddUpdatePerson(_PersonID);
            frmEditPerson.ShowDialog();

            LoadPersonInfo(_PersonID);

        }
    }
}
