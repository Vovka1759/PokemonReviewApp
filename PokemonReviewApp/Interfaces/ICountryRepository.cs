using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int counId);
        Country GetCountryByOwnerId(int owneId);
        ICollection<Owner> GetOwnersFromCountry(int counId);
        bool IsCountryExists(int counId);

        bool CreateCountry(Country country);
        bool Save();
    }
}
