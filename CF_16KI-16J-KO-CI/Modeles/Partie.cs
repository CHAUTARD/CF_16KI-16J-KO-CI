namespace CF_16KI_16J_KO_CI.Modeles
{
    public class Partie
    {
        public long IdPartie { get; set; }

        public string sPartie { get; set; }

        public Joueur Joueur1 { get; set; }

        public Joueur Joueur2 { get; set; }

        public Joueur JoueurA { get; set; }

        public int Score1 { get; set; } = 99;

        public int Score2 { get; set; } = 99;

        public int Score3 { get; set; } = 99;

        public int Score4 { get; set; } = 99;
        public int Score5 { get; set; } = 99;

        public char Abandon { get; set; } = '0'; // '1', '2', '3', '0'

        public char Forfait { get; set; } = '0'; // '1', '2', '3', '0'
    }
}
