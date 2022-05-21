using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class Task
    {
        public string name { get; set; }
        public enum status
        {
            ToDo,
            InProgress,
            Done
        };
        public string description { get; set; }
        public int priority { get; set; }
    }
}
