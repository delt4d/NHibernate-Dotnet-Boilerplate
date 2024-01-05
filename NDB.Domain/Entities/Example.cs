using System;

namespace NDB.Domain.Entities
{
    public class Example : IExample
    {
        public int Id { get; set; }
        public string UUID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
