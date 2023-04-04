using AutoMapper;
using TaskReturn.Request;

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
