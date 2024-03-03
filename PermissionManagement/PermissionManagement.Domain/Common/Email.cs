using PermissionManagement.Domain.Abstractions;
using System.Text.RegularExpressions;

namespace PermissionManagement.Domain.Common
{
    public record Email
    {
        public static readonly Error InvalidEmail = new(
            "Email.InvalidEmail",
            "El formato del correo el invalido"
        );

        public string Value { get; init; }

        private Email(string value) => Value = value;

        public static Result<Email> Create(string value)
        {
            if(!IsValidEmail(value))
            {
                return Result.Failure<Email>(InvalidEmail);
            }

            return new Email(value);
        }

        private static bool IsValidEmail(string value)
        {
            return Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
    }
}
