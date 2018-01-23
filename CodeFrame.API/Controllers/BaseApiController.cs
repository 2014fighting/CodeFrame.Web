using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFrame.API.Controllers
{
    [Produces("application/json")]
    [Route("api/BaseApi")]
    public class BaseApiController : Controller
    {
    }
}