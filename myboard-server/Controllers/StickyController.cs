using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using myboard_server.Models;

namespace myboard_server.Controllers
{
    public class StickyController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Sticky with that id not found.");
        }

        public HttpResponseMessage Put(string id, Sticky sticky)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        public HttpResponseMessage Post(Sticky sticky)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        public HttpResponseMessage Delete(string id)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }
    }
}
