using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Model;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace DataKnihovna.DAO
{
    public class GameDao : DaoBase<Hra>
    {
        
        public GameDao() : base()
        {

        }

        public IList<Hra> SearchName(string query)
        {
            return session.CreateCriteria<Hra>()
                .Add((Restrictions.Like("Nazev", string.Format("%{0}%", query))))
                .List<Hra>();

        }
        public IList<Hra> SearchName2(string query)
        {
            return session.CreateCriteria<Hra>()
                .Add((Restrictions.Like("Nazev", string.Format("%{0}%", query))))
                .Add(Restrictions.Eq("Aktivovano", true))
                .List<Hra>();

        }
        public IList<Hra> GetByPlatforma(int id, out int totalItems, Boolean vse)
        {
          
            if (vse == true)
            {
                totalItems = session.CreateCriteria<Hra>()
                    .Add((Restrictions.Eq("Platforma.Id", id)))
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();

               

                return session.CreateCriteria<Hra>()
                    .Add((Restrictions.Eq("Platforma.Id", id)))
                    .List<Hra>();
            }
            else
            {
                totalItems = session.CreateCriteria<Hra>()
                    .Add((Restrictions.Eq("Platforma.Id", id)))
                    .Add(Restrictions.Eq("Aktivovano", true))
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();



                return session.CreateCriteria<Hra>()
                    .Add(Restrictions.Eq("Aktivovano", true))
                    .Add((Restrictions.Eq("Platforma.Id", id)))
                    .List<Hra>();
            }
        }
        public IList<Hra> GetByVydavatel(int id, out int totalItems, Boolean vse)
        {

            if (vse == true)
            {
                totalItems = session.CreateCriteria<Hra>()
                    .Add((Restrictions.Eq("Vydavatel.Id", id)))
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();



                return session.CreateCriteria<Hra>()
                    .Add((Restrictions.Eq("Vydavatel.Id", id)))
                    .List<Hra>();
            }
            else
            {
                totalItems = session.CreateCriteria<Hra>()
                    .Add((Restrictions.Eq("Vydavatel.Id", id)))
                    .Add(Restrictions.Eq("Aktivovano", true))
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();



                return session.CreateCriteria<Hra>()
                    .Add(Restrictions.Eq("Aktivovano", true))
                    .Add((Restrictions.Eq("Vydavatel.Id", id)))
                    .List<Hra>();
            }
        }


        public IList<Hra> getPaged( int count,  int page, out int totalItems, Boolean vse)
        {

            if (vse == true)
                    {
                        totalItems = session.CreateCriteria<Hra>()
                  .SetProjection((Projections.RowCount())).UniqueResult<int>();

                        return session.CreateCriteria<Hra>()
                          
                            .AddOrder(Order.Asc("Nazev"))
                            .SetFirstResult((page - 1) * count)
                            .SetMaxResults(count)
                            .List<Hra>();
                    }
                    else
                    {
                        totalItems = session.CreateCriteria<Hra>()
                            .SetProjection((Projections.RowCount()))
                         
                            .Add(Restrictions.Eq("Aktivovano", true))
                           
                            .UniqueResult<int>();

                        return session.CreateCriteria<Hra>()
                         
                            .Add(Restrictions.Eq("Aktivovano", true))
                       
                            .AddOrder(Order.Asc("Nazev"))
                            .SetFirstResult((page - 1) * count)
                            .SetMaxResults(count)
                            .List<Hra>();
                    }


        }
        public IList<Hra> SearchName3(string query)
        {
            return session.CreateCriteria<Hra>("hra")
                .CreateAlias("Vydavatel", "v", JoinType.InnerJoin)
                .CreateCriteria("Platforma", "p", JoinType.InnerJoin)
                .Add(Restrictions.And((Restrictions.Eq("hra.Aktivovano", true)), Restrictions.And((Restrictions.Eq("p.Aktivovano", true)),

                    (Restrictions.And(Restrictions.Eq("v.Aktivovano", true), (Restrictions.Like("hra.Nazev", string.Format("%{0}%", query))))))
                ))
      
                .List<Hra>();

        }
        public IList<Hra> GetByPlatforma2(int id, out int totalItems, Boolean vse)
        {

            if (vse == true)
            {
                totalItems = session.CreateCriteria<Hra>()
                    .Add((Restrictions.Eq("Platforma.Id", id)))
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();



                return session.CreateCriteria<Hra>()
                    .Add((Restrictions.Eq("Platforma.Id", id)))
                    .List<Hra>();
            }
            else
            {
                totalItems = session.CreateCriteria<Hra>("hra")
                    .CreateAlias("Vydavatel", "v", JoinType.InnerJoin)
                    .CreateCriteria("Platforma", "p", JoinType.InnerJoin)
                    .Add(Restrictions.And((Restrictions.Eq("hra.Aktivovano", true)), Restrictions.And((Restrictions.Eq("p.Aktivovano", true)),

                        (Restrictions.Eq("v.Aktivovano", true)))
                    ))
                    .Add((Restrictions.Eq("p.Id", id)))
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();



                return session.CreateCriteria<Hra>("hra")
                    .CreateAlias("Vydavatel", "v", JoinType.InnerJoin)
                    .CreateCriteria("Platforma", "p", JoinType.InnerJoin)
                    .Add(Restrictions.And((Restrictions.Eq("hra.Aktivovano", true)), Restrictions.And((Restrictions.Eq("p.Aktivovano", true)),

                        (Restrictions.Eq("v.Aktivovano", true)))
                    ))
                  
                    .Add((Restrictions.Eq("p.Id", id)))
                    .List<Hra>();
            }
        }
        public IList<Hra> GetByVydavatel2(int id, out int totalItems, Boolean vse)
        {

            if (vse == true)
            {
                totalItems = session.CreateCriteria<Hra>()
                    .Add((Restrictions.Eq("Vydavatel.Id", id)))
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();



                return session.CreateCriteria<Hra>()
                    .Add((Restrictions.Eq("Vydavatel.Id", id)))
                    .List<Hra>();
            }
            else
            {
                totalItems = session.CreateCriteria<Hra>("hra")
                    .CreateAlias("Vydavatel", "v", JoinType.InnerJoin)
                    .CreateCriteria("Platforma", "p", JoinType.InnerJoin)
                    .Add(Restrictions.And((Restrictions.Eq("hra.Aktivovano", true)), Restrictions.And((Restrictions.Eq("p.Aktivovano", true)),

                        (Restrictions.Eq("v.Aktivovano", true)))
                    ))
                    .Add((Restrictions.Eq("v.Id", id)))
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();



                return session.CreateCriteria<Hra>("hra")
                    .CreateAlias("Vydavatel", "v", JoinType.InnerJoin)
                    .CreateCriteria("Platforma", "p", JoinType.InnerJoin)
                    .Add(Restrictions.And((Restrictions.Eq("hra.Aktivovano", true)), Restrictions.And((Restrictions.Eq("p.Aktivovano", true)),

                        (Restrictions.Eq("v.Aktivovano", true)))
                    ))
                    .Add((Restrictions.Eq("v.Id", id)))
                    .List<Hra>();
            }
        }
        public IList<Hra> getPaged2(int count, int page, out int totalItems, Boolean vse)
        {

            if (vse == true)
            {
                totalItems = session.CreateCriteria<Hra>()
                    .SetProjection((Projections.RowCount())).UniqueResult<int>();

                return session.CreateCriteria<Hra>()

                    .AddOrder(Order.Asc("Nazev"))
                    .SetFirstResult((page - 1) * count)
                    .SetMaxResults(count)
                    .List<Hra>();
            }
            else
            {     
                totalItems = session.CreateCriteria<Hra>("hra")
                    .CreateAlias("Vydavatel", "v", JoinType.InnerJoin)
                    .CreateCriteria("Platforma", "p", JoinType.InnerJoin)
                    .Add(Restrictions.And((Restrictions.Eq("hra.Aktivovano", true)), Restrictions.And((Restrictions.Eq("p.Aktivovano", true)),

                        (Restrictions.Eq("v.Aktivovano", true)))
                       ))
                    
                    .SetProjection((Projections.RowCount()))

                   
             
              
               
                  
                    .UniqueResult<int>();

                return session.CreateCriteria<Hra>("hra")
                    .CreateAlias("Vydavatel", "v", JoinType.InnerJoin)
                    .CreateCriteria("Platforma", "p", JoinType.InnerJoin)
                    .Add(Restrictions.And((Restrictions.Eq("hra.Aktivovano", true)), Restrictions.And((Restrictions.Eq("p.Aktivovano", true)),

                        (Restrictions.Eq("v.Aktivovano", true)))
                    ))

                    .AddOrder(Order.Asc("Nazev"))
                    .SetFirstResult((page - 1) * count)
                    .SetMaxResults(count)
                    .List<Hra>();
            }


        }
    }
}
