using System.Runtime.Serialization;

namespace ClinicBLLibrary
{
    [Serializable]
    internal class NotAddedException : Exception
    {
        string message;
        public NotAddedException()
        {
            message = "Doctor was not added";
        }
        public override string Message => message;
    }
}