using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ISimcardRepository : IRepository<SimcardBussines>
    {
        Task<SimcardBussines> GetAsync(long number);
        Task<bool> CheckNumber(Guid guid, long number);
    }
}
