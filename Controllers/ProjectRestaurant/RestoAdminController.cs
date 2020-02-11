using CentralRestWS.Entities;
using CentralRestWS.Models.Resto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CentralRestWS.Controllers.ProjectRestaurant
{
    public class RestoAdminController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Login(RestoAdminLoginModel LoginModel)
        {
            LoginReturn xReturn = new LoginReturn();
            if (LoginModel != null)
            {
                if (LoginModel.Username == "Admin" && LoginModel.Password == "Admin")
                {
                    xReturn.username = LoginModel.Username;
                    xReturn.password = LoginModel.Password;
                    xReturn.ipAddress = LoginModel.IpAddress;
                    xReturn.returnValue = "Login Ok";
                }
                else
                {
                    xReturn.returnValue = "Login Fail";
                }
            }
            else
            {
                xReturn.returnValue = "Login Fail";
            }

            return Ok(new { xReturn });
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Register(RestoAdminRegisterModel RegisterModel)
        {
            RegisterReturn xReturn = new RegisterReturn();
            if (RegisterModel != null)
            {
                using (var ctx = new RestoAdminEntity())
                {
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(RegisterModel.Password);

                    int xVal = ctx.sp_ra_registerUser(RegisterModel.Username, passwordHash, RegisterModel.RoleId, RegisterModel.FirstName, RegisterModel.MiddleName, RegisterModel.LastName, "System");

                    
                    if(xVal == 0)
                    {
                        xReturn.ResponseCode = "200";
                        xReturn.ResponseDescription = "Success";
                    }
                    else
                    {
                        xReturn.ResponseCode = "500";
                        xReturn.ResponseDescription = "Unknown Error";
                    }

                }
            }
            else
            {
                xReturn.ResponseCode = "500";
                xReturn.ResponseDescription = "Unknown Error";
            }
            return Ok(new { xReturn });
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetRoles()
        {
            RolesReturn xReturn = new RolesReturn();
            List<RolesModel> RoleObject = new List<RolesModel>();

            using (var ctx = new RestoAdminEntity())
            {
                var roles = ctx.sp_ra_getRoles();

                foreach (var role in roles)
                {
                    RolesModel rm = new RolesModel();
                    rm.RoleId = role.id.ToString();
                    rm.RoleName = role.roleValue;
                    RoleObject.Add(rm);
                }

            }

            xReturn.Role = RoleObject;

            return Ok(new { xReturn });
        }
    }
}
