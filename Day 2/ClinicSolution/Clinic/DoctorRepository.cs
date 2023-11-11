using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    internal class DoctorRepository
    {
        List<Doctor> Doctors;

        public DoctorRepository()
        {
            Doctors = new List<Doctor>();
        }

        int getNextDoctorId()
        {
            if (Doctors.Count == 0)
                return 1;
            int id = Doctors[Doctors.Count - 1].ID;
            return id + 1;
        }

        Doctor getDoctorById(int id)
        {
            for (int i = 0; i < Doctors.Count; i++)
            {
                if (Doctors[i].ID == id)
                    return Doctors[i];
            }
            return null;
        }

        public void Add()
        {
            int id = getNextDoctorId();
            Doctor doctor = new Doctor();
            doctor.ID = id;
            getOtherDetails(doctor);
            Doctors.Add(doctor);
            Console.WriteLine("New Doctor is Added Successfully");
        }

        public void getOtherDetails(Doctor doctor)
        {
            Console.WriteLine("Enter Doctor Name : ");
            doctor.name = Console.ReadLine();
            Console.WriteLine("Enter The Experience(In Years) : ");
            doctor.experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Doctor's Mobile Number : ");
            doctor.phoneNumber = Console.ReadLine();
        }

        public void Update(int id, int choice)
        {

            Doctor doctor = getDoctorById(id);
            if (doctor != null)
            {
                if (choice == 1)
                {
                    Console.WriteLine("Enter the Updated Experience(In Years) : ");

                    int exp = Convert.ToInt32(Console.ReadLine());
                    doctor.experience = exp;
                    Console.WriteLine("Updated Successfully!");
                    return;
                }
                else
                {
                    Console.WriteLine("Enter New Mobile Number : ");
                    string Number = Console.ReadLine();
                    doctor.phoneNumber = Number;
                    Console.WriteLine("Updated Successfully!");
                    return;
                }
            }
            Console.WriteLine("Invalid ID");
        }

        public void Delete(int id)
        {
            Doctor doctor = getDoctorById(id);
            if (doctor != null)
            {
                Doctors.Remove(doctor);
                Console.WriteLine("Successfully deleted!");
            }
            else
                Console.WriteLine("Can't Delete!");
        }

        public List<Doctor> getDoctorsDetails()
        {
            return Doctors;
        }

    }
}