using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class Task
    {
        public string Name { get; set; }

        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
    
}
