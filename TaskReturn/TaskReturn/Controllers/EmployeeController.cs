using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public EmployeeController(TaskDBContext taskDBContext, IMapper mapper)
        {
            mtaskDBContext = taskDBContext;
            mmapper = mapper;
        }

        [HttpPost]
        public async Task<string> Create(EmployeeRequest employeeRequest)
        {
            EmployeeInfo employee1 = mmapper.Map<EmployeeInfo>(employeeRequest);
            mtaskDBContext.EmployeeInfo.Add(employee1);
            await mtaskDBContext.SaveChangesAsync();
            return $"Created-{employee1.ID}";
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails()
        {
            var es = mtaskDBContext.EmployeeInfo.ToList();
            var us = mmapper.Map<EmployeeInfo>(es);
            return Ok(es);
        }
        [HttpGet("Address")]
        public async Task<IActionResult> GetEmployee(string address)
        {
            var emp = from s in mtaskDBContext.EmployeeInfo.Where(x => x.Address.Contains(address)).ToList()/*&&  x.Address.Contains(address)*/ 
            select mmapper.Map<EmployeeInfo>(s); 
            return Ok(emp.ToList());
        }

    } 
}
