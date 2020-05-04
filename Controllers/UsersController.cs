using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostgresAPI.Models;

namespace PostgresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private MyWebApiContext _context;
        public UsersController(MyWebApiContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allUsers = _context.Users.ToList();
                return Ok(allUsers);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get users");
            }
        }

        //GET: api/users/userid
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _context.Users
                    .Include(u => u.Group)
                    .Where(u => u.Id == id)
                    .FirstOrDefault();
                if (user != null) return Ok(user);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get user");
            }
        }

        //POST: api/users
        //model is come from body
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            try
            {
                _context.Add(model);
                if (_context.SaveChanges() > 0)
                {
                    //instead of return 200: Ok, we return 201: Created 
                    return Created($"/api/users/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Failed to save new user: {ex}");
            }

            return BadRequest("Failed to save new user");
        }
    }
}