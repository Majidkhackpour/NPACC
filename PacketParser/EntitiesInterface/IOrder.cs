using System;

namespace PacketParser.EntitiesInterface
{
    public interface IOrder : IHasGuid
    {
        int OrderNo { get; set; }
        Guid CustomerGuid { get; set; }
        DateTime Date { get; set; }
        bool IsFinally { get; set; }
    }
}
