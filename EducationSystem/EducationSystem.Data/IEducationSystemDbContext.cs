namespace EducationSystem.Data
{
    using EducationSystem.Models;
    using EducationSystem.Models.Mappings;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading.Tasks;

    public interface IEducationSystemDbContext
    {
        IDbSet<Project> Projects { get; set; }

        IDbSet<AcceptedProjectRequest> AcceptedProjectRequests { get; set; }

        IDbSet<ReceivedProjectRequest> ReceivedProjectRequests { get; set; }

        IDbSet<RequestedProjectRequest> RequestedProjectRequests { get; set; }

        IDbSet<Feedback> Feedbacks { get; set; }

        IDbSet<Resource> Resources { get; set; }

        IDbSet<Skill> Skills { get; set; }
        void Dispose();

        int SaveChanges();

        Task<int> SaveChangesAsync();

    }
}