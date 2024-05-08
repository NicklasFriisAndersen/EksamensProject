using System;
using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories
{
	public class PeriodRepository : IPeriodRepository
    {
        private string connectionString = "mongodb+srv://eksamenprojekt:gruppe3eksamen@sumarumpasning.fmcwhpm.mongodb.net/";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<Period> collection;

        public PeriodRepository()
		{
            mongoClient = new MongoClient(connectionString);

            database = mongoClient.GetDatabase("SumarumDagpleje");

            collection = database.GetCollection<Period>("Period");
        }

        public List<Period> getAllItems()
        {
            var filter = Builders<Period>.Filter.Empty;

            return collection.Find(filter).ToList();
        }
    }
}

