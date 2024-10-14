namespace SchoolClassManagmentProject.Models.AppExceptions
{
    [Serializable]
    internal class StudentIsNotFoundException : Exception
    {
        public StudentIsNotFoundException()
        {
        }

        public StudentIsNotFoundException(string? message) : base(message)
        {
        }

        public StudentIsNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}