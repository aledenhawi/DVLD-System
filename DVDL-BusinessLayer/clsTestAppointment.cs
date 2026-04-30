using DVDL_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsTestAppointment
    {
        enum enMode { AddNew, Update }

        enMode _Mode;

        public int TestAppointmentID { get; set; }

        public clsTestType.enTestType TestTypeID { get; set; }

        public int LocalDrivingLicenseApplicationID { get; set; }

        public int CreatedByUserID { get; set; }

        public DateTime AppoitmentDate { get; set; }

        public float PaidFees { get; set; }

        public bool IsLocked { get; set; }

        public int RetakeTestApplicationID { get; set; }

        public int TestID 
        {
            get   {return _GetTestID();}
        }

        public clsApplication RetakeTestApplication 
        {
            get 
            {
                if(RetakeTestApplicationID != -1)
                    return clsApplication.FindBaseApplication(RetakeTestApplicationID);
                else
                    return null;
            } 
        } 

        public clsTestAppointment()
        {
            RetakeTestApplicationID = -1;
            TestAppointmentID = -1;
            TestTypeID = clsTestType.enTestType.Written;
            LocalDrivingLicenseApplicationID = -1;
            CreatedByUserID = -1;
            AppoitmentDate = DateTime.Now;
            PaidFees = 0.0f;
            IsLocked = false;
            _Mode = enMode.AddNew;
        }

        clsTestAppointment(int appointmentID, int testTypeID, int localDrivingLicenseID, DateTime appoitmentDate, float paidFees, int CreatedByUserID, bool isLocked,int retakeTestApplicationID)
        {
            TestAppointmentID = appointmentID;
            TestTypeID = (clsTestType.enTestType)testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseID;
            AppoitmentDate = appoitmentDate;
            PaidFees = paidFees;
            IsLocked = isLocked;
            this.CreatedByUserID = CreatedByUserID;
            _Mode = enMode.Update;
            RetakeTestApplicationID = retakeTestApplicationID;
        }

        private bool _AddNew()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(Convert.ToInt32(this.TestTypeID), LocalDrivingLicenseApplicationID, AppoitmentDate, PaidFees, CreatedByUserID, IsLocked);
            return this.TestAppointmentID != -1;
        }

        private bool _Update()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, Convert.ToInt32(this.TestTypeID), this.LocalDrivingLicenseApplicationID, this.AppoitmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
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
            {
                return _Update();
            }
        }

        public static clsTestAppointment Find(int AppointmentID)
        {
            int TestTypeID = -1;
            int LocalDrivingLicenseID = -1;
            DateTime AppointmetDate = DateTime.Now;
            float paidFees = 0.0f;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;

            if (clsTestAppointmentData.GetTestAppointmentInfoByID(AppointmentID, ref TestTypeID, ref LocalDrivingLicenseID, ref AppointmetDate, ref paidFees, ref CreatedByUserID, ref IsLocked,ref RetakeTestApplicationID))

                return new clsTestAppointment(AppointmentID, TestTypeID, LocalDrivingLicenseID, AppointmetDate, paidFees, CreatedByUserID, IsLocked,RetakeTestApplicationID);
            else
                return null;
        }

        public static DataTable GetApplicatoinTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID,int TestType) 
        {
            return clsTestAppointmentData.GetApplicatonTestAppointmentsPerTestTypeID(LocalDrivingLicenseApplicationID,TestType);
        }
    
        public static clsTestAppointment FindLastTestAppointmentForLocalDrivingLiceseApplicatoin(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            int TestAppointmentID = -1;
            DateTime AppointmetDate = DateTime.Now;
            float paidFees = 0.0f;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;

            if(clsTestAppointmentData.GetLastTestAppointment(LocalDrivingLicenseApplicationID,TestTypeID,ref TestAppointmentID, ref AppointmetDate, ref paidFees, ref CreatedByUserID, ref IsLocked,ref RetakeTestApplicationID))
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmetDate, paidFees, CreatedByUserID, IsLocked,RetakeTestApplicationID);
            else
                return null;

        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }

        private int _GetTestID() 
        {
            return clsTestAppointmentData.GetTestID(this.TestAppointmentID);
        }
    }
}
