using System.Collections.Generic;

namespace EducationSystem.Dtos.Account
{
    public class ManageInfoDTO
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoDTO> Logins { get; set; }

        public IEnumerable<ExternalLoginDTO> ExternalLoginProviders { get; set; }
    }
}