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
    public class ProductBussines : IProduct
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImageName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ShortDesc { get; set; }
        private List<ProductPicturesBussines> _imageList;
        private List<PrdSelectedGroupBussines> _groupList;
        private List<PrdTagBussines> _tagsList;
        private List<PrdFeatureBussines> _featureList;
        private List<PrdCommentBussines> _commentList;
        public List<ProductPicturesBussines> ImageList
        {
            get
            {
                if (_imageList != null) return _imageList;
                _imageList = AsyncContext.Run(() => ProductPicturesBussines.GetAllAsync(Guid));
                return _imageList;
            }
            set => _imageList = value;
        }
        public List<PrdSelectedGroupBussines> GroupList
        {
            get
            {
                if (_groupList != null) return _groupList;
                _groupList = AsyncContext.Run(() => PrdSelectedGroupBussines.GetAllAsync(Guid));
                return _groupList;
            }
            set => _groupList = value;
        }
        public List<PrdTagBussines> TagsList
        {
            get
            {
                if (_tagsList != null) return _tagsList;
                _tagsList = AsyncContext.Run(() => PrdTagBussines.GetAllAsync(Guid));
                return _tagsList;
            }
            set => _tagsList = value;
        }
        public List<PrdFeatureBussines> FeatureList
        {
            get
            {
                if (_featureList != null) return _featureList;
                _featureList = AsyncContext.Run(() => PrdFeatureBussines.GetAllAsync(Guid));
                return _featureList;
            }
            set => _featureList = value;
        }
        public List<PrdCommentBussines> CommentList
        {
            get
            {
                if (_commentList != null) return _commentList;
                _commentList = AsyncContext.Run(() => PrdCommentBussines.GetAllAsync(Guid));
                return _commentList;
            }
            set => _commentList = value;
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

                if (ImageList.Count > 0)
                {
                    var list = await ProductPicturesBussines.GetAllAsync(Guid);
                    res.AddReturnedValue(
                        await UnitOfWork.ProductPictures.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                            tranName));
                    res.ThrowExceptionIfError();


                    res.AddReturnedValue(
                        await UnitOfWork.ProductPictures.SaveRangeAsync(ImageList, tranName));
                    res.ThrowExceptionIfError();
                }



                if (GroupList.Count > 0)
                {
                    var list = await PrdSelectedGroupBussines.GetAllAsync(Guid);
                    res.AddReturnedValue(
                        await UnitOfWork.PrdSelectedGroup.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                            tranName));
                    res.ThrowExceptionIfError();


                    res.AddReturnedValue(
                        await UnitOfWork.PrdSelectedGroup.SaveRangeAsync(GroupList, tranName));
                    res.ThrowExceptionIfError();
                }



                if (TagsList.Count > 0)
                {
                    var list = await PrdTagBussines.GetAllAsync(Guid);
                    res.AddReturnedValue(
                        await UnitOfWork.PrdTag.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                            tranName));
                    res.ThrowExceptionIfError();


                    res.AddReturnedValue(
                        await UnitOfWork.PrdTag.SaveRangeAsync(TagsList, tranName));
                    res.ThrowExceptionIfError();
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

                var list = await ProductPicturesBussines.GetAllAsync(Guid);
                res.AddReturnedValue(
                    await UnitOfWork.ProductPictures.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                        tranName));
                res.ThrowExceptionIfError();

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
                                    x.Name.Contains(item) || x.TagsList.Select(q => q.Tag).Contains(item) ||
                                    x.ShortDesc.Contains(item) || x.Description.Contains(item))
                                ?.ToList();
                        }
                    }

                res = res?.Distinct().OrderBy(o => o.Name).ToList();
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
