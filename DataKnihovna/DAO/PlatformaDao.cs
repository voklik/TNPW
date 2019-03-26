using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
    public class PlatformaDao : DaoBase<Platforma>
    {
        public PlatformaDao() : base()
        {

        }

        public Platforma GetByGame(int id)
        {


            return session.CreateCriteria<Hra>()
                .Add((Restrictions.Eq("Id", id)))
                .UniqueResult<Hra>().Platforma;
        }
    }
}
