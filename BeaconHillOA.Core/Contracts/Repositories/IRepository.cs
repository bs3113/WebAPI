namespace BeaconHillOA.Core.Contracts.Repositories;

public interface IRepository<T> where T : class
{
    T Create(T entity);
    T Update(T entity);
    bool Delete(int id);
    IEnumerable<T> GetAll();
    T GetById(int id);
}