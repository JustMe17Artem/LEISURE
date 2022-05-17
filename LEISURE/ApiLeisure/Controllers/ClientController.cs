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
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return DataAccess.GetClients();
        }
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            var client = DataAccess.GetClientById(id);
            if (client == null)
                return NotFound();
            return client;
        }
    }
}
