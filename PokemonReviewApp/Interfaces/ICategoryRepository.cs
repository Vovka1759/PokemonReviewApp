using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int cateId);
        bool IsCategoryExists(int cateId);
        ICollection<Pokemon> GetPokemonsByCategory(int cateId);

        bool CreateCategory(Category category);
        bool Save();

    }
}
