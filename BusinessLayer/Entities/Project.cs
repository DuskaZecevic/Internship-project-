using WebApiCommon.Enums;
using System;

namespace BusinessLayer.Entities
{
    public class Project
    { 
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int Priority { get; set; }
    }
}
