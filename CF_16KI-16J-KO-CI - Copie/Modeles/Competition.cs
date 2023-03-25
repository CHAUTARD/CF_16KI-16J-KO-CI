namespace CF_16KI_16J_KO_CI.Modeles
{
    public class Competition
    {
        public long IdCompetition { get; set; }

        public int NumGroupe { get; set; }

        public string Sexe { get; set; } = "Messieurs"; // Dames

        public int Tour { get; set; } = 1; // 1, 2, 3 , 4

        public int Table { get; set; } = 1;

        public long IdEpreuve { get; set; }
        public Epreuve epreuve = new Epreuve();

        public long IdCategorie { get; set; }
        public Categorie categorie = new Categorie();

        public long IdDivision { get; set; }
        public Division division = new Division();
    }
}
