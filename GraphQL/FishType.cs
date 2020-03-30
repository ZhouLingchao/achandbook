using AnimalCrossing.Db.Entities;
using GraphQL.Types;

namespace AnimalCrossing.GraphQL
{
    public class FishType:ObjectGraphType<Fish>
    {
        public FishType()
        {
            Field(x=>x.Id).Description("The Id of the Fish.");
            Field(x=>x.Name).Description("The Name of the Fish.");
            Field(x=>x.Price).Description("The Price of the Fish.");
            Field(x=>x.VisibleDate).Description("The VisibleDate of the Fish.");
            Field(x=>x.VisibleTime).Description("The VisibleTime of the Fish.");
            Field(x=>x.Location).Description("The Location of the Fish.");
            Field(x=>x.ShadowType).Description("The ShadowType of the Fish.");
        }
    }
}