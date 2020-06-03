using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class Visit : IVisit
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [MaxLength(150)]
        public string IP { get; set; }
        [MaxLength(10)]
        public string Date { get; set; }
    }
}
