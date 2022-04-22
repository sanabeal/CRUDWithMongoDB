using CRUDWithMongoDB.Entities;
using CRUDWithMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDWithMongoDB.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeModel employeeModel = new EmployeeModel();

        // GET: Employee
        public ActionResult Index()
        {
            ViewBag.employees = employeeModel.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Add", new Employee());
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            employeeModel.create(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            employeeModel.delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit", employeeModel.find(id));
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            var currentEmployee = employeeModel.find(employee.Id.ToString());
            currentEmployee.Name = employee.Name;
            currentEmployee.FatherName = employee.FatherName;
            currentEmployee.MotherName = employee.MotherName;
            currentEmployee.Address = employee.Address;
            currentEmployee.ContactNo = employee.ContactNo;
            currentEmployee.Email = employee.Email;
            currentEmployee.Status = employee.Status;
            return RedirectToAction("Index");
        }
    }
}