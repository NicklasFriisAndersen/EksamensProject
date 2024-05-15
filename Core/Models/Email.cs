using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class Email
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string? Id { get; set; }
    
    public string? Subject { get; set; }
    
    public string? Content { get; set; }
}