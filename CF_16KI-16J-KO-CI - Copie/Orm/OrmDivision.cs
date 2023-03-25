using CF_16KI_16J_KO_CI.Modeles;

namespace CF_16KI_16J_KO_CI.Orm
{
    internal class OrmDivision
    {
        public static Division FindById(int IdDivision)
        {
            Division match = SingletonOutils.lDivisions.Find(x => x.IdDivision == IdDivision);

            return match;
        }

        public static long FindIdByNom(string sDivision)
        {
            Division match = SingletonOutils.lDivisions.Find(x => x.Nom == sDivision);

            return match.IdDivision;
        }
    }
}
