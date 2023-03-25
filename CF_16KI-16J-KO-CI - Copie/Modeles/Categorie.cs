namespace CF_16KI_16J_KO_CI.Modeles
{
    public class Categorie
    {
        public long IdCategorie { get; set; }

        public string Nom { get; set; }

        public string NomCourt { get; set; }

        public string Parent { get; set; }

        public int Ord { get; set; }
    }
}