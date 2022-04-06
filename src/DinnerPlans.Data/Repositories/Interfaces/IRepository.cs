using System;
using System.Collections.Generic;
using System.Text;

namespace DinnerPlans.Data.Repositories.Interfaces
{
    interface IRepository<T>
    {
        T Get(Guid id);
        IEnumerable<T> Get(List<Guid> ids);
    }
}
