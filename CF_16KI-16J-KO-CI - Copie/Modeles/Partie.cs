namespace CF_16KI_16J_KO_CI.Modeles
{
    public class Partie
    {
        public long IdPartie { get; set; }

        public string sPartie { get; set; }

        public long IdJoueur1 { get; set; }
        public Joueur Joueur1 { get; set; }

        public long IdJoueur2 { get; set;  } 
        public Joueur Joueur2 { get; set; }

        public long IdArbitre { get; set; }
        public Joueur JoueurA { get; set; }

        public string Score1 { get; set; } = "/";

        public string Score2 { get; set; } = "/";

        public string Score3 { get; set; } = "/";

        public string Score4 { get; set; } = "/";
        public string Score5 { get; set; } = "/";

        public bool Abandon1 { get; set; } = false;

        public bool Abandon2 { get; set; } = false;
    }
}
