using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFrame.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/BaseApi")]
    public class BaseApiController : Controller
    {
    }
}