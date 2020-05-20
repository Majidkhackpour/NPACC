using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class Features : IFeatures
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
    }
}
