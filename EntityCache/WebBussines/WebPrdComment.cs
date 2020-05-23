using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using Nito.AsyncEx;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.WebBussines
{
    public class WebPrdComment : IPrdComment
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid PrdGuid { get; set; }
        [DisplayName("نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Name { get; set; }
        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }
        [DisplayName("وب سایت")]
        public string WebSite { get; set; }
        public Guid ParentGuid { get; set; }
        [DisplayName("متن نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(Modified);


        public static List<WebPrdComment> GetAll(Guid guid)
        {
            try
            {
                var list = AsyncContext.Run(()=>PrdCommentBussines.GetAllAsync(guid));
                var mapList = Mappings.Default.Map<List<WebPrdComment>>(list);
                return mapList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static WebPrdComment Get(Guid guid)
        {
            try
            {
                var prd = PrdCommentBussines.Get(guid);
                var mapList = Mappings.Default.Map<WebPrdComment>(prd);
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
