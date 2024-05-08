using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models
{
	public class Priority
	{
        public string Week { get; set; }

        public string Day { get; set; }

        public string? Location { get; set; }
    }
}

