using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class ProductPicturesBussines : IProductPictures
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string Path { get; set; }
        public Guid PrdGuid { get; set; }

        public static async Task<List<ProductPicturesBussines>> GetAllAsync(Guid prdGuid) =>
            await UnitOfWork.ProductPictures.GetAllAsync(prdGuid);

        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<ProductPicturesBussines> list,
            string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.ProductPictures.SaveRangeAsync(list, tranName));
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

        public async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(List<Guid> list,string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.ProductPictures.RemoveRangeAsync(list, tranName));
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
