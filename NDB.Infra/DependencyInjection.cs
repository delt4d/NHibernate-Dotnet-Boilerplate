using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using Microsoft.Extensions.DependencyInjection;

namespace NDB.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton(!UnitTesting.IsRunningInUnitTest ? GetSqlServerSessionFactory() : GetInMemorySessionFactory());
            services.AddScoped(provider => provider.GetService<ISessionFactory?>()!.OpenSession());
            return services;
        }

        public static ISessionFactory GetInMemorySessionFactory()
        {
            return Fluently
                .Configure()
                .Database(SQLiteConfiguration.Standard
                    .ConnectionString("Data Source=:memory:;Version=3;New=True;")
                    .ShowSql()
                    .FormatSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(DependencyInjection).Assembly))
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
        }

        public static ISessionFactory GetSqlServerSessionFactory()
        {
            return Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString("Server=localhost,1433;Database=example;User Id=sqluser;Password=1234;")
                    .ShowSql()
                    .FormatSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(DependencyInjection).Assembly))
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
        }
    }
}
