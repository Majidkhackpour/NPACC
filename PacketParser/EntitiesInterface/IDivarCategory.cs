using System;

namespace PacketParser.EntitiesInterface
{
    public interface IDivarCategory : IHasGuid
    {
        string Name { get; set; }
        Guid ParentGuid { get; set; }
    }
}
