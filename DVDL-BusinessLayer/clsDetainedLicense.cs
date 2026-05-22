using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsDetainedLicense
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode;
        public int DetainID { get; set; }
        public int LicenseID { get; set; }

        public DateTime DetainDate { get; set; }

        public float FineFees { get; set; }

        public int CreatedByUserID { get; set; }

        public clsUser CreatedByUserInfo { get { return clsUser.Find(CreatedByUserID); } }

        public bool IsReleased { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int ReleasedByUserID { get; set; }

        public clsUser ReleasedByUserInfo { get { return clsUser.Find(ReleasedByUserID); } }

        public int ReleaseApplicationID { get; set; }

        public clsDetainedLicense(int detainID, int licenseID, DateTime detainDate, float fineFees,
            int createdByUserID, bool isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
            _Mode = enMode.Update;
        }

        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;

            DetainDate = DateTime.Now;

            FineFees = 0.0f;

            CreatedByUserID = -1;

            IsReleased = false;

            ReleaseDate = default;

            ReleasedByUserID = -1;

            ReleaseApplicationID = -1;

            _Mode = enMode.AddNew;
        }

        private bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDetainedLicenseData.AddNewDetainLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased);

            return this.DetainID != -1;
        }

        private bool _Update()
        {
            return clsDetainedLicenseData.UpdateDetainedLicense(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees,
                this.CreatedByUserID);
        }

        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                if (_AddNewDetainedLicense())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return _Update();
            }
        }

        public static clsDetainedLicense Find(int DetainID)
        {
            int licenseID = -1;
            DateTime detainDate = default;
            float fineFees = 0f;
            int CreatedByUserID = -1;
            bool isReleased = false;
            DateTime releaseDate = default;
            int releasedByUserID = -1;
            int releaseApplicationID = -1;

            if (clsDetainedLicenseData.GetDetainedLicenseInfoByID(DetainID, ref licenseID, ref detainDate, ref fineFees, ref CreatedByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
            {
                return new clsDetainedLicense(DetainID, licenseID, detainDate, fineFees, CreatedByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            }
            else
                return null;
        }

        public static clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            int DetainID = -1;
            DateTime detainDate = default;
            float fineFees = 0f;
            int CreatedByUserID = -1;
            bool isReleased = false;
            DateTime releaseDate = default;
            int releasedByUserID = -1;
            int releaseApplicationID = -1;

            if (clsDetainedLicenseData.GetDetainedLicenseInfoByLicenseID(LicenseID, ref DetainID, ref detainDate, ref fineFees, ref CreatedByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
            {
                return new clsDetainedLicense(DetainID, LicenseID, detainDate, fineFees, CreatedByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            }
            else
                return null;
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDetainedLicenseData.ReleaseDetainedLicense(this.DetainID, ReleasedByUserID, ReleaseApplicationID);
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }

        public static DataTable GetAllDetainedLicense() { return clsDetainedLicenseData.GetAllDetainedLicenses(); }

    }
}
