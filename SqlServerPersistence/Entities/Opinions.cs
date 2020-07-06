using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class Opinions : IOpinion
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        public string Opinion { get; set; }
    }
}
