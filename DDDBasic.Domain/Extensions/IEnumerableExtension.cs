using DDDBasic.Domain.Exceptions;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace DDDBasic.Domain.Extensions
{
    public static class IEnumerableExtension
    {
        public static void ThrowException(this IEnumerable<string> errors)
        {
            if (errors.Any())
            {
                List<ValidationFailure> failures = new List<ValidationFailure>();
                foreach (var error in errors)
                {
                    failures.Add(new ValidationFailure("Excecao", error));
                }

                throw new ValidationException(failures);
            }
        }
    }
}
