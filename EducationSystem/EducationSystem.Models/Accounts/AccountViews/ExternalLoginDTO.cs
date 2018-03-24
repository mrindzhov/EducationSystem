namespace EducationSystem.Models.Accounts.AccountViews
{
    // Models returned by AccountController actions.

    public class ExternalLoginDTO
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }
}