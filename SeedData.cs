using System.Linq;
using AnimalCrossing.Db;
using AnimalCrossing.Db.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace AnimalCrossing
{
    public static class SeedData
    {
        public static void EnsureSeedData(this ApiDbContext db)
        {
            if(!db.Fishs.Any()){
                var fish = new Fish{
                    Id = 1,
                    Name="nimo"
                };
                db.Add(fish);
                db.SaveChanges();
            }
        }
    }
}