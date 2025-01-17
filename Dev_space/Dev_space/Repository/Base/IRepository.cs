﻿using System.Linq.Expressions;
namespace Dev_space.Repository.Base
{
    public interface IRepository<T> where T : class 
    {
        //Find and Get Items
        T FindById(string Id);
        T SelectOne(Expression<Func<T, bool>> match);
        ICollection<T> GetAll();

       
        //ager loading
            IEnumerable<T> FindAllItem(params string[] agers);
        //CURD
        void AddItem(T item);
        void RemoveItem(T item);
        void UpdateItem (T item);


    }
}
