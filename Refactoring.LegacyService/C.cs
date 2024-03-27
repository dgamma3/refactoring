using System;

namespace Refactoring.LegacyService
{
    public class Candidate2
    {
        private string firstname;
        public string Firstname
        {
            get => firstname;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Firstname cannot be empty.");
                }
                firstname = value;
            }
        }

        private string surname;
        public string Surname
        {
            get => surname;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Surname cannot be empty.");
                }
                surname = value;
            }
        }

        private string emailAddress;
        public string EmailAddress
        {
            get => emailAddress;
            private set
            {
                if (!value.Contains("@") || !value.Contains("."))
                {
                    throw new ArgumentException("Invalid email address.");
                }
                emailAddress = value;
            }
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            private set
            {
                if (CalculateAge(value) < 18)
                {
                    throw new ArgumentException("Candidate must be at least 18 years old.");
                }
                dateOfBirth = value;
            }
        }

        public int PositionId { get; private set; }
        public Position Position { get; set; }
        public bool RequireCreditCheck { get; private set; }
        public int Credit { get; private set; }

        public Candidate(string firstname, string surname, string email, DateTime dateOfBirth, int positionId)
        {
            Firstname = firstname;
            Surname = surname;
            EmailAddress = email;
            DateOfBirth = dateOfBirth;
            PositionId = positionId;
        }

        public void AssignPosition(Position position)
        {
            Position = position;
        }

        public void PerformCreditCheck(Func<string, string, DateTime, int> creditCheckFunc)
        {
            var credit = creditCheckFunc(Firstname, Surname, DateOfBirth);
            if (Position != null && Position.Name == "SecuritySpecialist")
            {
                Credit = credit / 2;
            }
            else if (Position != null && Position.Name == "FeatureDeveloper")
            {
                Credit = credit;
            }

            RequireCreditCheck = true;
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
            {
                age--;
            }
            return age;
        }
    }
}
