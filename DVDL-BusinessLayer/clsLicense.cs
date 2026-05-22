using DVDL_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsLicense
    {
        enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode;

        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 }

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo
        {
            get
            {
                return clsDriver.Find(DriverID);
            }
        }
        public int LicenseClass { get; set; }
        public clsLicenseClass LicenseClassInfo { get { return clsLicenseClass.Find(LicenseClass); } }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }

        public clsDetainedLicense DetainedLicenseInfo { get; set; }

        public bool IsDetained { get { return clsDetainedLicense.IsLicenseDetained(LicenseID); } }

        public string IssueReasonText
        {
            get
            {
                switch (IssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "First Time";
                    case enIssueReason.Renew:
                        return "Renew";
                    case enIssueReason.ReplacementForDamaged:
                        return "Replacement for Damaged";
                    case enIssueReason.ReplacementForLost:
                        return "Replacement for Lost";
                    default:
                        return "";
                }
            }
        }
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            CreatedByUserID = -1;
            LicenseClass = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = default;
            PaidFees = default;
            IsActive = false;
            IssueReason = default;
            _Mode = enMode.AddNew;

            DetainedLicenseInfo = null;
        }

        clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            _Mode = enMode.Update;

            DetainedLicenseInfo = clsDetainedLicense.FindByLicenseID(LicenseID);
        }

        private bool _AddNew()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID,
                this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (short)this.IssueReason, this.CreatedByUserID);

            return LicenseClass != -1;
        }

        private bool _Update()
        {
            return clsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate,
                this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (short)this.IssueReason, this.CreatedByUserID);
        }

        public bool Save()
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

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = null;
            float PaidFees = 0.0f;
            bool IsActive = false;
            short IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate,
                ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                    Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            return null;
        }

        public static bool IsLicenseIssued(int PesronID, int LicenseClass)
        {
            return GetActiveLicenseIDByPersonID(PesronID, LicenseClass) != -1;
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClass)
        {
            return clsLicenseData.GetActiveLicenseIDForPersonID(PersonID, LicenseClass);
        }

        public bool IsLicenseExpired()
        {
            return DateTime.Now > ExpirationDate;
        }

        public bool DeactivateCurrentLicense()
        {

            if (clsLicenseData.DeactivateLicense(this.LicenseID))
            {
                this.IsActive = false;
                return true;
            }
            return false;
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetAllDriverLicenses(DriverID);
        }

        public static string GetIssueReasonTest(enIssueReason issueReason)
        {
            switch (issueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.ReplacementForDamaged:
                    return "Replacement For Damaged";
                case enIssueReason.ReplacementForLost:
                    return "Replacement For Lost";
                default:
                    return string.Empty;
            }
        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {
            clsApplication RenewLicenseApplication = new clsApplication();

            RenewLicenseApplication.ApplicantPersonID = this.DriverInfo.PersonID;
            RenewLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            RenewLicenseApplication.ApplicationDate = DateTime.Now;
            RenewLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            RenewLicenseApplication.CreatedByUserID = CreatedByUserID;
            RenewLicenseApplication.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;

            if (!RenewLicenseApplication.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.DriverID = this.DriverID;
            NewLicense.ApplicationID = RenewLicenseApplication.ApplicationID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefualtValidityLength);
            NewLicense.IssueReason = clsLicense.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;
            NewLicense.IsActive = true;
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.Fees;
            NewLicense.LicenseClass = this.LicenseClass;

            if (!NewLicense.Save())
            {
                return null;
            }

            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsLicense RepleaceLicense(int CreatedByUser, int ApplicationTypeID)
        {
            clsApplication RepleacmentLicenseApplication = new clsApplication();

            RepleacmentLicenseApplication.ApplicantPersonID = this.DriverInfo.PersonID;
            RepleacmentLicenseApplication.ApplicationTypeID = ApplicationTypeID;
            RepleacmentLicenseApplication.ApplicationDate = DateTime.Now;
            RepleacmentLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            RepleacmentLicenseApplication.CreatedByUserID = CreatedByUserID;
            RepleacmentLicenseApplication.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;

            if (!RepleacmentLicenseApplication.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.DriverID = this.DriverID;
            NewLicense.ApplicationID = RepleacmentLicenseApplication.ApplicationID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.IssueReason = (clsApplication.enApplicationType)ApplicationTypeID == clsApplication.enApplicationType.ReplacementforDamagedDrivingLicense ?
                enIssueReason.ReplacementForDamaged : enIssueReason.ReplacementForLost;
            NewLicense.CreatedByUserID = CreatedByUserID;
            NewLicense.IsActive = true;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;
            NewLicense.LicenseClass = this.LicenseClass;

            if (!NewLicense.Save())
            {
                clsApplication.DeleteApplication(RepleacmentLicenseApplication.ApplicationID);
                return null;
            }

            DeactivateCurrentLicense();

            return NewLicense;
        }

        public int Detain(int DetaindByUserID, float FineFees)
        {
            if (IsDetained)
                return -1;

            clsDetainedLicense detainedLicense = new clsDetainedLicense();

            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.CreatedByUserID = this.CreatedByUserID;
            detainedLicense.FineFees = FineFees;
            detainedLicense.DetainDate = DateTime.Now;

            if (!detainedLicense.Save()) 
            {
                return -1;
            }

            this.DetainedLicenseInfo = detainedLicense;

            return detainedLicense.DetainID;
        }

        public bool ReleaseLicense(int ReleasedByUserID,ref int ApplicationID)
        {
            if (!IsDetained)
                return false;

            clsApplication ReleaseLicenseApplication = new clsApplication();

            ReleaseLicenseApplication.ApplicantPersonID = this.DriverInfo.PersonID;
            ReleaseLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            ReleaseLicenseApplication.ApplicationDate = DateTime.Now;
            ReleaseLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            ReleaseLicenseApplication.CreatedByUserID = ReleasedByUserID;
            ReleaseLicenseApplication.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;

            if (!ReleaseLicenseApplication.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = ReleaseLicenseApplication.ApplicationID;


            if(!DetainedLicenseInfo.ReleaseDetainedLicense(ReleasedByUserID,ApplicationID))
            {
                clsApplication.DeleteApplication(ReleaseLicenseApplication.ApplicationID);
                return false;
            }
            return true;
        }
    }
}
