using System.Collections.Generic;

namespace DinnerPlans.Services
{
    public interface ILibraryUpdater<T>
    {
        void UpdateLibrary(object repo);

        List<T> Repo { get; set; }
    }
}