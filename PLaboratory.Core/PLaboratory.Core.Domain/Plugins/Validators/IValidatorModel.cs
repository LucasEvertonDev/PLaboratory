using PLaboratory.Core.Domain.Models.Base;

namespace PLaboratory.Core.Domain.Plugins.Validators;

public interface IValidatorModel<TModel> where TModel : IModel
{
    Task ValidateModelAsync(TModel model);
}
