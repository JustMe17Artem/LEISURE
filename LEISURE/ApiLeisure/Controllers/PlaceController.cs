using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ado;
using Core.Classes_Core;

namespace ApiLeisure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IEnumerable<Place> Get()
        {
            return DataAccess.GetPlaces();
        }
        [HttpGet("{id}")]
        public ActionResult<Place> Get(int id)
        {
            var place = DataAccess.GetPlace(id);
            if (place == null)
                return NotFound();
            return place;
        }
    }
}
