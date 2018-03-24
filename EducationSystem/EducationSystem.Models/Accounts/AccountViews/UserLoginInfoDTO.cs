using System;

namespace EducationSystem.Models.Accounts.AccountViews
{
    public class UserLoginInfoDTO
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}