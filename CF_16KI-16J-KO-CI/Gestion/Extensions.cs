using System.Collections.Generic;

namespace CF_16KI_16J_KO_CI.Gestion
{
    public static class Extensions
    {
        public static void removeDuplicates<T>(this List<T> list)
        {
            HashSet<T> hashset = new HashSet<T>();
            list.RemoveAll(x => !hashset.Add(x));
        }
    }
}
