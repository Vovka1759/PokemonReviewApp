using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviId);
        ICollection<Review> GetReviewsOfPokemon(int pokeId);
        bool IsReviewExists(int reviId);

    }
}
