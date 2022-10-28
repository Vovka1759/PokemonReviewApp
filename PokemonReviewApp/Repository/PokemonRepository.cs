using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public Pokemon GetPokemon(int pokeId)
        {
            return _context.Pokemon.FirstOrDefault(p => p.Id == pokeId);
        }

        public Pokemon GetPokemon(string pokeName)
        {
            return _context.Pokemon.FirstOrDefault(p => p.Name == pokeName);
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var reviews = _context.Pokemon.FirstOrDefault(p => p.Id == pokeId).Reviews;
            if (reviews.Count() <= 0)
            {
                return 0;
            }
                
            return ((decimal)reviews.Sum(r => r.Rating)/ reviews.Count());
        }

        public bool IsPokemonExists(int pokeId)
        {
            var pokemon = _context.Pokemon.FirstOrDefault(p => p.Id == pokeId);
            if (pokemon != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
