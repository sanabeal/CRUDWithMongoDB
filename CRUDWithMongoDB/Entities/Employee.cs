using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDWithMongoDB.Entities
{
    public class Employee
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("FatherName")]
        public string FatherName { get; set; }

        [BsonElement("MotherName")]
        public string MotherName { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("ContactNo")]
        public string ContactNo { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Status")]
        public bool Status { get; set; }
    }
}