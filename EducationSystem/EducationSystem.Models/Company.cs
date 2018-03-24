using System.Collections.Generic;

namespace EducationSystem.Models
{
    public class Company
    {
        public Company()
        {
            this.PublishedProjects = new HashSet<Project>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Project> PublishedProjects { get; set; }
    }
}
