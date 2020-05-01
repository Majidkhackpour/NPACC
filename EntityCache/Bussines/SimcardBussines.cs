using System;
using System.Threading.Tasks;
using EntityCache.Assistence;
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
        public Guid? ChatCat1 { get; set; }
        public Guid? ChatCat2 { get; set; }
        public Guid? ChatCat3 { get; set; }

        public static async Task<SimcardBussines> GetAsync(long number) => await UnitOfWork.Simcard.GetAsync(number);

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
    }
}
