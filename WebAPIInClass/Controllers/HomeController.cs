using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WebAPIInClass.Models;

namespace WebAPIInClass.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Details(int EmployeeId)
        {
            ViewBag.EmployeeId = EmployeeId;
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string RequestURI,Employee emp)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:61022/api/values");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.PostAsJsonAsync(RequestURI, emp).Result;
            return View("Index");
        }
    }
}
