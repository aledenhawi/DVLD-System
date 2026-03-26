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

namespace DVDL_Driving_License_Management_WindowsForm.Screens.PeopleScreens
{
    public partial class frmPersonDetails : Form
    {
        public frmPersonDetails(int ID)
        {
            InitializeComponent();
            ctrPersonDetails1.LoadPersonInfo(ID);
        }
        public frmPersonDetails(string NationalNumber)
        {
            InitializeComponent();
            ctrPersonDetails1.LoadPersonInfo(NationalNumber);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
