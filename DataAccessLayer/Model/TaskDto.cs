using WebApiCommon.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Model
{
    public class TaskDto
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public int Priority { get; set; }
        public ProjectDto Project { get; set; }

    }
}
