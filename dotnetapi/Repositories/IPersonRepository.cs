using System;
using System.Collections.Generic;
using dotnetapi.Models;

namespace dotnetapi.Repositories
{
    public interface IPersonRepository
    {
        void AddPerson(string name, string address, int number);
        Person GetPerson(Guid id);
        IEnumerable<Person> GetPersons();
    }
}