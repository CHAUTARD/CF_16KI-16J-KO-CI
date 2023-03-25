using CF_16KI_16J_KO_CI.Modeles;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CF_16KI_16J_KO_CI.CRUD
{
    internal class CrudJoueur
    {
        public static List<Joueur> GetAllJoueurs()
        {
            List<Joueur> lc = new List<Joueur>();

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                lc = db.Query<Joueur>("SELECT * FROM Joueur ORDER BY Dossard;").ToList();
                db.Close();
            }
            return lc;
        }

        // Suppression de tous les enregistrement sauf le premier
        public static void Clear()
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Execute("DELETE FROM Joueur WHERE IdJoueur > 0;");
                db.Close();
            }
        }

        // Insertion d'un enregistrement
        public static void InsertJoueur(Joueur joueur)
        {
            string sql = @"INSERT INTO Joueur( IdJoueur, Nom, DatNais, IdCategorie, Classement, IsPresent, Dossard, Club ) VALUES ( @IdJoueur, @Nom, @DatNais, @IdCategorie, @Classement, @IsPresent, @Dossard, @Club );";

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Execute(sql,
                    new { joueur.IdJoueur, joueur.Nom, joueur.DatNais, joueur.IdCategorie, joueur.Classement, joueur.IsPresent, joueur.Dossard, joueur.Club });
                db.Close();
            }
        }

        // Les autres champs ne sont jamais modifiés
        public static void InsertSingleJoueur(Joueur joueur)
        {
            string sql = @"UPDATE Joueur SET IsPresent = @IsPresent, Poule = @Poule, NumInPoule = @NumInPoule, PouleClassement = @PouleClassement, ClassementInPoule = @ClassementInPoule, IdPartieAbandon = @IdPartieAbandon WHERE IdJoueur = @IdJoueur";

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Execute(sql, joueur);
                db.Close();
            }
        }

        public static void SetPresent(long IdJoueur, bool bPresent)
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Execute("UPDATE Joueur SET IsPresent=@Present WHERE IdJoueur = @IdJoueur", 
                    new { Present = bPresent, IdJoueur } );
                db.Close();
            }
        }

        // Mise a jour de la table joueur avec la poule et le numéro dans la poule
        // a partir du numéro de dossard colonne 3
        public static void UpdatePouleNum(char cPoule, int iNum, int iDossard)
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Execute("UPDATE Joueur SET `Poule` = @Poule, NumInPoule = @NumInPoule WHERE Dossard = @Dossard",
                    new { Poule=cPoule, NumInPoule=iNum, Dossard= iDossard });
                db.Close();
            }
        }

        // Positionnement de l'abandon du joueur
        public static void UpdateAbandon(int IdPartieAbandon, long IdJoueur)
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Execute("UPDATE Joueur SET `IdPartieAbandon`=@IdPartieAbandon WHERE IdJoueur=@IdJoueur",
                    new { IdPartieAbandon, IdJoueur });
                db.Close();
            }
        }
    }
}
