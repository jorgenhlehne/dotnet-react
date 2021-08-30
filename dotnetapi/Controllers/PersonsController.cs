using System;
using System.Collections.Generic;
using dotnetapi.Models;
using dotnetapi.Repositories;
using dotnetapi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapi.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        private IPersonRepository repository;

        public PersonsController(IPersonRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<PersonDto> GetPersons()
        {
            return dotnetapi.Daos.PersonDaos.GetPersons();
        }

        // Commented out, not currently needed.
        /* [HttpGet("{id}")]
        public Person GetPerson(Guid id)
        {
            return repository.GetPerson(id);
        } */

        [HttpPost]
        public ActionResult<PersonDto> AddPerson(CreatePersonDto createPersonDto)
        {
            Person newPerson = new()
            {
                Id = Guid.NewGuid(),
                Name = createPersonDto.Name,
                Address = createPersonDto.Address,
                Number = createPersonDto.Number
            };

            // Code duplication. Ok this once, but if project grows bigger
            // then dedicated methods for converting between objects and DTOs
            // should be implemented.
            PersonDto newPersonDto = new()
            {
                Id = Guid.NewGuid(),
                Name = createPersonDto.Name,
                Address = createPersonDto.Address,
                Number = createPersonDto.Number
            };

            //repository.AddPerson(newPerson);

            dotnetapi.Daos.PersonDaos.AddPerson(newPerson);

            return newPersonDto;
        }
    }
}