using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class DivarCategory : IDivarCategory
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public Guid ParentGuid { get; set; }
    }
}
