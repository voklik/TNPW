using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
    public class KombinaceMoznostiDao : DaoBase<KombinaceMoznosti>
    {
        public KombinaceMoznostiDao() : base()
        {

        }

        public IList<Stav> getALLAktiv(Boolean vse)
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
        public KombinaceMoznosti IsKombinace(int dopravaID, int platbaID,Boolean vse)
        {

            if (vse)
                return session.CreateCriteria<KombinaceMoznosti>()
                    .Add((Restrictions.Eq("PlatbaMoznost.Id", platbaID)))
                    .Add((Restrictions.Eq("DopravaMoznost.Id", dopravaID)))
                    .UniqueResult<KombinaceMoznosti>();

            else
            {
                

                return session.CreateCriteria<KombinaceMoznosti>()
                    .Add((Restrictions.Eq("PlatbaMoznost.Id", platbaID)))
                    .Add((Restrictions.Eq("DopravaMoznost.Id", dopravaID)))
                    .Add((Restrictions.Eq("Aktivovano", true)))
                    .UniqueResult<KombinaceMoznosti>();
            }
        }
    }
}
