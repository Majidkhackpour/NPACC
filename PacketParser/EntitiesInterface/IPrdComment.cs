using System;

namespace PacketParser.EntitiesInterface
{
    public interface IPrdComment : IHasGuid
    {
        Guid PrdGuid { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string WebSite { get; set; }
        Guid ParentGuid { get; set; }
        string Comment { get; set; }
        DateTime CreateDate { get; set; }
    }
}
