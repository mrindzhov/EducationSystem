using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EducationSystem.Models.Accounts.AccountBindings
{
    // Models used as parameters to AccountController actions.

    public class AddExternalLoginDTO
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}