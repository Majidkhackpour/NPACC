using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ISettingsRepositort : IRepository<SettingsBussines>
    {
        Task<SettingsBussines> GetAsync(string memberName);
    }
}
