using GameAPI.Models;
using GameAPI.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GameAPI.Controllers
{
    public class ProgressionController : ApiController
    {
        // GET /GetProgression
        [HttpGet]
        [Route("GetProgression/{AccountID}")]
        public HttpResponseMessage RegisterAccount(int AccountID)
        {
            if (AccountID == 0)
            {
                return null;
            }
            return Request.CreateResponse<Progression>(HttpStatusCode.OK, ProgressionProcessor.getProgress(AccountID));
        }

        // POST /RegisterAccount
        [HttpPost]
        [Route("UpdateProgression")]
        public bool RegisterAccount(Progression progress)
        {
            if (progress == null)
            {
                return false;
            }
            return ProgressionProcessor.updateProgress(progress);
        }
    }
}