using DVDL_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

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
            catch { }
        }

        public static bool RestoreUsernameAndPassword(ref string username,ref string password)
        {

            try 
            {
                password = Registry.GetValue(KeyPath, "Last_Password", null) as string;
                username = Registry.GetValue(KeyPath, "Last_Username", null) as string;
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
