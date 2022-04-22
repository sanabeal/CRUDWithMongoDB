using CRUDWithMongoDB.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CRUDWithMongoDB.Models
{
    public class EmployeeModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<Employee> employeeCollection;
        public EmployeeModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            employeeCollection = db.GetCollection<Employee>("employee");
        }

        public List<Employee> findAll()
        {
            return employeeCollection.AsQueryable<Employee>().ToList();
        }

        public void create(Employee employee)
        {
            employeeCollection.InsertOne(employee);
        }

        public void update(Employee employee)
        {
            employeeCollection.UpdateOne(
                Builders<Employee>.Filter.Eq("_id", employee.Id),
                Builders<Employee>.Update
                .Set("Name", employee.Name)
                .Set("FatherName", employee.FatherName)
                .Set("MotherName", employee.MotherName)
                .Set("Address", employee.Address)
                .Set("ContactNo", employee.ContactNo)
                .Set("Email", employee.Email)
                .Set("status", employee.Status)

                );
        }

        public Employee find(string id)
        {
            var employeeId = new ObjectId(id);
            return employeeCollection.AsQueryable<Employee>().SingleOrDefault(a => a.Id == employeeId);
        }

        public void delete(string id)
        {
            employeeCollection.DeleteOne(Builders<Employee>.Filter.Eq("_id", ObjectId.Parse(id)));
        }
    }
}