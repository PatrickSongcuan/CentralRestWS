using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralRestWS.Models.Resto
{
    public class RestoAdminModels
    {
    }

    public class RestoAdminLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
    }

    public class RestoAdminRegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string IpAddress { get; set; }
        public int RoleId { get; set; }
    }

    public class RolesModel
    {
        public string RoleName { get; set; }
        public string RoleId { get; set; }
    }
}