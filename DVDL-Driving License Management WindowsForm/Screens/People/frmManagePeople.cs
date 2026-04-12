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
using System.IO;

namespace DVDL_Driving_License_Management_WindowsForm
{
    public partial class frmManagePeople : Form
    {
   
        private static DataTable dt = DVDL_BusinessLayer.clsPerson.GetAllPeople();

        private DataTable PeopleDataTable = dt.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName",
                "SecondName", "ThirdName", "LastName", "Gender", "DateOfBirth", "CountryName", "Phone", "Email");

        public frmManagePeople()
        {
            InitializeComponent();
        }

       
        private void frmPeople_Load(object sender, EventArgs e)
        {
            dgvPeopleList.DataSource = PeopleDataTable;
            cmbPeopleFiltring.SelectedIndex = 0;

            lblTotalRecords.Text = PeopleDataTable.Rows.Count.ToString();

            if (dgvPeopleList.Rows.Count > 0) 
            {
                dgvPeopleList.Columns["PersonID"].HeaderText = "Person ID";
                dgvPeopleList.Columns["PersonID"].Width = 110;

                dgvPeopleList.Columns["NationalNo"].HeaderText = "National No.";
                dgvPeopleList.Columns["NationalNo"].Width = 120;

                dgvPeopleList.Columns["FirstName"].HeaderText = "First Name";
                dgvPeopleList.Columns["FirstName"].Width = 120;

                dgvPeopleList.Columns["SecondName"].HeaderText = "Second Name";
                dgvPeopleList.Columns["SecondName"].Width = 120;

                dgvPeopleList.Columns["ThirdName"].HeaderText = "ThirdName";
                dgvPeopleList.Columns["ThirdName"].Width = 120;

                dgvPeopleList.Columns["LastName"].HeaderText = "Last Name";
                dgvPeopleList.Columns["LastName"].Width = 120;
              
                dgvPeopleList.Columns["Gender"].HeaderText = "Gender";
                dgvPeopleList.Columns["Gender"].Width = 100;

                dgvPeopleList.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
                dgvPeopleList.Columns["DateOfBirth"].Width = 140;

                dgvPeopleList.Columns["CountryName"].HeaderText = "Nationality";
                dgvPeopleList.Columns["CountryName"].Width = 120;

                dgvPeopleList.Columns["Phone"].HeaderText = "Phone";
                dgvPeopleList.Columns["Phone"].Width = 120;

                dgvPeopleList.Columns["Email"].HeaderText = "Email";
                dgvPeopleList.Columns["Email"].Width = 170;


            }
        }

        private void _RefreshPeopleList() 
        {
            DataTable dt = clsPerson.GetAllPeople();
            PeopleDataTable = dt.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName",
                "SecondName", "ThirdName", "LastName", "Gender", "DateOfBirth", "CountryName", "Phone", "Email");
            dgvPeopleList.DataSource = PeopleDataTable;
            cmbPeopleFiltring.SelectedIndex = 0;

            lblTotalRecords.Text = PeopleDataTable.Rows.Count.ToString();
        }

        private void cmbPeopleFiltring_SelectedValueChanged(object sender, EventArgs e)
        {
            if (PeopleDataTable == null) return;


            txbFiltringPeople.Visible = (cmbPeopleFiltring.Text == "None") ? false : true;
       
            if(txbFiltringPeople.Visible)
            {
                txbFiltringPeople.Text = string.Empty;
                txbFiltringPeople.Focus();
            }
        }
 
        private void txbFiltringPeople_TextChanged(object sender, EventArgs e)
        {
            if (PeopleDataTable == null) return;

            // sanitize single quotes for DataView expressions
            string term = txbFiltringPeople.Text?.Replace("'", "''") ?? string.Empty;
            string FilterColumn = default;

            switch (cmbPeopleFiltring.Text)
            {
                case "None":
                    FilterColumn = "";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "LastName":
                    FilterColumn = "LastName";
                    break;
                case "Gender":
                    FilterColumn = "Gender";
                    break;
                case "Date Of Birth":
                    FilterColumn = "Date Of Birth";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                case "Country Name":
                    FilterColumn = "CountryName";
                    break;
                default:
                    break;
            }

            if (txbFiltringPeople.Text == "") 
            {
                PeopleDataTable.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvPeopleList.Rows.Count.ToString();
                return;
            }

            if(FilterColumn == "PersonID")
            {
                PeopleDataTable.DefaultView.RowFilter = $"{FilterColumn} = {term}";
            }
            else 
            {
                PeopleDataTable.DefaultView.RowFilter = $"{FilterColumn} LIKE '{term}%'";
            }

            lblTotalRecords.Text = dgvPeopleList.Rows.Count.ToString();
        }

        private void txbFiltringPeople_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbPeopleFiltring.SelectedIndex == 1) // PersonID should only accept digits
            { 
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                e.Handled = true;
                }
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddPerson = new frmAddUpdatePerson();
            frmAddPerson.ShowDialog(this);
            _RefreshPeopleList();
        }

        private void tsShowDetails_Click(object sender, EventArgs e)
        {
            frmPersonDetails frmPersonDetails1 = new frmPersonDetails((int)(dgvPeopleList.CurrentRow.Cells[0].Value));
            frmPersonDetails1.ShowDialog(this);

            _RefreshPeopleList();
        }

        private  void tsAddNew_Click(object sender, EventArgs e)
        {
            if (dgvPeopleList.CurrentRow == null) return;

            frmAddUpdatePerson frmAddPerson = new frmAddUpdatePerson();
            frmAddPerson.ShowDialog(this);

            _RefreshPeopleList();
        }

        private  void tsEdit_Click(object sender, EventArgs e)
        {
            if(dgvPeopleList.CurrentRow == null) return;

            frmAddUpdatePerson frmEditPerson1 = new frmAddUpdatePerson((int)(dgvPeopleList.CurrentRow.Cells["PersonID"].Value));
            frmEditPerson1.ShowDialog(this);

            _RefreshPeopleList();
        }

        private  void tsDelete_Click(object sender, EventArgs e)
        {

            int PersonID = (int)(dgvPeopleList.CurrentRow.Cells["PersonID"].Value);
            clsPerson Person = clsPerson.Find(PersonID);

            if(MessageBox.Show("Are you sure to delete person with ID: " + PersonID.ToString() , "Deletion",MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                if (clsPerson.DeletePerson(PersonID))
                {
                    if (!string.IsNullOrEmpty(Person.ImagePath)) 
                    {
                        try
                        {
                            File.Delete(Person.ImagePath);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }

                    MessageBox.Show("Person with ID: " + PersonID.ToString() + " has been deleted successfully.", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    _RefreshPeopleList();
                }
                else 
                {
                     MessageBox.Show("Deletion canceled because person has data linked to it.", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }



        }

    }
}
