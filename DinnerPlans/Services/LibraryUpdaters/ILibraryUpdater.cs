using System.Collections.Generic;

namespace DinnerPlans.Services
{
    public interface ILibraryUpdater<T>
    {
        void UpdateLibrary(List<T> repo);
    }
}