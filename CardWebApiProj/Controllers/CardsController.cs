using CardManagerProj.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CardWebApiProj.Controllers
{
    public class CardsController : ApiController
    {
        [HttpGet]
        [Route("api/card/{id}")]
        public IHttpActionResult Get(int id)
        {
            using (CardManager cm = new CardManager())
            {
                return Ok(cm.GetCard(id));
            }
        }

    }
}