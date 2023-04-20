namespace TaskReturn.Request
{
    public class ImageRequest
    {
        public string UploadedBy { get; set; }
        public IFormFile Image { get; set; }
    }
}
