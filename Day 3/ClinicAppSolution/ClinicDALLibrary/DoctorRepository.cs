using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDALLibrary
{
    internal class DoctorRepository : IRepositary<int, Doctor>
    {
        Dictionary<int, Doctor> doctors = new Dictionary<int, Product>();
        ///<summary>
        ///c
        ///</summary>
        ///<param name="doctor">Doctor object that has to be added</param>
        ///<returns>The doctor that has been added</returns>
        public Doctor Add(Doctor doctor)
        {
            int id = GetTheNextId();
            try
            {
                doctor.Id = id;
                doctors.Add(doctor.Id, doctor);
                return doctor;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("The Doctor ID aleady exists");
                Console.WriteLine(e.Message);
            }
            return null;
        }
        private int GetTheNextId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = products.Keys.Max();
            return ++id;
        }
        ///<summary>
        ///Deletes the doctor from the dictionary using the id as key
        ///</summary>
        ///<param name="id">The Id of the doctor to be deleted</param>
        ///<returns>The deleted doctor</returns>
        public Doctor Delete(int id)
        {
            var doctor = doctors[id];
            doctors.Remove(id);
            return doctor;
        }
        public List<Doctor> GetAll()
        {
            var doctorList = doctors.Values.ToList();
            return doctorList;
        }
        public Doctor GatById(int id)
        {
            if (doctors.ContainsKey(id))
                return doctors[id];
            return null;
        }
        public Doctor Update(Doctor doctor)
        {
            doctors[doctor.Id] = doctor;
            return doctors[doctor.Id];
        }
    }
}
