using System.ComponentModel.DataAnnotations.Schema;

namespace TaskReturn.Model
{
    [Table("StudentInfo")]
    public class StudentInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
    }
}
