using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralRestWS.Models
{
    public class StudentPortalAdminModels
    {
    }

    public class AdminLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
    }

    public class RoleModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class RegisterStudentProfessor
    {
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
    }
}