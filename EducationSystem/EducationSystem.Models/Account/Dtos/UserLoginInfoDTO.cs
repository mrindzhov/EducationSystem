using System;

namespace EducationSystem.Models.Account.Dtos
{
    public class UserLoginInfoDTO
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}