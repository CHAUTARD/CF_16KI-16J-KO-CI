namespace CF_16KI_16J_KO_CI.Modeles
{
    public class Param
    {
        public string Division { get; set; }
        public string Tour { get; set; }
        public string Sexe { get; set; }
        public string Groupe { get; set; }
        public string Categorie { get; set; }

        public Param( string _Division, string _Tour, string _Sexe, string _Groupe, string _Categorie)
        { 
            Division = _Division;
            Tour = _Tour;
            Sexe = _Sexe;
            Groupe = _Groupe;
            Categorie = _Categorie;
        }
    }
}
