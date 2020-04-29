using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class ProductPictures : IProductPictures
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [MaxLength(400)]
        public string Path { get; set; }
        public Guid PrdGuid { get; set; }
    }
}
