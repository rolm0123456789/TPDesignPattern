namespace tp3;

public class SauvegardeManager
{
    public static void SauvegarderFichier(IFichier fichier, string chemin)
    {
        fichier.Enregistrer(chemin);
    }

    public static void SauvegarderEtCompresser(IFichier fichier, string chemin)
    {
        fichier = new CompressionDecorator(fichier);
        fichier.Enregistrer(chemin);
    }

    public static void SauvegarderEtChiffrer(IFichier fichier, string chemin)
    {
        fichier = new ChiffrementDecorator(fichier);
        fichier.Enregistrer(chemin);
    }

    public static void SauvegarderCompresserEtChiffrer(IFichier fichier, string chemin)
    {
        fichier = new CompressionDecorator(fichier);
        fichier = new ChiffrementDecorator(fichier);
        fichier.Enregistrer(chemin);
    }
}
