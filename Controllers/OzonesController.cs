using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQualityAPI.Models;
using AirQualityAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AirQualityAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Ozones")]
    public class OzonesController : Controller
    {
        public IOzonesRepository OzonesRepo { get; set; }

        public OzonesController(IOzonesRepository _repo)
        {
            OzonesRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<Ozone> GetAll()
        {
            return OzonesRepo.GetAll().Take(500);
        }

        [HttpGet("{id}", Name = "GetOzones")]
        public IActionResult GetById(string id)
        {
            var item = OzonesRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPut("{id}")]
        public IActionResult Create([FromBody] Ozone item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            OzonesRepo.Add(item);
            return CreatedAtRoute("GetOzones", new { Controller = "Ozones", id = item.Ozone_Id }, item);
        }

        [HttpPut]
        public IActionResult Update(string id, [FromBody] Ozone item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var ozoneObj = OzonesRepo.Find(id);
            if (ozoneObj == null)
            {
                return NotFound();
            }
            OzonesRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            OzonesRepo.Remove(id);
        }
    }
}
