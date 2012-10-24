using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using myboard_server.Database;
using myboard_server.Models;

namespace myboard_server.Controllers
{
    public class StickyController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            using (var session = RavenDatabase.GetSession())
            {
                var boardRepo = new BoardRepository(session);
                var board = boardRepo.Get();
                var sticky = board.Stickies.Where(s => s.Id == id).FirstOrDefault();

                if (sticky == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Sticky with that id not found.");
                else
                    return Request.CreateResponse<Sticky>(HttpStatusCode.OK, sticky);
            }
        }

        public HttpResponseMessage Put(string id, Sticky sticky)
        {
            using (var session = RavenDatabase.GetSession())
            {
                var boardRepo = new BoardRepository(session);
                var board = boardRepo.Get();
                var existingSticky = board.Stickies.Where(s => s.Id == id).FirstOrDefault();

                if (existingSticky == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Sticky with that id not found.");
                }
                else
                {
                    existingSticky.Content = sticky.Content;
                    existingSticky.X = sticky.X;
                    existingSticky.Y = sticky.Y;
                    existingSticky.Height = sticky.Height;
                    existingSticky.Width = sticky.Width;

                    boardRepo.Save(board);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }

        public HttpResponseMessage Post(Sticky sticky)
        {
            using (var session = RavenDatabase.GetSession())
            {
                var boardRepo = new BoardRepository(session);
                var board = boardRepo.Get();
                board.AddSticky(sticky);
                boardRepo.Save(board);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(string id)
        {
            using (var session = RavenDatabase.GetSession())
            {
                var boardRepo = new BoardRepository(session);
                var board = boardRepo.Get();
                var sticky = board.Stickies.Where(s => s.Id == id).FirstOrDefault();

                if (sticky == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Sticky with that id not found.");
                }
                else
                {
                    board.Stickies.Remove(sticky);
                    boardRepo.Save(board);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }
    }
}
