
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Memory;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using TaskReturn.DataBase;
using TaskReturn.Model;
using TaskReturn.Request;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace TaskReturn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly TaskDBContext mtaskDBContext;
        private readonly IWebHostEnvironment menvironment;

        public ImageUploadController(TaskDBContext taskDBContext, IWebHostEnvironment environment)
        {
            mtaskDBContext = taskDBContext;
            menvironment = environment;
        }

        //public async Task<IHttpActionResult> CompressImage(IFormFile image)
        //{
        //    // Get the image file from the HTTP request.
        //    var file = await GetImageFile();

        //    // Read the image data from the file.
        //    var imageData = await ReadImageData(file);

        //    // Compress the image data.
        //    var compressedImageData = CompressImageData(imageData);

        //    // Return the compressed image data as a response.
        //    return (IHttpActionResult)Ok(compressedImageData);
        //}

        //private async Task<Stream> GetImageFile()
        //{
        //    // Check if the request contains multipart/form-data.
        //    //if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //    }


        //    // Get the image file from the HTTP request.
        //    var provider = new MultipartMemoryStreamProvider();
        //    //await Request.Content.ReadAsMultipartAsync(provider);
        //    var file = provider.Contents.FirstOrDefault(c => c.Headers.ContentType.MediaType.StartsWith("image/"));
        //    if (file == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }

        //    return await file.ReadAsStreamAsync();
        //}

        //private async Task<byte[]> ReadImageData(Stream imageStream)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await imageStream.CopyToAsync(memoryStream);
        //        return memoryStream.ToArray();
        //    }
        //}

        //private byte[] CompressImageData(byte[] imageData)
        //{
        //    using (var inputStream = new MemoryStream(imageData))
        //    {
        //        using (var outputStream = new MemoryStream())
        //        {
        //            using (var image = Image.FromStream(inputStream))
        //            {
        //                var encoderParams = new EncoderParameters(1);
        //                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 50);

        //                var codec = ImageCodecInfo.GetImageDecoders()
        //                    .FirstOrDefault(c => c.FormatID == image.RawFormat.Guid);

        //                if (codec != null)
        //                {
        //                    image.Save(outputStream, codec, encoderParams);
        //                    return outputStream.ToArray();
        //                }
        //            }
        //        }
        //    }

        //    return imageData;
        //}

        //[HttpPost]
        //public async Task<IActionResult> CompressImage(IFormFile image)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        // Load the image from the IFormFile object
        //        var imageSharp = SixLabors.ImageSharp.Image.Load(image.OpenReadStream());

        //        // Resize the image while maintaining the aspect ratio
        //        imageSharp.Mutate(x => x.Resize(new ResizeOptions
        //        {
        //            Size = new SixLabors.ImageSharp.Size(800, 600),
        //            Mode = ResizeMode.Max
        //        }));

        //        // Compress the image and save it to a memory stream
        //      imageSharp.Save(memoryStream, new JpegEncoder { Quality = 70 });
        //        // Return the compressed image from the memory stream as a byte array
        //        var uploadDirecotroy = "Image";
        //        var uploadPath = Path.Combine(menvironment.ContentRootPath, uploadDirecotroy);
        //        if (!Directory.Exists(uploadPath))
        //        {
        //            Directory.CreateDirectory(uploadPath);
        //        }
        //        return (Ok(memoryStream.ToArray()));
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> CompressImage(IFormFile image)
        //{
        //    if (image == null || image.Length == 0)
        //    {
        //        return BadRequest("Invalid file.");
        //    }

        //    // Load the image into a Bitmap object
        //    using (var imageStream = image.OpenReadStream())
        //    {
        //        var bitmap = new Bitmap(imageStream);

        //        // Set the size of the compressed image
        //        var newWidth = 500;
        //        var newHeight = (int)(bitmap.Height * ((double)newWidth / bitmap.Width));

        //        // Resize the image
        //        var resizedBitmap = new Bitmap(newWidth, newHeight);
        //        using (var graphics = Graphics.FromImage(resizedBitmap))
        //        {
        //            graphics.DrawImage(bitmap, 0, 0, newWidth, newHeight);
        //        }

        //        // Set the quality of the compressed image (between 0 and 100)
        //        var encoderParameters = new EncoderParameters(1);
        //        encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 50L);

        //        // Create a new MemoryStream to save the compressed image
        //        using (var compressedImageStream = new MemoryStream())
        //        {
        //            // Save the compressed image to the MemoryStream using the JPEG encoder
        //            resizedBitmap.Save(compressedImageStream, GetEncoderInfo("image/jpeg/" +
        //                ""), encoderParameters);

        //            // Save the compressed image to the database
        //            byte[] compressedImageBytes = compressedImageStream.ToArray();
        //            // Save the compressed image bytes to your database using your preferred method
        //            var uploadDirecotroy = "Image";
        //            var uploadPath = Path.Combine(menvironment.ContentRootPath, uploadDirecotroy);
        //            if (!Directory.Exists(uploadPath))
        //            {
        //                Directory.CreateDirectory(uploadPath);
        //            }
        //            var filePath = Path.Combine(uploadPath);
        //            using (FileStream fs = System.IO.File.Create(filePath))
        //            {
        //                    image.FileName.(fs);
        //            }

        //            return Ok("Image compressed, resized and saved successfully.");
        //        }
        //    }
        //}

        //private ImageCodecInfo GetEncoderInfo(string mimeType)
        //{
        //    var codecs = ImageCodecInfo.GetImageEncoders();
        //    foreach (var codec in codecs)
        //    {
        //        if (codec.MimeType == mimeType)
        //        {
        //            return codec;
        //        }
        //    }
        //    return null;
        //}


        [HttpPost]
        public async Task<IActionResult> CompressImage(IFormFile image)
        {
            // Check if a file was uploaded
            if (image == null || image.Length == 0)
                return BadRequest("Please upload an image file.");

            // Load the uploaded image
            using (var inputStream = image.OpenReadStream())
            using (var imageObj = SixLabors.ImageSharp.Image.Load(inputStream))
            {
                // Configure the WebP encoder options
                var encoder = new WebpEncoder()
                {
                    Quality = 50
                };
                // Convert the image to the WebP format and save it to a memory stream
                using (var outputStream = new MemoryStream())
                {
                    imageObj.Save(outputStream, encoder);
                    // Return the compressed image as a file download
                    var result = new FileContentResult(outputStream.ToArray(), "image/webp");
                    result.FileDownloadName = "CompressedImage.webp";
                    return result;
                }
            }
        }
    }
}


