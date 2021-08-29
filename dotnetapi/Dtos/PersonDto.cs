using System;

namespace dotnetapi.Dtos
{
    // Person Data Transfer Object. Not currently used for anything,
    // should ideally be used in the API endpoints so as to not expose
    // the person object to the outside, or to not break clients if the
    // person object is changed later.
    public record PersonDto
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
    }
}