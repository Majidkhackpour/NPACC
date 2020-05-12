using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class UserBussines : IUsers
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string RealName { get; set; }
        public Guid RolleGuid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ActiveCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool RememberMe { get; set; }

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
                res.AddReturnedValue(await UnitOfWork.Users.SaveAsync(this, tranName));
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

        public static async Task<UserBussines> GetAsync(string activeCode) =>
            await UnitOfWork.Users.GetAsync(activeCode);

        public static async Task<UserBussines> AuthenticationUserAsync(string email, string hashPass) =>
            await UnitOfWork.Users.AuthenticationUser(email, hashPass);

        public static async Task<string[]> GetAllRollesAsync(string userName) =>
            await UnitOfWork.Users.GetAllRollesAsync(userName);

        public static string[] GetAllRolles(string userName) => AsyncContext.Run(() => GetAllRollesAsync(userName));

        public static async Task<List<UserBussines>> GetAllAsync() => await UnitOfWork.Users.GetAllAsync();
    }
}
