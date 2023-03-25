using CF_16KI_16J_KO_CI.Modeles;
using System.IO;

namespace CF_16KI_16J_KO_CI.Orm
{
    internal class OrmJoueur
    {
        public static Joueur FindById(long IdJoueur)
        {
            Joueur match = SingletonOutils.lJoueurs.Find(x => x.IdJoueur == IdJoueur);

            return match;
        }

        public static Joueur FindByNom(string strNom)
        {
            if (strNom.Contains("  ("))
                strNom = strNom.Substring(0, strNom.Length - 5);

            Joueur match = SingletonOutils.lJoueurs.Find(x => x.Nom == strNom);
            return match;
        }
    }
}
