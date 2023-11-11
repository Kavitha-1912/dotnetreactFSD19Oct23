using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Clinic
{
    internal class ClinicHome
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Clinic");
            ClinicHome home = new ClinicHome();
            home.AdminActivities();
        }
        DoctorRepository docRepository;

        public ClinicHome()
        {
            docRepository = new DoctorRepository();
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
                        docRepository.Add();
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

        int GetDoctorId()
        {
            int id;
            Console.WriteLine("Please Enter Doctor ID : ");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

        private void UpdateDoctor()
        {
            int id = GetDoctorId();
            int choice;
            Console.WriteLine("Do you Want To Change Doctor's Experience or Mobile Number ? \nPress 1 for Experience\nPress 2 for Mobile Number");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1 || choice == 2)
                docRepository.Update(id, choice);
            else
                Console.WriteLine("Invalid choice!");
        }
        private void DeleteDoctor()
        {
            int id = GetDoctorId();
            docRepository.Delete(id);
        }

    }
}