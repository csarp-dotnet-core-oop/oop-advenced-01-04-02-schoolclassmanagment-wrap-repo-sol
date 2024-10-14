namespace SchoolClassManagmentProject.Models.AppExceptions
{
    [Serializable]
    internal class StudentIsAlreadyInSchoolClassException : Exception
    {
        public StudentIsAlreadyInSchoolClassException()
        {
        }

        public StudentIsAlreadyInSchoolClassException(string? message) : base(message)
        {
        }

        public StudentIsAlreadyInSchoolClassException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}