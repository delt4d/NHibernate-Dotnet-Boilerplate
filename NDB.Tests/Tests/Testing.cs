namespace NDB.Tests.Tests
{
    public static class Testing
    {
        static private ServiceCollection Services { get; } = new();

        static Testing()
        {
            UnitTesting.IsRunningInUnitTest = true;
            Services.AddInfrastructure();
        }
    }
}
