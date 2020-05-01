using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.WebBussines
{
    public class WebSimcard : ISimcard
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public long Number { get; set; }
        public string OwnerName { get; set; }
        public string DivarToken { get; set; }
        public string ChatToken { get; set; }
        public Guid? ChatCat1 { get; set; }
        public Guid? ChatCat2 { get; set; }
        public Guid? ChatCat3 { get; set; }
    }
}
