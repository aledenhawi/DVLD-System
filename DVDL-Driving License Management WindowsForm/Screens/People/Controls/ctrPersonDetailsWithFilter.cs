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

namespace DVDL_Driving_License_Management_WindowsForm.User_Controls
{
    public partial class ctrPersonDetailsWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PersonID) 
        {
            Action<int> Handler = OnPersonSelected;

            if(Handler != null)
            Handler(PersonID);
        }

        private bool _AddNewVisablity = true;

        public bool AddNewVisablity 
        {
        set {
                _AddNewVisablity = value;
                btnAddPeson.Visible = value;
             }
            get { return _AddNewVisablity; }
        }

        private bool _FilterEnable = true;

        public bool FilterEnable { get { return _FilterEnable; } 
        set {
                _FilterEnable = value;
                groupBox1.Enabled = value;
            }
        }

        public int PersonID { get { return ctrPersonDetails2.PersonID; } }

        public clsPerson SelectedPersonInfo { get { return ctrPersonDetails2.SelectedPersonInfo; } }

        public ctrPersonDetailsWithFilter()
        {
            InitializeComponent();
            ctrPersonDetails2.ResetPersonInfo();
        }

        public void LoadPersonInfo(int PersonID) 
        {
            cmbFilterType.SelectedIndex = 0;
            txbFilterText.Text = PersonID.ToString();
            FindNow();
        }

        private void FindNow() 
        {
            switch (cmbFilterType.Text)     
            {
                case "PersonID":
                    ctrPersonDetails2.LoadPersonInfo(int.Parse(txbFilterText.Text));
                    break;
                case "NationalNumber" :
                    ctrPersonDetails2.LoadPersonInfo(txbFilterText.Text.ToString());
                    break;
                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnable)
                // Raise the event with a parameter
                OnPersonSelected(ctrPersonDetails2.PersonID);
        }
        private void btnAddPeson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form1 = new frmAddUpdatePerson();
            form1.ShowDialog();
            form1.DataBack += DataBackEvent; 
        }

        private void DataBackEvent(object obj , int ID) 
        {
            cmbFilterType.SelectedIndex = 0;
            txbFilterText.Text = ID.ToString();
            ctrPersonDetails2.LoadPersonInfo(ID);
        }

        public void FilterFocus() 
        {
            txbFilterText.Focus();
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some faileds are not valid!, put the mouse over the red icon to read more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FindNow();
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbFilterText.Text = "";
            txbFilterText.Focus();
        }

        private void txbFilterText_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrEmpty(txbFilterText.Text.Trim())) 
            {
                e.Cancel = true;
                errorProvider1.SetError(this.txbFilterText,"This faild is required.");
            }
            else 
            {
                errorProvider1.SetError(this.txbFilterText, null);
            }
        }

        private void ctrPersonDetailsWithFilter_Load(object sender, EventArgs e)
        {
            cmbFilterType.SelectedIndex = 0;
            txbFilterText.Focus();
        }

        private void txbFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFindPerson.PerformClick();

            if(cmbFilterType.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
