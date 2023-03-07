using System;

namespace CF_16KI_16J_KO_CI.Modeles
{
    public class Categorie
    {
        public long IdCategorie { get; set; }
        public string Nom { get; set; }
        public string NomCourt { get; set; }
        public string Parent { get; set; }
        public int Ord { get; set; }

        public Categorie(long _idCategorie, string _nom, string _nomCourt, string _parent, int _ord)
        {
            IdCategorie = _idCategorie;
            Nom = _nom ?? throw new ArgumentNullException(nameof(_nom));
            NomCourt = _nomCourt ?? throw new ArgumentNullException(nameof(_nomCourt));
            Parent = _parent ?? throw new ArgumentNullException(nameof(_parent));
            Ord = _ord;
        }

        public Categorie() { }
    }
}