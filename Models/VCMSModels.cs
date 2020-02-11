using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralRestWS.Models
{
    public class VCMS_ReturnModel
    {
        public string code { get; set; }
        public string desc { get; set; }
        public string user_role { get; set; }
        public string user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
    public class VCMS_AuthModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    
    public class VCMS_RoleModel
    {
        public string roleId { get; set; }
        public string roleName { get; set; }
    }

    public class VCMS_UserRegisterModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string emailAddress { get; set; }
        public string contactNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string roleId { get; set; }
    }

    public class VCMS_UserUpdateModel
    {
        public string user_id { get; set; }
        public string email_address { get; set; }
        public string contact_number { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string is_enabled { get; set; }
        public string user_logged { get; set; }
    }

    public class VCMS_GetUserModel
    {
        public string user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email_address { get; set; }
        public string contact_number { get; set; }
        public string role_name { get; set; }
    }

    public class VCMS_GetUserModelByID
    {
        public string user_id { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email_address { get; set; }
        public string contact_number { get; set; }
        public string role_name { get; set; }
        public string is_active { get; set; }
    }

    public class VCMS_CreateResidentModel
    {
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string email_address { get; set; }
        public string contact_number { get; set; }
        public string monthly_collection { get; set; }
        public string start_date_of_collection { get; set; }
        public int has_payment { get; set; }
        public string payment_amount { get; set; }
        public int logged_user { get; set; }
    }
}