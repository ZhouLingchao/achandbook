using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalCrossing.GraphQL
{
    public class AnimalCrossingSchema:Schema
    {
        public AnimalCrossingSchema(AnimalCrossingQuery query)
        {
            Query = query;
        }
    }
}