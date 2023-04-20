using System.ComponentModel.DataAnnotations.Schema;

namespace TaskReturn.Model
{
    [Table("Images")]
    public class Images
    {
        public int ID { get; set; }
        public string UploadedBy { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }       
        public DateTime CreatedTime { get; set; }
    }
}
 