using CentralRestWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace CentralRestWS.Controllers
{
    public class UQueueController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Login(LoginObject LoginModel)
        {
            return Ok(new { LoginModel });
        }
       
    }
}
