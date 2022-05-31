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
            var activites = DataAccess.GetActivitiesList();
            return View(activites);
        }

        [HttpGet]
        public IActionResult WatchActivity(int id)
        {
            Activity activity = DataAccess.GetActivity(id);
            DataAccess.AddVisitToActivity(activity);
            return View(activity);
        }

    }
}
