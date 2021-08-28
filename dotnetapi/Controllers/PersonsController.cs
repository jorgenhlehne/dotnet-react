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
        private PersonRepository repository;

        public PersonsController()
        {
            repository = new();
        }

        [HttpGet]
        public IEnumerable<Person> GetPersons()
        {
            return repository.GetPersons();
        }
    }
}