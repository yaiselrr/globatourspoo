using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;
using Infrastucture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PlaceController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public async Task<ActionResult<List<Place>>> GetPlaces()
        {
            var places = await _db.Place.ToListAsync();

            return Ok(places);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlace(int id)
        {
            return await _db.Place.FirstOrDefaultAsync(p => p.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddPlace(DtoPlace model)
        {
            var place = await _db.Place.FirstOrDefaultAsync(p => p.Name == model.Name);

            if (place != null)
            {
                return BadRequest(false);
            }
            else
            {

                await _db.AddAsync(new Place(model.Name));
                await _db.SaveChangesAsync();

                return Ok(true);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdatePlace(int id, DtoPlace model)
        {
            var place = await _db.Place.FirstOrDefaultAsync(p => p.Id == id);

            if (place == null)
            {
                return BadRequest(false);
            }
            else
            {
                place.Name = model.Name;
                place.UpdatedAt = DateTime.Now;

                _db.Update(place);
                await _db.SaveChangesAsync();

                return Ok(true);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeletePlace(int id)
        {
            var place = await _db.Place.FirstOrDefaultAsync(p => p.Id == id);

            if (place == null)
            {
                return BadRequest(false);
            }
            else
            {
                _db.Remove(place);
                await _db.SaveChangesAsync();

                return Ok(true);
            }
        }
    }
}