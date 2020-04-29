using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.WebBussines
{
    public class WebProduct : IProduct
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid GroupGuid { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Abad { get; set; }
        public string Kind { get; set; }
        public string Color { get; set; }
    }
}
