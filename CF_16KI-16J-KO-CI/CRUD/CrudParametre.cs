using CF_16KI_16J_KO_CI.Modeles;
using Dapper;
using System.Data;

namespace CF_16KI_16J_KO_CI.CRUD
{
    internal class CrudParametre
    {
        public static void Save(int IdParametre, string sParam)
        {
            string sql = @"UPDATE Parametre SET init=@sParam WHERE IdParametre = @IdParametre";

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Query(sql, new { IdParametre, sParam });
                db.Close();
            }
        }

        public static string Read(int IdParametre)
        {
            string sql = @"SELECT * FROM Parametre WHERE IdParametre=@IdParametre";
            Parametre parametre = new Parametre();

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                parametre = db.QuerySingle<Parametre>(sql, new { IdParametre });
                db.Close();
            }
            return parametre.Init;
        }
    }
}
