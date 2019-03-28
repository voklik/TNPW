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

        public IList<KombinaceMoznosti> getALLAktiv(Boolean vse)
        {

            if (vse)
                return session.CreateCriteria<KombinaceMoznosti>()

                    .AddOrder(Order.Asc("id"))
                    .List<KombinaceMoznosti>();

            else
            {


                return session.CreateCriteria<KombinaceMoznosti>()

                    .Add((Restrictions.Eq("Aktivovano", true)))
                    .AddOrder(Order.Asc("id"))
                    .List<KombinaceMoznosti>();
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
        public Boolean IsKombinaceQuery(int dopravaID, int platbaID, Boolean vse)
        {

            if (vse)
            {
               int totalItems = session.CreateCriteria<KombinaceMoznosti>()
                    .Add((Restrictions.Eq("PlatbaMoznost.Id", platbaID)))
                    .Add((Restrictions.Eq("DopravaMoznost.Id", dopravaID)))
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();
               if (totalItems==1)
               {
                   return true;

               }
               else
               {
                   return false;
                }
            }
            else
            {


               
                int totalItems = session.CreateCriteria<KombinaceMoznosti>()
                    .Add((Restrictions.Eq("PlatbaMoznost.Id", platbaID)))
                    .Add((Restrictions.Eq("Aktivovano", true)))
                    .Add((Restrictions.Eq("DopravaMoznost.Id", dopravaID)))
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();
                if (totalItems == 1)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
        }
    }
}
