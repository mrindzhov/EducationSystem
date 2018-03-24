using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EducationSystem.Dtos.Account
{
    public class RegisterExternalDTO
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}