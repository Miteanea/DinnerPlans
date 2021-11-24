using System;
using System.Collections.Generic;

namespace DinnerPlans.API.Services.Data.Recipes
{
    public interface IRepository<T>
    {
        T Get(Guid guid);

        T Get(Guid id, Guid userId);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Guid userId);

        IEnumerable<T> Get(Filters filters);

        IEnumerable<T> Get(Filters filters, Guid userId);

        void Save(T input, Guid userId);

        void Delete(T input, Guid userId);
    }
}