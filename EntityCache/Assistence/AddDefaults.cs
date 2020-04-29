using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using PacketParser.Services;
using SqlServerPersistence.Model;

namespace EntityCache.Assistence
{
   public class AddDefaults
    {
        public static async Task InsertDefaultDataAsync()
        {
            var dbContext = new ModelContext();
            var res = new ReturnedSaveFuncInfo();

            #region Customer

            var allCusGroup = await CustomerGroupBussines.GetAllAsync();
            if (allCusGroup.Count <= 0)
            {
                var cusGroup = new CustomerGroupBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = "فروشگاه اینترنتی",
                    ParentGuid = Guid.Empty
                };
                res.AddReturnedValue(await cusGroup.SaveAsync());
                res.ThrowExceptionIfError();
            }
            #endregion

            await dbContext.SaveChangesAsync();
            dbContext.Dispose();
        }
    }
}
