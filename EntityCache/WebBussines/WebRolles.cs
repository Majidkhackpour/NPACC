using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.WebBussines
{
    public class WebRolles : IRolles
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string RolleTitle { get; set; }
        public string RolleName { get; set; }
    }
}
