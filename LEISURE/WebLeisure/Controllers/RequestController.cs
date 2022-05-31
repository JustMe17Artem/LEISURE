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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(Request request)
        {
            if (ModelState.IsValid)
            {
                DataAccess.AddNewRequest(request);
                return RedirectToAction("Index");
            }
            else
            {
                return View(request);
            }
        }
    }
}
