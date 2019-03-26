using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
    public class DopravaMoznostDao : DaoBase<DopravaMoznost>
    {
        public DopravaMoznostDao() : base()
        {

        }
        public IList<DopravaMoznost> getAktiv(Boolean vse)
        {

            if (vse)
                return session.CreateCriteria<DopravaMoznost>()
                   
                    .AddOrder(Order.Asc("id"))
                    .List<DopravaMoznost>();

            else
            {
                
     
            return session.CreateCriteria<DopravaMoznost>()
            
                .Add((Restrictions.Eq("Aktivovano", true)))
               .AddOrder(Order.Asc("id"))
                .List<DopravaMoznost>();
            }
        }

    }
}
