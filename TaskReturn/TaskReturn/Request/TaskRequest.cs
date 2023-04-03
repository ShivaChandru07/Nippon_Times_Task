using TaskReturn.Model;
using TaskReturn.Model.Enum;

namespace TaskReturn.Request
{
    public class TaskRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? TimeTaken { get; set; }
        public int Status { get; set; }
    }
}
