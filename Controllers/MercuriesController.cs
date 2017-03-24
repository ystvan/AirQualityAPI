using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQualityAPI.Models;
using AirQualityAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AirQualityAPI.Controllers
{

    [Produces("application/json")]
    [Route("api/Mercuries")]
    public class MercuriesController : Controller
    {
        public IMercuriesRepository MercuriesRepo { get; set; }

        public MercuriesController(IMercuriesRepository _repo)
        {
            MercuriesRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<Mercury> GetAll()
        {
            return MercuriesRepo.GetAll().Take(500);
        }

        [HttpGet("{id}", Name = "GetMercuries")]
        public IActionResult GetById(string id)
        {
            var item = MercuriesRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPut("{id}")]
        public IActionResult Create([FromBody] Mercury item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            MercuriesRepo.Add(item);
            return CreatedAtRoute("GetMercuries", new { Controller = "Mercuries", id = item.Mercury_Id }, item);
        }

        [HttpPut]
        public IActionResult Update(string id, [FromBody] Mercury item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var mercuryObj = MercuriesRepo.Find(id);
            if (mercuryObj == null)
            {
                return NotFound();
            }
            MercuriesRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            MercuriesRepo.Remove(id);
        }
    }
}
