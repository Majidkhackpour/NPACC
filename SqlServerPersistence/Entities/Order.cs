using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class Order : IOrder
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public int OrderNo { get; set; }
        public Guid CustomerGuid { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinally { get; set; }
    }
}
