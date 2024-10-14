using SchoolClassManagmentProject.Models;
using SchoolClassManagmentProject.Models.AppExceptions;
using SchoolClassManagmentProject.Models.Entities;
using SchoolClassManagmentProject.Repos;

namespace SchoolClassManagmentProject.Services
{
    public class ManagementServices : IManagementService
    {
        private WrapRepo _wrapRepo;
        public ManagementServices(WrapRepo wrapRepo) 
        {
            _wrapRepo = wrapRepo;
        }
        public int GetNumberOfSchoolClasses()
        {      
            return _wrapRepo.SchoolClassRepo.NumberOfSchoolClasses;
        }

        public int GetNumberOfStudents()
        {
            return _wrapRepo.StudentRepo.NumberOfStudents;
        }

        public void AdvanceAllGrades()
        {
        }

        public void DropOut(string firstName, string lastName)
        {
        }

        public void Enroll(string lastName, string firstName, byte grade, char gradeLetter)
        {
            // Osztály megkeresése
            SchoolClass? foundSchoolClass=SearchSchoolClass(grade,gradeLetter);
            if (foundSchoolClass is null || foundSchoolClass == default(SchoolClass))
                throw new SchoolClassNotFoundException($"A {grade}.{gradeLetter} osztály nem létezik!");
            
            // Az osztály aktív vagy már végzett? Ha végzett nem kell felvenni.
            if (foundSchoolClass.IsGraduate)
                throw new SchoolClassIsGraduatedException($"A {foundSchoolClass.Name} osztály már végzett, nem lehet diákot beíratni!");
            
            // Diák megkeresése, ellenőrizni kell, hogy a diák még nincs osztályba besorolva.
            Student? foundStudent=SearchStudent(lastName,firstName);
            if (foundStudent is null || foundStudent == default(Student))
                throw new StudentIsNotFoundException($"A(z)  {firstName} {lastName} diák nem létezik!");
            if (foundStudent.HasSchoolClass)
                throw new StudentIsAlreadyInSchoolClassException($"A {firstName} {lastName}  már be van sorolva osztályba, nem lehet beírni!");
            
            // Megtalált diák esetén a diák osztálykódjának megadása
            foundStudent.AddToSchoolClass(grade, gradeLetter);
            // Az iskolai osztályba a tanulók közé fel kell venni a megtalált diákot
            foundSchoolClass.AddStudent(foundStudent);
        }

        public void SwitchClass(string lastName, string firstName, byte newGrade, char newGradeLetter)
        {
        }

        private SchoolClass? SearchSchoolClass(byte grade, char gradeLetter)
        {
            return _wrapRepo.SchoolClassRepo.SearchSchoolClass(grade, gradeLetter);
        }

        private Student? SearchStudent(string lastName, string firstName)
        {
            return _wrapRepo.StudentRepo.SearchStudent(firstName, lastName);
        }

        public int GetNumberofWomanInSchoolClass(byte grade, char gradeLetter)
        {
            return 0;
        }

        public Dictionary<string, int> GetNumberofGender(byte grade, char gradeLetter)
        {
            return new Dictionary<string, int>();
        }

        public Dictionary<SchoolClassId, int> GetNumberInSchoolClass(string grade, char gradeLetter)
        {
            return new Dictionary<SchoolClassId, int>();
        }

        public Dictionary<SchoolClassId, List<Student>> GetStudentByClass(string grade, char gradeLetter)
        {
            return new Dictionary<SchoolClassId, List<>();
        }
    }
}
