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


        public void Validate()
        {
            if (string.IsNullOrEmpty(UUID))
                throw new Exception("UUID cannot be empty");

            if (string.IsNullOrEmpty(Title))
                throw new Exception("Title cannot be empty");

            if (Content == null)
                throw new Exception("Content cannot be empty");

            Content.Validate();

            if (Id == 0)
            {
                if (CreatedAt == null || CreatedAt == DateTime.MinValue)
                {
                    throw new Exception("CreatedAt must be provided");
                }
            }
            else
            {
                if (UpdatedAt != null)
                {
                    throw new Exception("UpdatedAt must be null if ID is not provided");
                }
            }
        }

        public static Exception Create(string uuid, string title, string content, DateTime createdAt, DateTime? updatedAt, out Example @example)
        {
            try
            {
                @example = new Example
                {
                    UUID = uuid,
                    Title = title,
                    Content = new ExampleContent(content),
                    CreatedAt = createdAt,
                    UpdatedAt = updatedAt
                };

                @example.Validate();

                return null;
            }
            catch(Exception ex)
            {
                @example = null;
                return ex;
            }
        }
    }
}
