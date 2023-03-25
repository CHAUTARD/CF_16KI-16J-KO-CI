using CF_16KI_16J_KO_CI.Modeles;
using CF_16KI_16J_KO_CI.Orm;
using Dapper;
using System.Data;

namespace CF_16KI_16J_KO_CI.CRUD
{
    internal class CrudPartie
    {
        // Mise à jour des nom des joueurs
        public static void UpdateJoueur(string sPartie, long IdJoueur1, long IdJoueur2, long IdArbitre)
        {
            string sql = @"UPDATE Partie SET IdJoueur1=@IdJoueur1, IdJoueur2=@IdJoueur2, IdArbitre=@IdArbitre WHERE sPartie=@sPartie;";

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Execute(sql, new { IdJoueur1, IdJoueur2, IdArbitre, sPartie });
                db.Close();
            }
        }

        // Recherche des scores enregistrées pour une partie
        public static Partie GetPartie(string sPartie)
        {
            Partie partie = null;

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                partie = db.QuerySingle<Partie>("SELECT * FROM Partie WHERE sPartie=@sPartie", new { sPartie });
                db.Close();
            }

            return partie;
        }

        // Recherche de l'identifiant partie à  partir de son nom
        public static long GetIdPartieByNom(string sPartie)
        {
            Partie partie = null;

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                partie = db.QuerySingle<Partie>("SELECT * FROM Partie WHERE sPartie=@sPartie", new { sPartie });
                db.Close();
            }

            return partie.IdPartie;
        }

        // Sauvegarde des scores
        public static void SaveScore(string sPartie, string Score1, string Score2, string Score3, string Score4, string Score5)
        {
            string sql = @"UPDATE Partie SET Score1=@Score1, Score2=@Score2, Score3=@Score3, Score4=@Score4, Score5=@Score5 WHERE sPartie = @sPartie";

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Query(sql, new { sPartie, Score1 , Score2, Score3, Score4, Score5 });
                db.Close();
            }
        }

        // Sauvegarde des abandons
        public static void SaveAbandon1(string sPartie, bool bAbandon)
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Query("UPDATE Partie SET Abandon1=@bAbandon WHERE sPartie = @sPartie", 
                    new { sPartie, bAbandon });
                db.Close();
            }
        }

        public static void SaveAbandon2(string sPartie, bool bAbandon)
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Query("UPDATE Partie SET Abandon2=@bAbandon WHERE sPartie = @sPartie",
                    new { sPartie, bAbandon });
                db.Close();
            }
        }

        private static void PropageAbandon1(long IdJoueur, long IdPartie)
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Query("UPDATE Partie SET Abandon1=true, Score1=@Score1, Score2=@Score2, Score3=@Score3 WHERE IdJoueur1=@IdJoueur AND IdPartie > @IdPartie",
                    new { IdJoueur, IdPartie, Score1="-00", Score2="-00", Score3="-00" });
                db.Close();
            }
        }

        private static void PropageAbandon2(long IdJoueur, long IdPartie)
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Query("UPDATE Partie SET Abandon2=true, Score1=@Score1, Score2=@Score2, Score3=@Score3 WHERE IdJoueur2=@IdJoueur AND IdPartie > @IdPartie",
                    new { IdJoueur, IdPartie, Score1 = "00", Score2 = "00", Score3 = "00" });
                db.Close();
            }
        }

        public static void PropageAbandon( int INbrPartieEnCours, long IdJoueur1, long IdJoueur2)
        {
            // Recherche de l'objet Joueur1
            Joueur J1 = OrmJoueur.FindById(IdJoueur1);

            // Recherche si le joueur1 à déjà abandonné
            if(J1.IdPartieAbandon != 99 && J1.IdPartieAbandon <= INbrPartieEnCours)
            {
                // Si Oui cocher l'abandon dans la table
                PropageAbandon1(J1.IdJoueur, J1.IdPartieAbandon);
                PropageAbandon2(J1.IdJoueur, J1.IdPartieAbandon);
            }

            // Recherche de l'objet Joueur1
            J1 = OrmJoueur.FindById(IdJoueur2);

            // Recherche si le joueur1 à déjà abandonné
            if (J1.IdPartieAbandon != 99 && J1.IdPartieAbandon <= INbrPartieEnCours)
            {
                // Si Oui cocher l'abandon dans la table
                PropageAbandon1(J1.IdJoueur, J1.IdPartieAbandon);
                PropageAbandon2(J1.IdJoueur, J1.IdPartieAbandon);
            }
        }
    }
}
