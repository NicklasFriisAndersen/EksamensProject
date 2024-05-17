using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class AssignedPeriod
{
    public string Week { get; set; } = "Ikke Tilføjet";

    public string Days { get; set; } = "Ikke Tilføjet";

}