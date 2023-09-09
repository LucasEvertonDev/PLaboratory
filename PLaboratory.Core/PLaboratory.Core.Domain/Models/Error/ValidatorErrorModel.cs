using PLaboratory.Core.Domain.Models.Base;

namespace PLaboratory.Core.Domain.Models.Error;

public class ValidatorErrorModel : BaseModel, IModel
{
    public ValidatorErrorModel(string propName, string message, string code)
    {
        ErrorCode = code;
        ErrorMessage = message;
        Property = propName;
    }
    public string ErrorMessage { get; set; }
    public string Property { get; set; }
    public string ErrorCode { get; set; }
}
