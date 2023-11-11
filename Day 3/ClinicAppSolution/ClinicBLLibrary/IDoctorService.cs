using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBLLibrary
{
    internal interface IDoctorService
    {
        public Doctor AddDoctor(Doctor doctor);
        public Doctor UpdateDoctorExperience(int id, int experience);
        public Doctor GetDoctor(int id);
        public List<Doctor> GetDoctors();
        public Doctor UpdatePhoneNumber(int id, string phoneNumber, string action);
        public Doctor Delete(int id);
    }
}
