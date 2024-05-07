using Core.Models;
using MongoDB.Driver;
using ServerAPI.Utilities;

namespace ServerAPI.Repositories;

public class LoginRepository : ILoginRepository
{
    private readonly IMongoCollection<User> _users;

    IMongoClient mongoClient;

    IMongoDatabase database;

    IMongoCollection<User> collection;

    public LoginRepository()
    {
        mongoClient = new MongoClient(MongoHelper.ConnectionString);
        database = mongoClient.GetDatabase("SumarumDagpleje");
        _users = database.GetCollection<User>("User");
    }

    public User GetUserByUserName(string username)
    {
        return _users.Find(u => u.Username == username).FirstOrDefault();
    }

    public bool Verify(string username, string password)
    {
        var user = GetUserByUserName(username);
        if (user != null)
        {
            return user.Password == password;
        }

        return false;
    }


}