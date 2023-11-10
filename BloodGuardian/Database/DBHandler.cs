using BloodGuardian.Common;
using BloodGuardian.Models;
using Newtonsoft.Json;

namespace BloodGuardian.Database
{


    public interface DB<T>
    {


        void Add(T entity);
        void Delete(T entity);

        void Update(string path);
        List<T> Read();


    }
}
