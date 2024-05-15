using Core.Models;
using MongoDB.Driver;
using ServerAPI.Utilities;

namespace ServerAPI.Repositories;

public class EmailRepository : IEmailRepository
{
    private readonly IMongoCollection<Email> _emails;

    IMongoClient mongoClient;

    IMongoDatabase database;

    IMongoCollection<Email> collection;

    public EmailRepository()
    {
        mongoClient = new MongoClient(MongoHelper.ConnectionString);

        database = mongoClient.GetDatabase("SumarumDagpleje");

        collection = database.GetCollection<Email>("Email");
    }

    public async Task UpdateEmail(Email email)
    {
        var filter = Builders<Email>.Filter.Empty;
        var update = Builders<Email>.Update
            .Set(e => e.Subject, email.Subject)
            .Set(e => e.Content, email.Content);
        var opts = new UpdateOptions
        {
            IsUpsert = true
        };

        var result = await collection.UpdateOneAsync(filter, update, opts);
    }

    public Task SendEmails(List<RegisteredChild> children)
    {
        return null;
    }
}