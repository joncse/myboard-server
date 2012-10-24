using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myboard_server.Models
{
    public class Board
    {
        public List<Sticky> Stickies { get; set; }

        public Board()
        {
            Stickies = new List<Sticky>();
        }
    }
}