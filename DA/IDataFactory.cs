using System.Collections.Generic;

namespace StudentManagementAPI.DA
{
    public interface IDataFactory<T>
    {
        List<T> GetAll();
        T Get(string id);
        bool Add(T itm);
        bool Update(T itm);
        bool Remove(T itm);
        int Total();
    }
}