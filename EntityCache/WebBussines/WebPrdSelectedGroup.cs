using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.WebBussines
{
    public class WebPrdSelectedGroup : IPrdSelectedGroup
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid PrdGuid { get; set; }
        public Guid GroupGuid { get; set; }
    }
}
