using Microsoft.EntityFrameworkCore;
using TaskReturn.Model;
using TaskReturn.Response;

namespace TaskReturn.DataBase
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
        {



        }
        public DbSet<Tasks> Task { get; set; }
        public DbSet <StudentInfo> StudentInfo { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfo { get; set; }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Images> Images { get; set; }
    }
}