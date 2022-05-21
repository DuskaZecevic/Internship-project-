using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class Project
    {

        public string nameOfProject { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? completionDate { get; set; }
        public enum statusOfProject
        {
            NotStarted,
            Active,
            Completed
        };

        public int priorityOfProject { get; set; }
    }
}
