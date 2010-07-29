using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;
using NHibernate.Tool.hbm2ddl;

namespace Acme.Data
{
    public class SessionProvider
    {
        private static ISessionFactory _sessionFactory;
        private static Configuration _config;



        public static ISessionFactory SessionFactory
        {
            get
            {
                return _sessionFactory ?? 
                    (_sessionFactory = CreateSessionFactory());
            }
            set { _sessionFactory = value; }
        }

        



        public static Configuration Config
        {
            get
            {
                if (_config == null)
                {
                    _config = new Configuration();
                    _config.AddAssembly(Assembly.GetCallingAssembly());
                }
                return _config;
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Config.BuildSessionFactory();
        }

        public static void RebuildSchema()
        {
            var schema = new SchemaExport(Config);
            schema.Create(true, true);
        }
    }
}
