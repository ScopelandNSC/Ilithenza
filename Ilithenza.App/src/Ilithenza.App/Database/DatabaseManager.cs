using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Ilithenza.App.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Ilithenza.App.Database
{
    public static class DatabaseManager
    {
        private static string dbConn = "mongodb+srv://OWLAdmin:fACboz58YFyNnZTs@owl-rkvnm.mongodb.net/test?retryWrites=true&w=majority";

        public static void Initialise()
        {
            MongoClient dbClient = new MongoClient(dbConn);

            var dbList = dbClient.ListDatabases().ToList();

#pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("The list of databases on this server is: ");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
        }
    }
}
