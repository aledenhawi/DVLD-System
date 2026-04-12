using DVDL_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode;

        // Check it Later
        public int PassedTest { get; set; }

        public int LocalDrivingLicenseApplicationsID { get; set; }

        public int LicenseClassID { get; set; }

        public clsLicenseClasses LicenseClass { get; set; }

        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationsID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
            _Mode = enMode.AddNew;
            PassedTest = 0;
        }

        private clsLocalDrivingLicenseApplication(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, int createdByUserID, DateTime lastStatusDate,
            enApplicationStatus applicationStatus, float paidFees, int _LocalDrivingLicenseApplicationsID, int _LicenseClassID) : base(applicationID, applicantPersonID, applicationDate, applicationTypeID, createdByUserID, lastStatusDate, applicationStatus, paidFees)
        {
            LocalDrivingLicenseApplicationsID = _LocalDrivingLicenseApplicationsID;
            LicenseClassID = _LicenseClassID;
            LicenseClass = clsLicenseClasses.Find(LicenseClassID);
            _Mode = enMode.Update;
            // Check it Later
            PassedTest = clsLocalDrivingLicenseApplicationData.GetPassedTest(_LocalDrivingLicenseApplicationsID);
        }

        private bool _AddNew()
        {
            this.LocalDrivingLicenseApplicationsID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(ApplicationID, LicenseClassID);

            return this.LocalDrivingLicenseApplicationsID != -1;
        }

        private bool _Update()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationsID, LicenseClassID);
        }

        public override bool Save()
        {
            base.Mode = (clsApplication.enMode)_Mode;
            if (base.Save())
            {
                if (_Mode == enMode.AddNew)
                {
                    _Mode = enMode.Update;
                    return _AddNew();
                }
                else
                    return _Update();
            }
            return false;
        }

        public static bool DeleteLocalDrivingLicenseApplication(int ID, int ApplicationID)
        {
            if (clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(ID))
                return clsApplication.DeleteApplication(ApplicationID);
            else
                return false;
        }

        public static clsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                clsApplication application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication(application.ApplicationID, application.ApplicantPersonID, application.ApplicationDate, application.ApplicationTypeID, application.CreatedByUserID,
                    application.LastStatusDate, application.ApplicationStatus, application.PaidFees, LocalDrivingLicenseApplicationID, LicenseClassID);

            }
            else
                return null;

        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            int LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                clsApplication application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication(application.ApplicationID, application.ApplicantPersonID, application.ApplicationDate, application.ApplicationTypeID, application.CreatedByUserID,
                    application.LastStatusDate, application.ApplicationStatus, application.PaidFees, LocalDrivingLicenseApplicationID, LicenseClassID);

            }
            else
                return null;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public bool DoesPassedTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationsID, (int)TestTypeID);

        }

        public bool DoesPassedPrivousTestType(clsTestType.enTestType CurrentTestTypeID)
        {
            int TestTypeID = ((int)CurrentTestTypeID - 1) > 0 ? (int)CurrentTestTypeID - 1 : 1;
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationsID, TestTypeID);
        }

        public static bool DoesPassedTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttentedTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationsID, (int)TestTypeID);
        }

        public static bool DoesAttentedTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public byte TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationsID, (int)TestTypeID);
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool IsThereAnActiveSchduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveSchduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool IsThereAnActiveSchduledTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveSchduledTest(LocalDrivingLicenseApplicationsID, (int)TestTypeID);
        }

        ////////// Another Methods will be added later
    }
}
