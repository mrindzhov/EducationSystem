using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EducationSystem.Dtos.Account
{
    public class AddExternalLoginDTO
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}