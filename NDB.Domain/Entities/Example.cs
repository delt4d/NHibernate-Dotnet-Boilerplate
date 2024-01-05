using NDB.Domain.Values;
using System;

namespace NDB.Domain.Entities
{
    public interface IExample
    {
        int Id { get; set; }
        string UUID { get; set; }
        string Title { get; set; }
        ExampleContent Content { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }

    public class Example : IExample
    {
        public int Id { get; set; }
        public string UUID { get; set; }
        public string Title { get; set; }
        public ExampleContent Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
