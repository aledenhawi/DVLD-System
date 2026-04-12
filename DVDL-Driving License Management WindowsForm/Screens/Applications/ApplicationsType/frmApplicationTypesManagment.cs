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

namespace DVDL_Driving_License_Management_WindowsForm.Screens.ApplicationsType
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }


       
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType updateForm = new frmUpdateApplicationType(Convert.ToInt32(dgvApplicationTypesList.CurrentRow.Cells["ApplicationTypeID"].Value));
            updateForm.ShowDialog();
            frmManageApplicationTypes_Load(null,null);
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            DataTable dtApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypesList.DataSource = dtApplicationTypes;

            lblTotalTypes.Text = dtApplicationTypes.Rows.Count.ToString();

            if (dgvApplicationTypesList.Rows.Count > 0)
            {
                dgvApplicationTypesList.Columns["ApplicationTypeID"].HeaderText = "ID";
                dgvApplicationTypesList.Columns["ApplicationTypeID"].Width = 110;

                dgvApplicationTypesList.Columns["ApplicationTypeTitle"].HeaderText = "Title";
                dgvApplicationTypesList.Columns["ApplicationTypeTitle"].Width = 500;

                dgvApplicationTypesList.Columns["ApplicationFees"].HeaderText = "Fees";
                dgvApplicationTypesList.Columns["ApplicationFees"].Width = 150;


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
