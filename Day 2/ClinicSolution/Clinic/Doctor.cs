using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    internal class Doctor
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int experience { get; set; }
        public string phoneNumber { get; set; }

        public Doctor()
        {
            experience = 0;
        }
        public Doctor(int ID, string name, int experience, string phoneNumber)
        {
            this.ID = ID;
            this.name = name;
            this.experience = experience;
            this.phoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"Doctor Id : {ID}\nDoctor Name {name}\nExperience : { experience} years\nMobile Numer : { phoneNumber}";
        }
    }
}