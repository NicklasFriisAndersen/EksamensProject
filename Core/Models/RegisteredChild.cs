using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class RegisteredChild
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string? Id { get; set; }
    
    public string Name { get; set; }

    public int Age { get; set; }
    
    public string ClothingSize { get; set; }
    
    public string Comment { get; set; }
    
    public bool BeenBefore { get; set; }

    public string Hobbies { get; set; }
    
    // public string GuardianSignature { get; set; }
    
    public string Kraevnummer { get; set; }
    
    public User user { get; set; }

    public Period period { get; set; }


}