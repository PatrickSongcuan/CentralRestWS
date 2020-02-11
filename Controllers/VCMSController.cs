using CentralRestWS.Entities;
using CentralRestWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BCrypt.Net;

namespace CentralRestWS.Controllers
{
    public class VCMSController : ApiController
    {
        #region Login Action VCMS
        [HttpPost]
        public IHttpActionResult Login([FromBody] VCMS_AuthModel AuthModel)
        {
            string passwordHash = "";
            string userRole = "";
            string firstName = "";
            string lastName = "";
            string userId = "";

            VCMS_ReturnModel returnModel = new VCMS_ReturnModel();

            try
            {
                using (var ctx = new GeneralEntity2())
                {
                    passwordHash = ctx.prc_VCMS_get_password_hash(AuthModel.username).First();
                    var item = ctx.prc_VCMS_get_user_roles_and_details(AuthModel.username).First();
                    userRole = item.role_id.ToString();
                    firstName = item.first_name.ToString();
                    lastName = item.last_name.ToString();
                    userId = item.user_id.ToString();
                }
            }
            catch (Exception) { }

            if (passwordHash == "")
            {
                returnModel.code = "0001";
                returnModel.desc = "ACCTMS";
                returnModel.user_role = "0";
                returnModel.first_name = "";
                returnModel.last_name = "";
                returnModel.user_id = "";
            }
            else
            {
                //string passwordHashAuth = BCrypt.Net.BCrypt.HashPassword(AuthModel.password);

                if (BCrypt.Net.BCrypt.Verify(AuthModel.password, passwordHash))
                {
                    returnModel.code = "0000";
                    returnModel.desc = "OK";
                    returnModel.user_role = userRole;
                    returnModel.first_name = firstName;
                    returnModel.last_name = lastName;
                    returnModel.user_id = userId;
                }
                else
                {
                    returnModel.code = "0002";
                    returnModel.desc = "WRNGPW";
                    returnModel.user_role = "0";
                    returnModel.first_name = "";
                    returnModel.last_name = "";
                    returnModel.user_id = "";
                }
            }

            return Ok(new { returnModel });
        }
        #endregion Login Action VCMS

        #region GetRole Action VCMS
        [HttpGet]
        public IHttpActionResult GetRoles()
        {
            List<RoleModel> RoleList = new List<RoleModel>();

            using (var ctx = new GeneralEntity2())
            {
                var roles = ctx.prc_VCMS_get_roles();

                foreach (var role in roles)
                {
                    RoleModel Role = new RoleModel()
                    {
                        RoleId = role.role_id,
                        RoleName = role.role_name
                    };

                    RoleList.Add(Role);
                }
            }

            return Ok(new { RoleList });
        }
        #endregion GetRole Action VCMS

        #region RegisterUser Action VCMS
        [HttpPost]
        public IHttpActionResult RegisterUser([FromBody] VCMS_UserRegisterModel UserRegisterModel)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(UserRegisterModel.password);

            using (var ctx = new GeneralEntity2())
            {
                ctx.prc_VCMS_register_user(UserRegisterModel.username, passwordHash, UserRegisterModel.firstName,
                    UserRegisterModel.lastName, Convert.ToInt32(UserRegisterModel.roleId), UserRegisterModel.emailAddress, UserRegisterModel.contactNumber, 1);
            }

            return Ok(200);
        }
        #endregion RegisterUser Action VCMS

        [HttpPost]
        public IHttpActionResult UpdateUser([FromBody] VCMS_UserUpdateModel UserUpdateModel)
        {
            using (var ctx = new GeneralEntity2())
            {
                ctx.prc_VCMS_update_user(Convert.ToInt32(UserUpdateModel.user_id),
                    UserUpdateModel.first_name,
                    UserUpdateModel.last_name,
                    UserUpdateModel.email_address,
                    UserUpdateModel.contact_number,
                    Convert.ToInt32(UserUpdateModel.user_logged),
                    Convert.ToInt32(UserUpdateModel.is_enabled));
            }

            return Ok(200);
        }

        #region CheckUser Action VCMS
        [HttpGet]
        public IHttpActionResult UserCheck(string Username)
        {
            string retVal = "";

            using (var ctx = new GeneralEntity2())
            {
                retVal = ctx.prc_VCMS_check_username(Username).First().ToString();
            }

            return Ok(retVal);
        }
        #endregion CheckUser Action VCMS

