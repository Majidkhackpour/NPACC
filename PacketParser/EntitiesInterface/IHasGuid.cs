using System;

namespace PacketParser.EntitiesInterface
{
   public interface IHasGuid
    {
        Guid Guid { get; set; }
        DateTime Modified { get; set; }
    }
}
