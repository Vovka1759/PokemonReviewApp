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
    public class ReviewerRepository : IReviewerRepository
    {

        private readonly DataContext _context;
        public ReviewerRepository(DataContext context)
        {
            _context = context;
        }
        public Reviewer GetReviewer(int revrId)
        {
            return _context.Reviewers.FirstOrDefault(r => r.Id == revrId);
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.OrderBy(r => r.Id).ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int revrId)
        {
            var reviewer = _context.Reviewers.FirstOrDefault(r => r.Id == revrId);
            if (reviewer != null)
            {
                return reviewer.Reviews;
            }
            else
            {
                return null;
            }
        }
        public bool IsReviewerExists(int revrId)
        {
            var reviewer = _context.Reviewers.FirstOrDefault(r => r.Id == revrId);
            if (reviewer != null)
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
