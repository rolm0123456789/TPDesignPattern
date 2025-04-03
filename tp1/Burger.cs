class Burger
{
    public string Pain { get; set; }
    public string Viande { get; set; }
    public List<string> Accompagnements { get; set; } = new List<string>();

    public void Afficher()
    {
        Console.WriteLine($"Burger avec pain: {Pain}, viande: {Viande}, accompagnements: {string.Join(", ", Accompagnements)}");
    }
}