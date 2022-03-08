using System;

namespace myportfolio.Models
{
    public class Project
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public Guid ProfileId { get; set; }
    }
}
