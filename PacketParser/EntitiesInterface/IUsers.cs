using System;

namespace PacketParser.EntitiesInterface
{
    public interface IUsers : IHasGuid
    {
        string RealName { get; set; }
        Guid RolleGuid { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string Email { get; set; }
        string ActiveCode { get; set; }
        bool IsActive { get; set; }
        DateTime RegisterDate { get; set; }
        bool RememberMe { get; set; }
    }
}
