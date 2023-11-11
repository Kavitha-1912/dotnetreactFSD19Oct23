using System.Runtime.Serialization;

namespace ClinicBLLibrary
{
    [Serializable]
    internal class NoSuchDoctorException : Exception
    {
        string message;
        public NoSuchDoctorException()
        {
            message = "The doctor with the given id is not present";
        }
        public override string Message => message;
    }
}