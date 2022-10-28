using AutoMapper;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _owneryRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository owneryRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _owneryRepository = owneryRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Owner>))]
        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDto>>(_owneryRepository.GetOwners());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owners);
        }

        [HttpGet("{owneId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int owneId)
        {
            if (!_owneryRepository.IsOwnerExists(owneId))
            {
                return NotFound();
            }
            var owner = _mapper.Map<OwnerDto>(_owneryRepository.GetOwner(owneId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owner);
        }

        [HttpGet("{owneId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(ICollection<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonsOfOwner(int owneId)
        {
            if (!_owneryRepository.IsOwnerExists(owneId))
            {
                return NotFound();
            }
            var pokemon = _mapper.Map<PokemonDto>(_owneryRepository.GetPokemonsOfOwner(owneId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOwner([FromQuery]int counId, [FromBody] OwnerDto owner_new)
        {
            if (owner_new == null)
            {
                return BadRequest(ModelState);
            }

            var owner = _owneryRepository.GetOwners()
                .Where(o => o.LastName.Trim().ToUpper() == owner_new.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (owner != null)
            {
                ModelState.AddModelError("", "This owner already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapped_owner_new = _mapper.Map<Owner>(owner_new);

            mapped_owner_new.Country = _countryRepository.GetCountry(counId);
            if (!_owneryRepository.CreateOwner(mapped_owner_new))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
