using NDB.Tests.Factory;

namespace NDB.Tests
{
    public class ExampleEntityTests()
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void ExpectDoesNotThrowException()
        //{
        //    for (var i = 0; i < 100; i++)
        //    {
        //        var exampleEntity = CreateExampleEntityFactory.Generate();
        //        Assert.DoesNotThrow(() => exampleEntity.Validate());
        //    }
        //}

        [Test]
        public void ExpectThrowsInvalidTitleException()
        {
            Example exampleEntity;

            exampleEntity = CreateExampleEntityFactory.Generate((m) => {
                m.Title = null;
                return m;
            });
            Assert.Throws<Exception>(() => exampleEntity.Validate());

            exampleEntity = CreateExampleEntityFactory.Generate((m) => {
                m.Title = "";
                return m;
            });
            Assert.Throws<Exception>(() => exampleEntity.Validate());
        }

        [Test]
        public void ExpectThrowsInvalidContentException()
        {
            Example exampleEntity;

            exampleEntity = CreateExampleEntityFactory.Generate((m) => {
                m.Content = null;
                return m;
            });
            Assert.Throws<Exception>(() => exampleEntity.Validate());

            exampleEntity = CreateExampleEntityFactory.Generate((m) => {
                m.Content = new ExampleContent("");
                return m;
            });
            Assert.Throws<ArgumentException>(() => exampleEntity.Validate());
        }

        [Test]
        public void ExpectThrowsInvalidDatesException()
        {
            Example exampleEntity;

            exampleEntity = CreateExampleEntityFactory.Generate((m) => {
                m.Id = 0;
                m.CreatedAt = DateTime.MinValue;
                return m;
            });
            Assert.Throws<Exception>(() => exampleEntity.Validate());

            exampleEntity = CreateExampleEntityFactory.Generate((m) => {
                m.UpdatedAt = DateTime.UtcNow;
                return m;
            });
            Assert.Throws<Exception>(() => exampleEntity.Validate());
        }
    }
}