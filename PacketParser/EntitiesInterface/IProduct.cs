using System;

namespace PacketParser.EntitiesInterface
{
    public interface IProduct : IHasGuid
    {
        string Code { get; set; }
        string Name { get; set; }
        DateTime CreateDate { get; set; }
        string ImageName { get; set; }
        decimal Price { get; set; }
        string Description { get; set; }
        string ShortDesc { get; set; }
        string Abad { get; set; }
        string Kind { get; set; }
        string Color { get; set; }
    }
}
