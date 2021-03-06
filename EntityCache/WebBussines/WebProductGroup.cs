﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using Nito.AsyncEx;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.WebBussines
{
    public class WebProductGroup : IProductGroup
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [DisplayName("کد گروه")]
        public string Code { get; set; }
        [DisplayName("عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Name { get; set; }
        public Guid ParentGuid { get; set; }
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        public List<WebProductGroup> SubGroups => GetAll().Where(q => q.ParentGuid == Guid).ToList();
        public int CountPrdInGroup => AsyncContext
            .Run(PrdSelectedGroupBussines.GetAllAsync).Count(q => q.GroupGuid == Guid);


        public static List<WebProductGroup> GetAll()
        {
            try
            {
                var list = AsyncContext.Run(ProductGroupBussines.GetAllAsync);
                var mapList = Mappings.Default.Map<List<WebProductGroup>>(list);
                return mapList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static WebProductGroup Get(Guid guid)
        {
            try
            {
                var list = AsyncContext.Run(() => ProductGroupBussines.GetAsync(guid));
                var mapList = Mappings.Default.Map<WebProductGroup>(list);
                return mapList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static async Task<List<WebProductGroup>> GetAllAsync()
        {
            try
            {
                var list = await ProductGroupBussines.GetAllAsync();
                var mapList = Mappings.Default.Map<List<WebProductGroup>>(list);
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
