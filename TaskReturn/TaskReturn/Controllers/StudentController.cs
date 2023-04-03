using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskReturn.DataBase;
using TaskReturn.Model;
using TaskReturn.Request;

namespace TaskReturn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly TaskDBContext mtaskDBContext;
        private readonly ILogger<StudentController> mlogger1;

        public StudentController([FromBody]TaskDBContext taskDBContext,ILogger<StudentController> logger1)
        {
            mtaskDBContext = taskDBContext;
            mlogger1 = logger1;
        }

        [HttpPost]
        public async Task<string>CreateStu(StudentRequest student)
        {
            mlogger1.LogInformation("Creating log for - "  +  student.Name);
            StudentInfo info = new StudentInfo()
            {
                ID = student.ID,
                Name = student.Name,
                Class = student.Class,
                Address = student.Address,
                MobileNumber = student.MobileNumber,
            };
            mtaskDBContext.StudentInfo.Add(info);
            await mtaskDBContext.SaveChangesAsync();
            return $"Created -{info.ID}";
        }
    }
}
