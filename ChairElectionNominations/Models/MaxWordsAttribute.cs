using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ChairElections.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MaxWordsAttribute : ValidationAttribute
    {
        public int MaxWords { get; }

        public MaxWordsAttribute(int maxWords)
        {
            MaxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var text = value as string;
            if (string.IsNullOrWhiteSpace(text)) return ValidationResult.Success;

            var words = text.Trim().Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length > MaxWords)
            {
                var msg = ErrorMessage ?? $"The field {validationContext.DisplayName} must be at most {MaxWords} words ({words.Length} provided).";
                return new ValidationResult(msg);
            }

            return ValidationResult.Success;
        }
    }
}
