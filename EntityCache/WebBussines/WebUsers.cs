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
    public class WebUsers : IUsers
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [DisplayName("نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string RealName { get; set; }
        public Guid RolleGuid { get; set; }
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string UserName { get; set; }
        [DisplayName("کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }
        public string ActiveCode { get; set; }
        [DisplayName("وضعیت")]
        public bool IsActive { get; set; }
        [DisplayName("تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }
        [DisplayName("مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }

        [DisplayName("تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }

        [DisplayName("عنوان نقش")]
        public string RolleName => AsyncContext.Run(() => RolleBussines.GetAsync(RolleGuid)).RolleTitle;
        [DisplayName("تاریخ ثبت نام")]
        public string DateSh => Calendar.MiladiToShamsi(RegisterDate);
        [DisplayName("کاربر به عنوان ادمین فعال باشد")]
        public bool IsAdmin { get; set; }
        

        public static async Task<bool> CheckEmail(Guid guid, string email) =>
            await UnitOfWork.Users.CheckEmail(guid, email);

        public static Guid GetRolleGuid(string rolleName) => UnitOfWork.Users.GetRolleGuid(rolleName);


        public static List<WebUsers> GetAll()
        {
            try
            {
                var list = AsyncContext.Run(UserBussines.GetAllAsync);
                var mapList = Mappings.Default.Map<List<WebUsers>>(list);
                return mapList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static WebUsers Get(Guid guid)
        {
            try
            {
                try
                {
                    var list = AsyncContext.Run(() => UserBussines.GetAsync(guid));
                    var mapList = Mappings.Default.Map<WebUsers>(list);
                    return mapList;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    return null;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public ReturnedSaveFuncInfo Remove()
        {
            var user = AsyncContext.Run(() => UserBussines.GetAsync(Guid));
            var res = new ReturnedSaveFuncInfo();
            res.AddReturnedValue(AsyncContext.Run(() => user.RemoveAsync()));
            return res;
        }

    }
}
