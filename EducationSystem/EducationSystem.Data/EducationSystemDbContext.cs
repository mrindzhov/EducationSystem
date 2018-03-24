namespace EducationSystem.Data
{
    using EducationSystem.Data.Configurations;
    using EducationSystem.Models;
    using EducationSystem.Models.Accounts;
    using EducationSystem.Models.Mappings;
    using System.Data.Entity;

    public class EducationSystemDbContext : DbContext
    {
        public EducationSystemDbContext()
            : base("name=EducationSystemDbContext")
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<DeveloperAccount> DeveloperAccounts { get; set; }

        public DbSet<CompanyAccount> CompanyAccounts { get; set; }
        
        public DbSet<AcceptedProjectRequest> AcceptedProjectRequests { get; set; }

        public DbSet<ReceivedProjectRequest> ReceivedProjectRequests { get; set; }

        public DbSet<RequestedProjectRequest> RequestedProjectRequests { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Skill> Skills { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProjectConfiguration());
        }
}