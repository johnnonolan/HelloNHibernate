using System;
using ACME.Repository;
using Acme.Model;
using NHibernate;
namespace Acme.Data
{
    public class ProductRepository : IRepository<Product,Int32?>
    {
        private static ISession GetSession()
        {
            return SessionProvider.SessionFactory.OpenSession();
        }

        public Product GetById(int? id)
        {
            using (var session = GetSession())
            {
                return session.Get<Product>(id);
            }
        }

        public void Save(Product saveObj)
        {
            using (var session = GetSession())
            {               
                using(var trans = session.BeginTransaction())   
                {
                    session.SaveOrUpdate(saveObj);
                    trans.Commit();
                }
            }
        }

        public void Delete(Product delObj)
        {
            using (var session = GetSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    session.Delete(delObj);
                    trans.Commit();
                }
            }

        }
    }
}
