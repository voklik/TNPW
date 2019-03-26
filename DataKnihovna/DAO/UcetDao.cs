using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;

namespace DataKnihovna.DAO
{
 public   class UcetDao : DaoBase<Ucet>
    {

        public UcetDao() : base()
        {

        }
        public  Ucet GetUser(string username)
        {
            UcetDao ucetDao = new UcetDao();
            Ucet ucet = ucetDao.GetByLogin(username);

            return ucet;
        }
        public Ucet GetByLoginAndPassword(string login, string password)
        {
            return session.CreateCriteria<Ucet>()
                .Add((Restrictions.Eq("Login", login)))
                .Add((Restrictions.Eq("Heslo", password)))
                .UniqueResult<Ucet>();

        }
        public Ucet GetByLogin(string login)
        {
            return session.CreateCriteria<Ucet>()
                .Add((Restrictions.Eq("Login", login)))
                .UniqueResult<Ucet>();

        }
        public IList<Ucet> GetByRole(int idRole)
        {
            return session.CreateCriteria<Ucet>()
                .Add((Restrictions.Eq("RoleUzivatele.Id", idRole)))
                .List<Ucet>();

        }
        public IList<Ucet> SearchLogin(string query)
        {
            return session.CreateCriteria<Ucet>()
                .Add((Restrictions.Like("Login", string.Format("%{0}%",query))))
                .List<Ucet>();

        }
        public IList<Ucet> SearchPrijmeni(string query)
        {
            return session.CreateCriteria<Ucet>()
                .Add((Restrictions.Like("Prijmeni", string.Format("%{0}%", query))))
                .List<Ucet>();

        }
        public IList<Ucet> SearchPrezdivka(string query)
        {
            return session.CreateCriteria<Ucet>()
                .Add((Restrictions.Like("Prezdivka", string.Format("%{0}%", query))))
                .List<Ucet>();

        }
       
        public IList<Ucet> Search(string jmeno, string login, string prezdivka, string prijmeni, out int totalItems)
        {
            totalItems = session.CreateCriteria<Ucet>()
                .Add((Restrictions.Like("Jmeno", string.Format("%{0}%", jmeno))))
                .Add((Restrictions.Like("Prijmeni", string.Format("%{0}%", prijmeni))))
                .Add((Restrictions.Like("Login", string.Format("%{0}%", login))))
                .Add((Restrictions.Like("Prezdivka", string.Format("%{0}%", prezdivka))))
                .SetProjection((Projections.RowCount())).UniqueResult<int>();

            return session.CreateCriteria<Ucet>()
                .Add((Restrictions.Like("Jmeno", string.Format("%{0}%", jmeno))))
                .Add((Restrictions.Like("Prijmeni", string.Format("%{0}%", prijmeni))))
                .Add((Restrictions.Like("Login", string.Format("%{0}%", login))))
                .Add((Restrictions.Like("Prezdivka", string.Format("%{0}%", prezdivka))))
                .List<Ucet>();

        }
        public IList<Ucet> SearchJmeno(string query)
        {
            return session.CreateCriteria<Ucet>()
                .Add((Restrictions.Like("Jmeno", string.Format("%{0}%", query))))
                .List<Ucet>();

        }
        public IList<Ucet> getPagedByRole(int count,int idRole, int page, out int totalItems, Boolean vse)
        {



            if  (idRole == 1 || idRole == 2 || idRole == 3)
                {// vrací samostatné skupiny
                    if (vse == true)
                    {
                        totalItems = session.CreateCriteria<Ucet>()
                            .Add((Restrictions.Eq("RoleUzivatele.Id", idRole)))
                            .SetProjection((Projections.RowCount())).UniqueResult<int>();

                        return session.CreateCriteria<Ucet>()
                            .Add((Restrictions.Eq("RoleUzivatele.Id", idRole)))
                            .SetFirstResult((page - 1) * count)
                            .SetMaxResults(count)
                            .List<Ucet>();
                    }
                    else
                    {
                        totalItems = session.CreateCriteria<Ucet>()
                            .SetProjection((Projections.RowCount()))
                            .Add((Restrictions.Eq("RoleUzivatele.Id", idRole)))
                            .Add(Restrictions.Eq("Aktivovano", true)).UniqueResult<int>();

                        return session.CreateCriteria<Ucet>()
                            .Add((Restrictions.Eq("RoleUzivatele.Id", idRole)))
                            .Add(Restrictions.Eq("Aktivovano", true))
                            .SetFirstResult((page - 1) * count)
                            .SetMaxResults(count)
                            .List<Ucet>();
                    }
                }
            else if (idRole == 4)
            {// vrací všechny pracovníky a adminy
                if (vse == true)
                {
                    totalItems = session.CreateCriteria<Ucet>()
                        .Add(Restrictions.Between("RoleUzivatele.Id", 2, 3))
                        .SetProjection((Projections.RowCount())).UniqueResult<int>();

                    return session.CreateCriteria<Ucet>()
                        .Add(Restrictions.Between("RoleUzivatele.Id", 2, 3))
                        .SetFirstResult((page - 1) * count)
                        .SetMaxResults(count)
                        .List<Ucet>();
                }
                else
                {
                    totalItems = session.CreateCriteria<Ucet>()
                        .SetProjection((Projections.RowCount()))
                        .Add(Restrictions.Between("RoleUzivatele.Id", 2, 3))
                        .Add(Restrictions.Eq("Aktivovano", true)).UniqueResult<int>();

                    return session.CreateCriteria<Ucet>()
                        .Add(Restrictions.Between("RoleUzivatele.Id", 2, 3))
                        .Add(Restrictions.Eq("Aktivovano", true))
                        .SetFirstResult((page - 1) * count)
                        .SetMaxResults(count)
                        .List<Ucet>();
                }
            }
            else 
            {
                //vrací vše
                if (vse == true)
                {
                    totalItems = session.CreateCriteria<Ucet>()
                      .SetProjection((Projections.RowCount())).UniqueResult<int>();

                    return session.CreateCriteria<Ucet>()
                      .SetFirstResult((page - 1) * count)
                        .SetMaxResults(count)
                        .List<Ucet>();
                }
                else
                {
                    totalItems = session.CreateCriteria<Ucet>()
                        .SetProjection((Projections.RowCount()))
                      .Add(Restrictions.Eq("Aktivovano", true)).UniqueResult<int>();

                    return session.CreateCriteria<Ucet>()
                 .Add(Restrictions.Eq("Aktivovano", true))
                        .SetFirstResult((page - 1) * count)
                        .SetMaxResults(count)
                        .List<Ucet>();
                }
            }
        }
    }
}
