using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EntityCache.Assistence;
using EntityCache.Bussines;
using Nito.AsyncEx;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.WebBussines
{
    public class WebProduct : IProduct
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [DisplayName("کد محصول")]
        public string Code { get; set; }
        [DisplayName("عنوان محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        [DisplayName("تصویر")]
        public string ImageName { get; set; }
        [DisplayName("قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public decimal Price { get; set; }
        [DisplayName("شرح")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("توضیح مختصر")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
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


        public static List<WebProduct> GetAll()
        {
            try
            {
                var list = AsyncContext.Run(ProductBussines.GetAllAsync);
                var mapList = Mappings.Default.Map<List<WebProduct>>(list);
                return mapList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static WebProduct Get(Guid guid)
        {
            try
            {
                var prd = ProductBussines.Get(guid);
                var mapList = Mappings.Default.Map<WebProduct>(prd);
                return mapList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static List<WebProduct> GetAll(string search, int minPrice = 0, int maxPrice = 0, List<Guid> selectedGrpous = null)
        {
            try
            {
                var list = AsyncContext.Run(() =>
                    ProductBussines.GetAllAsync(search, minPrice, maxPrice, selectedGrpous));
                var mapList = Mappings.Default.Map<List<WebProduct>>(list);
                return mapList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
