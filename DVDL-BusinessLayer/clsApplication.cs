using DVDL_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsApplication
    {
        protected enum enMode { AddNew = 1, Update = 2 }

        protected enMode Mode;

        public enum enApplicationType {NewLocalDrivingLicense = 1 , RenewDrivingLicnes = 2 , ReplacementforLostDrivingLicense = 3 ,
            ReplacementforDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6,RetakeTest = 7}

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 }

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }

        // Try another way |Instead of put it in the constructer|
        public clsPerson PersonInfo 
        { 
            get 
            {
                return clsPerson.Find(ApplicantPersonID);
            } 
        }

        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        public DateTime LastStatusDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public enApplicationStatus ApplicationStatus;
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unkown";
                }
            }
        }
        public float PaidFees { get; set; }


        public clsApplication()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationTypeID = -1;
            CreatedByUserID = -1;
            ApplicationStatus = enApplicationStatus.New;
            PaidFees = 0f;
            Mode = enMode.AddNew;
        }

        protected clsApplication(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, int createdByUserID, DateTime lastStatusDate,
            enApplicationStatus applicationStatus, float paidFees)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationTypeID = applicationTypeID;
            this.LastStatusDate = lastStatusDate;
            this.ApplicationDate = applicationDate;
            ApplicationTypeInfo = clsApplicationType.Find(applicationTypeID);
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUser.Find(createdByUserID);
            ApplicationStatus = applicationStatus;
            PaidFees = paidFees;
            Mode = enMode.Update;
        }

        protected bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID, DateTime.Now, this.ApplicationTypeID,
                (int)this.ApplicationStatus, DateTime.Now, this.PaidFees, this.CreatedByUserID);

            return this.ApplicationID != -1;
        }

        protected bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, ApplicationDate, this.ApplicationTypeID,
                (int)this.ApplicationStatus, LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public virtual bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                if (_AddNewApplication())
                {
                    Mode = enMode.Update;
                    return true;
                }
                return false;
            }
            else if (Mode == enMode.Update)
            {
                return _UpdateApplication();
            }
            return false;
        }

        public static bool Cancle(int ApplicationID)
        {
            return clsApplicationData.UpdateStatus(ApplicationID,Convert.ToInt16(enApplicationStatus.Cancelled));
        }

        public static bool SetComplete(int ApplicationID)
        {
            return clsApplicationData.UpdateStatus(ApplicationID, Convert.ToInt16(enApplicationStatus.Completed));
        }

        public static clsApplication FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            int ApplicationTypeID = -1;
            int ApplicationStatus = -1;
            int CreatedByUserID = -1;
            DateTime LastStatusDate = DateTime.MinValue;
            DateTime ApplicationDate = DateTime.MinValue;
            float PaidFees = 0f;

            if (clsApplicationData.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID,
             ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, CreatedByUserID, LastStatusDate,
                    (enApplicationStatus)ApplicationStatus, PaidFees);
            }
            else
                return null;
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationData.DeleteApplication(ApplicationID);
        }

        public static bool IsApplicationExists(int ApplicationID) 
        {
            return clsApplicationData.IsApplicationExists(ApplicationID);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID,int ApplicationTypeID) 
        {
            return clsApplicationData.DoesPersonHasActiveApplication(PersonID, ApplicationTypeID);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID,int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplication.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID,LicenseClassID);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHasActiveApplication(ApplicantPersonID, ApplicationTypeID);
        }
        
        public static int GetActiveApplicationID( int PersonID,enApplicationType ApplicationType) 
        {
            return clsApplicationData.GetActiveApplicationID(PersonID,Convert.ToInt32(ApplicationType));
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, enApplicationType ApplicationType, int LiscenseClassID) 
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID,Convert.ToInt32(ApplicationType),LiscenseClassID);
        }

        public int GetActiveApplicationID(enApplicationType ApplicationType)
        {
            return clsApplicationData.GetActiveApplicationID(ApplicantPersonID, Convert.ToInt32(ApplicationType));
        }

    }
}
