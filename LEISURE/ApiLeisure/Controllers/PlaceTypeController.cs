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
    public class PlaceTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IEnumerable<Place_Type> Get()
        {
            return DataAccess.GetPlaceTypes();
        }
        [HttpPost]
        public IActionResult Create(Place_Type type)
        {
            DataAccess.AddNewPlaceType(type);
            return CreatedAtAction(nameof(Create), new { id = type.Id }, type);
        }
        [HttpGet("{id}")]
        public ActionResult<Place_Type> Get(int id)
        {
            var type = DataAccess.GetPlaceType(id);
            if (type == null)
                return NotFound();
            return type;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Place_Type type)
        {
            if (id != type.Id)
                return BadRequest();

            var result = DataAccess.GetPlaceType(id);
            if (result == null)
                return NotFound();

            DataAccess.UpdatePlaceType(type);

            return NoContent();
        }


    }
}
