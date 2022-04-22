using CRUDWithMongoDB.Entities;
using CRUDWithMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDWithMongoDB.Controllers
{
    public class AccountController : Controller
    {
        AccountModel accountModel = new AccountModel();

        // GET: Account
        public ActionResult Index()
        {
            ViewBag.accounts = accountModel.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Add", new Account());
        }

        [HttpPost]
        public ActionResult Add(Account account)
        {
            accountModel.create(account);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            accountModel.delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit", accountModel.find(id));
        }

        [HttpPost]
        public ActionResult Edit(Account account)
        {
            var currentAccount = accountModel.find(account.Id.ToString());
           if(account.Password.Length!=0)
            {
                currentAccount.Password = account.Password;
            }
            currentAccount.Username = account.Username;
            currentAccount.FullName = account.FullName;
            currentAccount.Status = account.Status;        
            return RedirectToAction("Index");
        }
    }
}