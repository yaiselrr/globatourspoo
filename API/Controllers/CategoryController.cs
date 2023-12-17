using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }        

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCategory(int Id, DtoCategory model)
        {
            if (await _repo.EditCategory(Id, model))
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategory()
        {
            var categories = await _repo.GetCategoriesAsync();

            return Ok(categories);
        }
    }
}