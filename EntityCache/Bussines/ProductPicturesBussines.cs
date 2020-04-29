using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.Bussines
{
    public class ProductPicturesBussines : IProductPictures
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string Path { get; set; }
        public Guid PrdGuid { get; set; }
    }
}
