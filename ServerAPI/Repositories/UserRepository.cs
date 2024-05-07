using System;
using Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using ServerAPI.Utilities;

namespace ServerAPI.Repositories;

public class UserRepository : IUserrepository
{
    private readonly IMongoCollection<User> _users;
    
    IMongoClient mongoClient;

    IMongoDatabase database;

    IMongoCollection<User> collection;

    public UserRepository()
    {
        mongoClient = new MongoClient(MongoHelper.ConnectionString);

        database = mongoClient.GetDatabase("SumarumDagpleje");

        collection = database.GetCollection<User>("User");
    }

    public void insertOneUser(User user)
    {
        collection.InsertOne(user);
    }
}