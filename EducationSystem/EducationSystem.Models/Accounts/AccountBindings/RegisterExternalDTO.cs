using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EducationSystem.Models.Accounts.AccountBindings
{
    public class RegisterExternalDTO
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}