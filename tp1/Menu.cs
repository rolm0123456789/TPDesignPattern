class Menu
{
    public string Nom { get; set; }
    public Burger Burger { get; set; }
    public string Frites { get; set; } = "Frites moyennes";
    public string Boisson { get; set; } = "Soda";

    public void Afficher()
    {
        Console.WriteLine($"Menu: {Nom}");
        Burger.Afficher();
        Console.WriteLine($"Frites: {Frites}, Boisson: {Boisson}\n");
    }
}