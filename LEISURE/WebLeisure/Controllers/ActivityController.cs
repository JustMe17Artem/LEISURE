using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLeisure.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            var activites = Core.Classes_Core.DataAccess.GetActivities();
            return View(activites);
        }
    }
}
