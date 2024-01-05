using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using Microsoft.Extensions.DependencyInjection;

namespace NDB.Infra
{
    public static class DependencyInjection
    {
        public static readonly string ConnectionString = "Server=localhost,1433;Database=todo;User Id=sqluser;Password=1234;";

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton(GetSessionFactory());
            services.AddScoped(provider => provider.GetService<ISessionFactory?>()!.OpenSession());
            return services;
        }

        public static ISessionFactory GetSessionFactory()
        {
            return Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(ConnectionString)
                    .ShowSql()
                    .FormatSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(DependencyInjection).Assembly))
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
        }
    }
}
