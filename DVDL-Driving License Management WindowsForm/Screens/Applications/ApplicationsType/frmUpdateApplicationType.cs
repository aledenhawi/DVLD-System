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
    public partial class frmUpdateApplicationType : Form
    {
        clsApplicationType _clsApplicationType;

        int _TypeID;
        bool IsValid;

        public frmUpdateApplicationType(int typeID)
        {
            InitializeComponent();
            _TypeID = typeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValid) 
            {
                MessageBox.Show("Please correct the errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _clsApplicationType.Title = txbTitle.Text.Trim();
            _clsApplicationType.Fees = Convert.ToSingle(txbFees.Text.Trim());

            if (_clsApplicationType.Save())
            {
                MessageBox.Show("Application Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed To Update Application Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _clsApplicationType = clsApplicationType.Find(_TypeID);

            if (_clsApplicationType != null)
            {
                lblApplicationTypeID.Text =  _clsApplicationType.ID.ToString();
                txbTitle.Text = _clsApplicationType.Title;
                txbFees.Text = _clsApplicationType.Fees.ToString();
            }
            else
            {
                MessageBox.Show("Application Type Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void txbFees_Validating(object sender, CancelEventArgs e)
        {
            if (!double.TryParse(txbFees.Text, out double fees) || fees < 0)
            {
                IsValid = false;
                errorProvider1.SetError(txbFees, "Please enter a valid non-negative number for fees.");
            }
            else if (string.IsNullOrEmpty(txbFees.Text)) 
            {
                IsValid = false;
                errorProvider1.SetError(txbFees, "Fees field cannot be empty.");
            }
            else
            {
                IsValid = true;
                errorProvider1.SetError(txbFees, "");
            }
        }

        private void txbTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbTitle.Text))
            {
                IsValid = false;
                errorProvider1.SetError(txbTitle, "Title field cannot be empty.");
            }
            else
            {
                IsValid = true;
                errorProvider1.SetError(txbTitle, "");
            }
        }
    }
}
