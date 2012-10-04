using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myboard_server.Models
{
    public class Sticky
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}