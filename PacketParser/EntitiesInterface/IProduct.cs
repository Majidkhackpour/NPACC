using System;

namespace PacketParser.EntitiesInterface
{
    public interface IProduct : IHasGuid
    {
        string Code { get; set; }
        string HalfCode { get; set; }
        string Name { get; set; }
        Guid GroupGuid { get; set; }
        decimal Price { get; set; }
        string Description { get; set; }
        string Abad { get; set; }
        string Kind { get; set; }
        string Color { get; set; }
    }
}
