namespace NDB.Tests.Factory
{
    public static class CreateExampleEntityFactory
    {
        public static Example ExampleEntity { get; private set; }
        private static int LastId = 0;

        static CreateExampleEntityFactory()
        {
            ExampleEntity = Generate();
        }

        public static Example Generate()
        {
            return Generate(example => example);
        }

        public static Example Generate(Func<Example, Example> c)
        {
            ExampleEntity = new Example
            {
                Id = ++LastId,
                Title = Faker.Lorem.Sentence(2),
                Content = new ExampleContent(Faker.Lorem.Paragraphs(5).ToString()),
                UUID = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return c(ExampleEntity);
        }
    }
}
