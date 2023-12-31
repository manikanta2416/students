﻿using DBFirstCore.DataAccessLayer.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DBFirstCore.DataAccessLayer
{
    public class PolyClinicRepository
    {
        private PolyClinicDBContext context;
        public PolyClinicRepository(PolyClinicDBContext context)
        {
            this.context = context;
        }


        public List<Patients> GetPatientDetails()
        {
            var PatientsList = context.Patients.ToList();
            return PatientsList;
        }

        public bool AddPatientDetails(string PatientId, string PatientName, byte Age, string Gender, string ContactNumber)
        {
            bool status = false;
            Patients patient = new Patients();
            patient.PatientId = PatientId;
            patient.PatientName = PatientName;
            patient.Age = Age;
            patient.Gender = Gender;
            patient.ContactNumber = ContactNumber;
            try
            {
                context.Patients.Add(patient);
                context.SaveChanges();
                status = true;

            }
            catch (Exception)
            {
                status = false;
            }
            return status;

        }

        public bool UpdatePatientAge(string PatientId, byte newAge)
        {
            bool status = false;
            Patients patients = context.Patients.Find(PatientId);
            try
            {
                if (patients != null)
                {
                    patients.Age = newAge;
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public int CancelAppointment(int AppointmentNo)
        {
            Appointments appointment = new Appointments();
            int result = -1;
            try
            {
                appointment = context.Appointments.Find(AppointmentNo);
                if(appointment != null)
                {
                    context.Appointments.Remove(appointment);
                    context.SaveChanges();
                    result = 1;
                }

                else
                {
                    result = -1;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                result = -99;
            }
            return result;
        }

        public List<AppointmentDetails> FetchAllAppointments(string DoctorID, DateTime DateOfAppointment)
        {
            List<AppointmentDetails> lstAppointment =null;
            try
            {
                SqlParameter prmDoctorID = new SqlParameter("@DoctorID", DoctorID);
                SqlParameter prmDateOfAppointment = new SqlParameter("@DateOfAppointment", DateOfAppointment);

                lstAppointment = context.AppointmentDetails.FromSqlRaw("SELECT * FROM ufn_FetchAllAppointments(@DoctorID,@DateOfAppointment)",
                                                        prmDoctorID, prmDateOfAppointment).ToList();
            }
            catch (Exception ex)
            {
                lstAppointment = null;
                Console.WriteLine(ex.Message);
                throw;
            }
            return lstAppointment;
        }

        public int GetDoctorAppointment(string PatientID,string DoctorID, DateTime DateOfAppointment, out int AppointmentNo)
        {
            AppointmentNo = 0;
            //int noOfRowsAffected = 0;
            int returnResult = 0;
            SqlParameter prmPatientID = new SqlParameter("@PatientID", PatientID);
            SqlParameter prmDoctorID = new SqlParameter("@DoctorID", DoctorID);
            SqlParameter prmDateOfAppointment = new SqlParameter("@DateOfAppointment", DateOfAppointment);
            SqlParameter prmAppointmentNo = new SqlParameter("@AppointmentNo", System.Data.SqlDbType.TinyInt);
            prmAppointmentNo.Direction = System.Data.ParameterDirection.Output;
            SqlParameter prmReturnResult = new SqlParameter("@ReturnResult", System.Data.SqlDbType.Int);
            prmReturnResult.Direction = System.Data.ParameterDirection.Output;
            try
            {
                AppointmentNo = context.Database.ExecuteSqlInterpolated($"EXEC {prmReturnResult} = usp_GetDoctorAppointment @PatientID={prmPatientID},@DoctorID={prmDoctorID}, @DateOfAppointment={prmDateOfAppointment}, @AppointmentNo={prmAppointmentNo} OUTPUT");
                returnResult = Convert.ToInt32(prmReturnResult.Value);
                //AppointmentNo = Convert.ToInt32(prmAppointmentNo.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                AppointmentNo = 0;
                returnResult = -99;
            }
            return returnResult;
        }



    }
}

