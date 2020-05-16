using System;

namespace PacketParser.EntitiesInterface
{
    public interface IPrdSelectedGroup : IHasGuid
    {
        Guid PrdGuid { get; set; }
        Guid GroupGuid { get; set; }
    }
}
