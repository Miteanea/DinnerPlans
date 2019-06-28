using System.Collections.Generic;

namespace DinnerPlans.Services
{
    internal interface IDataHandler<T>
    {
        List<T> GetAll();

        T GetById();

        void Save(T viewModel);

        void SaveAll();
    }
}