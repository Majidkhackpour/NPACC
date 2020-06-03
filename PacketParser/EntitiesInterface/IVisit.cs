using System;

namespace PacketParser.EntitiesInterface
{
    public interface IVisit : IHasGuid
    {
        string IP { get; set; }
        string Date { get; set; }
    }
}
