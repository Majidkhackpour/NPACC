using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.Bussines
{
    public class PrdTagBussines : IPrdTag
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid PrdGuid { get; set; }
        public string Tag { get; set; }
    }
}
