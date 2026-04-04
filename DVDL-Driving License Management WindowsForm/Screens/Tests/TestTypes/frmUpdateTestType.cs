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

namespace DVDL_Driving_License_Management_WindowsForm.Screens.Tests.TestTypes
{
    public partial class frmUpdateTestType : Form
    {
        clsTestType.enTestType _TypeID;
        bool IsValid;
        clsTestType _clsTestType;


        public frmUpdateTestType(clsTestType.enTestType TypeID)
        {
            InitializeComponent();
            _TypeID = TypeID;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                MessageBox.Show("Please correct the errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _clsTestType.Title = txbTitle.Text.Trim();
            _clsTestType.Description = txbDescription.Text.Trim();
            _clsTestType.Fees = Convert.ToSingle(txbFees.Text.Trim());

            if (_clsTestType.Save())
            {
                MessageBox.Show("Test Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed To Update Test Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _clsTestType = clsTestType.Find((clsTestType.enTestType) _TypeID);

            if (_clsTestType != null)
            {
                lblTestTypeID.Text = _clsTestType.ID.ToString();
                txbTitle.Text = _clsTestType.Title;
                txbDescription.Text = _clsTestType.Description;
                txbFees.Text = _clsTestType.Fees.ToString();
            }
            else
            {
                MessageBox.Show("Test Type Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void txbTitleAndDescription_Validating(object sender, CancelEventArgs e)
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
