using System.Linq;
using AnimalCrossing.Db;
using AnimalCrossing.Db.Entities;
using GraphQL.Types;

namespace AnimalCrossing.GraphQL
{
    public class AnimalCrossingQuery:ObjectGraphType
    {
        public AnimalCrossingQuery(ApiDbContext db)
        {
            Field<FishType>(
                nameof(Fish).ToLower(),
                resolve: context => new Fish()
            );
        }
    }
}