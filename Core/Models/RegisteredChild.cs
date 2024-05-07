using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models
{
	public class RegisteredChild
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        public string? Name { get; set; } = " ";

        public int? Age { get; set; } = 0;

        public string? ClothingSize { get; set; } = " ";

        public string? Comment { get; set; } = " ";

        public bool BeenBefore { get; set; }

        public string? Hobbies { get; set; } = " ";

        public string? Signature { get; set; } = " ";

        public int? Krævnr { get; set; } = 0;
    }
}

