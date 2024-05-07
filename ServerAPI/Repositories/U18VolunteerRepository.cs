using System;
using Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using ServerAPI.Utilities;
namespace ServerAPI.Repositories;

public class U18VolunteerRepository : IU18VolunteerRepository
{
    private readonly IMongoCollection<U18Volunteer> _u18volunteer;

    IMongoClient MongoClient;

    IMongoDatabase database;

    IMongoCollection<U18Volunteer> collection;


    public U18VolunteerRepository()
    {
        MongoClient = new MongoClient(MongoHelper.ConnectionString);

        database = MongoClient.GetDatabase("SumarumDagpleje");

        collection = database.GetCollection<U18Volunteer>("U18Volunteer");
    }

    public void insertOneU18Volunteer(U18Volunteer u18Volunteer)
    {
        collection.InsertOne(u18Volunteer);
    }
}