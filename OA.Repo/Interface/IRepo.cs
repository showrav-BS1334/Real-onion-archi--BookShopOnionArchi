using OA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interface
{
    public interface IRepo<T> where T : BaseEntity // lower layer er sathe all connection hobe base entity er maddhome
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
