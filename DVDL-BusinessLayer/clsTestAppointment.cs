using DVDL_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsTestAppointment
    {
        enum enMode { AddNew, Update }

        enMode _Mode;


        public int AppointmentID { get; set; }

        public int TestTypeID { get; set; }

        public int LocalDrivingLicenseApplicationID { get; set; }

        public int CreatedByUserID { get; set; }

        public DateTime AppoitmentDate { get; set; }

        public float PaidFees { get; set; }

        public bool IsLocked { get; set; }

        public clsTestAppointment()
        {
            AppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            CreatedByUserID = -1;
            AppoitmentDate = DateTime.Now;
            PaidFees = 0.0f;
            IsLocked = false;
        }

        clsTestAppointment(int appointmentID, int testTypeID, int localDrivingLicenseID, DateTime appoitmentDate, float paidFees, int CreatedByUserID, bool isLocked)
        {
            AppointmentID = appointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseID;
            AppoitmentDate = appoitmentDate;
            PaidFees = paidFees;
            IsLocked = isLocked;
            this.CreatedByUserID = CreatedByUserID;
        }

        private bool _AddNew()
        {
            this.AppointmentID = clsTestAppointmentData.AddNewTestAppointment(this.TestTypeID, LocalDrivingLicenseApplicationID, AppoitmentDate, PaidFees, CreatedByUserID, IsLocked);
            return this.AppointmentID != -1;
        }

        private bool _Update()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.AppointmentID, this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppoitmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
        }

        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                _Mode = enMode.Update;
                return _AddNew();
            }
            else
            {
                return _Update();
            }
        }

        public static bool Delete(int AppointmentID)
        {
            return clsTestAppointmentData.DeleteTestAppointment(AppointmentID);
        }

        public static clsTestAppointment Find(int AppointmentID)
        {
            int TestTypeID = -1;
            int LocalDrivingLicenseID = -1;
            DateTime AppointmetDate = DateTime.Now;
            float paidFees = 0.0f;
            int CreatedByUserID = -1;
            bool IsLocked = false;

            if (clsTestAppointmentData.GetTestAppointmentInfoByID(AppointmentID, ref TestTypeID, ref LocalDrivingLicenseID, ref AppointmetDate, ref paidFees, ref CreatedByUserID, ref IsLocked))

                return new clsTestAppointment(AppointmentID, TestTypeID, LocalDrivingLicenseID, AppointmetDate, paidFees, CreatedByUserID, IsLocked);
            else
                return null;
        }

        public static bool IsExist(int AppointmentID)
        {
            return clsTestAppointmentData.IsTestAppointmentExists(AppointmentID);
        }

        public static DataTable GetAllTestAppointmentsForLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID,int TestType) 
        {
            return clsTestAppointmentData.GetAllTestAppointmentsForLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID,TestType);
        }
    }
}
