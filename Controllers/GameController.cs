using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAPIGameList.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ProjectAPIGameList.Context;

namespace ProjectAPIGameList.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GameController : ControllerBase
    {
        private readonly GameListContext _context;

        public GameController(GameListContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var game = _context.Games.Find(id);
            if(game == null)
            {
                return NotFound();
            }
            
            return Ok(game);
        }

        
        [HttpPost]
        public IActionResult Create(Game game)
        {
            _context.Add(game);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, Game game)
        {
            var gameDb = _context.Games.Find(id);

            if(gameDb == null)
            {
                return NotFound();
            }
            gameDb.Title = game.Title;
            gameDb.Description = game.Description;
            gameDb.Status = game.Status;

            _context.Games.Update(gameDb);
            _context.SaveChanges();
            
            return Ok(gameDb);

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var gameDb = _context.Games.Find(id);

            if(gameDb == null)
            {
                return NotFound();
            }

            _context.Games.Remove(gameDb);
            _context.SaveChanges();
            return NoContent();
        }
    }
}