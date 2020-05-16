using System;

namespace PacketParser.EntitiesInterface
{
    public interface IPrdTag : IHasGuid
    {
        Guid PrdGuid { get; set; }
        string Tag { get; set; }
    }
}
