using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF_16KI_16J_KO_CI.Modeles
{
    public class Joueur
    {
        public int Dossard { get; set; }
        public string Nom { get; set; }
        public int Licence { get; set; }
        public int Classement { get; set; }
        public string Club { get; set; }
        public int Ordre { get; set; }
        public char Poule { get; set; } // 1, 2, 3, 4
        public int NumInPoule { get; set; } // 1, 2, 3, 4
        public string Tableau { get; set; }    // 

        // Present, Dossard, Nom, Licence, Classement, Club
        public Joueur(int iDossard, string sNom, int iLicence, int iClassement, string sClub)
        {
            Dossard = iDossard;
            Nom = sNom;
            Licence = iLicence;
            Classement = iClassement;
            Club = sClub;

            Poule = '1';
            NumInPoule = 1;
            Tableau = "";
        }
    }
}
