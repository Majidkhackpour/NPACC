using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class Product : IProduct
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(50)]
        public string ImageName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [MaxLength(350)]
        public string ShortDesc { get; set; }
        [MaxLength(30)]
        public string Abad { get; set; }
        [MaxLength(100)]
        public string Kind { get; set; }
        [MaxLength(100)]
        public string Color { get; set; }
    }
}
