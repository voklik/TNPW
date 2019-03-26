using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
    public class PolozkaObjednavkaDao : DaoBase<PolozkaObjednavka>
    {
        public PolozkaObjednavkaDao() : base()
        {

        }
        public IList<PolozkaObjednavka> getbyObjednavka(int id)
        {


            return session.CreateCriteria<PolozkaObjednavka>()
                .Add((Restrictions.Eq("ObjednavkaID", id)))
                .AddOrder(Order.Asc("Id"))
                .List<PolozkaObjednavka>();
        }

    }
}
