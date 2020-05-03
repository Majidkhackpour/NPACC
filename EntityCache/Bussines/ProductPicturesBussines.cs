using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using PacketParser.EntitiesInterface;

namespace EntityCache.Bussines
{
    public class ProductPicturesBussines : IProductPictures
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string Path { get; set; }
        public Guid PrdGuid { get; set; }

        public static async Task<List<ProductPicturesBussines>> GetAllAsync(Guid prdGuid) =>
            await UnitOfWork.ProductPictures.GetAllAsync(prdGuid);
    }
}
