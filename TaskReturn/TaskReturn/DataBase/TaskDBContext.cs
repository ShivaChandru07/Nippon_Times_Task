using Microsoft.EntityFrameworkCore;
using TaskReturn.Model;

namespace TaskReturn.DataBase
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
        {



        }
        public DbSet<Tasks> Task { get; set; }
        public DbSet <StudentInfo> StudentInfo { get; set; }

    }
}