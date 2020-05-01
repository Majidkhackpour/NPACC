using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.Bussines
{
    public class ChatNumberBussines : IChatNumbers
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public long FromNumber { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public bool IsSendChat { get; set; }
        public bool IsSendSMS { get; set; }
    }
}
