using Dev_space.Data;
using Dev_space.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dev_space.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        protected AppDbContext context;
        public MainRepository(AppDbContext context)
        {
            this.context = context;
        }
        

        public IEnumerable<T> FindAllItem(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }
            return query.ToList();
        }

        public T FindById(int Id)
        {
            return context.Set<T>().Find(Id);
        }
        ICollection<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().SingleOrDefault(match);
        }
        //CURD
         public void AddItem(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public void AddList(IEnumerable<T> items)
        {
            context.Set<T>().AddRange(items);
            context.SaveChanges();
        }
        public void RemoveItem(T item)
        {
            context.Set<T>().Remove(item);
            context.SaveChanges();
        }

        public void RemoveList(IEnumerable<T> items)
        {
            context.Set<T>().RemoveRange(items);
            context.SaveChanges();
        }

        public void UpdateItem(T item)
        {
            context.Set<T>().Update(item);
            context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> items)
        {
            context.Set<T>().UpdateRange(items);
            context.SaveChanges();
        }
    }
}
