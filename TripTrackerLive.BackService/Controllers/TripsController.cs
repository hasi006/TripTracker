using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripTrackerLive.BackService.Data;
using TripTrackerLive.BackService.Models;

namespace TripTrackerLive.BackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        //private Repository _repository;

        private TripContext _context;

        public TripsController(TripContext context) //(Repository repository)
        {
            //_repository = repository;
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;//only stop tracking for queary not affecting update 
        }

        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            //return _repository.Get();
            return _context.Trips.ToList();
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAsync()
        //{
        //    var trips = await _context.Trips.AsNoTracking()
        //        .ToListAsync();

        //    return Ok(trips);
        //}

        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            return _context.Trips.Find(id);
        }

        [HttpPost]
        public IActionResult Post(Trip value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Trips.Add(value);
            _context.SaveChanges();

            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id,Trip value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Trips.Update(value);
            _context.SaveChanges();
            //_context.Trips;
            //_repository.Update(value);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var myTrip = _context.Trips.Find(id);

            if (myTrip == null)
                return NotFound();

            _context.Trips.Remove(myTrip);
            _context.SaveChanges();

            return Ok();
            //_repository.Remove(id);
        }
    }
}