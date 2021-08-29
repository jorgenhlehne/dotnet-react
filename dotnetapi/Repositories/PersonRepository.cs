using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapi.Models;

namespace dotnetapi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> persons = new()
        {
            new Person { Id = Guid.NewGuid(), Name = "Alice", Address = "Drammensveien 2", Number = 55577555 }
        };

        public IEnumerable<Person> GetPersons()
        {
            return persons;
        }

        public Person GetPerson(Guid id)
        {
            return persons.Where(person => person.Id == id).SingleOrDefault();
        }

        public void AddPerson(string name, string address, int number)
        {
            Person newPerson = new Person
            {
                Id = Guid.NewGuid(),
                Name = name,
                Address = address,
                Number = number
            };

            persons.Add(newPerson);
        }
    }
}