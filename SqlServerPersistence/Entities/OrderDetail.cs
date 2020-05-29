using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class OrderDetail : IOrderDetail
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid OrderGuid { get; set; }
        public Guid PrdGuid { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
