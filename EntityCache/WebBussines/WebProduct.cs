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
        [DisplayName("ابعاد")]
        public string Abad { get; set; }
        [DisplayName("جنس")]
        public string Kind { get; set; }
        [DisplayName("رنگ")]
        public string Color { get; set; }


        private List<ProductPicturesBussines> _imageList;
        private List<PrdSelectedGroupBussines> _groupList;
        private List<PrdTagBussines> _tagsList;
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
    }
}
