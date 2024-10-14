
namespace SchoolClassManagmentProject.Repos
{
    public class WrapRepo
    {
        // becsomagoló -> becsomagolja az összes repository-t

        private StudentRepo _studentRepo;
        private SchoolClassRepo _schoolClassRepo;

        public WrapRepo()
        {
            _schoolClassRepo = new SchoolClassRepo();
            _studentRepo = new StudentRepo();
        }

        public WrapRepo(StudentRepo studentRepo, SchoolClassRepo schoolClassRepo)
        {
            _studentRepo = studentRepo;
            _schoolClassRepo = schoolClassRepo;
        }

        public StudentRepo StudentRepo => _studentRepo;
        public SchoolClassRepo SchoolClassRepo => _schoolClassRepo;

    }
}
