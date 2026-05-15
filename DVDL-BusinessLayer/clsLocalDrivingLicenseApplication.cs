using DVDL_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode;

        public int LocalDrivingLicenseApplicationID { get; set; }

        public int LicenseClassID { get; set; }

        public clsLicenseClass LicenseClassInfo { get; set; }

        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
            _Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, int createdByUserID, DateTime lastStatusDate,
            enApplicationStatus applicationStatus, float paidFees, int _LocalDrivingLicenseApplicationsID, int _LicenseClassID) : base(applicationID, applicantPersonID, applicationDate, applicationTypeID, createdByUserID, lastStatusDate, applicationStatus, paidFees)
        {
            LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationsID;
            LicenseClassID = _LicenseClassID;
            LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            _Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(ApplicationID, LicenseClassID);

            return this.LocalDrivingLicenseApplicationID != -1;
        }

        private bool _Update()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, LicenseClassID);
        }

        public override bool Save()
        {
            if (base.Save())
            {
                if (_Mode == enMode.AddNew)
                {
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;
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
        public static bool DeleteLocalDrivingLicenseApplication(int ID)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = Find(ID);

            if(localDrivingLicenseApplication == null)
                return false;

            if (clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(ID))
                return clsApplication.DeleteApplication(localDrivingLicenseApplication.ApplicationID);
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

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID);

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
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }

        public clsTest GetLastTestPerTestType(clsTestType.enTestType TestTypeID) 
        {
            return clsTest.FindLastTestPerPersonIDAndLicenseClassID(this.ApplicantPersonID, this.LicenseClassID, TestTypeID);
        }

        public bool DoesPassedPreviousTestType(clsTestType.enTestType CurrentTestTypeID)
        {
            if (CurrentTestTypeID == clsTestType.enTestType.Vision)
                return true;

            CurrentTestTypeID = CurrentTestTypeID - 1 ;

            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID,(int)CurrentTestTypeID);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationsID)
        {
            return clsTestData.GetPassedTestCount(LocalDrivingLicenseApplicationsID);
        }

        public byte GetPassedTestCount()
        {
            return clsTestData.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return clsTest.PassedAllTests(LocalDrivingLicenseApplicationID);
        }

        public bool PassedAllTests()
        {
            return clsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }

        public static bool DoesPassedTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttentedTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool DoesAttentedTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public byte TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
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
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveSchduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public int IssueLicenseForTheFirstTime(string Notes,int CreatedByUserID) 
        {
            int DriverID = -1;

            if (!this.PassedAllTests())
                return -1;

            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                Driver = new clsDriver();
                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUser = this.CreatedByUserID;


                if (Driver.Save())
                    DriverID = Driver.DriverID;
                else
                    return -1;
            }
            else
                DriverID = Driver.DriverID;

            clsLicense license = new clsLicense();
            license.ApplicationID = this.ApplicationID;
            license.DriverID = DriverID;
            license.LicenseClass = this.LicenseClassID;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(LicenseClassInfo.DefualtValidityLength);
            license.Notes = Notes;
            license.PaidFees = LicenseClassInfo.Fees;
            license.IsActive = true;
            license.IssueReason = clsLicense.enIssueReason.FirstTime;
            license.CreatedByUserID = CreatedByUserID;

            if(license.Save())
            {
                SetComplete();
                return license.LicenseID;

            }
            else
                return -1;
        }
     
        public bool IsLicenseIssued()
        {
            return clsLicense.IsLicenseIssued(this.ApplicantPersonID, this.LicenseClassID);
        }

        public int GetActiveLicenseID() 
        {
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }

    }
}
