using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripTrackerLive.BackService.Models;

namespace TripTrackerLive.BackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private Repository _repository;

        public TripsController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return _repository.Get();
        }

        [HttpPost]
        public void Post(Trip value)
        {
            _repository.Add(value);
        }


        [HttpPut("{id}")]
        public void Put(int id,Trip value)
        {
            _repository.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}