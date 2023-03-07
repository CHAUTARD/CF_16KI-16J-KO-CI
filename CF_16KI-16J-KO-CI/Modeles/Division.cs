using System;

namespace CF_16KI_16J_KO_CI.Modeles
{
    public class Division
    {
        public long IdDivision { get; set; }
        public string Nom { get; set; }
        public string NomCourt { get; set; }
        public string Niveau { get; set; }
        public int Ord { get; set; }

        public Division(long _idDivision, string _nom, string _nomCourt, string _niveau, int _ord)
        {
            IdDivision = _idDivision;
            Nom = _nom ?? throw new ArgumentNullException(nameof(_nom));
            NomCourt = _nomCourt ?? throw new ArgumentNullException(nameof(_nomCourt));
            Niveau = _niveau ?? throw new ArgumentNullException(nameof(_niveau));
            Ord = _ord;
        }

        public Division() { }
    }
}
