using AnimalCrossing.Constants.Enums;

namespace AnimalCrossing.Db.Entities
{
    public class Fish
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string VisibleDate { get; set; }
        public string VisibleTime { get; set; }
        public string Location { get; set; }
        public ShadowType ShadowType { get; set; }
    }
}