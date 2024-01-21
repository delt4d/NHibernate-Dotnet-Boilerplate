using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace NDB.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton(GetDatabaseSessionFactory());
            services.AddSingleton(CreateMapper());
            services.AddTransient<IExampleRepository, NHibernateExampleRepository>();
            services.AddScoped(provider => provider.GetService<ISessionFactory?>()!.OpenSession());
            return services;
        }

        public static IMapper CreateMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Example, NHibernateExample>().ReverseMap();
            });

            return configuration.CreateMapper();
        }

        public static ISessionFactory GetDatabaseSessionFactory()
        {
            FluentConfiguration configuration = Fluently.Configure();

            if (UnitTesting.IsRunningInUnitTest)
            {
                configuration.Database(MsSqlConfiguration.MsSql2012
                       .ConnectionString("Server=localhost,1433;Database=test;User Id=sqluser;Password=1234;")
                       .ShowSql()
                       .FormatSql());
            }
            else
            {
                configuration.Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString("Server=localhost,1433;Database=example;User Id=sqluser;Password=1234;")
                        .ShowSql()
                        .FormatSql());
            }

            return configuration
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssembly(typeof(DependencyInjection).Assembly);
                })
                .ExposeConfiguration(cfg =>
                {
                    if (UnitTesting.IsRunningInUnitTest)
                        new SchemaExport(cfg).Create(true, true);
                    new SchemaUpdate(cfg).Execute(false, true);
                })
                .BuildSessionFactory();
        }
    }
}
