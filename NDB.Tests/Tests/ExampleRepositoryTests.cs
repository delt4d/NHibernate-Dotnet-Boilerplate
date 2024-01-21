using NDB.Domain.Repositories;
using NDB.Tests.Factory;
using NDB.Tests.Tests;

namespace NDB.Tests
{
    public class ExampleRepositoryTests
    {
        private readonly Random _rng = new();
        private readonly IExampleRepository _exampleRepository = Testing.GetRequiredService<IExampleRepository>();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExpectFindByAllToMatchCreateCount()
        {
            for (int i = 0; i < 100; i++)
            {
                Assert.DoesNotThrow(() => _exampleRepository.Create(
                    CreateExampleEntityFactory.Generate((m) =>
                    {
                        m.UpdatedAt = null;
                        return m;
                    })
                ));
            }

            Assert.True(_exampleRepository.FindAll().Count.Equals(100));
        }
    }
}
