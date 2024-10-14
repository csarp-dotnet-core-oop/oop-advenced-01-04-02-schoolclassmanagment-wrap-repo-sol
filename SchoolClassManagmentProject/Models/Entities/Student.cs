using SchoolClassManagmentProject.Models.AppExceptions;

namespace SchoolClassManagmentProject.Models.Entities
{
    public class Student
    {
        private string _lastName;
        private string _firstName;
        private DateTime _birthDate;
        private bool _gender;
        private string _email;
        private string _phone;
        
        private byte _grade;
        private char _gradeLetter;

        public Student()
        {
            _lastName = _firstName = _email = _phone = string.Empty;
            _grade = 0;
            _gradeLetter = 'z';
            _birthDate = new DateTime();
            _gender = false;
        }

        public Student(string lastName, string firstName, string email, string phone, DateTime birthDate, bool gender)
        {
            _lastName = lastName;
            _firstName = firstName;
            _email = email;
            _phone = phone;
            _birthDate = birthDate;
            _gender = gender;

            _grade = 0;
            _gradeLetter = 'z';

        }

        public Student(string lastName, string firstName, string phone, DateTime birthDate, bool gender)
        {
            _lastName = lastName;
            _firstName = firstName;
            _email = string.Empty;
            _phone = phone;
            _birthDate = birthDate;
            _gender = gender;

            _grade = 0;
            _gradeLetter = 'z';

        }
        public string EnglishFullName => _firstName + " " + _lastName;
        public string HungarianFullName => _lastName + " " + _firstName;
        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string Email { get => _email; private set => _email = value; }
        public string Phone { get => _phone; private set => _phone = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }
        public bool Gender { get => _gender; set => _gender = value; }
        public byte Age
        {
            get
            {
                if (DateTime.Now.DayOfYear > _birthDate.DayOfYear)
                    return (byte)(DateTime.Now.Year - _birthDate.Year);
                return (byte)(DateTime.Now.Year - _birthDate.Year - 1);
            }
        }
        public bool HasEmail => !string.IsNullOrEmpty(_email);
        public bool HasPhone => !string.IsNullOrEmpty(_phone);

        public bool HasSchoolClass => _grade != 0 && _gradeLetter != 'z';

        public void SetEmail(string newEmail)
        {
            if (newEmail == _email) 
                throw new NewEmailEqualsToOldOneException();
            else if (!newEmail.Contains('@'))
                throw new EmailDoesNotContainerAtException();
            else
                _email = newEmail;
        }
        public void SetPhone(string newPhone)
        {
            if (newPhone == _phone)
                throw new NewPhoneEqualsToOldOneException();
            else
                _phone = newPhone;
        }
        public void SetFirstName(string newName)
        {
            string allowedCharacters = "öüóqwertzuiopőúasdfghjkléáűíyxcvbnm- ";

            foreach (char letter in newName)
            {
                if (!allowedCharacters.Contains(char.ToLower(letter)))
                    throw new NotAllowedCharacterInNewNameException();
            }
           _firstName = newName;
        }

        public void AddToSchoolClass(byte grade, char gradeLetter)
        {
            _grade = grade;
            _gradeLetter = gradeLetter;
        }

        public void RemoveFromSchoolClass(byte grade, char gradeLetter)
        {
            _grade = 0;
            _gradeLetter = 'z';
        }

    }
}
