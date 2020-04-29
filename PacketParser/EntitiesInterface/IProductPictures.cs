using System;

namespace PacketParser.EntitiesInterface
{
    public interface IProductPictures : IHasGuid
    {
        string Path { get; set; }
        Guid PrdGuid { get; set; }
    }
}
