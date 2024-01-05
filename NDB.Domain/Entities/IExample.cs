using System;

namespace NDB.Domain.Entities
{
    public interface IExample
    {
        int Id { get; set; }
        string UUID { get; set; }
        string Title { get; set; }
        string Content { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
