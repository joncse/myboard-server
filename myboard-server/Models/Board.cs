using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myboard_server.Models
{
    public class Board
    {
        public static string BoardId = "1";
        public string Id { get; set; }
        public List<Sticky> Stickies { get; set; }
        public int NextStickyId { get; set; }

        public Board()
        {
            Id = BoardId;
            Stickies = new List<Sticky>();
            NextStickyId = 1;
        }

        public void AddSticky(Sticky sticky)
        {
            sticky.Id = NextStickyId.ToString();
            NextStickyId++;
            Stickies.Add(sticky);
        }
    }
}