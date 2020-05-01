using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class ChatNumbers : IChatNumbers
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public long FromNumber { get; set; }
        [MaxLength(20)]
        public string Number { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Category { get; set; }
        public bool IsSendChat { get; set; }
        public bool IsSendSMS { get; set; }
    }
}
