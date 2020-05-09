using System;
using System.Collections.Generic;
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

            #region Rolles
            var allRolles = await RolleBussines.GetAllAsync();
            var _roolesList = new List<RolleBussines>();
            if (allRolles.Count <= 0)
            {
                var rolle1 = new RolleBussines()
                {
                    Guid = Guid.NewGuid(),
                    RolleName = "User",
                    RolleTitle = "کاربر عادی"
                };
                var rolle2 = new RolleBussines()
                {
                    Guid = Guid.NewGuid(),
                    RolleName = "Admin",
                    RolleTitle = "مدیر کل سیستم"
                };
                _roolesList.Add(rolle1);
                _roolesList.Add(rolle2);
                res.AddReturnedValue(await RolleBussines.SaveRangeAsync(_roolesList));
                res.ThrowExceptionIfError();
            }
            #endregion

            await dbContext.SaveChangesAsync();
            dbContext.Dispose();
        }
    }
}
