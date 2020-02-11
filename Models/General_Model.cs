using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralRestWS.Models
{
    public class General_Model
    {

    }

    public class LoginObject
    {
        public string name { get; set; }
        public string password { get; set; }
    }
    public class LoginObjectContainer
    {
        public LoginObject LoginObject { get; set; }
    }

    public class GroupModel
    {
        public string group_name { get; set; }
    }

    public class LogoutGroup
    {
        public string group_no { get; set; }
        public string guid { get; set; }
    }


    public class LogoutGroupContainer
    {
        public LogoutGroup LogoutGroup { get; set; }
    }

    public class GroupModelContainer
    {
        public GroupModel GroupModel { get; set; }
    }

    public class PresmatReturnModel
    {
        public string GroupNumber { get; set; }
        public string GroupName { get; set; }
        public string Guid { get; set; }
    }

    public class GroupObj
    {
        public string GroupNo { get; set; }
        public string GroupName { get; set; }
        public string isBuzzed { get; set; }
        public string Score { get; set; }
    }

    public class TimeReturn
    {
        public string timeStart { get; set; }
        public string timeEnd { get; set; }
    }

    public class GroupAndScores
    {
        public string groupNumber { get; set; }
        public string score { get; set; }
    }



}