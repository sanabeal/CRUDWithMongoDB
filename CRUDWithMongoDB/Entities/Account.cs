using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUDWithMongoDB.Entities
{
    public class Account
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("fullName")]
        public string FullName { get; set; }

        [BsonElement("status")]
        public bool Status { get; set; }
    }
}