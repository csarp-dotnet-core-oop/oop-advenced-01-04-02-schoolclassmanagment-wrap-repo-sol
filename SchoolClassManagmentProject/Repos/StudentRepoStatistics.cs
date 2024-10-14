using SchoolClassManagmentProject.Models.Entities;

namespace SchoolClassManagmentProject.Repos
{
    public partial class StudentRepo
    {
        public int NumberOfStudentsWithoutEmail => StudentsWithoutEmail.Count;
        public int NumberOfAdultStudents => AdultStudents.Count;
        public int NumberOfStudents  => _students.Count;

    }
}
