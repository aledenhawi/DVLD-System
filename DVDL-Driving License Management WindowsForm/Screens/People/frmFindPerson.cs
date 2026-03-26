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
    public partial class frmFindPerson : Form
    {
        public frmFindPerson()
        {
            InitializeComponent();
        }

        public delegate void DataBackHandler(object sender, int ID);

        public event DataBackHandler DataBack;

        private void button1_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrPersonDetailsWithFilter1.PersonID);
            this.Close();
        }
    }
}
