using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.WebBussines
{
    public class WebProductGroup : IProductGroup
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string Name { get; set; }
        public Guid ParentGuid { get; set; }
        public string Description { get; set; }
    }
}
