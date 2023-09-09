﻿using FluentValidation;
using FluentValidation.Validators;
using PLaboratory.Core.Domain.Models.Error;

namespace PLaboratory.Plugins.FluentValidation.Extensions;

public static class FluentExtensions
{
    public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, ErrorModel errorModel)
    {
        return rule.WithMessage(errorModel.Message).WithErrorCode(errorModel.Context);
    }

	public static IRuleBuilderOptions<T, TProperty> NotNullOrEmpty<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new NotEmptyValidator<T, TProperty>());
    }
}
