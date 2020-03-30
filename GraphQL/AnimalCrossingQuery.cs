using System.Linq;
using AnimalCrossing.Db;
using AnimalCrossing.Db.Entities;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace AnimalCrossing.GraphQL
{
    public class AnimalCrossingQuery : ObjectGraphType
    {
        public AnimalCrossingQuery(ApiDbContext db)
        {
            var id = nameof(Fish.Id).ToLower();
            Field<FishType>(
                nameof(Fish).ToLower(),
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = id, Description = "id of the fish" }
                ),
                resolve: context => db.Fishs.FirstOrDefaultAsync(x => x.Id == context.GetArgument<int>(id, 0))
            );
            Field<FishType>(
                "fishs",
                resolve: context => db.Fishs.FirstOrDefaultAsync()
            );
        }
    }
}