using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EntityCache.Assistence;
using EntityCache.Bussines;
using Nito.AsyncEx;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.WebBussines
{
    public class WebOpinion : IOpinion
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [DisplayName("نام و نام خانوادگی")]
        public string Name { get; set; }
        [DisplayName("ایمیل")]
        public string Email { get; set; }
        [DisplayName("شرح")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Opinion { get; set; }
        [DisplayName("تاریخ ثبت")]
        public string DateSh => Calendar.MiladiToShamsi(Modified);



        public static List<WebOpinion> GetAll()
        {
            try
            {
                var list = AsyncContext.Run(OpinionBussines.GetAllAsync);
                var mapList = Mappings.Default.Map<List<WebOpinion>>(list);
                return mapList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static WebOpinion Get(Guid guid)
        {
            try
            {
                var prd = AsyncContext.Run(() => OpinionBussines.GetAsync(guid));
                var mapList = Mappings.Default.Map<WebOpinion>(prd);
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
