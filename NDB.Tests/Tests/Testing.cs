namespace NDB.Tests.Tests
{
    public class Testing
    {
        static Testing()
        {
            UnitTesting.IsRunningInUnitTest = true;
        }

        private static IServiceProvider Provider()
        {
            ServiceCollection services = new();
            services.AddInfrastructure();
            return services.BuildServiceProvider();
        }

        public static T GetRequiredService<T>()
        {
            var provider = Provider();
            return provider.GetRequiredService<T>();
        }
    }
}
