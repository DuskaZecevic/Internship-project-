﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Entities
{
    public class ProjectTask
    {
        [Key]
        //svaki zadatak deo samo jednog projekta
        public int ProjectId { get; set; }
        public string Name { get; set; }

        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        
        public Project Project;
    }
    
}
