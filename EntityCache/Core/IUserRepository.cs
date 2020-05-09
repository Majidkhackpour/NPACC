using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IUserRepository : IRepository<UserBussines>
    {
        Task<bool> CheckEmail(Guid guid, string email);
        Guid GetRolleGuid(string rolleName);
        Task<UserBussines> GetAsync(string activeCode);
    }
}
