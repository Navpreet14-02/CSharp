namespace BloodGuardian.Database.Interface
{


    public interface IDB<T>
    {

        void Add(T entity);
        void Delete(T entity);

        void Update(string path);
        List<T> Get();


    }
}
