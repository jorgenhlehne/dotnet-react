using System;

namespace dotnetapi.Models 
{
    public record Person
    {
        public Guid Id { get; init; }

        public string Name { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }

    }
}