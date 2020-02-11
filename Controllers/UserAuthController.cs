using CentralRestWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CentralRestWS.Entities;
using System.Data.Entity.Core.Objects;

namespace CentralRestWS.Controllers
{
    public class UserAuthController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetHash(string username)
        {
            return Ok(200);
        }

        [HttpGet]
        public IHttpActionResult Login()
        {
            return Ok(new { result = 200 });
        }

        //    [HttpPost]
        //    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
        //    //public IHttpActionResult Register([FromBody] IELTS_Register_Model_Container RegisterModel)
        //    //{
        //    //    int returnCode = 0;
        //    //    IELTS_Return_Model returnModel = new IELTS_Return_Model();

        //    //    try {

        //    //        IELTS_Register_Model RegisterObject = RegisterModel.RegisterModel;

        //    //        //string bcryptSalt = BCryptHelper.GenerateSalt();
        //    //        //string hashed_pw = BCryptHelper.HashPassword("papasaAKO", bcryptSalt);

        //    //        using (var ctx = new CentralWsAuthEntity())
        //    //        {
        //    //            if (ctx.ielts_get_all_users().ToList().Where(u => u.ielts_username == RegisterObject.username) != null)
        //    //            {
        //    //                returnCode = 1;
        //    //            }
        //    //            else
        //    //            {
        //    //                int id = Convert.ToInt32(ctx.ielts_insert_user(RegisterObject.username, hashed_pw, RegisterObject.is_admin).FirstOrDefault().ToString());

        //    //                ctx.ielts_insert_user_details(id, RegisterObject.first_name, RegisterObject.middle_name, RegisterObject.last_name, RegisterObject.email_address, RegisterObject.contact_number);
        //    //                returnCode = 200;
        //    //            }
        //    //        }

        //    //        switch (returnCode)
        //    //        {
        //    //            case 200:
        //    //                returnModel.returnCode = returnCode.ToString();
        //    //                returnModel.returnDesc = "Ok";
        //    //                return Ok(new { returnModel });
        //    //            case 1:
        //    //                returnModel.returnCode = returnCode.ToString();
        //    //                returnModel.returnDesc = "UserExists";
        //    //                return Ok(new { returnModel });
        //    //            default:
        //    //                returnModel.returnCode = returnCode.ToString();
        //    //                returnModel.returnDesc = "UknownError";
        //    //                return Ok(new { returnModel });

        //    //        }
        //    //    }
        //    //    catch(Exception e)
        //    //    {
        //    //        returnModel.returnCode = returnCode.ToString();
        //    //        returnModel.returnDesc = e.ToString();
        //    //        return Ok(new { returnModel });
        //    //    }
        //    //}
        //}
    }
   }
