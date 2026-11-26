using System.Text.RegularExpressions;
namespace csharp_practice28;

class Person
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public Person() {}
    
    public Person(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Phone: {Phone}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string input = "Привіт! Alex : 066-555-555-4 сьогодні зустрівся з командою. " +
                       "Також Maria : 067-123-456-7 залишила повідомлення, " +
                       "а John : 050-987-654-3 чекає на дзвінок. " +
                       "Учасники заходу: Олег : 063-111-222-3, " +
                       "Anna : 099-444-555-6. Організатор Peter : 068-777-888-9 " +
                       "повідомить деталі пізніше.";

        string phonePattern = @"\d{3}-\d{3}-\d{3}-\d";
        Regex phoneRegex = new Regex(phonePattern);
        Console.WriteLine("Phones: ");
        Match m = phoneRegex.Match(input);
        while (m.Success)
        {
            Console.WriteLine(m.Value);
            m = m.NextMatch();
        }

        string personPattern = @"(\p{L}+)\s*:\s*(\d{3}-\d{3}-\d{3}-\d)";
        Regex personRegex = new Regex(personPattern);
        List<Person> persons = new List<Person>();
        Match match = personRegex.Match(input);
        while (match.Success)
        {
            string name = match.Groups[1].Value;
            string phone = match.Groups[2].Value;
            persons.Add(new Person(name, phone));
            match = match.NextMatch();
        }
        Console.WriteLine("\nPersons: ");
        foreach (Person person in persons)
            Console.WriteLine(person);
    }
}