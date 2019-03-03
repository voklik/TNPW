using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
    public class GameDao : DaoBase<Hra>
    {
        
        public GameDao() : base()
        {

        }
        public IList<Hra> GetByPlatforma(int id)
        {
            return null;
            // return session.CreateCriteria<Hra>().Add(Restrictions.Eq("Id", id)).UniqueResult<Hra>();
        }
        public IList<Hra> GetByVydavatel(int id)
        {
            return null;
            //  return session.CreateCriteria<Hra>().Add(Restrictions.Eq("Id", id)).UniqueResult<Hra>();
        }
    }
}
