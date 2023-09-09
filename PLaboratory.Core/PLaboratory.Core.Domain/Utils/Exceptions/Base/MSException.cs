using System.Runtime.Serialization;

namespace PLaboratory.Core.Domain.Utils.Exceptions.Base;

[Serializable]
public class MSException : SystemException
{
    public MSException(string message) : base(message)
    {
    }

    protected MSException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
