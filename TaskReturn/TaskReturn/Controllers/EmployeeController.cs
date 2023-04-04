using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskReturn.DataBase;
using TaskReturn.Model;
using TaskReturn.Request;

namespace TaskReturn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly TaskDBContext mtaskDBContext;
        private readonly IMapper mmapper;

        public EmployeeController(TaskDBContext taskDBContext,IMapper mapper)
        {
            mtaskDBContext = taskDBContext;
            mmapper = mapper;
        }

        [HttpPost]
        public async Task<string>Create(EmployeeRequest employeeRequest)
        {
          EmployeeInfo employee1 = mmapper.Map<EmployeeInfo>(employeeRequest);
           mtaskDBContext.EmployeeInfo.Add(employee1);
            await mtaskDBContext.SaveChangesAsync();
            return $"Created-{employee1.ID}";   
        }
    }
}
