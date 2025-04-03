namespace tp3;

class Program
{
    static void Main()
    {
        string chemin = "/home/romain/esgiM1/desginPattern/tp3/tp3/test/test.txt";
        string contenu = "Ceci est un fichier de test";

        // Création d'un fichier texte simple
        IFichier fichier = new FichierTexte(contenu);

        // Sauvegarde via la façade avec différentes options
        Console.WriteLine("Sauvegarde simple :");
        SauvegardeManager.SauvegarderFichier(fichier, chemin);
            
        Console.WriteLine("Sauvegarde avec compression :");
        SauvegardeManager.SauvegarderEtCompresser(fichier, chemin);
            
        Console.WriteLine("Sauvegarde avec chiffrement :");
        SauvegardeManager.SauvegarderEtChiffrer(fichier, chemin);
            
        Console.WriteLine("Sauvegarde avec compression et chiffrement :");
        SauvegardeManager.SauvegarderCompresserEtChiffrer(fichier, chemin);
    }
}
