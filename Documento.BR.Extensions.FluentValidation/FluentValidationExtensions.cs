using Documento.BR.Rules.Validators;
using FluentValidation;
using System;
using System.Globalization;

namespace Documento.BR.Extensions.FluentValidation
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, string?> ValidateCPF<T>(this IRuleBuilderInitial<T, string?> ruleBuilder)
        {
            return ruleBuilder.Must(input => CPFValidator.Validate(input))
                .WithMessage(IsBrazillianCulture() ? "{PropertyName} {PropertyValue} não é válido." : "{PropertyName} {PropertyValue} is not valid.")
                .WithErrorCode("InvalidCPF");
        }

        public static IRuleBuilderOptions<T, string?> ValidateCNPJ<T>(this IRuleBuilderInitial<T, string?> ruleBuilder)
        {
            return ruleBuilder.Must(input => CNPJValidator.Validate(input))
                .WithMessage(IsBrazillianCulture() ? "{PropertyName} {PropertyValue} não é válido." : "{PropertyName} {PropertyValue} is not valid.")
                .WithErrorCode("InvalidCNPJ"); ;
        }

        private static bool IsBrazillianCulture() => CultureInfo.CurrentUICulture.Name == "pt-BR";
    }
}
