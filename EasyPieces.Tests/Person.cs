namespace EasyPieces.Tests
{
    internal class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public Person()
        {

        }

        public Person(string? firstName, string? middleName, string? lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
    }
}
