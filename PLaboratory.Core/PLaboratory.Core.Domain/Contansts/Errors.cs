using MS.Libs.Core.Domain.Models.Error;
using PLaboratory.Core.Domain.Contansts.Auth;
using PLaboratory.Core.Domain.Contansts.User;

namespace PLaboratory.Core.Domain.Contansts;

public class AuthErrors
{
    public static AuthBusinessErrors Business = new AuthBusinessErrors(); 
}

public class UserErrors
{
    public static AuthValidatorsErrors Validators = new AuthValidatorsErrors();
    
    public static UserBusinessErrors Business = new UserBusinessErrors();
}
