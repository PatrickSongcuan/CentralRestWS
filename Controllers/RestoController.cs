using CentralRestWS.Entities;
using CentralRestWS.Models.Resto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CentralRestWS.Controllers
{
    public class RestoController : ApiController
    {
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetSpecials(int company_id)
        {
            List<Special> SpecialList = new List<Special>();

            using (var ctx = new RestoEntity())
            {
                var specials = ctx.sp_resto_get_specials(company_id);

                foreach (var xSpecial in specials)
                {
                    Special special = new Special()
                    {
                        item_name = xSpecial.item_name,
                        is_new = xSpecial.is_new,
                        is_available = xSpecial.is_available,
                        is_special = xSpecial.is_special,
                        date_created = xSpecial.date_created.ToString(),
                        item_description = xSpecial.item_description,
                        item_image = xSpecial.item_image
                        
                    };

                    SpecialList.Add(special);
                }
            }

            return Ok(new { SpecialList });
        }
    }
}
