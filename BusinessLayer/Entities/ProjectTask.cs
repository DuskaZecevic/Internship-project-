﻿using WebApiCommon.Enums;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Model;

namespace BusinessLayer.Entities
{
    public class ProjectTask
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public ProjectDto Project;
    }
    
}
