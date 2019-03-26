using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
    public class StavDao : DaoBase<Stav>
    {
        public StavDao() : base()
        {

        }

        public IList<Stav> getAktiv( Boolean vse)
        {

            if (vse)
                return session.CreateCriteria<Stav>()
                 
                    .AddOrder(Order.Asc("id"))
                    .List<Stav>();

            else
            {


                return session.CreateCriteria<Stav>()
                    
                    .Add((Restrictions.Eq("Aktivovano", true)))
                    .AddOrder(Order.Asc("id"))
                    .List<Stav>();
            }
        }
        public IList<Stav> getMezi(Boolean vse, int dolni,int horni)
        {

            if (vse)
                return session.CreateCriteria<Stav>()
                    .Add(Restrictions.Between("Id", dolni, horni))
                    .AddOrder(Order.Asc("id"))
                    .List<Stav>();

            else
            {


                return session.CreateCriteria<Stav>()
                    .Add(Restrictions.Between("Id", dolni, horni))
                    .Add((Restrictions.Eq("Aktivovano", true)))
                    .AddOrder(Order.Asc("id"))
                    .List<Stav>();
            }
        }
    }
}
