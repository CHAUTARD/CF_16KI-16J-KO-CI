/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
using CF_16KI_16J_KO_CI.Modeles;
using System;

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
            sPartie = _sPartie;
            iJoueur1 = _iJoueur1;
            iJoueur2 = _iJoueur2;
            iArbitre = _iArbitre;
            iDestinationGagnant = _iDestinationGagnant;
            iDestinationPerdant = _iDestinationPerdant;
        }

        public string[] GetAdd() 
        {
            int IndexPartie = SingletonOutils.GetIndexPartie(sPartie);

            return new string[] { this.sPartie, 
                SingletonOutils.GetNomExcel(IndexPartie, iJoueur1), 
                SingletonOutils.GetNomExcel(IndexPartie, iJoueur2) , 
                SingletonOutils.GetNomExcel(IndexPartie, iArbitre)
            };
        }
    }
}
