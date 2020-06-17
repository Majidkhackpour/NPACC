using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class PrdFeatureBussines : IPrdFeatures
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid PrdGuid { get; set; }
        public Guid FeatureGuid { get; set; }
        public string Value { get; set; }
        public string FeatureName => AsyncContext.Run(() => FeatureBussines.GetAsync(FeatureGuid))?.Title ?? "";



        public static async Task<List<PrdFeatureBussines>> GetAllAsync() => await UnitOfWork.PrdFeature.GetAllAsync();

        public static async Task<PrdFeatureBussines> GetAsync(Guid guid) => await UnitOfWork.PrdFeature.GetAsync(guid);

        public static PrdFeatureBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));

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

                res.AddReturnedValue(await UnitOfWork.PrdFeature.SaveAsync(this, tranName));
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

                res.AddReturnedValue(await UnitOfWork.PrdFeature.RemoveAsync(Guid, tranName));
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

        public static async Task<List<PrdFeatureBussines>> GetAllAsync(Guid prdGuid) =>
            await UnitOfWork.PrdFeature.GetAllAsync(prdGuid);
        public static async Task<List<PrdFeatureBussines>> GetAllByFeaturesGuidAsync(Guid featureGuid) =>
            await UnitOfWork.PrdFeature.GetAllByFeaturesGuidAsync(featureGuid);
    }
}
