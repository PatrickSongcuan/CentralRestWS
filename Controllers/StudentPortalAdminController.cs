using CentralRestWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CentralRestWS.Controllers
{
    public class StudentPortalAdminController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login(AdminLoginModel LoginModel)
        {
            return Ok(new { LoginModel });
        }


    }
}
