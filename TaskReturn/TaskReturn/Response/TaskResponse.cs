using TaskReturn.Model.Enum;

namespace TaskReturn.Response
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? TimeTaken { get; set; }
        public int Status { get; set; }
    }
}
