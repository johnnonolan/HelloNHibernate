using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace HelloNhibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting..");
            Configuration config = new Configuration();
            config.AddAssembly(typeof(Product).Assembly);
            ISessionFactory sessionFactory = config.BuildSessionFactory();
            var schema = new SchemaExport(config);
            schema.Create(true, true);

            Product pNew = new Product() {ProductName = "Canned Salmon"};
            using (var session = sessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    session.Save(pNew);
                    trans.Commit();
                }

                //Retrieve  product 
                Product pGet = session.Get<Product>(pNew.ProductId);
                
                pGet.ProductName = "Canned Tuna";
                using (var trans= session.BeginTransaction())
                {
                    session.Update(pGet);
                    trans.Commit();
                }


                using (var trans = session.BeginTransaction())
                {
                    session.Delete(pNew);
                    trans.Commit();
                }
            }
            Console.ReadKey();
        }
    }
}
