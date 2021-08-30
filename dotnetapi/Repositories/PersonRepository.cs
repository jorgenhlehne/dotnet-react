using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapi.Models;

// In-memory repository which stores data. No longer in use, as
// an SQLite db has been implemented.

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

        public void AddPerson(Person person)
        {
            persons.Add(person);
        }
    }
}