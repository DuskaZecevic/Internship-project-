using WebApiCommon.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Model
{
    public class ProjectDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
    }
}
