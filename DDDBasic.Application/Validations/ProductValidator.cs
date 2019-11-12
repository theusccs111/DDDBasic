using DDDBasic.Application.Resource.Response;
using DDDBasic.Domain.Entities;
using DDDBasic.Domain.Enums;
using DDDBasic.Domain.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDBasic.Application.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage(Message.FieldRequired.GetDescription(Field.Name))
                .Length(3,100)/*.WithMessage(Message..GetDescription())*/
                ;

            RuleFor(product => product.Value)
                .NotEmpty().WithMessage(Message.FieldRequired.GetDescription(Field.Value))
                .Must(ValueMinimumZero)/*.WithMessage(Message.FieldRequired.GetDescription())*/;

        }

        private static bool ValueMinimumZero(decimal value)
        {
            return value >= 0;
        }
    }
}
