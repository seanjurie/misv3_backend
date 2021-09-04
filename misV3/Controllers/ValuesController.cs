using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using misV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace misV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(AuthenticationContext context)
        {

        }
    }
}
