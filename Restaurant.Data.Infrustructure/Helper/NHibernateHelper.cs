using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Restaurant.Domains.Mappers;
using System;
using System.Data.SqlClient;

/// <summary>
/// NHibernate Helper
/// </summary>
/// <remarks>
/// Because the SessionFactory creation is lazy-loaded, you technically never need to bootstrap NHibernate
/// and instead can just call OpenSession() as it will do it for you the first time you make the call.
/// </remarks>

namespace Restaurant.Data.Infrustructure.Helper
{
    public static class NHibernateHelper
    {
        #region OLD
        //#region Private Fields

        //private static ISessionFactory _sessionFactory;

        //#endregion Private Fields

        //#region Public Properties

        ///// <summary>
        ///// Creates <c>ISession</c>s.
        ///// </summary>
        //public static ISessionFactory SessionFactory
        //{
        //    get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        //}

        ///// <summary>
        ///// Allows the application to specify properties and mapping documents to be used when creating a <see cref="T:NHibernate.ISessionFactory"/>.
        ///// </summary>
        //public static NHibernate.Cfg.Configuration Configuration { get; set; }

        //#endregion Public Properties

        //#region Public Methods

        ///// <summary>
        ///// Open a new NHibenate Session
        ///// </summary>
        ///// <returns>A new ISession</returns>
        //public static ISession OpenSession()
        //{
        //    var session = SessionFactory.OpenSession();

        //    return session;
        //}

        ///// <summary>
        ///// Open a new stateless NHibernate Session
        ///// </summary>
        ///// <returns>Stateless NHibernate Session</returns>
        //public static IStatelessSession OpenStatelessSession()
        //{
        //    var session = SessionFactory.OpenStatelessSession();

        //    return session;
        //}

        //#endregion Public Methods

        //#region Private Methods

        //private static ISessionFactory CreateSessionFactory()
        //{
        //    if (Configuration == null)
        //    {
        //        Configuration = new Configuration();

        //        Configuration.BeforeBindMapping += OnBeforeBindMapping;

        //        // FluentNHibernate Configuration API for configuring NHibernate
        //        Configuration = Fluently.Configure(Configuration)
        //            .Database(
        //                    MsSqlConfiguration.MsSql2012
        //                        .ConnectionString(connectionString)
        //                        .UseReflectionOptimizer()
        //                        .AdoNetBatchSize(100))
        //            .ExposeConfiguration(
        //                    x =>
        //                    {
        //                        // Increase the timeout for long running queries
        //                        x.SetProperty("command_timeout", "600");

        //                        // Allows you to have non-virtual and non-public methods in your entities
        //                        x.SetProperty("use_proxy_validator", "false");
        //                    })
        //            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SomeFluentMappingClass>())
        //            .BuildConfiguration();
        //    }

        //    var sessionFactory = Configuration.BuildSessionFactory();

        //    return sessionFactory;
        //}

        //private static void OnBeforeBindMapping(object sender, BindMappingEventArgs bindMappingEventArgs)
        //{
        //    // Force using the fully qualified type name instead of just the class name.
        //    // This will get rid of any duplicate mapping/class name issues.
        //    bindMappingEventArgs.Mapping.autoimport = false;
        //}

        //#endregion Private Methods
        #endregion
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory("Data Source=ASUS-PC\\SAMI;Integrated Security=True;Initial Catalog=Restaurant;"); return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory(string ConnectionString)
        {
                _sessionFactory = Fluently.Configure()
             .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                ConnectionString).ShowSql())

             .Mappings(m => m.FluentMappings
             .AddFromAssemblyOf<DishMap>())
             //.ExposeConfiguration(cfg => new SchemaExport(cfg)
             //.Create(true, false))
             .BuildSessionFactory();
            
            
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}