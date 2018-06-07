using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RateMyPokemon.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Picture { get; set; }
    }

    public class PokemonDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemans { get; set; }
    }
}