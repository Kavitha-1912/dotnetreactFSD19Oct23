namespace ClinicBLLibrary
{
    public class DoctorService : IDoctorService
    {
        IRepository<int, Doctor> repository;
        public DoctorService()
        {
            repository = new DoctorRepository();
        }
        /// <summary>
        /// Adds the doctor to the collection using the repository
        /// </summary>
        /// <param name="doctor">The doctor to be added</param>
        /// <returns></returns>
        /// <exception cref="NotAddedException">Doctor Id duplicated</exception>
        public Doctor AddDoctor(Doctor doctor)
        {
            var result=repository.Add(doctor);
            if(result != null)
                return result;
            throw new NotAddedException();
        }
        public Doctor Delete(int id)
        {
            var doctor = GetDoctor(id);
            if(doctor != null)
            {
                repository.Delete(id);
                return doctor;
            }
            throw new NoSuchDoctorException();
        }
        /// <summary>
        /// Returns the doctor for the given Id
        /// </summary>
        /// <param name="id">Id of the doctor to be returned</param>
        /// <returns></returns>
        /// <exception cref="NoSuchDoctorException">No doctor with the given Id</exception>
        public Doctor GetDoctor(int id)
        {
            var result = repository.GetById(id);
            return result == null ? throw new NoSuchDoctorException() : result;
        }
        public List<Doctors> GetDoctors()
        {
            var doctors = repository.getAll();
            if (doctors.Count != 0)
                return doctors;
            throw new NoDoctorsAvailableException();
        }
        public Doctor UpdateDoctorPhoneNumber(int id,string phoneNumber,string action)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                doctor.PhoneNumber = phoneNumber;
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }
        public Doctor UpdateDoctorExperience(int id,int  experience)
        {
            var doctor = GetDoctor(id);
            if(doctor!=null)
            {
                if (action == "add")
                {
                    doctor.experience += experience;
                }
                else if (action == "remove")
                {
                    doctor.experience -= experience;
                }
                else
                    throw new InValidUpdateActionException();
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException()
        }
    }
}