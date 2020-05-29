using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class OrderBussines : IOrder
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public int OrderNo { get; set; }
        public Guid CustomerGuid { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinally { get; set; }
        private List<OrderDetailBussines> _detList;
        public List<OrderDetailBussines> DetList
        {
            get
            {
                if (_detList != null) return _detList;
                _detList = AsyncContext.Run(() => OrderDetailBussines.GetAllAsync(Guid));
                return _detList;
            }
            set => _detList = value;
        }

        public async Task<ReturnedSaveFuncInfo> SaveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                if (DetList.Count > 0)
                {
                    var list = await OrderDetailBussines.GetAllAsync(Guid);
                    res.AddReturnedValue(
                        await UnitOfWork.OrderDetail.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                            tranName));
                    res.ThrowExceptionIfError();


                    res.AddReturnedValue(
                        await UnitOfWork.OrderDetail.SaveRangeAsync(DetList, tranName));
                    res.ThrowExceptionIfError();
                }


                res.AddReturnedValue(await UnitOfWork.Order.SaveAsync(this, tranName));
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

        public static async Task<int> GetMaxOrderNo() => await UnitOfWork.Order.GetMaxOrderNo();
    }
}
