using System;
using System.Collections.Generic;
using Smartspace.Repository.Interfaces;

namespace Smartspace.Repository
{
    public class InMemoryRepository<T> : IRepository<T> where T : IStoreable
    {
        private readonly List<T> _entityList;

        public InMemoryRepository()
        {
            _entityList = new List<T>();
        }

        public IEnumerable<T> All()
        {
            return _entityList;
        }

        public void Delete(IComparable id)
        {
            throw new NotImplementedException();
        }

        public T FindById(IComparable id)
        {
            throw new NotImplementedException();
        }

        public void Save(T item)
        {
            _entityList.Add(item);
        }
    }
}
