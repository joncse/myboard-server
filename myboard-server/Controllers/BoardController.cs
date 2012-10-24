﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using myboard_server.Database;
using myboard_server.Models;

namespace myboard_server.Controllers
{
    public class BoardController : ApiController
    {
        // GET api/board
        public HttpResponseMessage Get()
        {
            Board board = GetBoardFromDatabase();

            if (board == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No board found.");
            else
                return Request.CreateResponse<Board>(HttpStatusCode.OK, board);
        }

        private Board GetBoardFromDatabase()
        {
            Board board = default(Board);

            using (var session = RavenDatabase.GetSession())
            {
                board = session.Load<Board>(Board.BoardId);

                if (board == null)
                {
                    board = new Board();
                    session.Store(board);
                }

                session.SaveChanges();
            }

            return board;
        }
    }
}
