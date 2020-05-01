using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class Simcard : ISimcard
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public long Number { get; set; }
        [MaxLength(100)]
        public string OwnerName { get; set; }
        public string DivarToken { get; set; }
        public string ChatToken { get; set; }
        public Guid? ChatCat1 { get; set; }
        public Guid? ChatCat2 { get; set; }
        public Guid? ChatCat3 { get; set; }
    }
}
