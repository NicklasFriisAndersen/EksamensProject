using System;
using System.Reflection;
using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories
{
	public class RegisteredChildRepository : IRegisteredChildRepository
    {
        private string connectionString = "mongodb+srv://eksamenprojekt:gruppe3eksamen@sumarumpasning.fmcwhpm.mongodb.net/";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<RegisteredChild> collection;

        public RegisteredChildRepository()
		{
        }
	}
}

