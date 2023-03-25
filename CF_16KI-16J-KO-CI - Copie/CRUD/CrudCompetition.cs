using CF_16KI_16J_KO_CI.Modeles;
using Dapper;
using System.Data;

namespace CF_16KI_16J_KO_CI.CRUD
{
    internal class CrudCompetition
    {
        public static Competition GetCompetition(int Id = 1)
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                Competition competition = db.QuerySingle<Competition>("SELECT * FROM Competition WHERE IdCompetition=@IdC;",
                    new { IdC = Id});
                db.Close();

                return competition;
            }
        }

        public static void UpdateSingleCompetition(Competition competition)
        {
            string sql = @"UPDATE Competition SET NumGroupe = @NumGroupe, Sexe = @Sexe, Tour = @Tour, `Table` = @Table, IdCategorie = @IdCategorie, IdDivision = @IdDivision  WHERE IdCompetition = @IdCompetition";

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                db.Execute(sql, competition);
                db.Close();
            }
        }
    }
}
