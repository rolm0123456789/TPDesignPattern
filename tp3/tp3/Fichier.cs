namespace tp3;
  
    public interface IFichier
    {
        void Enregistrer(string chemin);
    }

    public class FichierTexte : IFichier
    {
        private string _contenu;

        public FichierTexte(string contenu)
        {
            _contenu = contenu;
        }

        public virtual void Enregistrer(string chemin)
        {
            File.WriteAllText(chemin, _contenu);
            Console.WriteLine("Fichier enregistré : " + chemin);
        }
    }

 
    
