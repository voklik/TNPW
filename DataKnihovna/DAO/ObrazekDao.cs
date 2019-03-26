using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
    public class ObrazekDao :DaoBase<Obrazek>
    {
        public ObrazekDao() : base()
        {

        }
        public IList<Obrazek> GetByGame(int hra)
        {
            return session.CreateCriteria<Obrazek>()
                    .Add((Restrictions.Eq("Game.Id", hra))).List<Obrazek>();
        }
    }
}
