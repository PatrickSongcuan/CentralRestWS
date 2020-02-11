using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CentralRestWS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.EnableCors();

            config.MapHttpAttributeRoutes();

            #region Resto Admin Routes
                config.Routes.MapHttpRoute(
                    name: "resto_admin_get_roles",
                    routeTemplate: "api/RestoAdmin/GetRoles/",
                    defaults: new { Controller = "RestoAdmin", Action = "GetRoles" }
                );

                config.Routes.MapHttpRoute(
                    name: "resto_admin_login",
                    routeTemplate: "api/RestoAdmin/Login/",
                    defaults: new { Controller = "RestoAdmin", Action = "Login" }
                );

                config.Routes.MapHttpRoute(
                    name: "resto_admin_register",
                    routeTemplate: "api/RestoAdmin/Register/",
                    defaults: new { Controller = "RestoAdmin", Action = "Register" }
                );
            #endregion

            #region Resto Routes

            config.Routes.MapHttpRoute(
                name: "resto_get_specials",
                routeTemplate: "api/resto/getSpecials/{company_id}",
                defaults: new { Controller = "Resto", Action = "getSpecials"}
            );

            #endregion

            #region VCMS Routes

            config.Routes.MapHttpRoute(
            name: "VCMSCheckDuplicateResident",
            routeTemplate: "api/VCMS/CheckDuplicateResident/",
            defaults: new { Controller = "VCMS", Action = "CheckDuplicateResident", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
            name: "VCMSCreateResident",
            routeTemplate: "api/VCMS/CreateResident/",
            defaults: new { Controller = "VCMS", Action = "CreateResident", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
            name: "VCMSGetUserByStatus",
            routeTemplate: "api/VCMS/GetUsersByStatus/{user_id}/{status_flag}",
            defaults: new { Controller = "VCMS", Action = "GetUsersByStatus", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
            name: "VCMSUpdateUser",
            routeTemplate: "api/VCMS/UpdateUser/",
            defaults: new { Controller = "VCMS", Action = "UpdateUser", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
             name: "VCMSSearchUsers",
             routeTemplate: "api/VCMS/SearchUsers/{search_input}/{user_id}",
             defaults: new { Controller = "VCMS", Action = "SearchUsers", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
             name: "VCMSGetUserById",
             routeTemplate: "api/VCMS/GetUserById/{user_id}",
             defaults: new { Controller = "VCMS", Action = "GetUserById", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
             name: "VCMSUserCheck",
             routeTemplate: "api/VCMS/UserCheck/{Username}",
             defaults: new { Controller = "VCMS", Action = "UserCheck", id = RouteParameter.Optional }
           );


            config.Routes.MapHttpRoute(
             name: "VCMSGetAllUsers",
             routeTemplate: "api/VCMS/GetAllUsers/{user_id}",
             defaults: new { Controller = "VCMS", Action = "GetAllUsers", id = RouteParameter.Optional }
           );


            config.Routes.MapHttpRoute(
             name: "VCMSRegisterUser",
             routeTemplate: "api/VCMS/RegisterUser/",
             defaults: new { Controller = "VCMS", Action = "RegisterUser", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
              name: "VCMSGetRoles",
              routeTemplate: "api/VCMS/GetRoles/",
              defaults: new { Controller = "VCMS", Action = "GetRoles", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "VCMSLogin",
              routeTemplate: "api/VCMS/Login/",
              defaults: new { Controller = "VCMS", Action = "Login", id = RouteParameter.Optional }
            );

            #endregion VCMS Routes

            #region Student Portal Routes

            #region Student Portal Admin Routes
            config.Routes.MapHttpRoute(
              name: "StudentPortalAdminLogin",
              routeTemplate: "api/admin/login/",
              defaults: new { Controller = "StudentPortalAdmin", Action = "Login", id = RouteParameter.Optional }
            );


            #endregion Student Portal Admin Routes

            #endregion Student Portal Routes

            #region Other Routes
            config.Routes.MapHttpRoute(
               name: "UQueue",
               routeTemplate: "api/UQueueLogin/",
               defaults: new { Controller = "UQueue", Action = "Login", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "ToggleButtonDisable",
               routeTemplate: "api/ToggleButtonDisable/",
               defaults: new { Controller = "PresMat", Action = "ToggleButtonDisable", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "CheckDisability",
               routeTemplate: "api/CheckDisability/",
               defaults: new { Controller = "PresMat", Action = "CheckDisability", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "AddScore",
               routeTemplate: "api/AddScore/{id}",
               defaults: new { Controller = "PresMat", Action = "AddScore", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "RemoveScore",
               routeTemplate: "api/RemoveScore/{id}",
               defaults: new { Controller = "PresMat", Action = "RemoveScore", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "GetTime",
               routeTemplate: "api/GetTime/",
               defaults: new { Controller = "PresMat", Action = "GetTime", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "Tick",
               routeTemplate: "api/Tick/",
               defaults: new { Controller = "PresMat", Action = "Tick", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "StartTimer",
               routeTemplate: "api/StartTimer/",
               defaults: new { Controller = "PresMat", Action = "StartTimer", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
                name: "GetGroups",
                routeTemplate: "api/GetGroups/",
                defaults: new { Controller = "PresMat", Action = "GetGroups", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GroupLogout",
                routeTemplate: "api/GroupLogout/",
                defaults: new { Controller = "PresMat", Action = "GroupLogout", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "LogAndRegister",
                routeTemplate: "api/LoginAndRegister/",
                defaults: new { Controller = "PresMat", Action = "LogAndRegister", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "EndRound",
                routeTemplate: "api/resetbuzz/",
                defaults: new { Controller = "PresMat", Action = "ResetBuzz", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Buzz",
                routeTemplate: "api/buzz/{id}",
                defaults: new { Controller = "PresMat", Action = "Buzz", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetBuzz",
                routeTemplate: "api/getbuzz/",
                defaults: new { Controller = "PresMat", Action = "GetBuzz", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetAccoutHash",
                routeTemplate: "apis/GetAccountHash/{username}",
                defaults: new { Controller = "UserAuth", Action = "GetHash", username = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ValidateAuth",
                routeTemplate: "apis/login",
                defaults: new { Controller = "UserAuth", Action = "Login", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "RegisterApi",
                routeTemplate: "apis/register",
                defaults: new { Controller = "UserAuth", Action = "Register", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "LoginApi",
                routeTemplate: "apis/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            #endregion Other Routes
        }
    }
}
