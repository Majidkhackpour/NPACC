using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IVisitRepository : IRepository<VisitBussines>
    {
        Task<bool> CheckIP(string ip, string date);
    }
}
