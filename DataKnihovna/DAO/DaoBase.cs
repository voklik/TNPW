using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Interface;
using NHibernate;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
    public class DaoBase<T> : IDaoBase<T> where T : class, IEntity
    {
        protected ISession session;

        protected DaoBase()
        {
            session = NHibernateHelper.Session;
        }
        public object Create(T entity)
        {
            object o;
            using (ITransaction transaction = session.BeginTransaction())
            {
                o = session.Save(entity);
                transaction.Commit();
            }

            return o;
          
        }

        public void Delete(T entity)
        {

            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }

        public T GetById(int id)
        {
            return session.CreateCriteria<T>().Add(Restrictions.Eq("Id", id)).UniqueResult<T>();
        }

        public IList<T> GetlAll()
        {
          
            return session.QueryOver<T>().List<T>();
        }

        public void Update(T entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
               session.Update(entity);
                transaction.Commit();
            }
        }
       
        public int getNewId()
        {
        
            int Id = session.QueryOver<T>().List<T>().Max(u => u.Id);
            Id++;
            return Id;
        }



        public IList<T> getPaged(int count, int page, out int totalItems,Boolean onlyActive)
        {

            if (onlyActive == false)
            {
                totalItems = session.CreateCriteria<T>()
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();

                return session.CreateCriteria<T>()
                    .SetFirstResult((page - 1) * count)
                    .SetMaxResults(count)
                    .List<T>();
            }
            else
            {
                totalItems = session.CreateCriteria<T>()
                    .SetProjection((Projections.RowCount())).Add(Restrictions.Eq("Aktivovano", true)).UniqueResult<int>();

                return session.CreateCriteria<T>()
                    .Add(Restrictions.Eq("Aktivovano", true))
                    .SetFirstResult((page - 1) * count)
                    .SetMaxResults(count)
                    .List<T>();
            }
        }
    }
}
