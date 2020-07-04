using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

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
        public ProductBussines Prd => ProductBussines.Get(PrdGuid);
        public string PrdName => Prd?.Name;
        public string PrdCode => Prd?.Code;
        public decimal TotalPrice => Price * Count;


        public static async Task<List<OrderDetailBussines>> GetAllAsync(Guid orderGuid) =>
            await UnitOfWork.OrderDetail.GetAllAsync(orderGuid);


        public async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(List<Guid> list, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.OrderDetail.RemoveRangeAsync(list, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
