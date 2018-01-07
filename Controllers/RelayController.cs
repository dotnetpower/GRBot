using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GBot.Controllers
{
    public class RelayController : ApiController
    {
        [HttpGet]
        [ActionName("ping")]
        public async Task<string> Ping()
        {
            return "pong";
        }
    }
}
