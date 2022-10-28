using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;
        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public Owner GetOwner(int owneId)
        {
            return _context.Owners.FirstOrDefault(o => o.Id == owneId);
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(o => o.Id).ToList();
        }

        public ICollection<Owner> GetOwnersOfPokemon(int pokeId)
        {
            return _context.PokemonOwners.Where(po => po.Pokemon.Id == pokeId).Select(po => po.Owner).ToList();
        }

        public ICollection<Pokemon> GetPokemonsOfOwner(int owneId)
        {
            return _context.PokemonOwners.Where(po => po.Owner.Id == owneId).Select(o => o.Pokemon).ToList();
        }

        public bool IsOwnerExists(int owneId)
        {
            var owner = _context.Owners.FirstOrDefault(o => o.Id == owneId);
            if (owner != null)
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
