using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Document;

namespace myboard_server.Database
{
    public class RavenDatabase
    {
        private static IDocumentStore store;
        private static object locker = new object();

        public static RavenDatabase()
        {
            Initialize();
        }

        private static void Initialize()
        {
            if (store == null)
            {
                lock (locker)
                {
                    if (store == null)
                    {
                        store = new DocumentStore { ConnectionStringName = "RavenDB" };
                        store.Conventions.IdentityPartsSeparator = "-";
                        store.Initialize();
                    }
                }
            }
        }

        public IDocumentSession GetSession()
        {
            return store.OpenSession();
        }

    }
}