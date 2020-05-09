using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class Rolles : IRolles
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [MaxLength(150)]
        public string RolleTitle { get; set; }
        [MaxLength(150)]
        public string RolleName { get; set; }
    }
}
