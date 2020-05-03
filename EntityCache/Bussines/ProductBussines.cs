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
    public class ProductBussines : IProduct
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string Code { get; set; }
        public string HalfCode { get; set; }
        public string Name { get; set; }
        public Guid GroupGuid { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Abad { get; set; }
        public string Kind { get; set; }
        public string Color { get; set; }
        private List<ProductPicturesBussines> _imageList;

        public List<ProductPicturesBussines> ImageList
        {
            get
            {
                _imageList = AsyncContext.Run(()=>ProductPicturesBussines.GetAllAsync(Guid));
                return _imageList;
            }
            set => _imageList = value;
        }

        public static async Task<List<ProductBussines>> GetAllAsync() =>
            await UnitOfWork.Product.GetAllAsync();

        public static async Task<ProductBussines> GetAsync(Guid guid) =>
            await UnitOfWork.Product.GetAsync(guid);

        public static ProductBussines Get(Guid guid) =>
            AsyncContext.Run(() => GetAsync(guid));

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

                res.AddReturnedValue(await UnitOfWork.Product.SaveAsync(this, tranName));
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

        public static async Task<bool> CheckName(Guid guid, string name) =>
            await UnitOfWork.Product.CheckName(guid, name);

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

                res.AddReturnedValue(await UnitOfWork.Product.RemoveAsync(Guid, tranName));
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


        public static async Task<string> NextCode() => await UnitOfWork.Product.NextCode();

        public static async Task<List<ProductBussines>> GetAllAsync(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                List<ProductBussines> res = null;
                res = await GetAllAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x =>
                                    x.Name.Contains(item) ||
                                    x.Kind.Contains(item) ||
                                    x.Color.Contains(item))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.Name).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<ProductBussines>();
            }
        }

        public static async Task<List<ProductBussines>> GetAllByGroupAsync(Guid groupGuid) =>
            await UnitOfWork.Product.GetAllByGroupAsync(groupGuid);
    }
}
