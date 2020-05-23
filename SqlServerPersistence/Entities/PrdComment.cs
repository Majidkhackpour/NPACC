using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class PrdComment : IPrdComment
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid PrdGuid { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string WebSite { get; set; }
        public Guid ParentGuid { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
