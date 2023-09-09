using PLaboratory.Core.Domain.Models.Base;

namespace PLaboratory.Core.Domain.Models.Error;

public class BusinessErrorModel : BaseModel
{
    public BusinessErrorModel(string message, string code)
    {
        ErrorCode = code;
        ErrorMessage = message;
    }
    public string ErrorMessage { get; set; }
    public string ErrorCode { get; set; }
}
