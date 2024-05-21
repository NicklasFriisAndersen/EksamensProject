using System;
using System.Reflection;
using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories
{
    public class RegisteredChildRepository : IRegisteredChildRepository
    {
        private string connectionString = "mongodb+srv://eksamenprojekt:gruppe3eksamen@sumarumpasning.fmcwhpm.mongodb.net/";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<RegisteredChild> collection;

        public RegisteredChildRepository()
        {
            mongoClient = new MongoClient(connectionString);

            database = mongoClient.GetDatabase("SumarumDagpleje");

            collection = database.GetCollection<RegisteredChild>("RegisteredChild");
        }

        public List<RegisteredChild> getAllItems()
        {
            var filter = Builders<RegisteredChild>.Filter.Empty;

            return collection.Find(filter).ToList();
        }

        public void insertOneItem(RegisteredChild item)
        {
            collection.InsertOne(item);
        }

        public List<RegisteredChild> FilterChildByKraevNummer(string kraevnr)
        {
            var filter = Builders<RegisteredChild>.Filter.Eq("Krævnr", kraevnr);
            return collection.Find(filter).ToList();
        }

        public List<RegisteredChild> FilterByAssignedWeek(string assignedWeek)
        {
            Console.WriteLine(assignedWeek);
            var filter = Builders<RegisteredChild>.Filter.Eq(child => child.AssignedPeriod.Week, assignedWeek);
            return collection.Find(filter).ToList();
        }

        public List<RegisteredChild> FilterByNewsletter()
        {
            var filter = Builders<RegisteredChild>.Filter.Eq("Newsletter", true);
            return collection.Find(filter).ToList();
        }
        
        public void UpdateAssignedPeriod(RegisteredChild registeredChild)
        {
            var filter = Builders<RegisteredChild>.Filter.Eq("Id", registeredChild.Id);

            var update = Builders<RegisteredChild>.Update
                .Set(r => r.Name, registeredChild.Name)
                .Set(r => r.Age, registeredChild.Age)
                .Set(r => r.ClothingSize, registeredChild.ClothingSize)
                .Set(r => r.Comment, registeredChild.Comment)
                .Set(r => r.BeenBefore, registeredChild.BeenBefore)
                .Set(r => r.Hobbies, registeredChild.Hobbies)
                .Set(r => r.GuardianSignature, registeredChild.GuardianSignature)
                .Set(r => r.Krævnr, registeredChild.Krævnr)
                .Set(r => r.ParentName, registeredChild.ParentName)
                .Set(r => r.ParentEmail, registeredChild.ParentEmail)
                .Set(r => r.ParentPhoneNumber, registeredChild.ParentPhoneNumber)
                .Set(r => r.AssignedPeriod, registeredChild.AssignedPeriod)
                .Set(r => r.FirstPriority, registeredChild.FirstPriority)
                .Set(r => r.SecondPriority, registeredChild.SecondPriority)
                .Set(r => r.DateAdded, registeredChild.DateAdded);

            collection.UpdateOne(filter, update);

        }



    }
}