using Microsoft.EntityFrameworkCore;
using Student.Model;

namespace Student.DbConnection
{
    public class DbClass:DbContext
    {
        public DbClass(DbContextOptions<DbClass> opps):base(opps)
        {

        }
        public DbSet<RegisterClass> Students { get; set; }
        public DbSet<TeacherClass> Teachers { get; set; }
    }
}
