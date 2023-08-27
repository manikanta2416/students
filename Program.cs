using System;
using DBFirstCore.DataAccessLayer;
using DBFirstCore.DataAccessLayer.Models;

namespace PolyclinicApp.ConsoleApp
{
    public class Program
    {
        static PolyClinicDBContext context;
        static PolyClinicRepository repository;

        static Program()
        {
            context = new PolyClinicDBContext();
            repository = new PolyClinicRepository(context);
        }

        static void Main(string[] args)
        {
            //TestAddNewPatientDetails(); 
            //TestCalculateDoctorFees();  
            //TestCancelAppointment();
            //TestFetchAllAppointments(); 
            //TestGetDoctorAppointmentUsingUSP();  
            //TestGetPatientDetails(); 
            TestUpdatePatientAge(); 

        }

        #region TestAddNewPatientDetails
        public static void TestAddNewPatientDetails()
        {
            //Patients patientObj = new Patients();

            //patientObj.PatientId = "P113";
            //patientObj.PatientName = "Joseph Kuruvila";
            //patientObj.Age = 26;
            //patientObj.Gender = "M";
            //patientObj.ContactNumber = "7540432730";

            bool result = repository.AddPatientDetails("P114", "soniya", 22, "f", "9876543210");
            if (result)
            {
                Console.WriteLine("New Patient Details added successfully and PatientId");
            }
            else
            {
                Console.WriteLine("Something went wrong. Try again!");
            }

        }
        #endregion

        #region TestCalculateDoctorFees
        public static void TestCalculateDoctorFees()
        {
            //    decimal result = repository.CalculateDoctorFees("D2", new DateTime(2023, 01, 02));

            //    if (result > 0)
            //    {
            //        Console.WriteLine("The fees of the doctor  is calculated successfully and the charge is Rs." + result + " only.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Something went wrong. Try again! Enter a valid DoctorId.");
            //    }
        }
        #endregion

        #region TestCancelAppointment
        public static void TestCancelAppointment()
        {
            int result = repository.CancelAppointment(4);

            if (result > 0)
            {
                Console.WriteLine("The appointment is cancelled successfully.");
            }

            else
            {
                Console.WriteLine("The appointmentNo is not available or some error occured during cancelling.");
            }


        }
        #endregion

        #region TestFetchAllAppointments
        public static void TestFetchAllAppointments()
        {

            var appointments = repository.FetchAllAppointments("D1", new DateTime(2022, 12, 30));
            if (appointments == null || appointments.Count == 0)
            {
                Console.WriteLine("no appointments avaiable under the given category");
            }
            else
            {
                foreach (var meet in appointments)
                {
                    Console.WriteLine("{0,-15}{1,-15}{2,-10}{3,-15}{4}", meet.DoctorName, meet.Specialization, meet.PatientId, meet.PatientName, meet.AppointmentNo);
                }
            }
        }
        #endregion

        #region TestGetDoctorAppointmentUsingUSP
        public static void TestGetDoctorAppointmentUsingUSP()
        {
            int appointmentNo = 0;
            int returnResult = repository.GetDoctorAppointment("P105", "D1", DateTime.Today, out appointmentNo);

            if (returnResult > 0)
            {
                Console.WriteLine("Appointment placed successfully and AppointmentNo = " + appointmentNo + ".");
            }
            else
            {
                Console.WriteLine("Some error occurred. Try again!");
            }
        }
        #endregion

        #region TestGetPatientDetails
        public static void TestGetPatientDetails()
        {
            var patientDetails = repository.GetPatientDetails();
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-10}{1,-15}{2,-5}{3,-10}{4,-15}", "PatientID", "PatientName", "Age", "Gender", "ContactNumber");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            //Console.WriteLine("{0,-10}{1,-15}{2,-5}{3,-10}{4,-15}", patientDetails.PatientId, patientDetails.PatientName, patientDetails.Age, patientDetails.Gender, patientDetails.ContactNumber);
            foreach (var patient in patientDetails)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", patient.PatientId, patient.PatientName, patient.Age, patient.Gender, patient.ContactNumber);
            }
        }
        #endregion

        #region TestUpdatePatientAge
        public static void TestUpdatePatientAge()
        {
            bool result = repository.UpdatePatientAge("P113", 21);

            if (result)
            {
                Console.WriteLine("The age of the patient is updated successfully.");
            }
            else
            {
                Console.WriteLine("Something went wrong. Try again!");
            }
        }
        #endregion

    }
}