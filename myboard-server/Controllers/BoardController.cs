using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using myboard_server.Models;

namespace myboard_server.Controllers
{
    public class BoardController : ApiController
    {
        // GET api/board
        public Board Get()
        {
            var board = new Board();
            board.Stickies.Add(new Sticky { Content = "Hello World!", X = 5, Y = 10 });
            board.Stickies.Add(new Sticky { Content = "Goodbye World!", X = 15, Y = 20 });

            return board;
        }
    }
}
