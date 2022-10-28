using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonReviewApp.Dto
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } //Owner.cs
        public string LastName { get; set; } //Owner.cs
        public string Gym { get; set; }
    }
}
