using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myboard_server.Models;
using Raven.Client;

namespace myboard_server.Database
{
    public class BoardRepository
    {
        private readonly IDocumentSession session;

        public BoardRepository(IDocumentSession session)
        {
            this.session = session;
        }

        public Board Get()
        {
            Board board = default(Board);
            board = this.session.Load<Board>(Board.BoardId);

            if (board == null)
            {
                board = new Board();
                this.session.Store(board);
                this.session.SaveChanges();
            }

            return board;
        }

        public void Save(Board board)
        {
            this.session.Store(board);
            this.session.SaveChanges();
        }
    }
}