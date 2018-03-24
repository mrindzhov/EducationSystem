namespace EducationSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using EducationSystem.Models;
    using EducationSystem.Models.Mappings;

    public class EducationSystemDbContext : IdentityDbContext<ApplicationUser>, IEducationSystemDbContext
    {
        public EducationSystemDbContext()
            : base("name=EducationSystemDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Project> Projects { get; set; }
        public IDbSet<AcceptedProjectRequest> AcceptedProjectRequests { get; set; }
        public IDbSet<ReceivedProjectRequest> ReceivedProjectRequests { get; set; }
        public IDbSet<RequestedProjectRequest> RequestedProjectRequests { get; set; }
        public IDbSet<Feedback> Feedbacks { get; set; }
        public IDbSet<Resource> Resources { get; set; }
        public IDbSet<Skill> Skills { get; set; }

        public static EducationSystemDbContext Create()
        {
            return new EducationSystemDbContext();
        }
    }
}