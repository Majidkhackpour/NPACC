using System;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using PacketParser.Services;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class UsersPersistenceRepository : GenericRepository<UserBussines, Users>, IUserRepository
    {
        private ModelContext db;

        public UsersPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<bool> CheckEmail(Guid guid, string email)
        {
            try
            {
                var acc = db.Users.AsNoTracking().Where(q => q.Email == email.Trim().ToLower() && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }

        public Guid GetRolleGuid(string rolleName)
        {
            try
            {
                var acc = db.Rolles.AsNoTracking().FirstOrDefault(q => q.RolleName == rolleName);
                return acc?.Guid ?? Guid.Empty;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return Guid.Empty;
            }
        }

        public async Task<UserBussines> GetAsync(string activeCode)
        {
            try
            {
                var acc = db.Users.AsNoTracking().SingleOrDefault(q => q.ActiveCode == activeCode);
                return Mappings.Default.Map<UserBussines>(acc);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public async Task<UserBussines> AuthenticationUser(string email, string hashPass)
        {
            try
            {
                var acc = db.Users.AsNoTracking()
                    .SingleOrDefault(q => q.Email == email.Trim().ToLower() && q.Password == hashPass);
                var map = Mappings.Default.Map<UserBussines>(acc);
                return map;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<string[]> GetAllRollesAsync(string userName)
        {
            try
            {
                var acc = db.Users.AsNoTracking()
                    .SingleOrDefault(q => q.UserName == userName);
                var rolles = db.Rolles.AsNoTracking().Where(q => q.Guid == acc.RolleGuid).Select(q => q.RolleName)
                    .ToArray();
                return rolles;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
