using GameAPI.Models;
using GameAPI.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GameAPI.Controllers
{
    public class AccountsController : ApiController
    {
        // POST /RegisterAccount
        [HttpPost]
        [Route("RegisterAccount")]
        public bool RegisterAccount(Account account)
        {
            if (account == null)
            {
                return false;
            }
            return AccountProcessor.RegisterAccount(account);
        }

        // POST /Login
        [HttpPost]
        [Route("Login")]
        public int Login(Account account)
        {
            if (account == null)
            {
                return 0;
            }
            return AccountProcessor.LoginAccount(account);
        }



        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
    }
}