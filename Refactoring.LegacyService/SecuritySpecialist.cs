namespace Refactoring.LegacyService
{
    public class SecuritySpecialist : Candidate
    {
        public SecuritySpecialist(string firstname, string surname, string email, DateTime dateOfBirth, int positionId)
            : base(firstname, surname, email, dateOfBirth, positionId) { }

        public override void PerformCreditCheck(Func<string, string, DateTime, int> creditCheckFunc)
        {
            var credit = creditCheckFunc(Firstname, Surname, DateOfBirth);
            Credit = credit / 2;
            RequireCreditCheck = true;
        }
    }
}FeatureDeveloper