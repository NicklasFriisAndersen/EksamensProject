using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class U18Volunteer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string? Id { get; set; }
    
    public string? Name { get; set; }
    
    public byte[]? GuardianSignature {get; set;}
    
    public string? KraevnummerU18 { get; set; }
    
    public User? user { get; set; }
    
    public DateTime? DateAdded { get; set; }
    
}