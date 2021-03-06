﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public DateTime Modified { get; set; } = DateTime.Now;
        public string RealName { get; set; }
        public Guid RolleGuid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ActiveCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public bool RememberMe { get; set; }
        public string RolleName => RolleBussines.Get(RolleGuid).RolleTitle;

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

        public ReturnedSaveFuncInfo Save(string tranName = "") => AsyncContext.Run(() => SaveAsync(tranName));
        public static async Task<UserBussines> GetAsync(string activeCode) =>
            await UnitOfWork.Users.GetAsync(activeCode);

        public static async Task<UserBussines> AuthenticationUserAsync(string email, string hashPass) =>
            await UnitOfWork.Users.AuthenticationUser(email, hashPass);

        public static async Task<string[]> GetAllRollesAsync(string userName) =>
            await UnitOfWork.Users.GetAllRollesAsync(userName);

        public static string[] GetAllRolles(string userName) => AsyncContext.Run(() => GetAllRollesAsync(userName));

        public static async Task<List<UserBussines>> GetAllAsync() => await UnitOfWork.Users.GetAllAsync();

        public static async Task<UserBussines> GetAsyncByEmail(string email) =>
            await UnitOfWork.Users.GetAsyncByEmail(email);

        public static async Task<UserBussines> GetAsyncByUserName(string uName) =>
            await UnitOfWork.Users.GetAsyncByUserName(uName);

        public static async Task<UserBussines> GetAsync(Guid guid) => await UnitOfWork.Users.GetAsync(guid);

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

                res.AddReturnedValue(await UnitOfWork.Users.RemoveAsync(Guid, tranName));
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

        public static UserBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));

        public static async Task<List<UserBussines>> GetAllAsync(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                List<UserBussines> res = null;
                res = await GetAllAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x =>
                                    x.RealName.Contains(item) ||
                                    x.UserName.Contains(item) ||
                                    x.RolleName.Contains(item) ||
                                    x.Email.Contains(item))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.RealName).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<UserBussines>();
            }
        }

    }
}
