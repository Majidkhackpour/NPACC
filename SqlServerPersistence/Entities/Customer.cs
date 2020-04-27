using System;
using System.ComponentModel.DataAnnotations;
using PacketParser;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class Customer : ICustomer
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(20)]
        public string Phone1 { get; set; }
        [MaxLength(20)]
        public string Phone2 { get; set; }
        public string Address { get; set; }
        [MaxLength(20)]
        public string PostalCode { get; set; }
        [MaxLength(20)]
        public string NationalCode { get; set; }
        public EnNahveAshnaei NahveAshnaei { get; set; }
        public Guid GroupGuid { get; set; }
    }
}
