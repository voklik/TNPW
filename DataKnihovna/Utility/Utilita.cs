using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Type;

namespace DataKnihovna.Utility
{
  public static class Utilita
    {
        public static void Spojovatel<T>(this ICollection<T> collection, IEnumerable<T> enumerable)
        {
            foreach (var cur in enumerable)
            {
                collection.Add(cur);
            }
        }

        public static String formalizer(String X)
        {
            if (X==null)
            {
                return "Prvek nenalezen";
            }

            return X;

        }
        public static String formalizer(int X)
        {
            if (X == null)
            {
                return "Prvek nenalezen";
            }

            return X.ToString();

        }

        public static String formalizer(DateType X)
        {
            if (X == null)
            {
                return "Prvek nenalezen";
            }

            return X.ToString();

        }

        public static String formalizer(Boolean X)
        {
            if (X == null)
            {
                return "Prvek nenalezen";
            }
          else if (X == false)
            {
                return "Ano";
            }

          else  if (X == true)
            {
                return "Ne";
            }

            return X.ToString();

        }
        public static String formalizer(Double X)
        {
            if (X == null)
            {
                return "Prvek nenalezen";
            }

            return X.ToString();

        }



       



    }
    }
