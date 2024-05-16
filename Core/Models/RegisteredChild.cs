using System.Text.Json.Serialization;
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

        public string? Name { get; set; }

        public int? Age { get; set; }

        public string? ClothingSize { get; set; }

        public string? Comment { get; set; }

        public bool BeenBefore { get; set; }

        public bool Newsletter { get; set; }

        public string? Hobbies { get; set; }

        public byte[]? GuardianSignature { get; set; }

        public int? Krævnr { get; set; }

        public string? ParentName { get; set; }

        public string? ParentEmail { get; set; }

        public string? ParentPhoneNumber { get; set; }

        public AssignedPeriod? AssignedPeriod { get; set; }

        public Priority? FirstPriority { get; set; }

        public Priority? SecondPriority { get; set; }

        public DateTime DateAdded { get; set; }


    }
}