        #region GetAllUsers Action VCMS
        [HttpGet]
        public IHttpActionResult GetAllUsers(string user_id)
        {
            List<VCMS_GetUserModel> UserList = new List<VCMS_GetUserModel>();

            using (var ctx = new GeneralEntity2())
            {
                var users = ctx.prc_VCMS_get_all_users(Int32.Parse(user_id));

                foreach (var user in users)
                {
                    VCMS_GetUserModel userModel = new VCMS_GetUserModel();

                    userModel.user_id = user.user_id.ToString();
                    userModel.first_name = user.first_name.ToString();
                    userModel.last_name = user.last_name.ToString();
                    userModel.role_name = user.role_name.ToString();
                    userModel.email_address = user.email_address.ToString();
                    userModel.contact_number = user.contact_number.ToString();

                    UserList.Add(userModel);
                }
            }

            return Ok(new { UserList });
        }

        #endregion GetAllUsers Action VCMS


        [HttpGet]
        public IHttpActionResult GetUserById(string user_id)
        {
            VCMS_GetUserModelByID userModel = null;

            using (var ctx = new GeneralEntity2())
            {
                var userFromDB = ctx.prc_VCMS_get_user_by_id(Int32.Parse(user_id)).First();

                userModel = new VCMS_GetUserModelByID()
                {
                    username = userFromDB.username,
                    user_id = userFromDB.user_id.ToString(),
                    contact_number = userFromDB.contact_number,
                    email_address = userFromDB.email_address,
                    first_name = userFromDB.first_name,
                    last_name = userFromDB.last_name,
                    role_name = userFromDB.role_name,
                    is_active = userFromDB.is_active.ToString()
                };
            }

            return Ok(new { userModel });
        }

        [HttpGet]
        public IHttpActionResult SearchUsers(string search_input, string user_id)
        {
            List<VCMS_GetUserModel> UserList = new List<VCMS_GetUserModel>();

            using (var ctx = new GeneralEntity2())
            {
                var users = ctx.prc_VCMS_get_all_users_search(Int32.Parse(user_id), search_input);

                foreach (var user in users)
                {
                    VCMS_GetUserModel userModel = new VCMS_GetUserModel();

                    userModel.user_id = user.user_id.ToString();
                    userModel.first_name = user.first_name.ToString();
                    userModel.last_name = user.last_name.ToString();
                    userModel.role_name = user.role_name.ToString();
                    userModel.email_address = user.email_address.ToString();
                    userModel.contact_number = user.contact_number.ToString();

                    UserList.Add(userModel);
                }
            }

            return Ok(new { UserList });
        }

        [HttpGet]
        public IHttpActionResult GetUsersByStatus(string user_id, string status_flag)
        {
            List<VCMS_GetUserModel> UserList = new List<VCMS_GetUserModel>();

            using (var ctx = new GeneralEntity2())
            {
                var users = ctx.prc_VCMS_get_user_by_status(Int32.Parse(user_id), Int32.Parse(status_flag));

                foreach (var user in users)
                {
                    VCMS_GetUserModel userModel = new VCMS_GetUserModel();

                    userModel.user_id = user.user_id.ToString();
                    userModel.first_name = user.first_name.ToString();
                    userModel.last_name = user.last_name.ToString();
                    userModel.role_name = user.role_name.ToString();
                    userModel.email_address = user.email_address.ToString();
                    userModel.contact_number = user.contact_number.ToString();

                    UserList.Add(userModel);
                }
            }

            return Ok(new { UserList });
        }

        [HttpPost]
        public IHttpActionResult CreateResident([FromBody] VCMS_CreateResidentModel CreateResidentModel)
        {
            using (var ctx = new GeneralEntity2())
            {
                int payment_balance = Int32.Parse(CreateResidentModel.monthly_collection);

                if (CreateResidentModel.has_payment == 1)
                {
                    payment_balance = Int32.Parse(CreateResidentModel.monthly_collection) - Int32.Parse(CreateResidentModel.payment_amount);
                }

                ctx.prc_VCMS_create_resident(CreateResidentModel.first_name, CreateResidentModel.middle_name, CreateResidentModel.last_name,
                    CreateResidentModel.email_address, CreateResidentModel.contact_number, CreateResidentModel.monthly_collection,
                    DateTime.Parse(CreateResidentModel.start_date_of_collection), CreateResidentModel.has_payment, CreateResidentModel.logged_user,
                    CreateResidentModel.payment_amount, payment_balance.ToString());

            }

            return Ok(200);
        }

        [HttpPost]
        public IHttpActionResult CheckDuplicateResident([FromBody] VCMS_CreateResidentModel CreateResidentModel)
        {
            int returnCode = 0;

            using (var ctx = new GeneralEntity2())
            {
                returnCode = Int32.Parse(ctx.prc_VCMS_check_resident(CreateResidentModel.first_name,CreateResidentModel.last_name, CreateResidentModel.email_address).First().ToString());
            }

            return Ok(returnCode);
        }


    }


}
