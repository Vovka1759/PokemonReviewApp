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
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(c => c.Id).ToList();
        }

        public Country GetCountry(int counId)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == counId);
        }

        public Country GetCountryByOwnerId(int owneId)
        {
            var owner = _context.Owners.FirstOrDefault(o => o.Id == owneId);
            if (owner != null)
            {
                return owner.Country;
            }
            else
            {
                return null;
            }
        }

        public ICollection<Owner> GetOwnersFromCountry(int counId)
        {
            return _context.Owners.Where(o => o.Country == GetCountry(counId)).ToList();
        }

        public bool IsCountryExists(int counId)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == counId);
            if (country != null)
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


