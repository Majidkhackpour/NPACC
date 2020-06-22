using System;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.EntitiesInterface;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class SettingsBussines : ISettings
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string Value { get; set; }


        public static async Task<SettingsBussines> GetAsync(string memberName) =>
            await UnitOfWork.Setting.GetAsync(memberName);

        public static SettingsBussines Get(string memberName) => AsyncContext.Run(() => GetAsync(memberName));
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(string key, string value, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                var sett = Get(key);
                if (sett != null)
                {
                    res.AddReturnedValue(await UnitOfWork.Setting.RemoveAsync(sett.Guid, tranName));
                    res.ThrowExceptionIfError();
                }

                var set = new SettingsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = key,
                    Value = value,
                    Modified = DateTime.Now
                };

                res.AddReturnedValue(await UnitOfWork.Setting.SaveAsync(set, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }

        public async Task<ReturnedSaveFuncInfo> RemoveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.Setting.RemoveAsync(Guid, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }

        public static ReturnedSaveFuncInfo Save(string key, string value, string tranName = "") =>
            AsyncContext.Run(() => SaveAsync(key, value, tranName));


        private static string _email = "";
        public static string Email
        {
            get
            {
                if (!string.IsNullOrEmpty(_email)) return _email;
                var mem = Get("EmailSender");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _email = value;
                Save("EmailSender", _email);
            }
        }
        private static string _emailPassword = "";
        public static string EmailPassword
        {
            get
            {
                if (!string.IsNullOrEmpty(_emailPassword)) return _emailPassword;
                var mem = Get("EmailPassword");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _emailPassword = value;
                Save("EmailPassword", _emailPassword);
            }
        }
        private static string _firstBlockColor = "";
        public static string FirstBlockColor
        {
            get
            {
                if (!string.IsNullOrEmpty(_firstBlockColor)) return _firstBlockColor;
                var mem = Get("FirstBlockColor");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _firstBlockColor = value;
                Save("FirstBlockColor", _firstBlockColor);
            }
        }
        private static string _firstBlockText = "";
        public static string FirstBlockText
        {
            get
            {
                if (!string.IsNullOrEmpty(_firstBlockText)) return _firstBlockText;
                var mem = Get("FirstBlockText");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _firstBlockText = value;
                Save("FirstBlockText", _firstBlockText);
            }
        }
        private static string _tellForSite = "";
        public static string TellForSite
        {
            get
            {
                if (!string.IsNullOrEmpty(_tellForSite)) return _tellForSite;
                var mem = Get("TellForSite");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _tellForSite = value;
                Save("TellForSite", _tellForSite);
            }
        }
        private static string _siteDomain = "";
        public static string SiteDomain
        {
            get
            {
                if (!string.IsNullOrEmpty(_siteDomain)) return _siteDomain;
                var mem = Get("SiteDomain");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _siteDomain = value;
                Save("SiteDomain", _siteDomain);
            }
        }
    }
}
