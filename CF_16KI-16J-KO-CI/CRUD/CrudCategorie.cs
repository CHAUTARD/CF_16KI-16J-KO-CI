using CF_16KI_16J_KO_CI.Modeles;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CF_16KI_16J_KO_CI.CRUD
{
    internal class CrudCategorie
    {
        public static List<Categorie> GetAllCategories()
        {
            List < Categorie > lc = new List< Categorie >();

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                lc = db.Query<Categorie>("SELECT * FROM Categorie ORDER BY Ord;").ToList();
                db.Close();
            }
            return lc;
        }

        public static Categorie GetCategorie(long id)
        {
            Categorie categorie = new Categorie();

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                categorie = db.QuerySingle<Categorie>("SELECT * FROM Categorie WHERe IdCategorie=@Id",
                    new { Id=id });
                db.Close();

                return categorie;
            }
        }

        /*
        private static void InsertSingleCategorie(Categorie categorie)
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Insert<Categorie>(categorie);
                db.Close();
            }
        }

        private static void UpdateSingleCategorie(Categorie categorie)
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Update<Categorie>(categorie);
                db.Close();
            }
        }

        private static void DeleteSingleCategorie(long Id)
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Delete<Categorie>(new Categorie { IdCategorie = Id });
                db.Close();
            }
        }
        */
    }
}
