using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class PrdFeatures : IPrdFeatures
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid PrdGuid { get; set; }
        public Guid FeatureGuid { get; set; }
        [MaxLength(150)]
        public string Value { get; set; }
    }
}
