﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dockertraining_compose_juan_calderon_lx.Models;

namespace dockertraining_compose_juan_calderon_lx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController :  ControllerBase
    {
        private readonly FoodContext db;

        public FoodController(FoodContext context)
        {
            db = context;
        }


        // Get department with given id.
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFood(int id)
        {
            var food = await db.Foods.FindAsync(id);
            if (food == default(Food))
            {
                return NotFound();
            }
            return Ok(food);
        }

        // Add a department to db.
        [HttpPost]
        public async Task<IActionResult> AddFood([FromBody] Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.AddAsync(food);
            await db.SaveChangesAsync();
            return Ok(food.Id);
        }
    }
}