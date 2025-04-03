class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenue dans le restaurant de burgers!");

        Console.WriteLine("Choisissez un menu :");
        Console.WriteLine("1. Menu Enfant");
        Console.WriteLine("2. Menu Standard");
        Console.WriteLine("3. Menu XL");
        Console.Write("Votre choix: ");
        string menuChoix = Console.ReadLine();

        MenuFactory menuFactory = menuChoix switch
        {
            "1" => new MenuEnfantFactory(),
            "2" => new MenuStandardFactory(),
            "3" => new MenuXLFactory(),
            _ => null
        };

        if (menuFactory != null)
        {
            Menu menu = menuFactory.CreerMenu();
            Console.WriteLine("Menu choisi:");
            menu.Afficher();

            // Personnaliser le menu
            Console.WriteLine("Voulez-vous personnaliser ce menu? (O/N)");
            string personnalisation = Console.ReadLine().ToUpper();
            if (personnalisation == "O")
            {
                BurgerBuilder builder = new BurgerBuilder();

                // Utilisation des constantes dans l'affichage
                string pain;
                do
                {
                    Console.Write($"Choisissez votre pain ({string.Join("/ ", BurgerBuilder.PainsValides)}): ");
                    pain = Console.ReadLine();
                    pain = BurgerBuilder.AutoComplete(pain, BurgerBuilder.PainsValides);
                } while (!BurgerBuilder.PainsValides.Contains(pain));

                builder.ChoisirPain(pain);

                string viande;
                do
                {
                    Console.Write($"Choisissez votre viande ({string.Join("/ ", BurgerBuilder.ViandesValides)}): ");
                    viande = Console.ReadLine();
                    viande = BurgerBuilder.AutoComplete(viande, BurgerBuilder.ViandesValides);
                } while (!BurgerBuilder.ViandesValides.Contains(viande));

                builder.ChoisirViande(viande);

                while (true)
                {
                    Console.Write(
                        $"Ajoutez un accompagnement ({string.Join("/ ", BurgerBuilder.AccompagnementsValides)}) ou tapez 'fin' pour terminer: ");
                    string accompagnement = Console.ReadLine();
                    if (accompagnement.ToLower() == "fin") break;
                    accompagnement = BurgerBuilder.AutoComplete(accompagnement, BurgerBuilder.AccompagnementsValides);
                    if (BurgerBuilder.AccompagnementsValides.Contains(accompagnement))
                    {
                        builder.AjouterAccompagnement(accompagnement);
                    }
                    else
                    {
                        Console.WriteLine("Accompagnement invalide! Réessayez.");
                    }
                }

                menu.Burger = builder.Construire();
                menu.Afficher();
            }
        }
        else
        {
            Console.WriteLine("Choix invalide.");
        }
    }
}