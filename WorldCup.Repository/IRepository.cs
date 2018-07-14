using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Repository
{
    public interface IRepository<T> : IDisposable
    {
        //Read
        IEnumerable<T> GetAll();

        T GetById(Int16 id);

        //Write
        bool Create(T model);

        bool Update(T model);

        bool Delete(Int16 id);
    }
}
