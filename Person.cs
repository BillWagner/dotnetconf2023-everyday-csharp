// This sample is meant to show you the members that the compiler
// synthesizes for records.
// Paste this declaration into https://sharplab.io

// Then, add the "record" modifier for the class:
// public record class Person

// Do the same with a struct:
// public struct Person

// And change to:
// public record struct Person

// Look at the generated C# code for each case.
public class Person
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int Age { get; set; }
    public DateOnly Birthday { get; set; }
}
