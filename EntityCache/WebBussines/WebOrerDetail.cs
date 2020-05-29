using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.WebBussines
{
    public class WebOrerDetail : IOrderDetail
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid OrderGuid { get; set; }
        public Guid PrdGuid { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
