using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ado;
using Core.Classes_Core;

namespace WebLeisure.Controllers
{
    public class PlaceController : Controller
    {
        public IActionResult Index()
        {
            var activites = DataAccess.GetPlacesList();
            return View(activites);
        }
        [HttpGet]
        public IActionResult WatchPlace(int id)
        {
            Place place = DataAccess.GetPlace(id);
            DataAccess.AddVisitToPlace(place);
            return View(place);
        }
        
       
    }
}
