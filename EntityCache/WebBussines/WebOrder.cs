using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.WebBussines
{
    public class WebOrder : IOrder
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public int OrderNo { get; set; }
        public Guid CustomerGuid { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinally { get; set; }
    }
}
