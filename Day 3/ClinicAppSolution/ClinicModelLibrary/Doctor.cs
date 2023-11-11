namespace ClinicModelLibrary
{
    public class Doctor
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public int experience { get; set; }
        public string phoneNumber { get; set; } = string.Empty;
        public string specification { get; set; } = string.Empty;
        public object Id { get; private set; }

        public Doctor()
        {
            id = 0;
            name = string.Empty;
            experience = 0;
            phoneNumber = string.Empty;
            specification = string.Empty;
        }
        ///<summary>
        ///Construct the doctor object
        ///</summary>
        ///<param name="id"></param>
        ///<param name="name"></param>
        ///<param name="experience"></param>
        ///<param name="phoneNumber"></param>
        ///<param name="specification"></param>
        public Doctor(int id,string name,int experience,string phoneNumber,string specifiaction)
        {
            Id = id;
            Name = name;
            Experience = experience;
            PhoneNumber = phoneNumber;
            Specification = specifiaction;
        }
        public override string ToString()
        {
            return $Doctor ID :{ Id}\nDoctor Name:{ Name}\nDoctor Experience :{ Experience}\nDoctor Phone Number: { PhoneNumber}\nDoctor Specification :{ Specification};
        }
    }
}