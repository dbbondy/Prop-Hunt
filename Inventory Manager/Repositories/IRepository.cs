using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
