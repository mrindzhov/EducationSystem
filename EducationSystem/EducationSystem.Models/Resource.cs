namespace EducationSystem.Models
{
    public class Resource
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Project Project { get; set; }
    }
}