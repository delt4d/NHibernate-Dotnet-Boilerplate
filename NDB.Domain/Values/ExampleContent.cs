using System;

namespace NDB.Domain.Values
{
    public record ExampleContent
    {
        public string Value { get; set; }
        private const int MaxLength = 255;
        
        public ExampleContent()
        {
        }

        public ExampleContent(string value)
        {
            Value = value;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new ArgumentException("Content cannot be empty", nameof(Value));
            }
            if (Value.Length > MaxLength)
            {
                throw new ArgumentException($"Content cannot exceed {MaxLength} characters", nameof(Value));
            }
        }
    };
}
    