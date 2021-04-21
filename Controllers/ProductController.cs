using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEmos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DEmos.Controllers
{
    public class ProductController : Controller
    {
        private  ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            IEnumerable<ProductVM> prductList = _db.productVMs;
            

            return View(prductList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _db.productVMs.Find(id);
            if (obj != null)
            {
                _db.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

            
        }
        [HttpPost]
       public IActionResult Create(ProductVM obj)
        {
            _db.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            //SqlConnection con = new SqlConnection("server=.;database=BookList;integrated security=SSPI");
            //string message = "";
            //try
            //{

            //    con.Open();
            //    SqlCommand cm = new SqlCommand("select * from Book", con);
            //    SqlDataReader reader = cm.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        message += (" " + reader["Name"]);
            //    }
            //    return Content(message);
            //}
            //catch(Exception e)
            //{
            //    return Content(e.Message);
            //}
            return View(new ProductVM());


        }

       
        public IActionResult Hello()
        {
            ViewData["message"] = "Hello vishal";
            ViewBag.message1 = "Hello alu";
            return View();
        }
        [HttpPost]
        public IActionResult edit(ProductVM obj)
        {
            _db.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult edit(int id)
        {
            var obj = _db.productVMs.Find(id);
            if (obj != null)
            {
                return View(obj);
            }
            else
            {
                return NotFound();
            }
            

        }
    }
}
