
namespace NDB.Tests
{
    public class Tests
    {
        private ServiceCollection Services { get; } = new();

        [SetUp]
        public void Setup()
        {
            UnitTesting.IsRunningInUnitTest = true;
            Services.AddInfrastructure();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}