namespace SchoolClassManagmentProject.Models.AppExceptions
{
    [Serializable]
    internal class SchoolClassNotFoundException : Exception
    {
        public SchoolClassNotFoundException()
        {
        }

        public SchoolClassNotFoundException(string? message) : base(message)
        {
        }

        public SchoolClassNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}