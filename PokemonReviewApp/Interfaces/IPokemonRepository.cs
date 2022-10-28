using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonReviewApp.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int pokeId);
        Pokemon GetPokemon(string pokeName);
        decimal GetPokemonRating(int pokeId);
        bool IsPokemonExists(int pokeId);

        bool CreatePokemon(Pokemon pokemon);
        bool Save();
    }
}
