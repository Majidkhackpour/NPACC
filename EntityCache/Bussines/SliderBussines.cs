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
    public class SliderBussines : ISlider
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string URL { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7);
        public bool IsActive { get; set; }
        public string StartDateSh => Calendar.MiladiToShamsi(StartDate);
        public string EndDateSh => Calendar.MiladiToShamsi(EndDate);


        public static async Task<List<SliderBussines>> GetAllAsync() => await UnitOfWork.Slider.GetAllAsync();

        public static async Task<SliderBussines> GetAsync(Guid guid) => await UnitOfWork.Slider.GetAsync(guid);

        public static SliderBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));

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

                res.AddReturnedValue(await UnitOfWork.Slider.SaveAsync(this, tranName));
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

                res.AddReturnedValue(await UnitOfWork.Slider.RemoveAsync(Guid, tranName));
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


        public static async Task<List<SliderBussines>> GetAllAsync(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                List<SliderBussines> res = null;
                res = await GetAllAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x =>
                                    x.Title.Contains(item) ||
                                    x.URL.Contains(item) ||
                                    x.StartDateSh.Contains(item) ||
                                    x.EndDateSh.Contains(item))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.EndDateSh).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<SliderBussines>();
            }
        }
    }
}
