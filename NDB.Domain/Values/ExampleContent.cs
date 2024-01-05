using System;

namespace NDB.Domain.Values
{
    public record ExampleContent(string Value)
    {
        private const int MaxLength = 255;
        
        public void Validate()
        {
            if (Value.Length == 0)
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
    