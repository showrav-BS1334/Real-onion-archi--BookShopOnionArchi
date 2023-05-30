using Microsoft.EntityFrameworkCore;
using OA.Entity;
using OA.Repo.Interface;

namespace OA.Repo.Repo
{
    public class Repo<T> : IRepo<T> where T : BaseEntity
    {
        private readonly AppDbContext context;
        private DbSet<T> entities; // cz ami to jani na kon table e kaaj korbo
        public Repo(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T? Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(T? entity)
        {
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
