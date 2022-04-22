
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using CRUDWithMongoDB.Entities;
using System.Configuration;
using MongoDB.Bson;

namespace CRUDWithMongoDB.Models
{
    public class AccountModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<Account> accountCollection;
        public AccountModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            accountCollection = db.GetCollection<Account>("account");
        }
        public List<Account> findAll()
        {
            return accountCollection.AsQueryable<Account>().ToList();
        }
        public void create(Account account)
        {
            accountCollection.InsertOne(account);
        }
        public void update(Account account)
        {
            accountCollection.UpdateOne(
                Builders<Account>.Filter.Eq("_id", account.Id),
                Builders<Account>.Update
                .Set("username", account.Username)
                .Set("password", account.Password)
                .Set("fullName", account.FullName)
                .Set("status", account.Status)

                );
        }

        public Account find(string id)
        {
            var accountId = new ObjectId(id);
            return accountCollection.AsQueryable<Account>().SingleOrDefault(a => a.Id == accountId);
        }

        public void delete(string id)
        {
            accountCollection.DeleteOne(Builders<Account>.Filter.Eq("_id", ObjectId.Parse(id)));
        }
    }
}