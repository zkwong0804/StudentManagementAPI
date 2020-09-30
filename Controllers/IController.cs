using System.Collections.Generic;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
    public interface IController<T>
    {
        List<T> GetAll();
        T Get(string id);
        bool Post(T itm);
        bool Put(T itm);
        bool Delete(T itm);
    }
}