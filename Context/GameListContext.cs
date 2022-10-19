using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAPIGameList.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjectAPIGameList.Context
{
    public class GameListContext : DbContext
    {
        public GameListContext(DbContextOptions<GameListContext> options) : base(options)
        {

        }

        public DbSet<Game> Games {get; set;}
    }
}