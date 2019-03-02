using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKnihovna.Interface
{
    interface IDaoBase<T>
    {
        IList<T> GetlAll();

        object Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
    }
}
