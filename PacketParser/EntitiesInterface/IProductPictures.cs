using System;

namespace PacketParser.EntitiesInterface
{
    public interface IProductPictures : IHasGuid
    {
        string ImageName { get; set; }
        Guid PrdGuid { get; set; }
        string Title { get; set; }
    }
}
