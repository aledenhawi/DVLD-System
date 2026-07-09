using DVDL_BusinessLayer;
using DVDL_Driving_License_Management_WindowsForm.Global_Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Classes
{
    public class clsGlobal
    {
        
        public static clsUser CurrentUser = null;

        public static string KeyPath = @"HKEY_CURRENT_USER\Software\DVLD_Configuration";

        public static void RememberUsernameAndPassword(string username, string password)
        {

            if (username == null || password == null)
            {
                Registry.SetValue(KeyPath, "Last_Password", null);
                Registry.SetValue(KeyPath, "Last_Username", null);
                return;
            }

            try
            {
                Registry.SetValue(KeyPath, "Last_Password", password);
                Registry.SetValue(KeyPath, "Last_Username", username);
            }
            catch (Exception ex) 
            {
                clsLoger.LogError("Registry error", ex);
            }
        }

        public static bool RestoreUsernameAndPassword(ref string username,ref string password)
        {

            try 
            {
                password = Registry.GetValue(KeyPath, "Last_Password", null) as string;
                username = Registry.GetValue(KeyPath, "Last_Username", null) as string;
                return true;
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Restoring Username and Password Faild", ex);
                return false;
            }
        }
    }
}
