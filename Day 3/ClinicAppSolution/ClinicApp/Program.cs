using ClinicModelLibrary;
using ClinicBLLibrary;
using ClinicDALLibrary;
using System.Xml.Xsl;
namespace ClinicApp
{
    internal class Program
    {
        IDoctorService doctorService;
        public Program()
        {
            doctorService = new DoctorService();
        }
        void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Doctor's Details");
            Console.WriteLine("2. Update Doctor's Details");
            Console.WriteLine("3. Delete Doctor's Details");
            Console.WriteLine("4. Show All Doctors details");
            Console.WriteLine("0. Exit");
        }
        void AdminActivities()
        {
            int choice;
            do
            {
                DisplayAdminMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Thank you!!!");
                        break;
                    case 1:
                        AddDoctor();
                        break;
                    case 2:
                        UpdateDoctor();
                        break;
                    case 3:
                        DeleteDoctor();
                        break;
                    case 4:
                        ShowDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid choice \n Please choose the correct option");
                        break;
                }
            } while (choice != 0);
        }
        private void ShowDetails()
        {
            Console.WriteLine("--------------------------------------");
            var details = docRepository.getDoctorsDetails();
            foreach (var detail in details)
            {
                Console.WriteLine(detail);
                Console.WriteLine("---------------------------------------");
            }
            Console.WriteLine("********************************************");
        }
        void AddDoctor()
        {
            try
            {
                Doctor doctor = TakeDoctorDetails();
                var result = doctorService.AddDoctor(doctor);
                if(result != null)
                {
                    Console.WriteLine("Doctor Added");
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        Doctor TakeDoctorDetails()
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("Enter doctor's Name");
            doctor.name = Console.ReadLine();
            Console.WriteLine("Enter doctor's Experience");
            doctor. expeerience=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter doctor's Mobile number");
            doctor.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter doctor's Specification");
        }
        int GetDoctorIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the Doctor ID ");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        private void DeleteDoctor()
        {
            try
            {
                int id = GetDoctorIdFromUser();
                if (doctorService.Delete(id) != null)
                    Console.WriteLine("Doctor deleted");
            }
            catch(NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void UpdateDoctor()
        {
            var id = GetDoctorIdFromUser();
            int choice;
            Console.WriteLine("Do you Want To Change Doctor's Experience or Mobile Number ? \nPress 1 for Experience\nPress 2 for Mobile Number");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1 || choice == 2)
                doctorRepository.Update(id, choice);
            else
                Console.WriteLine("Invalid choice!");
            try
            {
                var result = doctorService.UpdateDoctor(id, experience);
                var result2 = doctorService.UpdateDoctoe(id, phoneNumber);
            }
            catch(NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static int Main(string[] args)
        {
            Program program = new Program();
            program.DisplayAdminMenu();
            return 0;
        }
    }
}