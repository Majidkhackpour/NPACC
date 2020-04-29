using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
   public class ProductGroup:IProductGroup
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public Guid ParentGuid { get; set; }
        public string Description { get; set; }
    }
}
