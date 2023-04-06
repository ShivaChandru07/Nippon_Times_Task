using AutoMapper;
using TaskReturn.Request;
using TaskReturn.Response;

namespace TaskReturn.Model
{
    public class EmployeeMapping:Profile
    {
        public EmployeeMapping()
        {
            CreateMap<EmployeeRequest, EmployeeInfo>();
           
        }

    }
}
