using System.Collections.Generic;

namespace Inventory_Manager.Repositories
{
    interface IRepository<T>
    {
        IEnumerable<T> getList { get; }

        void add(T item);

        T update(T item);

        void delete(T item);
    }
}
