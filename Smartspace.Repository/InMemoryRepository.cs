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
            return _entityList.AsReadOnly();
        }

        public void Delete(IComparable id)
        {
            var item = FindById(id);
            if (item == null)
                return;

            _entityList.Remove(item);
        }

        public T FindById(IComparable id)
        {
            return _entityList.Find(i => IsMatch(i.Id, id));
        }

        public void Save(T item)
        {
            _entityList.Add(item);
        }

        private bool IsMatch(IComparable id1, IComparable id2)
        {
            return id1.CompareTo(id2) == 0;
        }
    }
}
