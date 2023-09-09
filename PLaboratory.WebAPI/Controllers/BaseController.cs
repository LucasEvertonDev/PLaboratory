using Microsoft.AspNetCore.Mvc;

namespace PLaboratory.WebAPI.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
[Produces("application/json")]
public class BaseController : ControllerBase
{

}
