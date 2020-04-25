using System;
using System.Collections.Generic;
using PacketParser.Services;

namespace EntityCache.Core
{
    public interface IRepository<T> where T : class, IHasGuid, new()
    {
        T Get(Guid guid);
        ReturnedSaveFuncInfo Remove(T item);
        ReturnedSaveFuncInfo RemoveAll(List<T> list);
        List<T> GetAll();
        ReturnedSaveFuncInfo Save(T item);
    }
}
