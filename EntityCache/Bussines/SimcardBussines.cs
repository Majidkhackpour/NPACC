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
    public class SimcardBussines : ISimcard
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public long Number { get; set; }
        public string OwnerName { get; set; }
        public string DivarToken { get; set; }
        public string ChatToken { get; set; }
        public Guid? AdvCat1 { get; set; }
        public Guid? AdvCat2 { get; set; }
        public Guid? AdvCat3 { get; set; }
        public Guid? ChatCat1 { get; set; }
        public Guid? ChatCat2 { get; set; }
        public Guid? ChatCat3 { get; set; }
        public bool HasDivarToken => !string.IsNullOrEmpty(DivarToken);
        public bool HasDivarChatToken => !string.IsNullOrEmpty(ChatToken);

        public static async Task<SimcardBussines> GetAsync(long number) => await UnitOfWork.Simcard.GetAsync(number);

        public static async Task<SimcardBussines> GetAsync(Guid guid) => await UnitOfWork.Simcard.GetAsync(guid);

        public static SimcardBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));

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

                res.AddReturnedValue(await UnitOfWork.Simcard.SaveAsync(this, tranName));
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

        public static async Task<List<SimcardBussines>> GetAllAsync(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                List<SimcardBussines> res = null;
                res = await GetAllAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x =>
                                    x.OwnerName.Contains(item) ||
                                    x.Number.ToString().Contains(item))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.OwnerName).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<SimcardBussines>();
            }
        }

        public static async Task<List<SimcardBussines>> GetAllAsync() => await UnitOfWork.Simcard.GetAllAsync();

        public static async Task<bool> CheckNumber(Guid guid, long number) =>
            await UnitOfWork.Simcard.CheckNumber(guid, number);

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

                res.AddReturnedValue(await UnitOfWork.Simcard.RemoveAsync(Guid, tranName));
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
