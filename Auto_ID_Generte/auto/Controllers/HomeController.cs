using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auto.Models;
namespace auto.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MVCEntities db = new MVCEntities();
            Auto_Id_ emp = new Auto_Id_();

            var lastemp = db.Auto_Id_.OrderByDescending(c => c.id).FirstOrDefault();
            if (lastemp == null)
            {
                emp.Employeeid = "BICS SFDC001";
            }
            else
            {
                emp.Employeeid = "BICS SFDC"+(Convert.ToInt32(lastemp.Employeeid.Substring(9, lastemp.Employeeid.Length - 9))+1).ToString("D3");
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult Index(Auto_Id_ e)
        {
            if (ModelState.IsValid)
            { 
            MVCEntities db = new MVCEntities();
            db.Auto_Id_.Add(e);
            db.SaveChanges();
                return RedirectToAction("index");
            }
            
            
            
            return View();
        }
    }
}