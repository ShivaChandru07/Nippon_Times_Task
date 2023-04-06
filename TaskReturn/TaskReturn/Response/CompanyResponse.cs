using AutoMapper;
using System.Reflection.Metadata.Ecma335;
using TaskReturn.Model;

namespace TaskReturn.Response
{
    public class CompanyResponse 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public long PinCode { get; set; }      
    }
}
