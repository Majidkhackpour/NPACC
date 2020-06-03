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
    public class VisitBussines : IVisit
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string IP { get; set; }
        public string Date { get; set; }
        public int Sum => GetAll().Count;
        public int Yesterday => GetAll().Count(q => q.Date == _yestaerday);
        public int Today => GetAll().Count(q => q.Date == _today);

        private string _yestaerday = Calendar.MiladiToShamsi(DateTime.Now.AddDays(-1));
        private string _today=> Calendar.MiladiToShamsi(DateTime.Now);
        public async Task<ReturnedSaveFuncInfo> SaveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (!await CheckIP(IP, Date))
                {
                    if (autoTran)
                    { //BeginTransaction
                    }
                    res.AddReturnedValue(await UnitOfWork.Visit.SaveAsync(this, tranName));
                    res.ThrowExceptionIfError();
                    if (autoTran)
                    {
                        //CommitTransAction
                    }
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

        public ReturnedSaveFuncInfo Save(string tranName = "") => AsyncContext.Run(() => SaveAsync(tranName));

        public static async Task<bool> CheckIP(string ip, string date) => await UnitOfWork.Visit.CheckIP(ip, date);

        public static async Task<List<VisitBussines>> GetAllAsync() => await UnitOfWork.Visit.GetAllAsync();

        public static List<VisitBussines> GetAll() => AsyncContext.Run(GetAllAsync);
    }
}
