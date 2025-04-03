abstract class MenuFactory
{
    public abstract Menu CreerMenu();
}

class MenuEnfantFactory : MenuFactory
{
    public override Menu CreerMenu()
    {
        var burger = new BurgerBuilder()
            .ChoisirPain(BurgerBuilder.PAIN_BLANC)
            .ChoisirViande(BurgerBuilder.VIANDE_POULET)
            .AjouterAccompagnement(BurgerBuilder.ACCOMPAGNEMENT_FROMAGE)
            .Construire();
        return new Menu { Nom = "Menu Enfant", Burger = burger, Frites = "Petites frites", Boisson = "Jus de fruit" };
    }
}

class MenuStandardFactory : MenuFactory
{
    public override Menu CreerMenu()
    {
        var burger = new BurgerBuilder()
            .ChoisirPain(BurgerBuilder.PAIN_COMPLET)
            .ChoisirViande(BurgerBuilder.VIANDE_BOEUF)
            .AjouterAccompagnement(BurgerBuilder.ACCOMPAGNEMENT_SALADE)
            .AjouterAccompagnement(BurgerBuilder.ACCOMPAGNEMENT_TOMATE)
            .Construire();
        return new Menu { Nom = "Menu Standard", Burger = burger };
    }
}

class MenuXLFactory : MenuFactory
{
    public override Menu CreerMenu()
    {
        var burger = new BurgerBuilder()
            .ChoisirPain(BurgerBuilder.PAIN_BLANC)
            .ChoisirViande(BurgerBuilder.VIANDE_BOEUF)
            .AjouterAccompagnement(BurgerBuilder.ACCOMPAGNEMENT_FROMAGE)
            .AjouterAccompagnement(BurgerBuilder.ACCOMPAGNEMENT_TOMATE)
            .AjouterAccompagnement(BurgerBuilder.ACCOMPAGNEMENT_SAUCE)
            .Construire();
        return new Menu { Nom = "Menu XL", Burger = burger, Frites = "Grandes frites", Boisson = "Grande boisson" };
    }
}