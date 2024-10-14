using SchoolClassManagmentProject.Models.Entities;

namespace SchoolClassManagmentProject.Repos
{
    public partial class SchoolClassRepo
    {
        public List<SchoolClass> GetSchoolClassesPerGrade(int grade)
        {
            return _schoolClasses.Where(schoolClass => schoolClass.Grade == grade).ToList();
        }

        public List<SchoolClass> GetGraduateClasses()
        {
            return _schoolClasses.Where(schoolClass => schoolClass.IsGraduate).ToList();
        }

        public List<byte> GetGrades()
        {
            return _schoolClasses.Select(schoolClass => schoolClass.Grade).Distinct().ToList();
        }

        public List<Student> GetStudentByClass(byte grade, char gradeLetter)
        {
            return _schoolClasses.FirstOrDefault(schoolClass => schoolClass.Grade == grade && schoolClass.GradeLetter == gradeLetter)?.GetStudents() ?? new List<Student>();
        }
    }
}
