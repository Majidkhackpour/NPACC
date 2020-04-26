using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class CustomerGroupBussines : ICustomerGroup
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public Guid ParentGuid { get; set; }
        public string Description { get; set; }

        public static async Task<List<CustomerGroupBussines>> GetAllAsync() =>
            await UnitOfWork.CustomerGroup.GetAllAsync();

        public static async Task<CustomerGroupBussines> GetAsync(Guid guid) =>
            await UnitOfWork.CustomerGroup.GetAsync(guid);

        public static CustomerGroupBussines Get(Guid guid) =>
            AsyncContext.Run(() => GetAsync(guid));

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

                res.AddReturnedValue(await UnitOfWork.CustomerGroup.SaveAsync(this, tranName));
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
            await UnitOfWork.CustomerGroup.CheckName(guid, name);
    }
}
