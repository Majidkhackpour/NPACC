using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class OrderBussines : IOrder
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public int OrderNo { get; set; }
        public Guid CustomerGuid { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
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
        public string CustomerName => CustomerBussines.Get(CustomerGuid).Name;
        public decimal TotalPrice => DetList?.Sum(q => q.Count * q.Price) ?? 0;
        public int TotalCount => DetList?.Sum(q => q.Count) ?? 0;
        public string Status => IsFinally ? "نهایی شده" : "باز";
        public string DateSh => Calendar.MiladiToShamsi(Date);
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

        public static async Task<List<OrderBussines>> GetAllAsync() => await UnitOfWork.Order.GetAllAsync();

        public static async Task<List<OrderBussines>> GetAllAsync(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                List<OrderBussines> res = null;
                res = await GetAllAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x =>
                                    x.CustomerName.Contains(item) ||
                                    x.OrderNo.ToString().Contains(item) ||
                                    x.Status.Contains(item) ||
                                    x.TotalPrice.ToString().Contains(item) ||
                                    x.DateSh.ToString().Contains(item))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.OrderNo).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<OrderBussines>();
            }
        }

        public static async Task<OrderBussines> GetAsync(Guid guid) => await UnitOfWork.Order.GetAsync(guid);

        public static OrderBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));

        public async Task<ReturnedSaveFuncInfo> RemoveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }


                var list = await OrderDetailBussines.GetAllAsync(Guid);
                res.AddReturnedValue(
                    await UnitOfWork.OrderDetail.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                        tranName));
                res.ThrowExceptionIfError();

                res.AddReturnedValue(await UnitOfWork.Order.RemoveAsync(Guid, tranName));
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

        public static async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(Guid orderGuid) =>
            await UnitOfWork.Order.ChangeStatusAsync(orderGuid);
    }
}
