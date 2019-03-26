using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
    public class ObjednavkaDao : DaoBase<Objednavka>
    {
        public ObjednavkaDao() : base()
        {

        }
       
        public IList<Objednavka> GetByStav(int id, out int totalItems)
        {

           
                totalItems = session.CreateCriteria<Objednavka>()
                    .Add((Restrictions.Eq("Stav.Id", id)))
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();



                return session.CreateCriteria<Objednavka>()
                    .AddOrder(Order.Asc("Cislo"))
                    .Add((Restrictions.Eq("Stav.Id", id)))
                    .List<Objednavka>();
            }

        public IList<Objednavka> GetByUzivatel(int id)
        {


         


            return session.CreateCriteria<Objednavka>()
                .Add((Restrictions.Eq("IdUser", id)))
                .AddOrder(Order.Asc("Cislo"))
                .List<Objednavka>();
        }
 
        public IList<Objednavka> SearchObjednavku(string query, out int totalItems)
        {
            totalItems= session.CreateCriteria<Objednavka>()
                .Add((Restrictions.Like("Cislo", string.Format("%{0}%", query))))
                .SetProjection((Projections.RowCount())).UniqueResult<int>();
            return session.CreateCriteria<Objednavka>()
                .Add((Restrictions.Like("Cislo", string.Format("%{0}%", query))))
                .AddOrder(Order.Asc("Cislo"))
                .List<Objednavka>();

        }
        public IList<Objednavka> getPaged(int count, int page, out int totalItems)
        {

         
                totalItems = session.CreateCriteria<Objednavka>()
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();

                return session.CreateCriteria<Hra>()

                    .AddOrder(Order.Asc("Cislo"))
                    .SetFirstResult((page - 1) * count)
                    .SetMaxResults(count)
                    .List<Objednavka>();
            }
        }
    }

