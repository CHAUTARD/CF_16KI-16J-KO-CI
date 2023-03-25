using CF_16KI_16J_KO_CI.Modeles;

namespace CF_16KI_16J_KO_CI.CRUD
{
    internal class CrudEpreuve
    {
        // Une seule épreuve pour l'instant
        public static Epreuve GetEpreuve()
        {
            Epreuve epreuve = new Epreuve
            {
                IdEpreuve = 8984,
                Libelle = "Critérium Fédéral",
                libelleCourt = "Crit"
            };

            return epreuve;
        }
    }
}
