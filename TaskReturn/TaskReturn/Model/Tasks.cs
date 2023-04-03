using System.ComponentModel.DataAnnotations.Schema;
using TaskReturn.Model.Enum;
using TaskReturn.Response;

namespace TaskReturn.Model
{
    [Table("Task")]
    public class Tasks
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? TimeTaken { get; set; }
        public int Status { get; set; }

    }
}


