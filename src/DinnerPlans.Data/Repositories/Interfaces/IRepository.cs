namespace DinnerPlans.Data.Repositories.Interfaces;

interface IRepository<T>
{
    T Get(int id);
    T Update(T entity);
    T Delete(int id);
    T Create(T entity);
}
