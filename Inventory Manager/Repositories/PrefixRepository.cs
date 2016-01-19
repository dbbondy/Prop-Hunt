using System;
using System.Collections.Generic;
using Inventory_Manager.Domain;

namespace Inventory_Manager.Repositories
{
    class PrefixRepository : IRepository<Domain.Prefix>
    {
        IEnumerable<Prefix> IRepository<Prefix>.getList
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        void IRepository<Prefix>.add(Prefix item)
        {
            throw new NotImplementedException();
        }

        void IRepository<Prefix>.delete(Prefix item)
        {
            throw new NotImplementedException();
        }

        Prefix IRepository<Prefix>.update(Prefix item)
        {
            throw new NotImplementedException();
        }
    }
}
