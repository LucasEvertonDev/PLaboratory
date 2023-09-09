using PLaboratory.Core.Domain.Models.Error;
using PLaboratory.Core.Domain.Utils.Exceptions.Base;
using System.Runtime.Serialization;

namespace PLaboratory.Core.Domain.Utils.Exceptions;

[Serializable]
public class BusinessException : MSException
{
    public ErrorModel Error { get; set; }

    public BusinessException(ErrorModel error) : base(error.Message)
    {
        Error = error;
    }

    protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
