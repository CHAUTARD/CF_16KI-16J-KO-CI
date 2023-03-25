/*
 * User: CHAUTARD
 * Date: 02/03/2023
 */
using CF_16KI_16J_KO_CI.CRUD;
using CF_16KI_16J_KO_CI.Orm;
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

        public string Nom;

        public string DatNais { get; set; }

        public long IdCategorie { get; set; }

        public Categorie categorie { get; set; }

        public int Classement { get; set; }

        public bool IsPresent { get; set; } = false;

        public int Dossard { get; set; }
       
        public string Club { get; set; }

        public char Poule { get; set; } = 'A'; // A, B, C, D

        public int NumInPoule { get; set; } = 1; // 1, 2, 3, 4

        public int PouleClassement { get; set; } = 1; // 1, 2, 3, 4

        public int ClassementInPoule { get; set; } = 1; // 1, 2, 3, 4

        public long IdPartieAbandon { get; set; } = 99;

        public Joueur() { }

        // (System.Int64 IdJoueur, System.String Nom, System.String DatNais, System.Int64 IdCategorie, System.Int64 Classement,
        // System.Boolean IsPresent, System.Int64 Dossard, System.String Club, System.String Poule, System.Int64 NumInPoule,
        // System.Int64 PouleClassement, System.Int64 ClassementInPoule, System.Int64 IdPartieAbandon) 
        public Joueur( long _IdJoueur, string _Nom, string _DatNais, int _IdCategorie, int _Classement, 
            bool _IsPresent, int _Dossard, string _Club, char _Poule = 'A', int _NumInPoule = 1, 
            int _PouleClassement = 1, int _ClassementInPoule = 1, int _IdPartieAbandon = 99) 
        {
            IdJoueur = _IdJoueur;
            Nom= _Nom;
            DatNais= _DatNais;
            IdCategorie = _IdCategorie;
            categorie = OrmCategorie.FindById(_IdCategorie);
            Classement= _Classement;
            IsPresent= _IsPresent;
            Dossard= _Dossard;
            Club= _Club;
            Poule= _Poule;
            NumInPoule = _NumInPoule;
            PouleClassement = _PouleClassement;
            ClassementInPoule = _ClassementInPoule;
            IdPartieAbandon = _IdPartieAbandon;
        }

        // Saisie des joueurs à partir de la table Joueurs
        // IdJoueur, Nom, DatNais, IdCategorie, Classement, IsPresent, Dossard, Club, Poule, Ord
        public Joueur(SQLiteDataReader reader)
        {
            IdJoueur = reader.GetInt32(0);
            Nom = reader.GetString(1);
            DatNais = reader.GetString(2);
            categorie = OrmCategorie.FindById(reader.GetInt16(3));
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
            IdJoueur = Convert.ToInt64(dtRows[0]);
            Nom = dtRows[1].ToString();
            DatNais = dtRows[2].ToString();  
            categorie = OrmCategorie.FindByNomCourt(dtRows[4].ToString());
            IdCategorie = categorie.IdCategorie;
            Classement = Convert.ToInt32(dtRows[6]);
            Dossard = iDossard;
            Club = dtRows[3].ToString();
        }

        /* Nom du joueur avec un suffixe
         * (F) => Forfait
         * (A) => Abandon
         */
        public string GetNom(int iPartie, bool bAbandon = false) { 
            if (! IsPresent) return Nom + "  (F)";
            if (bAbandon) return Nom + "  (A)";
            if (IdPartieAbandon != 99 && ( IdPartieAbandon <= iPartie)) return Nom + "  (A)";

            return Nom; 
        }

        public string GetNom(string sPartie, bool bAbandon = false) { return GetNom(Array.IndexOf(SingletonOutils.aParties, sPartie), bAbandon); }
    }
}
