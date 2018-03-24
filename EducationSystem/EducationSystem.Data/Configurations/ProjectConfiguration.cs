using EducationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EducationSystem.Data.Configurations
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            this.HasKey(x => x.Id);

            this.Property(a => a.Name).IsRequired();
            this.Property(a => a.Description).IsRequired();
            this.Property(a => a.Requirements).IsRequired();
            this.Property(a => a.IsTeamFormed).IsRequired();
            this.HasRequired(a => a.ProductOwner).WithMany(a => a.CreatedProjects);
            this.HasMany(b => b.Feedbacks);
            this.HasMany(b => b.Resources).WithRequired(x=>x.Project);
            this.HasMany(b => b.SkillsNeeded);
            this.HasMany(b => b.AcceptedDevelopers).WithRequired(x=>x.Project).HasForeignKey(x=>x.ProjectId);
            this.HasMany(b => b.RequestedDevelopers).WithRequired(x=>x.Project).HasForeignKey(x=>x.ProjectId);
            this.HasMany(b => b.ReceivedRequests).WithRequired(x=>x.Project).HasForeignKey(x=>x.ProjectId);
        }
    }
}
