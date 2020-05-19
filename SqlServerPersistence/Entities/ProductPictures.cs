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
        [MaxLength(50)]
        public string ImageName { get; set; }
        public Guid PrdGuid { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
    }
}
