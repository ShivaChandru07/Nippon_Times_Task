using AutoMapper;
using TaskReturn.Model;

namespace TaskReturn.Response
{
    public class Mapping_Repo : Profile
    {
        public Mapping_Repo()
        {
            CreateMap<EmployeeResponse, Employee>();
        }
    }
}
