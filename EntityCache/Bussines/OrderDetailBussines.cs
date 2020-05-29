using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using PacketParser.EntitiesInterface;

namespace EntityCache.Bussines
{
    public class OrderDetailBussines : IOrderDetail
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid OrderGuid { get; set; }
        public Guid PrdGuid { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }


        public static async Task<List<OrderDetailBussines>> GetAllAsync(Guid orderGuid) =>
            await UnitOfWork.OrderDetail.GetAllAsync(orderGuid);
    }
}
