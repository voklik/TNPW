using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
    public class PolozkaKosikDao : DaoBase<PolozkaKosik>
    {
        public PolozkaKosikDao() : base()
        {

        }
        public IList<PolozkaKosik> GetByUzivatel(int id)
        {


           

            return session.CreateCriteria<PolozkaKosik>()
                .Add((Restrictions.Eq("IdUser", id)))
           
                .List<PolozkaKosik>();
        }

    }
}
