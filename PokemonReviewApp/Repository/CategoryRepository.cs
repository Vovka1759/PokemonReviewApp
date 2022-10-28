using Microsoft.OpenApi.Validations;
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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Id).ToList();
        }

        public Category GetCategory(int cateId)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == cateId);
        }

        public ICollection<Pokemon> GetPokemonsByCategory(int cateId)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == cateId).Select(e => e.Pokemon).ToList();
        }

        public bool IsCategoryExists(int cateId)
        {
            var category = _context.Pokemon.FirstOrDefault(c => c.Id == cateId);
            if (category != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
