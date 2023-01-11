namespace Phonebook.Repositories
{
    public interface IRepository<T1, T2> where T1 : class
    {
        IEnumerable<T1> GetAll();
        T1 GetById(T2 id);
        void Insert(T1 enitity);
        void Update(T1 enitity);
        void Delete(T2 id);
        void Save();
    }
}
