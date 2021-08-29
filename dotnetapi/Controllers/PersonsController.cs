using System;
using System.Collections.Generic;
using dotnetapi.Models;
using dotnetapi.Repositories;
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
        public IEnumerable<Person> GetPersons()
        {
            return repository.GetPersons();
        }

        [HttpGet("{id}")]
        public Person GetPerson(Guid id)
        {
            return repository.GetPerson(id);
        }
    }
}