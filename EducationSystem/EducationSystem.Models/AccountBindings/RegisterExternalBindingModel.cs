using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EducationSystem.Models.AccountBindings
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}