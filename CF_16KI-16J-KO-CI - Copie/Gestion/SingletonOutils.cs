/*
 * Crée par SharpDevelop.
 * Utilisateur: CHAUTARD
 * Date: 13/12/2019
 * Heure: 08:01
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using CF_16KI_16J_KO_CI.Modeles;
using CF_16KI_16J_KO_CI.Orm;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CF_16KI_16J_KO_CI
{
    /// <summary>
    /// Description of SingletonOutils.
    /// </summary>
    public sealed class SingletonOutils
    {
        static SingletonOutils instance = null;
        static readonly object padlock = new object();

        // Nom de la base de donnée
        public static string sFileDatabaseName;

        // Connection à la base de données
        public static SQLiteConnection sqliteConn;

        // Restauration à partir du fichier ini
        public static bool bRestaure { get; set; }

        // Couleur de fonf des formulaires
        public static Color BackColor { get; set; }

        // Liste des joueurs prévus
        public static List<Joueur> lJoueurs = new List<Joueur>();

        // Liste des toutes les divisions
        public static List<Division> lDivisions = new List<Division>();

        // Liste des toutes les catégories
        public static List<Categorie> lCategories = new List<Categorie>();

        // Paramétres Compétition
        public static Competition competition = new Competition();

        // Couleur dans les parties
        public static Color cPerdue = Color.LightCoral;
        public static Color cNull = Color.LightGray;
        public static Color cGagnee = Color.LightBlue;
        public static Color cWhite = Color.White;

        // Liste des parties pour une poule de 4
        public static readonly int[,] aPartie3 = { { 1, 3, 2 }, { 2, 3, 1 }, { 1, 2, 3 } };
        public static readonly int[,] aPartie4 = { { 1, 4, 3, 2 }, { 2, 3, 4, 1 }, { 1, 3, 2, 4 }, { 2, 4, 1, 3 }, { 1, 2, 3, 4 }, { 3, 4, 2, 1 } };

        // sPartie 52 => 0..51
        public static readonly string[] aParties = { 
            "PA:1/4", "PA:2/3", "PA:1/3", "PA:2/4", "PA:1/2", "PA:3/4", // 0..5
            "PB:1/4", "PB:2/3", "PB:1/3", "PB:2/4", "PB:1/2", "PB:3/4", // 6..11
            "PC:1/4", "PC:2/3", "PC:1/3", "PC:2/4", "PC:1/2", "PC:3/4", // 12..17
            "PD:1/4", "PD:2/3", "PD:1/3", "PD:2/4", "PD:1/2", "PD:3/4", // 18..23
            "3/4", "5/6", "11/12", "13/14", // 24..27
            "2/3", "6/7", "10/11", "14/15", // 28..31
            "1/4", "5/8", "9/12", "13/16",  // 32..35
            "3/6", "11/14", "2/7", "10/15", // 36..39
            "1/8", "9/16", "4/5", "12/13",  // 40..43
            "3/14", "6/11", "7/10", "2/15", // 44..47
            "1/16", "8/9", "5/12", "4/13"   // 48..51
        };

        // Tous les classement possible des quatres joueurs
        public static readonly int[,] aPossibleClassement = {
            {1,2,3,4},{1,2,4,3},{1,3,2,4},{1,3,4,2},{1,4,2,3},{1,4,3,2},
            {2,1,3,4},{2,1,4,3},{2,3,1,4},{2,3,4,1},{2,4,1,3},{2,4,3,1},
            {3,1,2,4},{3,1,4,2},{3,2,1,4},{3,2,4,1},{3,4,1,2},{3,4,2,1},
            {4,1,2,3},{4,1,3,2},{4,2,1,3},{4,2,3,1},{4,3,1,2},{4,3,2,1}
        };

        // Classement par default aprés tirage au sort
        public static readonly string[,] sTirageAuSort =
        {
            // A01 => Poule = A, Classement = 1
            { "A01", "B01", "C01", "D01", "A02", "B02", "C02", "D02","A03", "B03", "C03", "D03","A04", "B04", "C04", "D04"}, // 0
            { "A01", "B01", "D01", "C01", "A02", "B02", "D02", "C02","A03", "B03", "D03", "C03","A04", "B04", "D04", "C04"}  // 1
        };

        // Liste de tous les IdJoueurs des joueurs dans la feuille Classement de Excel
        public static long[] lIdJoueurExcel = new long[73];

        public static SingletonOutils GetInstance()
		{
			if (instance == null)
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new SingletonOutils();
					}
				}
			}
			return instance;
		}
		
		private SingletonOutils() 
		{
        }

        public static bool  Init()
        {
            // Couleur de fond par défaut des formulaires
            BackColor = SystemColors.Control;

            // Mettre a blanc le nom des joueurs
            for (int i = 0; i < 73; i++)
                lIdJoueurExcel[i] = 0;

            return true;
        }

        // Initialisation de la base de données
        public static SQLiteConnection Connextion()
        {
            SQLiteConnection connection = null;

            try
            {
                connection = new SQLiteConnection("Data Source=" + sFileDatabaseName + "; Version=3; New=True; Compress=True; foreign keys=true;");
            }
            catch
            {
                MessageBox.Show("Erreur à la connection de la base.", "Erreur", MessageBoxButtons.OK);         
            }
            return connection;
        }

        // Vide la liste est ajoute le premier enregistrement
        public static void ListJoueurClear()
        {
            lJoueurs.Clear();
            lJoueurs.Add(new Joueur(0, "( Vide )", "01/01/2023", 16, 500, false, 0, string.Empty, 'E', 1));
        }

        public static void SetNom(int iDestination1, int iSource1, int iDestination2, int iSource2, DataGridView dgv, int iRow) 
        { 
            if(dgv.Rows[iRow].Cells[2].Style.BackColor == SingletonOutils.cGagnee)
            {
                lIdJoueurExcel[iDestination1] = lIdJoueurExcel[iSource1];
                lIdJoueurExcel[iDestination2] = lIdJoueurExcel[iSource2];
            }
            else
            {
                lIdJoueurExcel[iDestination2] = lIdJoueurExcel[iSource1];
                lIdJoueurExcel[iDestination1] = lIdJoueurExcel[iSource2];
            } 
        }

        // Nombre de joueur avec un nom dans la liste
        public static int NbrLJoueur()
        {
            int iRet = 0;

            for(int i =1; i < lJoueurs.Count; i++)
                if (lJoueurs[i].Nom.Length > 1)
                    iRet++;

            return iRet;
        }

        /*
		 * QuiGagne le plus de partie entre 2 joueurs
		 * 
		 * iRow -> Ligne dans la grille
		 * 
		 * return 
		 *      True pour Joueur1
		 *      False pour joueur2
		 */

        public static bool QuiGagnePartie(DataGridView dgv, int J1, int J2)
        {
            int iRow;
            string s = J1.ToString() + "/" + J2.ToString();

            // Recherche de la partie dans le grid
            for (iRow = 0; iRow < dgv.Rows.Count; iRow++)
                if (dgv.Rows[iRow].Cells[0].Value.ToString() == s)
                    break;

            return Joueur1Gagne(dgv, iRow);
        }

        // Le joueur 1 gagne
        public static bool Joueur1Gagne(DataGridView dgv, int iRow)
        {
            return dgv.Rows[iRow].Cells[2].Style.Font.Bold == true;
        }

        // Ne joue pas dans la partie
        public static int GetArbitre4(int i) { return aPartie4[i, 2]; }
        public static int GetNoJoue4(int i) { return aPartie4[i, 3]; }

        // Conversion des parties en chaine de caractéres
        public static string GetsPartie4(int i) { return aParties[i]; }

        // Recherche du numéro de la partie
        public static int GetIndexPartie(DataGridView dgv, int iRow)
        {
            string sPoule = GetStringPartiePoule(dgv, iRow);
            return GetIndexPartie(sPoule)+1;
        }

        public static int GetIndexPartie(string sPartie) { return Array.IndexOf(SingletonOutils.aParties, sPartie); }

        // Joueur dans l'ordre du serpent
        public static int[] GetJoueurPoule3(char cPoule)
        {
            switch (cPoule)
            {
                case 'A':
                    return new[] { 1, 8, 9 };

                case 'B':
                    return new[] { 2, 7, 10 };

                case 'C':
                    return new[] { 3, 6, 11 };

                case 'D':
                    return new[] { 4, 5, 12 };
            }
            return new[] { 0, 0, 0, 0 };
        }

        public static int[] GetJoueurPoule4(char cPoule)
		{
			switch (cPoule)
			{
				case 'A':
					return new[] { 1, 8, 9, 16 };

				case 'B':
					return new[] { 2, 7, 10, 15 };

				case 'C':
					return new[] { 3, 6, 11, 14 };

				case 'D':
					return new[] { 4, 5, 12, 13 };
			}
            return new[] { 0, 0, 0, 0 };
        }

        /* Vainqueur sur une partie entre deux joueurs
		 * int a, b : Numero du joueur dans la poule.
		 * 
		 * retour :
		 * 		true  -> a vainqueur
		 * 		false -> b vainqueur
		 */
        public static bool ChercheVainqueur(DataGridView dgv, int a, int b)
        {
            int iRow = 0;

            // A est toujours inférieur a B dans les lignes de partie
            if (a > b)
            {
                int c = b;
                b = a;
                a = c;
            }

            string s = a.ToString() + "/" + b.ToString();
            
            for  (iRow = 0; iRow < dgv.Rows.Count; iRow++)
            {
                if (dgv.Rows[iRow].Cells[0].Value.ToString() == s)
                    return (dgv.Rows[iRow].Cells[2].Style.BackColor != cGagnee);

                iRow++;
            }
            return false;
        }

        public static string GetCompetition()
		{
			return competition.division.NomCourt + " - " + competition.Sexe + " -  Groupe : " + competition.NumGroupe + " - Tour : " + competition.Tour;
        }
       
        public static string GetStringPartiePoule(DataGridView dgv, int iRow)
        {
            string sPoule;
            string sPartie = dgv.Rows[iRow].Cells[0].Value.ToString();

            // Recherche de la poule en cours
            switch (dgv.Name)
            {
                case "DgvPoule1":
                    sPoule = "PA:" + sPartie;
                    break;

                case "DgvPoule2":
                    sPoule = "PB:" + sPartie; ;
                    break;

                case "DgvPoule3":
                    sPoule = "PC:" + sPartie; ;
                    break;

                default:
                    sPoule = "PD:" + sPartie; ;
                    break;
            }

            return sPoule;
        }

        /*---------------------------------------------------------------------
         * 
         * DataGridView
         * 
         * --------------------------------------------------------------------*/
        #region DataGridView

        // Compte le nombre de manche négative, perdu dans un DataGridView de saisie de score
        // et mise en couleur de la cellulle
        public static int GetMancheNegative(DataGridView dgv, int iRow, int iCol)
        {
            // Nombre de valeur négative
            int iReturn = 0;

            // Pas de saisie de score
            if ( dgv.Rows[iRow].Cells[iCol].Value.ToString() == "/")
                return 99;

            // Le score 1
            _GetManche(dgv, iRow, ref iCol, ref iReturn);

            // Le score 2
            _GetManche(dgv, iRow, ref iCol, ref iReturn);

            try
            {
                // Le score 3
                _GetManche(dgv, iRow, ref iCol, ref iReturn);

                // Le score 4
                _GetManche(dgv, iRow, ref iCol, ref iReturn);

                // Le score 5
                _GetManche(dgv, iRow, ref iCol, ref iReturn);
            }
            catch
            { }

            return iReturn;
        }

        private static void _GetManche( DataGridView dgv, int iRow, ref int iCol, ref int iReturn)
        {
            if (dgv.Rows[iRow].Cells[iCol].Value != null)
            {
                switch( dgv.Rows[iRow].Cells[iCol].Value.ToString()[0])
                {
                    case '/':
                        SetColorWhite(dgv, iRow, iCol);
                        break;

                    case '-':
                        SetColorPerdue(dgv, iRow, iCol);
                        iReturn++;
                        break;

                    default:
                        SetColorGagnee(dgv, iRow, iCol);
                        break;
                }
            }
            iCol++;
        }

        public static void SetColorGagnee(DataGridView dgv, int iRow, int iCol)
        {
            dgv.Rows[iRow].Cells[iCol].Style.Font = new Font(dgv.Font, FontStyle.Bold);
            dgv.Rows[iRow].Cells[iCol].Style.BackColor = cGagnee;
        }

        public static void SetColorPerdue(DataGridView dgv, int iRow, int iCol)
        {
            dgv.Rows[iRow].Cells[iCol].Style.Font = new Font(dgv.Font, FontStyle.Regular);
            dgv.Rows[iRow].Cells[iCol].Style.BackColor = cPerdue;
        }

        public static void SetColorNull(DataGridView dgv, int iRow, int iCol)
        {
            dgv.Rows[iRow].Cells[iCol].Style.Font = new Font(dgv.Font, FontStyle.Regular);
            dgv.Rows[iRow].Cells[iCol].Style.BackColor = cNull;
        }

        public static void SetColorWhite(DataGridView dgv, int iRow, int iCol)
        {
            dgv.Rows[iRow].Cells[iCol].Style.Font = new Font(dgv.Font, FontStyle.Regular);
            dgv.Rows[iRow].Cells[iCol].Style.BackColor = cWhite;
        }
        #endregion


        /* Recherche d'un joueur dans la liste à partir du Nom
         * 
         * iTirage = 0 ou 1
         * iPos = 0 à 15
         * 
         *
        public static int FindListByPoulePos(bool bTirage, int iPos)
        {
            char cPoule;
            int iPoulePos;

            cPoule =  sTirageAuSort[iTirage, iPos][0];
            iPoulePos = int.Parse( sTirageAuSort[iTirage, iPos].Substring(1) );

            // Recherche du numero de poule A,B,C,D et du numero dans la poule 1, 2, 3, 4
            for (int i = 0; i < lJoueurs.Count; i++)
                if (lJoueurs[i].Poule == cPoule && lJoueurs[i].PouleClassement == iPoulePos)
                    return i;

            return 99;
        }
        */

        /*
        public static int[,] Reverse2DimArray(int[] key, int[] value)
        {
            int[,] aRet = new int[4, 2];
            Array.Sort( key, value);
            int i = 0;

            for (int iRow = 3; iRow >= 0; iRow--)
            {
                aRet[i, 0] = key[iRow];
                aRet[i, 1] = value[iRow];
                i++;
            }
            return aRet;
        }
        */

        // Génération d'un nom de fichier commencant par ## dans le répertoire de l'application
        public static string GetTempFileName(string sTart = "P")
        {
            string fileName = "##" + sTart + "_" +  Path.GetRandomFileName();
            fileName = Path.ChangeExtension(fileName, "xlsx");
            return Path.Combine(".", fileName);
        }

        public static int ExcelColumnNameToNumber(string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("ExcelColumnNameToNumber(columnName)");

            columnName = columnName.ToUpperInvariant();

            int sum = 0;

            for (int i = 0; i < columnName.Length; i++)
            {
                sum *= 26;
                sum += (columnName[i] - 'A' + 1);
            }

            return sum;
        }

        public static void setTextRapport(RichTextBox txtRapport, string sText, bool bold = false)
        {
            Font currentFont = txtRapport.SelectionFont;

            if (bold)
            {
                txtRapport.AppendText(Environment.NewLine);
                txtRapport.SelectionFont = new Font(currentFont.FontFamily, 14, FontStyle.Bold );
            }

            txtRapport.AppendText(sText + Environment.NewLine);

            if (bold) txtRapport.SelectionFont = new Font(currentFont.FontFamily, 9, FontStyle.Regular );
        }

        public static void setTextRapport(RichTextBox txtRapport, string sText, Color color, bool AddNewLine = false)
        {
            if (AddNewLine)
                sText += Environment.NewLine;

            txtRapport.SelectionStart = txtRapport.TextLength;
            txtRapport.SelectionLength = 0;

            txtRapport.SelectionColor = color;
            txtRapport.AppendText(sText);
            txtRapport.SelectionColor = txtRapport.ForeColor;
        }

        /* Partie Arbre Excel */

        // Initialisation de la liste pour Arbre à partir de la liste des joueurs
        public static void SetNomList(int iDestination, int iSource) { lIdJoueurExcel[iDestination] = lJoueurs[iSource].IdJoueur; }

        public static string GetNomExcel(int iPartie, long IdJoueurExcel) 
        {
            string sName = string.Empty;

            // Recherche du joueur à partir de son IdJoueur -> Numero de licence
            Joueur J = OrmJoueur.FindById(lIdJoueurExcel[IdJoueurExcel]);

            return J.GetNom(iPartie);
        }
	}
}