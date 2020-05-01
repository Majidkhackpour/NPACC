using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.WebBussines
{
    public class WebChatNumbers : IChatNumbers
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public long FromNumber { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public bool IsSendChat { get; set; }
        public bool IsSendSMS { get; set; }
    }
}
