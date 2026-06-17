using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Screens;
using DVDL_Driving_License_Management_WindowsForm.Screens.Applications;
using DVDL_Driving_License_Management_WindowsForm.Screens.Applications.Release_License;
using DVDL_Driving_License_Management_WindowsForm.Screens.Basic;
using DVDL_Driving_License_Management_WindowsForm.Screens.Licenses.International_Licenses;
using DVDL_Driving_License_Management_WindowsForm.Screens.PeopleScreens;
using DVDL_Driving_License_Management_WindowsForm.Screens.TestAppointments;
using DVDL_Driving_License_Management_WindowsForm.Screens.Tests;
using DVDL_Driving_License_Management_WindowsForm.Screens.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL_Driving_License_Management_WindowsForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
