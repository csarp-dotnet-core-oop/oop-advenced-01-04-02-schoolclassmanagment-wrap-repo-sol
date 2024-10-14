namespace SchoolClassManagmentProject.Models.AppExceptions
{
    [Serializable]
    internal class SchoolClassIsGraduatedException : Exception
    {
        public SchoolClassIsGraduatedException()
        {
        }

        public SchoolClassIsGraduatedException(string? message) : base(message)
        {
        }

        public SchoolClassIsGraduatedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}