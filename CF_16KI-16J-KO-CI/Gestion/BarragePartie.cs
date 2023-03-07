/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
namespace CF_16KI_16J_KO_CI.Gestion
{
    internal class BarragePartie
    {
        // Partie jouer à partir des barrages
        public string sPartie { get; set; }

        // Identifiant de joueur 1
        public int iJoueur1 { get; set; }

        // Identifiant de joueur 2
        public int iJoueur2 { get; set; }

        public int iArbitre { get; set; }

        public bool bJoueur1Gagne { get; set; }

        // Destination en cas de gain de la partie
        public int iDestinationGagnant  { get; set;  }

        // Destination en cas de perte de la partie
        public int iDestinationPerdant { get; set; }

        public BarragePartie(string _sPartie, int _iJoueur1, int _iJoueur2, int _iArbitre, int _iDestinationGagnant, int _iDestinationPerdant)
        {
            this.sPartie = _sPartie;
            this.iJoueur1 = _iJoueur1;
            this.iJoueur2 = _iJoueur2;
            this.iArbitre = _iArbitre;
            this.iDestinationGagnant = _iDestinationGagnant;
            this.iDestinationPerdant = _iDestinationPerdant;
        }
    }
}
