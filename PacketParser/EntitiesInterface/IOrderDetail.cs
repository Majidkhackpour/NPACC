using System;

namespace PacketParser.EntitiesInterface
{
    public interface IOrderDetail : IHasGuid
    {
        Guid OrderGuid { get; set; }
        Guid PrdGuid { get; set; }
        decimal Price { get; set; }
        int Count { get; set; }
    }
}
