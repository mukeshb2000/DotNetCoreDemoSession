using CurdOperationEntityFramework.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurdOperationEntityFramework.Data
{

    // This Class is Bridge Between the Sql Server and Entity
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Student> tblStudents { get; set; }
    }
}
