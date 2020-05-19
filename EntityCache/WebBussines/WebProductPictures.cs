using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EntityCache.Assistence;
using EntityCache.Bussines;
using Nito.AsyncEx;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.WebBussines
{
    public class WebProductPictures : IProductPictures
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [DisplayName("تصویر")]
        public string ImageName { get; set; }
        [DisplayName("کالا")]
        public Guid PrdGuid { get; set; }
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Title { get; set; }

        public static WebProductPictures Get(Guid guid)
        {
            try
            {
                var prd = AsyncContext.Run(() => ProductPicturesBussines.GetAsync(guid));
                var mapList = Mappings.Default.Map<WebProductPictures>(prd);
                return mapList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public ReturnedSaveFuncInfo Remove()
        {
            var user = AsyncContext.Run(() => ProductPicturesBussines.GetAsync(Guid));
            var res = new ReturnedSaveFuncInfo();
            res.AddReturnedValue(AsyncContext.Run(() => user.RemoveAsync()));
            return res;
        }
    }
}
