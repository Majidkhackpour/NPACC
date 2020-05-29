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
    public class WebSlider : ISlider
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Title { get; set; }
        [DisplayName("تصویر")]
        public string ImageName { get; set; }
        [DisplayName("URL")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [Url(ErrorMessage = "آدرس وارد شده معتبر نمی باشد")]
        public string URL { get; set; }
        [DisplayName("تاریخ شروع")]
        public DateTime StartDate { get; set; }
        [DisplayName("تاریخ پایان")]
        public DateTime EndDate { get; set; }
        [DisplayName("وضعیت")]
        public bool IsActive { get; set; }
        public string StartDateSh => Calendar.MiladiToShamsi(StartDate);
        public string EndDateSh => Calendar.MiladiToShamsi(EndDate);


        public static List<WebSlider> GetAll()
        {
            try
            {
                var list = AsyncContext.Run(SliderBussines.GetAllAsync);
                var mapList = Mappings.Default.Map<List<WebSlider>>(list);
                return mapList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static WebSlider Get(Guid guid)
        {
            try
            {
                var prd = SliderBussines.Get(guid);
                var mapList = Mappings.Default.Map<WebSlider>(prd);
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
