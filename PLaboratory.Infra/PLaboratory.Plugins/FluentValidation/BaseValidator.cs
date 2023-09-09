using FluentValidation;
using PLaboratory.Core.Domain.Models.Base;
using PLaboratory.Core.Domain.Models.Error;
using PLaboratory.Core.Domain.Plugins.Validators;
using PLaboratory.Core.Domain.Utils.Exceptions;

namespace PLaboratory.Plugins.FluentValidation;

public class BaseValidator<TModel> : AbstractValidator<TModel>, IValidatorModel<TModel> where TModel : IModel
{
    public async Task ValidateModelAsync(TModel model)
    {
        var validationResult = await ValidateAsync(model);

        if (!validationResult.IsValid)
        {
            throw new ValidatorException(validationResult.Errors.Select(c => new ValidatorErrorModel(c.PropertyName, c.ErrorMessage, c.ErrorCode)).ToArray());
        }
    }
}
