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
    
    public List<User> GetAllUsers()
    {
        var filter = Builders<User>.Filter.Empty;

        return collection.Find(filter).ToList();
    }

    public async Task EditUserRole(User user)
    {
        Console.WriteLine("inside repo");
        var filter = Builders<User>.Filter
            .Eq(u => u.Id, user.Id);
        var update = Builders<User>.Update
            .Set(r => r.Role, user.Role);
        
        var result = await collection.UpdateOneAsync(filter, update);
        
    }

}