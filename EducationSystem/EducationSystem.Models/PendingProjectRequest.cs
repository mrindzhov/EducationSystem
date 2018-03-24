﻿namespace EducationSystem.Models
{
    public class PendingProjectRequest
    {
        public int ProjectId { get; set; }

        public int AccountId { get; set; }

        public Project Project { get; set; }

        public Account Account { get; set; }
    }
}