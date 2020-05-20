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
    public class WebFeature : IFeatures
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [DisplayName("ویژگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Title { get; set; }


        public static List<WebFeature> GetAll()
        {
            try
            {
                var list = AsyncContext.Run(FeatureBussines.GetAllAsync);
                var mapList = Mappings.Default.Map<List<WebFeature>>(list);
                return mapList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static WebFeature Get(Guid guid)
        {
            try
            {
                var prd = FeatureBussines.Get(guid);
                var mapList = Mappings.Default.Map<WebFeature>(prd);
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
