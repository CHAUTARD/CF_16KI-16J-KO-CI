/*
 * User: CHAUTARD
 * Date: 02/03/2023
 */
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace CF_16KI_16J_KO_CI.Modeles
{
    public class Joueur
    {
        public long IdJoueur { get; set; } // Numéro de licence
        public long Licence { get; set; }

        public string Nom;

        public string DatNais { get; set; }

        public Categorie categorie { get; set; }

        public int Classement { get; set; }

        public bool IsPresent { get; set; } = false;

        public int Dossard { get; set; }
       
        public string Club { get; set; }

        public char Poule { get; set; } = 'A'; // A, B, C, D

        public int NumInPoule { get; set; } = 1; // 1, 2, 3, 4

        public int PouleClassement { get; set; } = 1; // 1, 2, 3, 4
        public int ClassementInPoule { get; set; } = 1; // 1, 2, 3, 4

        // Present, Dossard, Nom, Licence, Classement, Club
        public Joueur(long _IdJoueur, string _Nom, string _DatNais, string _Categorie, int _Classement, bool _IsPresent, int _Dossard, string _Club, Char _Poule, int _NumInPoule ) 
        {
            Licence = IdJoueur = _IdJoueur;
            Nom= _Nom;
            DatNais= _DatNais;
            categorie = SingletonOutils.FindCategorieByNom(_Categorie);
            Classement= _Classement;
            IsPresent= _IsPresent;
            Dossard= _Dossard;
            Club= _Club;
            Poule= _Poule;
            NumInPoule = _NumInPoule;
        }

        // Saisie des joueurs à partir de la table Joueurs
        // IdJoueur, Nom, DatNais, IdCategorie, Classement, IsPresent, Dossard, Club, Poule, Ord
        public Joueur(SQLiteDataReader reader)
        {
            Licence = IdJoueur = reader.GetInt32(0);
            Nom = reader.GetString(1);
            DatNais = reader.GetString(2);
            categorie = SingletonOutils.FindCategorieById(reader.GetInt16(3));
            Classement = reader.GetInt16(4);
            IsPresent = reader.GetBoolean(5);
            Dossard = reader.GetInt16(6);
            Club = reader.GetString(7);
            Poule = reader.GetString(8)[0];
            NumInPoule = reader.GetInt16(9);
        }

        /* Saisie des joueurs à partir du fichier Excel
         * Licence, Nom, DatNais, Club, Categorie, Categorie Sportive, Classement
         */
        public Joueur(DataRow dtRows, int iDossard) 
        {
            Licence = IdJoueur = Convert.ToInt64(dtRows[0]);
            Nom = dtRows[1].ToString();
            DatNais = dtRows[2].ToString();  
            categorie = SingletonOutils.FindCategorieByNomCourt(dtRows[4].ToString());
            Classement = Convert.ToInt32(dtRows[6]);
            Dossard = iDossard;
            Club = dtRows[3].ToString();
        }

        public string GetNom(bool bAbandon = false) { 
            if (! IsPresent) return Nom + "  (F)";
            if (bAbandon) return Nom + "  (A)";

            return Nom; 
        }
    }
}
