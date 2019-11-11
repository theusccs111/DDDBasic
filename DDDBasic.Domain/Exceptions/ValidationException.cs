using DDDBasic.Domain.Extensions;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDBasic.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base(Enums.Message.ErrorSystem.GetDescription())
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(string key, string message) : this()
        {
            Failures.Add(key, new string[1] { message });
        }
        public ValidationException(string key, string[] message) : this()
        {
            Failures.Add(key, message);
        }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}
