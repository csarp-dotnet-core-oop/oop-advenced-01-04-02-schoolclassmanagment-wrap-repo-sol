using SchoolClassManagmentProject.Models;
using SchoolClassManagmentProject.Models.Entities;

namespace SchoolClassManagmentProject.Services
{
    public interface IManagementService
    {
        public void Enroll(string firstName, string lastName, byte grade, char gradeLetter);
        public void DropOut(string firstName, string lastName);
        public void SwitchClass(string firstName, string lastName, byte newGrade, char newGradeLetter);
        public void AdvanceAllGrades();

        public int GetNumberOfSchoolClasses();
        public int GetNumberOfStudents();
        public int GetNumberofWomanInSchoolClass(byte grade, char gradeLetter);
        public Dictionary<string,int> GetNumberofGender(byte grade, char gradeLetter);
        public Dictionary<SchoolClassId,int> GetNumberInSchoolClass(string grade, char gradeLetter);
        public Dictionary<SchoolClassId, List<Student>> GetStudentByClass(string grade, char gradeLetter);

    }
}
