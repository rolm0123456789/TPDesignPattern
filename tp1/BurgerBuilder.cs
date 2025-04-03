class BurgerBuilder
{
    private Burger _burger = new Burger();
    public static readonly string PAIN_BLANC = "Blanc";
    public static readonly string PAIN_COMPLET = "Complet";
    public static readonly string PAIN_SESAME = "Sésame";
    public static readonly string PAIN_BRIOCHE = "Brioche";
    
    public static readonly string VIANDE_BOEUF = "Boeuf";
    public static readonly string VIANDE_POULET = "Poulet";
    public static readonly string VIANDE_VEGETARIEN = "Végétarien";
    public static readonly string VIANDE_POISSON = "Poisson";
    
    public static readonly string ACCOMPAGNEMENT_FROMAGE = "Fromage";
    public static readonly string ACCOMPAGNEMENT_TOMATE = "Tomate";
    public static readonly string ACCOMPAGNEMENT_SALADE = "Salade";
    public static readonly string ACCOMPAGNEMENT_SAUCE = "Sauce";
    public static readonly string ACCOMPAGNEMENT_OIGNONS = "Oignons";
    public static readonly string ACCOMPAGNEMENT_CORNICHONS = "Cornichons";
    
    public static readonly HashSet<string> PainsValides = new HashSet<string> { PAIN_BLANC, PAIN_COMPLET, PAIN_SESAME, PAIN_BRIOCHE };
    public static readonly HashSet<string> ViandesValides = new HashSet<string> { VIANDE_BOEUF, VIANDE_POULET, VIANDE_VEGETARIEN, VIANDE_POISSON };
    public static readonly HashSet<string> AccompagnementsValides = new HashSet<string> { ACCOMPAGNEMENT_FROMAGE, ACCOMPAGNEMENT_TOMATE, ACCOMPAGNEMENT_SALADE, ACCOMPAGNEMENT_SAUCE, ACCOMPAGNEMENT_OIGNONS, ACCOMPAGNEMENT_CORNICHONS };

    public static string AutoComplete(string input, HashSet<string> validChoices)
    {
        return validChoices.FirstOrDefault(choice => choice.StartsWith(input, StringComparison.OrdinalIgnoreCase)) ?? input;
    }

    public BurgerBuilder ChoisirPain(string pain)
    {
        pain = AutoComplete(pain, PainsValides);
        if (!PainsValides.Contains(pain))
        {
            Console.WriteLine("Pain invalide! Choisissez parmi: " + string.Join(", ", PainsValides));
            return this;
        }
        _burger.Pain = pain;
        return this;
    }

    public BurgerBuilder ChoisirViande(string viande)
    {
        viande = AutoComplete(viande, ViandesValides);
        if (!ViandesValides.Contains(viande))
        {
            Console.WriteLine("Viande invalide! Choisissez parmi: " + string.Join(", ", ViandesValides));
            return this;
        }
        _burger.Viande = viande;
        return this;
    }

    public BurgerBuilder AjouterAccompagnement(string accompagnement)
    {
        accompagnement = AutoComplete(accompagnement, AccompagnementsValides);
        if (!AccompagnementsValides.Contains(accompagnement))
        {
            Console.WriteLine("Accompagnement invalide! Choisissez parmi: " + string.Join(", ", AccompagnementsValides));
            return this;
        }
        _burger.Accompagnements.Add(accompagnement);
        return this;
    }

    public Burger Construire()
    {
        return _burger;
    }
}
