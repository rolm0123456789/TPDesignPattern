using System.IO.Compression;
using System.Text;

namespace tp3;

public abstract class FichierDecorator : IFichier
{
    protected IFichier _fichier;

    public FichierDecorator(IFichier fichier)
    {
        _fichier = fichier;
    }

    public virtual void Enregistrer(string chemin)
    {
        _fichier.Enregistrer(chemin);
    }
}

public class CompressionDecorator : FichierDecorator
{
    public CompressionDecorator(IFichier fichier) : base(fichier) { }

    public override void Enregistrer(string chemin)
    {
        string compressedPath = chemin + ".gz";
        using (FileStream fs = new FileStream(compressedPath, FileMode.Create))
        using (GZipStream gz = new GZipStream(fs, CompressionMode.Compress))
        using (StreamWriter writer = new StreamWriter(gz))
        {
            writer.Write(File.ReadAllText(chemin));
        }
        Console.WriteLine("Fichier compressé : " + compressedPath);
        base.Enregistrer(chemin);
    }
}

public class ChiffrementDecorator : FichierDecorator
{
    public ChiffrementDecorator(IFichier fichier) : base(fichier) { }

    public override void Enregistrer(string chemin)
    {
        string contenu = File.ReadAllText(chemin);
        string encryptedContent = Convert.ToBase64String(Encoding.UTF8.GetBytes(contenu));
        File.WriteAllText(chemin + ".enc", encryptedContent);
        Console.WriteLine("Fichier chiffré : " + chemin + ".enc");
        base.Enregistrer(chemin);
    }
}
