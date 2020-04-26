using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.WebBussines
{
    public class WebCustomerGroup : ICustomerGroup
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string Name { get; set; }
        public Guid ParentGuid { get; set; }
        public string Description { get; set; }
    }
}
