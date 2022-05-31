using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ado;
using Core.Classes_Core;

namespace WebLeisure.Controllers
{
    public class RequestController : Controller
    {
        private static Place place;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            place = DataAccess.GetPlace(id);
            return View("Index");
        }
        [HttpPost]
        public IActionResult Add(Request request)
        {
            if (ModelState.IsValid)
            {
                DataAccess.AddNewRequest(request, place.Id);
                return RedirectToAction("Index");
            }
            else
            {
                return View(request);
            }
        }


    }
}
