using CentralRestWS.Entities;
using CentralRestWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CentralRestWS.Controllers
{
    public class PresMatController : ApiController
    {

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Buzz(int id)
        {
            using (var ctx = new CentralWsAuthEntity())
            {
                ctx.presmat_buzz(id);
            }
            return Ok(new { result = "OK" });
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetBuzz()
        {

            using (var ctx = new CentralWsAuthEntity())
            {
                try
                {
                    int buzzedGroup = Convert.ToInt32(ctx.presmat_get_buzzed_group().First());
                    return Ok(new { result = buzzedGroup });
                }
                catch (Exception)
                {
                    return Ok(new { result = 0 });
                }
            }
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult ResetBuzz()
        {

            using (var ctx = new CentralWsAuthEntity())
            {
                ctx.presmat_new_round();
                return Ok(new { result = "OK" });

            }
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult LogAndRegister([FromBody] GroupModelContainer GroupModel)
        {
            PresmatReturnModel returnModel = new PresmatReturnModel();

            int GroupNo = 1;
            int hasOne = 0, hasTwo = 0, hasThree = 0, hasFour = 0, hasFive = 0;
            
            try
            {

                GroupModel Group_Model = GroupModel.GroupModel;
                string GroupName = Group_Model.group_name;
                using (var ctx = new CentralWsAuthEntity())
                {
                    foreach(var groupNumber in ctx.presmat_v2_get_group_numbers())
                    {
                        switch (groupNumber)
                        {
                            case 1:
                                hasOne = 1;
                                break;
                            case 2:
                                hasTwo = 1;
                                break;
                            case 3:
                                hasThree = 1;
                                break;
                            case 4:
                                hasFour = 1;
                                break;
                            case 5:
                                hasFive = 1;
                                break;
                            default:
                                break;
                        }
                    }

                    GroupNo = GetGroupNo(hasOne, hasTwo, hasThree, hasFour, hasFive);

                    if (GroupNo == 0)
                    {
                        returnModel.GroupName = "FULL";
                        returnModel.GroupNumber = "-1";

                        return Ok(new { returnModel });
                    }
                    else
                    {
                        Guid guid = Guid.NewGuid();
                        ctx.presmat_v2_register_group(GroupNo, GroupName, guid.ToString());

                        returnModel.GroupName = GroupName;
                        returnModel.GroupNumber = GroupNo.ToString();
                        returnModel.Guid = guid.ToString();

                        return Ok(new { returnModel });
                    }
                }
            }
            catch (Exception e)
            {
                returnModel.GroupName = "FULL";
                returnModel.GroupNumber = "-2";

                return Ok(new { returnModel });
            }
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GroupLogout([FromBody] LogoutGroupContainer LogoutGroup)
        {
            
            try
            {
                LogoutGroup logoutGroup = LogoutGroup.LogoutGroup;
                string GroupNo = logoutGroup.group_no;
                string Guid = logoutGroup.guid;

                using (var ctx = new CentralWsAuthEntity())
                {
                    ctx.presmat_v2_logout_delete_group(Int32.Parse(GroupNo), Guid);

                    return Ok(new { result = 200 });
                }
            }
            catch (Exception e)
            {
                return Ok(new { result = e.ToString() });
            }
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetGroups()
        {

            try
            {
                List<GroupObj> GroupList = new List<GroupObj>();

                using (var ctx = new CentralWsAuthEntity())
                {
                    foreach (var item in ctx.presmat_v2_get_groups())
                    {
                        GroupObj go = new GroupObj
                        {
                            isBuzzed = item.presmat_is_buzzed.ToString(),
                            Score = item.presmat_group_score.ToString(),
                            GroupName = item.presmat_v2_group_name,
                            GroupNo = item.presmat_v2_group_no.ToString()
                        };

                        GroupList.Add(go);

                    }

                    return Ok(new { GroupList });
                }
            }
            catch (Exception e)
            {
                return Ok(new { result = e });
            }
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetTime()
        {

            TimeReturn tr = new TimeReturn();
            try
            {
                using (var ctx = new CentralWsAuthEntity())
                {

                    foreach(var x in ctx.presmat_v2_getBuzzStartDate_EndDate())
                    {
                        tr.timeStart = x.buzzlookUp_startDate.ToString();
                        tr.timeEnd = x.buzzlookUp_endDate.ToString();
                    }

                    return Ok(new { tr });
                }
            }
            catch (Exception e)
            {
                return Ok(new { result = e });
            }
        }

        //[HttpGet]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        //public IHttpActionResult Tick()
        //{
        //    try
        //    {
        //        tickTime();

        //        return Ok(new { result = "Running" });
        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(new { result = e });
        //    }
        //}

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult AddScore(int id)
        {

            List<GroupAndScores> gs = new List<GroupAndScores>();
            List<GroupAndScores> ugs = new List<GroupAndScores>();

            using (var ctx = new CentralWsAuthEntity())
            {
                foreach(var item in ctx.presmat_v2_get_groups())
                {
                    GroupAndScores gas = new GroupAndScores();
                    gas.groupNumber = item.presmat_v2_group_no.ToString();
                    gas.score = item.presmat_group_score.ToString();
                    gs.Add(gas);
                }
                GroupAndScores newGroupAndScores = gs.Where(u => u.groupNumber == id.ToString()).First();

                int currentScore = Int32.Parse(newGroupAndScores.score);
                currentScore++;

                ctx.presmat_v2_update_score(id, currentScore);
                return Ok(new { result = 200 });
            }
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult RemoveScore(int id)
        {

            List<GroupAndScores> gs = new List<GroupAndScores>();
            List<GroupAndScores> ugs = new List<GroupAndScores>();

            using (var ctx = new CentralWsAuthEntity())
            {
                foreach (var item in ctx.presmat_v2_get_groups())
                {
                    GroupAndScores gas = new GroupAndScores();
                    gas.groupNumber = item.presmat_v2_group_no.ToString();
                    gas.score = item.presmat_group_score.ToString();
                    gs.Add(gas);
                }
                GroupAndScores newGroupAndScores = gs.Where(u => u.groupNumber == id.ToString()).First();

                int currentScore = Int32.Parse(newGroupAndScores.score);
                currentScore--;
                if(currentScore < 0)
                {
                    return Ok(new { result = 105 });
                }
                else { 
                    ctx.presmat_v2_update_score(id, currentScore);
                    return Ok(new { result = 200 });
                }
            }
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult ToggleButtonDisable()
        {
            using (var ctx = new CentralWsAuthEntity())
            {
                ctx.button_toggle();
                return Ok(new { result = 200 });
            }
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult CheckDisability()
        {

            using (var ctx = new CentralWsAuthEntity())
            {
                string retVal = ctx.check_button_enable().First();
                return Ok(new { retVal });
            }
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult StartTimer()
        {
            try
            {
                using (var ctx = new CentralWsAuthEntity())
                {
                    if(ctx.presmat_v2_getBuzzStartDate_EndDate().Count() < 1)
                    {
                        ctx.presmat_v2_insert_time_to_lookup();

                        return Ok(new { result = 200 });
                    }
                    else {

                        return Ok(new { result = 105 });
                    }
                }
            }
            catch (Exception e)
            {
                return Ok(new { result = e });
            }
        }

            #region Functions
            public int GetGroupNo(int hasOne,int hasTwo, int hasThree, int hasFour, int hasFive)
        {

            if (hasOne == 1)
            {
                if (hasTwo == 1)
                {
                    if (hasThree == 1)
                    {
                        if (hasFour == 1)
                        {
                            if (hasFive == 1)
                            {
                                return 0;
                            }
                            else
                            {
                                return 5;
                            }
                        }
                        else
                        {
                            return 4;
                        }
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 1;
            }
        }
    }
    #endregion Functions
}
