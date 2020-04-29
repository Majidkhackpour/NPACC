using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class CustomerBussines : ICustomer
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string NationalCode { get; set; }
        public EnNahveAshnaei NahveAshnaei { get; set; }
        public Guid GroupGuid { get; set; }

        public static async Task<CustomerBussines> GetAsync(Guid guid) => await UnitOfWork.Customer.GetAsync(guid);

        public static CustomerBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));

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

                res.AddReturnedValue(await UnitOfWork.Customer.SaveAsync(this, tranName));
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

        public static async Task<bool> CheckName(Guid guid, string name) =>
            await UnitOfWork.Customer.CheckName(guid, name);

        public static async Task<List<CustomerBussines>> GetAllAsync() => await UnitOfWork.Customer.GetAllAsync();

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

                res.AddReturnedValue(await UnitOfWork.Customer.RemoveAsync(Guid, tranName));
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

        public static async Task<List<CustomerBussines>> GetAllByGroupAsync(Guid groupGuid) =>
            await UnitOfWork.Customer.GetAllByGroupAsync(groupGuid);

        public static async Task<List<CustomerBussines>> GetAllAsync(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                List<CustomerBussines> res = null;
                res = await GetAllAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x =>
                                x.Name.Contains(item) || 
                                x.Phone1.Contains(item) || 
                                x.Address.Contains(item))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.Name).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<CustomerBussines>();
            }
        }
    }
}
