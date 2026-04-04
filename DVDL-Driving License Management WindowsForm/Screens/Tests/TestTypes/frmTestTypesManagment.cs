using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Screens.ApplicationsType;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Tests.TestTypes
{
    public partial class frmTestTypesManagment : Form
    {

        public frmTestTypesManagment()
        {
            InitializeComponent();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            DataTable dtTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypesList.DataSource = dtTestTypes;

            lblTestTypes.Text = dtTestTypes.Rows.Count.ToString();

            if (dgvTestTypesList.Rows.Count > 0)
            {
                dgvTestTypesList.Columns["TestTypeID"].HeaderText = "ID";
                dgvTestTypesList.Columns["TestTypeID"].Width = 110;

                dgvTestTypesList.Columns["TestTypeTitle"].HeaderText = "Title";
                dgvTestTypesList.Columns["TestTypeTitle"].Width = 300;

                dgvTestTypesList.Columns["TestTypeDescription"].HeaderText = "Description";
                dgvTestTypesList.Columns["TestTypeDescription"].Width = 300;


                dgvTestTypesList.Columns["TestTypeFees"].HeaderText = "Fees";
                dgvTestTypesList.Columns["TestTypeFees"].Width = 150;


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
             frmUpdateTestType updateForm = new frmUpdateTestType((clsTestType.enTestType) dgvTestTypesList.CurrentRow.Cells["TestTypeID"].Value);
             updateForm.ShowDialog();
             frmManageTestTypes_Load(null, null);
        }
    }
}
