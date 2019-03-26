using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
    public class PlatetbniMoznostDao : DaoBase<PlatetbniMoznost>
    {
        public PlatetbniMoznostDao() : base()
        {

        }
        public IList<PlatetbniMoznost> getAktiv( Boolean vse)
        {

            if (vse)
                return session.CreateCriteria<PlatetbniMoznost>()
                
                    .AddOrder(Order.Asc("id"))
                    .List<PlatetbniMoznost>();

            else
            {


                return session.CreateCriteria<PlatetbniMoznost>()
                  
                    .Add((Restrictions.Eq("Aktivovano", true)))
                    .AddOrder(Order.Asc("id"))
                    .List<PlatetbniMoznost>();
            }
        }

    }
}
