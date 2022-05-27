using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ado;
using Core.Classes_Core;

namespace WebLeisure.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            var activites = DataAccess.GetActivities();
            return View(activites);
        }
        //[HttpGet]
        //public ActionResult<Activity> Get(string name)
        //{
        //    var activity = DataAccess.GetActivity(name);
        //    if (activity == null)
        //        return NotFound();
        //    return activity;
        //}

        //public IActionResult WatchActivity(string name)
        //{
        //    var activity = DataAccess.GetActivity(name);
        //    DataAccess.AddVisitToActivity(activity);
        //    return RedirectToAction("WatchActivity");
        //}
        //public IActionResult WatchActivity()// View нужно назвать WatchActivity
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult WatchActivity(int id)
        {
            Activity activity = DataAccess.GetActivity(id);
            return View(activity);
        }
    }
}
