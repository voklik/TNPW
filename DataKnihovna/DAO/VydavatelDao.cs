using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
    public class VydavatelDao : DaoBase<Vydavatel>
    {
        public VydavatelDao() : base()
        {

        }

        public IList<Vydavatel> SearchName(string query)
        {
            return session.CreateCriteria<Hra>()
                .Add((Restrictions.Like("Nazev", string.Format("%{0}%", query))))
                .List<Vydavatel>();

        }
     

        public Vydavatel GetByGame(int id)
        {


            return session.CreateCriteria<Hra>()
                .Add((Restrictions.Eq("Id", id)))
                .UniqueResult<Hra>().Vydavatel;
        }


    }
    
}