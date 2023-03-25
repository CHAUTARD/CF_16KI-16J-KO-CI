using CF_16KI_16J_KO_CI.Modeles;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CF_16KI_16J_KO_CI.CRUD
{
    internal class CrudDivision
    {
        public static List<Division> GetAllDivisions()
        {
            List<Division> lD = new List<Division>();

            using (IDbConnection db = SingletonOutils.Connextion())
            {
                db.Open();
                lD = db.Query<Division>("SELECT * FROM Division ORDER BY Ord;").ToList();
                db.Close();
            }

            return lD;
        }

        public static Division GetDivision(long id)
        {
            using (IDbConnection db = SingletonOutils.Connextion())
            {
                Division division = new Division();

                db.Open();
                division = db.QuerySingle<Division>("SELECT * FROM Division WHERE IdDivision=@Id",
                    new { Id = id });
                db.Close();

                return division;
            }
        }
    }
}
