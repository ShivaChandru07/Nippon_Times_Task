using System.ComponentModel.DataAnnotations.Schema;

namespace TaskReturn.Model
{
    [Table("EmployeeInfo")]
    public class EmployeeInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }

    }
}
