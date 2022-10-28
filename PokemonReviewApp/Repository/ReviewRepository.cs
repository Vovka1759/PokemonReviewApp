using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public Review GetReview(int reviId)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == reviId);
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.OrderBy(r => r.Id).ToList();
        }

        public ICollection<Review> GetReviewsOfPokemon(int pokeId)
        {
            return _context.Pokemon.FirstOrDefault(p => p.Id == pokeId).Reviews.ToList();
        }

        public bool IsReviewExists(int reviId)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.Id == reviId);
            if (review != null)
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
