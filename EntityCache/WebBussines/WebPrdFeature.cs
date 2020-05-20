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
    public class WebPrdFeature : IPrdFeatures
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid PrdGuid { get; set; }
        [DisplayName("ویژگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public Guid FeatureGuid { get; set; }
        [DisplayName("مقدار")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Value { get; set; }

        public static List<WebPrdFeature> GetAll()
        {
            try
            {
                var list = AsyncContext.Run(PrdFeatureBussines.GetAllAsync);
                var mapList = Mappings.Default.Map<List<WebPrdFeature>>(list);
                return mapList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static WebPrdFeature Get(Guid guid)
        {
            try
            {
                var prd = PrdFeatureBussines.Get(guid);
                var mapList = Mappings.Default.Map<WebPrdFeature>(prd);
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
            var user = AsyncContext.Run(() => PrdFeatureBussines.GetAsync(Guid));
            var res = new ReturnedSaveFuncInfo();
            res.AddReturnedValue(AsyncContext.Run(() => user.RemoveAsync()));
            return res;
        }
    }
}
