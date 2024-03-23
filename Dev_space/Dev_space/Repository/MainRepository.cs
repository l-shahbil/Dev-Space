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
        

        IEnumerable<T> IRepository<T>.FindAllItem(params string[] agers)
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

        T IRepository<T>.FindById(int Id)
        {
            return context.Set<T>().Find(Id);
        }
        ICollection<T> IRepository<T>.GetAll()
        {
            return context.Set<T>().ToList();
        }
        T IRepository<T>.SelectOne(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().SingleOrDefault(match);
        }
        //CURD
        void IRepository<T>.AddItem(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        void IRepository<T>.AddList(IEnumerable<T> items)
        {
            context.Set<T>().AddRange(items);
            context.SaveChanges();
        }
        void IRepository<T>.RemoveItem(T item)
        {
            context.Set<T>().Remove(item);
            context.SaveChanges();
        }

        void IRepository<T>.RemoveList(IEnumerable<T> items)
        {
            context.Set<T>().RemoveRange(items);
            context.SaveChanges();
        }

        void IRepository<T>.UpdateItem(T item)
        {
            context.Set<T>().Update(item);
            context.SaveChanges();
        }

        void IRepository<T>.UpdateList(IEnumerable<T> items)
        {
            context.Set<T>().UpdateRange(items);
            context.SaveChanges();
        }
    }
}
