
using Grpc.Core;
using Magnum.FileSystem;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using TaskReturn.DataBase;
using TaskReturn.Model;
using TaskReturn.Request;
using static System.Net.Mime.MediaTypeNames;
using Directory = System.IO.Directory;

namespace TaskReturn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    //    {
    //        private readonly TaskDBContext mtaskDBContext;
    //        private readonly IConfiguration mconfiguration;

    //        public ImageController(TaskDBContext taskDBContext, IConfiguration configuration)
    //        {
    //            mtaskDBContext = taskDBContext;
    //            mconfiguration = configuration;
    //        }
    //        //[HttpPost]
    //        //public async Task<string>UploadImage(ImageRequest image)
    //        //{
    //        //    var storagePath = "~/Images/" + image.ToString();
    //        //    Image image1 = new Image()
    //        //    {
    //        //        ID = image.ID,
    //        //        Images =    image.Image,
    //        //        CreatedTime = DateTime.Now,
    //        //        FilePath = storagePath,
    //        //        UploadedBy = image.UploadedBy,

    //        //    };
    //        //    mtaskDBContext.Images.Add(image1);
    //        //    await mtaskDBContext.SaveChangesAsync();
    //        //    return $"Created{image1.ID}";
    //        //}


    //        //public void MyMethod()
    //        //{
    //        //    string imageRootPath = mconfiguration.GetSection("ImageSettings")["ImageRootPath"];
    //        //    // Use the imageRootPath value to construct the path to your image files
    //        //}
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> UploadImage(IFormFile image, [FromBody] ImageRequest imageRequest)
    //    {
    //        var path = "C:Users/Triton-004/source/repos/TasksRepo/Nippon_Times_Task/TaskReturn/TaskReturn/Image";
    //        {
    //            Model.Image image1 = new Model.Image()
    //            {
    //                ID = imageRequest.ID,
    //                FilePath = path,
    //                CreatedTime = DateTime.Now,
    //                Images = image,
    //                UploadedBy = imageRequest.UploadedBy,
    //                FileType = image.ContentType,
    //            };

    //        }
    //    }
    {
        private readonly IConfiguration mconfiguration;
        private readonly IWebHostEnvironment menvironment;
        private readonly TaskDBContext mtaskDBContext;

        public ImageController(IConfiguration configuration, IWebHostEnvironment environment, TaskDBContext taskDBContext)
        {
            mconfiguration = configuration;
            menvironment = environment;
            mtaskDBContext = taskDBContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Upload([FromQuery] ImageRequest image1)
        {

            if (image1 == null || image1.Image.Length == 0)
                return BadRequest("Please select an image file to upload.");
            var uploadDirecotroy = "Image";
            var uploadPath = Path.Combine(menvironment.ContentRootPath, uploadDirecotroy);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            var fileName = Path.GetFileName(image1.Image.FileName);
            var filePath = Path.Combine(uploadPath, fileName);
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                image1.Image.CopyTo(fs);
            }
            Images image = new Images()
            {
                CreatedTime = DateTime.UtcNow,
                FilePath = uploadPath,
                FileType = Path.GetExtension(image1.Image.FileName),
                UploadedBy = image1.UploadedBy,
            };
            mtaskDBContext.Images.Add(image);
            mtaskDBContext.SaveChanges();
            return Ok();
        }
    }
}
