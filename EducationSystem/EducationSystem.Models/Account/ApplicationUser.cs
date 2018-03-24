using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using EducationSystem.Models.Mappings;
using System.ComponentModel.DataAnnotations;

namespace EducationSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Skills = new HashSet<Skill>();
            this.AcceptedProjects = new HashSet<AcceptedProjectRequest>();
            this.RequestedProjects = new HashSet<RequestedProjectRequest>();
            this.ReceivedProjectRequests = new HashSet<ReceivedProjectRequest>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public ICollection<Skill> Skills { get; set; }

        public ICollection<RequestedProjectRequest> RequestedProjects { get; set; }

        public ICollection<AcceptedProjectRequest> AcceptedProjects { get; set; }

        public ICollection<ReceivedProjectRequest> ReceivedProjectRequests { get; set; }
    }
}