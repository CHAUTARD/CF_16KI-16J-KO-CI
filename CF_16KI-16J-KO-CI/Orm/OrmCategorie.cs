using CF_16KI_16J_KO_CI.Modeles;

namespace CF_16KI_16J_KO_CI.Orm
{
    internal class OrmCategorie
    {
        public static Categorie FindByNom(string sCategorie)
        {
            Categorie match = SingletonOutils.lCategories.Find(x => x.Nom == sCategorie);

            return match;
        }

        public static long FindIdByNom(string sCategorie)
        {
            Categorie match = SingletonOutils.lCategories.Find(x => x.Nom == sCategorie);

            return match.IdCategorie;
        }

        public static Categorie FindById(int IdCategorie)
        {
            Categorie match = SingletonOutils.lCategories.Find(x => x.IdCategorie == IdCategorie);

            return match;
        }

        public static Categorie FindByNomCourt(string sNomCourt)
        {
            Categorie match = SingletonOutils.lCategories.Find(x => x.NomCourt == sNomCourt);

            return match;
        }
    }
}
