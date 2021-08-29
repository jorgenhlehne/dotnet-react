using System;
using System.Collections.Generic;
using dotnetapi.Models;

namespace dotnetapi.Repositories
{
    public interface IPersonRepository
    {
        void AddPerson(Person person);
        Person GetPerson(Guid id);
        IEnumerable<Person> GetPersons();
    }
}