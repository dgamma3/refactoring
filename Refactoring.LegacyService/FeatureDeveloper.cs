namespace Refactoring.LegacyService
{
    public class FeatureDeveloper : Candidate
    {
        public FeatureDeveloper(string firstname, string surname, string email, DateTime dateOfBirth, int positionId)
            : base(firstname, surname, email, dateOfBirth, positionId) { }

        public override void PerformCreditCheck(Func<string, string, DateTime, int> creditCheckFunc)
        {
            Credit = creditCheckFunc(Firstname, Surname, DateOfBirth);
            RequireCreditCheck = true;
        }
    }
}