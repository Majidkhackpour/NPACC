using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.EntitiesInterface;

namespace SqlServerPersistence.Entities
{
    public class Users : IUsers
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [MaxLength(250)]
        [Required]
        public string RealName { get; set; }
        public Guid RolleGuid { get; set; }
        [MaxLength(250)]
        [Required]
        public string UserName { get; set; }
        [MaxLength(200)]
        [Required]
        public string Password { get; set; }
        [MaxLength(250)]
        [Required]
        public string Email { get; set; }
        public string ActiveCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool RememberMe { get; set; }
    }
}
