using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralRestWS.Models.Resto
{
    public class RestoAdminReturnModels
    {
    }

    public class LoginReturn
    {
        public string username { get; set; }
        public string password { get; set; }
        public string ipAddress { get; set; }
        public string returnValue { get; set; }
    }

    public class RegisterReturn
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
    }

    public class RolesReturn
    {
        public List<RolesModel> Role { get; set; }
    }
}