using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerPlans.Services
{
    interface IDataHandler<T>
    {
        List<T> GetAll();
        T GetById();

        void Save(T viewModel);

        void SaveAll();
    }
}
