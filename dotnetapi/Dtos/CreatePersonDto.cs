namespace dotnetapi.Dtos
{
    // This record is used when POSTing new persons from the frontend,
    // so that the request doesn't have to deal with the ID
    // (or if the person definition changes at a later date)
    public record CreatePersonDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
    }
}