using System;
using PacketParser;
using PacketParser.EntitiesInterface;

namespace EntityCache.WebBussines
{
    public class WebCustomer : ICustomer
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string NationalCode { get; set; }
        public EnNahveAshnaei NahveAshnaei { get; set; }
        public Guid GroupGuid { get; set; }
    }
}
