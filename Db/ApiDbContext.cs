using AnimalCrossing.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalCrossing.Db
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {
        }

        public DbSet<Fish> Fishs { get; set; }
    }
}