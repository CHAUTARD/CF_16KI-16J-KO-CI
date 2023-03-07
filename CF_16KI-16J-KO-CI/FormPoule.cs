/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
using CF_16KI_16J_KO_CI.Modeles;
using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace CF_16KI_16J_KO_CI
{
    public partial class FormPoule : Form
    {
        FormSaisieScore formSaisieScore;

        // Classement par poule
        // A1,A2,A3,A4,B1,B2,B3,B4,C1,C2,C3,C4,D1,D2,D3,D4
        private int[,] iRetClassement = new int[4,4];

        // Calcul des points partie de tous les joueurs
        int[] iPointsParties = { 0, 0, 0, 0 };

        const int iColScore = 5;
        const int iColPoint = 10;

        public FormPoule()
        {
            InitializeComponent();

            // Couleur sélectionnée pour le fond du formulaire
            this.BackColor = SingletonOutils.BackColor;

            Text = "Saisie des poules ( " + SingletonOutils.getCompetition() + " )";

            // Affichage du bouton en Mode Debug
            if (System.Diagnostics.Debugger.IsAttached)
                btnRemplir.Visible = true;
        }

        private void FormPoule_Load(object sender, EventArgs e)
        {
            int iNbr = SingletonOutils.NbrLJoueur();

            /* Suppression de toutes les parties déjà enregistrées */
            SQLiteCommand sqlCommand = SingletonOutils.sqliteConn.CreateCommand();

            sqlCommand.CommandText = "DELETE FROM Parties;";
            sqlCommand.ExecuteNonQuery();

            switch (iNbr)
            {
                /*
                case 8: // 2 joueurs par poule
                    Init2Dgv(dgvPoule1);
                    Init2Dgv(dgvPoule2);
                    Init2Dgv(dgvPoule3);
                    Init2Dgv(dgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule2(dgvPoule1, 'A');
                    AddInPoule3(dgvPoule2, 'B');
                    AddInPoule2(dgvPoule3, 'C');
                    AddInPoule2(dgvPoule4, 'D');
                    break;

                case 9:
                    Init3Dgv(dgvPoule1);
                    Init2Dgv(dgvPoule2);
                    Init2Dgv(dgvPoule3);
                    Init2Dgv(dgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(dgvPoule1, 'A');
                    AddInPoule2(dgvPoule2, 'B');
                    AddInPoule2(dgvPoule3, 'C');
                    AddInPoule2(dgvPoule4, 'D');
                    break;

                case 10:
                    Init3Dgv(dgvPoule1);
                    Init3Dgv(dgvPoule2);
                    Init2Dgv(dgvPoule3);
                    Init2Dgv(dgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(dgvPoule1, 'A');
                    AddInPoule3(dgvPoule2, 'B');
                    AddInPoule2(dgvPoule3, 'C');
                    AddInPoule2(dgvPoule4, 'D');
                    break;

                case 11:
                    Init3Dgv(dgvPoule1);
                    Init3Dgv(dgvPoule2);
                    Init3Dgv(dgvPoule3);
                    Init2Dgv(dgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(dgvPoule1, 'A');
                    AddInPoule3(dgvPoule2, 'B');
                    AddInPoule3(dgvPoule3, 'C');
                    AddInPoule2(dgvPoule4, 'D');
                    break;

                case 12:
                    Init3Dgv(dgvPoule1);
                    Init3Dgv(dgvPoule2);
                    Init3Dgv(dgvPoule3);
                    Init3Dgv(dgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(dgvPoule1, 'A');
                    AddInPoule3(dgvPoule2, 'B');
                    AddInPoule3(dgvPoule3, 'C');
                    AddInPoule3(dgvPoule4, 'D');
                    break;

                case 13:
                    Init3Dgv(dgvPoule1);
                    Init3Dgv(dgvPoule2);
                    Init3Dgv(dgvPoule3);
                    Init4Dgv(dgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(dgvPoule1, 'A');
                    AddInPoule3(dgvPoule2, 'B');
                    AddInPoule3(dgvPoule3, 'C');
                    AddInPoule4(dgvPoule4, 'D');
                    break;

                case 14:
                    Init3Dgv(dgvPoule1);
                    Init3Dgv(dgvPoule2);
                    Init4Dgv(dgvPoule3);
                    Init4Dgv(dgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(dgvPoule1, 'A');
                    AddInPoule3(dgvPoule2, 'B');
                    AddInPoule4(dgvPoule3, 'C');
                    AddInPoule4(dgvPoule4, 'D');
                    break;

                case 15:
                    Init3Dgv(dgvPoule1);
                    Init4Dgv(dgvPoule2);
                    Init4Dgv(dgvPoule3);
                    Init4Dgv(dgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(dgvPoule1, 'A');
                    AddInPoule4(dgvPoule2, 'B');
                    AddInPoule4(dgvPoule3, 'C');
                    AddInPoule4(dgvPoule4, 'D');
                    break;
                */
                case 16:
                    // Positionnement des joueurs dans les poules
                    AddInPoule4(dgvPoule1, 'A');
                    AddInPoule4(dgvPoule2, 'B');
                    AddInPoule4(dgvPoule3, 'C');
                    AddInPoule4(dgvPoule4, 'D');
                    break;

                default:
                    MessageBox.Show("Le logiciel ne sait pas gérer des poules avec 1 seul joueur.");
                    Close();
                    break;
            }
        }

        // Ajout d'un joueur dans un groupe
        public void AddInPoule2(DataGridView dgv, char cPoule)
        {
            // 1 - 8 ou 2 - 7 ou 3 - 6 ou 4 - 5
            switch(cPoule)
            {
                case 'A':
                    dgv.Rows[0].Cells[2].Value = SingletonOutils.lJoueurs[0].GetNom();
                    dgv.Rows[0].Cells[3].Value = SingletonOutils.lJoueurs[7].GetNom();
                    break;

                case 'B':
                    dgv.Rows[0].Cells[2].Value = SingletonOutils.lJoueurs[1].GetNom();
                    dgv.Rows[0].Cells[3].Value = SingletonOutils.lJoueurs[6].GetNom();
                    break;

                case 'C':
                    dgv.Rows[0].Cells[2].Value = SingletonOutils.lJoueurs[2].GetNom();
                    dgv.Rows[0].Cells[3].Value = SingletonOutils.lJoueurs[5].GetNom();
                    break;

                case 'D':
                    dgv.Rows[0].Cells[2].Value = SingletonOutils.lJoueurs[3].GetNom();
                    dgv.Rows[0].Cells[3].Value = SingletonOutils.lJoueurs[4].GetNom();
                    break;
            }
        }

        public void AddInPoule3(DataGridView dgv, char cPoule)
        {
            // ( 0, 7, 8) (1,6,9) (2,5,10) (3,4,11)
            int[] aPosition = SingletonOutils.getJoueurPoule3(cPoule);

            // 1-3
            dgv.Rows[0].Cells[2].Value = SingletonOutils.lJoueurs[aPosition[0]].GetNom();
            dgv.Rows[0].Cells[3].Value = SingletonOutils.lJoueurs[aPosition[2]].GetNom();

            // 2-3
            dgv.Rows[1].Cells[2].Value = SingletonOutils.lJoueurs[aPosition[1]].GetNom();
            dgv.Rows[1].Cells[3].Value = SingletonOutils.lJoueurs[aPosition[2]].GetNom();

            // 1-2
            dgv.Rows[2].Cells[2].Value = SingletonOutils.lJoueurs[aPosition[0]].GetNom();
            dgv.Rows[2].Cells[3].Value = SingletonOutils.lJoueurs[aPosition[1]].GetNom();
        }

        public void AddInPoule4(DataGridView dgv, char cPoule)
        {
            // ( 1, 8, 9, 16) ( 2, 7, 10, 15) ( 3, 6, 11, 14) ( 4, 5, 12, 13)
            int[] INumJ = SingletonOutils.GetJoueurPoule4(cPoule);

            // Numero des joueurs dans la liste 1..16
            int iJoueur1, iJoueur2, ijoueurA;

            // Recontre Joueur 1, Joueur 2, Joueur Arbitre
            int[,] aPosition  = { { 1, 4, 3 }, { 2, 3, 4 }, { 1, 3, 2 }, { 2, 4, 1 }, { 1, 2, 3 }, { 3, 4, 2 } };

            // Disponible
            int[,] aPosition2 = { { 2, 3 }, { 1, 4 }, { 2, 4 }, { 1, 3 }, { 3, 4 }, { 1, 2 } };

            SQLiteCommand sqlCommand = SingletonOutils.sqliteConn.CreateCommand();

            // Création des enregistrements
            // Insertion d'une partie
            string insertPartie = "INSERT INTO parties (`sPartie`,`IdJoueur1`,`IdJoueur2`,`IdArbitre` ) VALUES ( @sPartie, @IdJoueur1, @IdJoueur2, @IdArbitre)";

            sqlCommand = new SQLiteCommand(insertPartie, SingletonOutils.sqliteConn);

            // Les partie pour les barrages
            for (int i = 0; i < 6; i++)
            {
                iJoueur1 = INumJ[aPosition[i, 0] - 1];
                iJoueur2 = INumJ[aPosition[i, 1] - 1];
                ijoueurA = INumJ[aPosition[i, 2] - 1];

                sqlCommand.Parameters.AddWithValue("@sPartie", SingletonOutils.getsPartie4(i));
                sqlCommand.Parameters.AddWithValue("@IdJoueur1", SingletonOutils.lJoueurs[iJoueur1].IdJoueur);
                sqlCommand.Parameters.AddWithValue("@IdJoueur2", SingletonOutils.lJoueurs[iJoueur2].IdJoueur);
                sqlCommand.Parameters.AddWithValue("@IdArbitre", SingletonOutils.lJoueurs[ijoueurA].IdJoueur);
                sqlCommand.Prepare();
                sqlCommand.ExecuteNonQuery();

                dgv.Rows.Add(SingletonOutils.getsPartie4(i).Substring(2), false, SingletonOutils.lJoueurs[iJoueur1].GetNom(), SingletonOutils.lJoueurs[iJoueur2].GetNom(), false, "/", "/", "/", "/", "/", 0, 0, 0, 0, SingletonOutils.lJoueurs[ijoueurA].GetNom());
                dgv.Rows[i].Cells[aPosition2[i, 0] + iColPoint - 1].Style.BackColor = Color.Black;
                dgv.Rows[i].Cells[aPosition2[i, 1] + iColPoint - 1].Style.BackColor = Color.Black;
            }
        }

        /*
        private void Init2Dgv(DataGridView dgv)
        {
            // ( 1 / 2 )
            dgv.Rows.Add("1 / 2", false, "", "", false, "/", "/", "/", "/", "/");
            dgv.Rows[0].Cells[iColPoint + 2].Style.BackColor = Color.Black;
            dgv.Rows[0].Cells[iColPoint + 3].Style.BackColor = Color.Black;
        }
        */

        /*
        private void Init3Dgv(DataGridView dgv)
        {
            // { 1, 3 }, { 2, 3 }, { 1, 2 }
            dgv.Rows.Add("1 / 3", false, "", "", false, "/", "/", "/", "/", "/");
            dgv.Rows[0].Cells[1 + iColPoint].Style.BackColor = Color.Black;

            dgv.Rows.Add("2 / 3", false, "", "", false, "/", "/", "/", "/", "/");
            dgv.Rows[0].Cells[iColPoint].Style.BackColor = Color.Black;

            dgv.Rows.Add("1 / 2", false, "", "", false, "/", "/", "/", "/", "/");
            dgv.Rows[0].Cells[2 + iColPoint].Style.BackColor = Color.Black;
        }
        */

        /*
        // Creation des enregistrements partie 4 joueurs
        private void Init4Dgv(DataGridView dgv) { }
        */

        private void dgvPoule1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_CellClick(dgvPoule1, sender, e);
        }

        private void dgvPoule2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_CellClick(dgvPoule2, sender, e);
        }

        private void dgvPoule3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_CellClick(dgvPoule3, sender, e);
        }

        private void dgvPoule4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_CellClick(dgvPoule4, sender, e);
        }

        private void dgv_CellClick(DataGridView dgv, object sender, DataGridViewCellEventArgs e)
        {
            // Pas de click sur le header
            if (e.RowIndex == -1) return;

            switch(e.ColumnIndex)
            {
                case 1:
                    dgv_CellClick(dgv, e.RowIndex, 1);
                    break;

                case 4:
                    dgv_CellClick(dgv, e.RowIndex, 4);
                    break;

                case iColScore:
                case iColScore + 1:
                case iColScore + 2:
                case iColScore + 3:
                case iColScore + 4:
                    // Gestion des Forfait Abandon, pas de saise de points
                    if ((bool)dgv.Rows[e.RowIndex].Cells[1].Value || (bool)dgv.Rows[e.RowIndex].Cells[4].Value)
                        MessageBox.Show("Pas de saisie de score pour les Forfait ou Abandon !");
                    else
                        GetScore(dgv, e.RowIndex);
                    break;
            }
        }

        // Saisie des scores dans les poules
        private void dgv_CellClick(DataGridView dgv, int iRow, int iCol)
        {
            char c;
            // "1 - 4"
            bool b1 = dgv.Rows[iRow].Cells[1].Value == null ? true : ((bool)dgv.Rows[iRow].Cells[1].Value);
            bool b4 = dgv.Rows[iRow].Cells[4].Value == null ? true : ((bool)dgv.Rows[iRow].Cells[4].Value);

            // Colonne Forfait, Abandon
            if (iCol == 1)
            {
                b1 = !b1;

                // Recherche du numero dans la poule du joueur
                c = dgv.Rows[iRow].Cells[0].Value.ToString()[0];


                // Remplir les scores avec 0 ou -0 sur toutes les partie concernées
                for (int i = iRow; i < 6; i++)
                {
                    switch (dgv.Rows[i].Cells[0].Value.ToString().IndexOf(c))
                    {
                        case 0:
                            // La case Forfait / Abandon est cocher
                            dgv.Rows[i].Cells[1].Value = b1;

                                // et saisir le score
                                if (b1)
                                    setScoreAndVainqueur(dgv, i, "-00");
                                else
                                    setScoreAndVainqueur(dgv, i, "/");
                            break;

                        case 4:
                            // La case Forfait / Abandon est coché
                            dgv.Rows[i].Cells[4].Value = b1;

                            // et saisir le score
                            if (b1)
                                setScoreAndVainqueur(dgv, i, "00");
                            else
                                setScoreAndVainqueur(dgv, i, "/");
                            break;
                    }
                }
            }

            if (iCol == 4)
            {
                b4 = !b4;
                dgv.Rows[iRow].Cells[4].Value = b4;

                // Recherche du numero du joueur
                c = dgv.Rows[iRow].Cells[0].Value.ToString()[4];

                // Reste t'il des parties pour ce joueur
                for (int i = iRow; i < 6; i++)
                {
                    switch (dgv.Rows[i].Cells[0].Value.ToString().IndexOf(c))
                    {
                        case 0: // "1 - 4"
                                // Cocher la case Forfait / Abandon
                            dgv.Rows[i].Cells[1].Value = b4;

                            // et saisir le score
                            if (b4)
                                setScoreAndVainqueur(dgv, i, "-00");
                            else
                                setScoreAndVainqueur(dgv, i, "/");
                            break;

                        case 4: // "1 - 4"
                                // Cocher la case Forfait / Abandon
                            dgv.Rows[i].Cells[4].Value = b4;

                            // et saisir le score
                            if (b4)
                                setScoreAndVainqueur(dgv, i, "00");
                            else
                                setScoreAndVainqueur(dgv, i, "/");
                            break;
                    }
                }
            }
        }

        // Positionne le score pour le forfait ou l'abandon et met en Gras le nom du vainqueur
        private void setScoreAndVainqueur(DataGridView dgv, int iRow, string sScore)
        {
            // Les 2 joueurs sont Forfait/Abandon
            if ((bool)dgv.Rows[iRow].Cells[1].Value && (bool)dgv.Rows[iRow].Cells[4].Value)
                sScore = "/";

            dgv.Rows[iRow].Cells[iColScore].Value = sScore;
            dgv.Rows[iRow].Cells[iColScore + 1].Value = sScore;
            dgv.Rows[iRow].Cells[iColScore + 2].Value = sScore;
            dgv.Rows[iRow].Cells[iColScore + 3].Value = "/";
            dgv.Rows[iRow].Cells[iColScore + 4].Value = "/";

            setVainqueurPartie(dgv, iRow);
        }

        private void GetScore(DataGridView dgv, int iRow)
        {
            string sJoueurs = "Partie : " + dgv.Rows[iRow].Cells[0].Value + Environment.NewLine +
            dgv.Rows[iRow].Cells[1].Value + Environment.NewLine +
            "contre" + Environment.NewLine +
            dgv.Rows[iRow].Cells[2].Value;

            string[] aScore = new string[5];
            string s;

            // Récupération des score déjà saisie
            for (int i = iColScore; i < iColScore + 5; i++)
            {
                if (dgv.Rows[iRow].Cells[i].Value is null || dgv.Rows[iRow].Cells[i].Value.ToString() == "/")
                    aScore[i - iColScore] = "/";
                else
                    aScore[i - iColScore] = dgv.Rows[iRow].Cells[i].Value.ToString();
            }

            formSaisieScore = new FormSaisieScore(sJoueurs, aScore);

            if (formSaisieScore.ShowDialog() == DialogResult.OK)
            {
                // Forfait / Abandon
                if (formSaisieScore.bAbandon1)
                {
                    // Cocher la case Forfait / Abandon
                    dgv.Rows[iRow].Cells[1].Value = true;

                    dgv_CellClick(dgv, iRow, 1);
                }

                if (formSaisieScore.bAbandon2)
                {
                    // Cocher la case Forfait / Abandon
                    dgv.Rows[iRow].Cells[4].Value = true;

                    dgv_CellClick(dgv, iRow, 4);
                }

                // Mise en couleur des scores
                for (int i = 0; i < 5; i++)
                {
                    s = formSaisieScore.aScore[i];

                    dgv.Rows[iRow].Cells[i + iColScore].Value = s;
                    switch (s[0])
                    {
                        case '-':
                            dgv.Rows[iRow].Cells[i + iColScore].Style.BackColor = SingletonOutils.cPerdue;
                            break;

                        case '/':
                            dgv.Rows[iRow].Cells[i + iColScore].Style.BackColor = SingletonOutils.cNull;
                            break;

                        default:
                            dgv.Rows[iRow].Cells[i + iColScore].Style.BackColor = SingletonOutils.cGagnee;
                            break;
                    }
                }

                setVainqueurPartie(dgv, iRow);
            }
        }

        private void setVainqueurPartie(DataGridView dgv, int iRow)
        {
            // Mise a jour des points partie
            string sRencontre = dgv.Rows[iRow].Cells[0].Value.ToString();
            int iJoueur1 = sRencontre[0] - '0';
            int iJoueur2 = sRencontre[4] - '0';

            // Remise a blanc des cellulles
            switch(SingletonOutils.GetMancheNegative(dgv, iRow, iColScore))
            {
                case 3:
                    // Partie perdu
                    // Mise en gras du vainqueur
                    SetPointPartie(dgv, iRow, iJoueur1, iJoueur2, false);
                    break;

                case 99:
                    // Supprime la couleur sur le nom
                    SetPointPartie(dgv, iRow, iJoueur1, iJoueur2, true);
                    SingletonOutils.SetWhite(dgv, iRow, 2);
                    SingletonOutils.SetWhite(dgv, iRow, 3);
                    break;

                default:
                    // Partie gagnée
                    // Mise en gras du vainqueur
                    SetPointPartie(dgv, iRow, iJoueur1, iJoueur2, true);
                    break;
            }

            // Mise a jour des points partie
            int[] iTotal = { 0, 0, 0, 0 };
            for (int iR = 0; iR < dgv.Rows.Count; iR++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (dgv.Rows[iR].Cells[iColPoint + j].Value != null)
                        iTotal[j] += int.Parse(dgv.Rows[iR].Cells[iColPoint + j].Value.ToString());
                }
            }

            // Affichage du total des points parties
            switch (dgv.Name)
            {
                case "dgvPoule1":
                    lbV11.Text = iTotal[0].ToString();
                    lbV12.Text = iTotal[1].ToString();
                    lbV13.Text = iTotal[2].ToString();
                    lbV14.Text = iTotal[3].ToString();
                    break;

                case "dgvPoule2":
                    lbV21.Text = iTotal[0].ToString();
                    lbV22.Text = iTotal[1].ToString();
                    lbV23.Text = iTotal[2].ToString();
                    lbV24.Text = iTotal[3].ToString();
                    break;

                case "dgvPoule3":
                    lbV31.Text = iTotal[0].ToString();
                    lbV32.Text = iTotal[1].ToString();
                    lbV33.Text = iTotal[2].ToString();
                    lbV34.Text = iTotal[3].ToString();
                    break;

                case "dgvPoule4":
                    lbV41.Text = iTotal[0].ToString();
                    lbV42.Text = iTotal[1].ToString();
                    lbV43.Text = iTotal[2].ToString();
                    lbV44.Text = iTotal[3].ToString();
                    break;
            }
        }

        /*
         * Ecriture des points partie pour la partie iRow
         * et mise à jour du score Point Partie 
         * et prise en compte des Forfaits et Abandon
         */
        private void SetPointPartie(DataGridView dgv, int iRow, int iJoueur1, int iJoueur2, bool bFirst)
        {
            bool b1 = (bool)dgv.Rows[iRow].Cells[1].Value;
            bool b4 = (bool)dgv.Rows[iRow].Cells[4].Value;

            // Premier joueur forfait
            if (b1)
            {
                SingletonOutils.SetForfaitAbandon(dgv, iRow, 2, true);
                dgv.Rows[iRow].Cells[iColPoint + iJoueur1 - 1].Value = "0";
                SingletonOutils.SetPerdue(dgv, iRow, 2);
                SingletonOutils.SetGagnee(dgv, iRow, 3);

                // Deuxiéme joueur Forfait
                if (b4)
                {
                    SingletonOutils.SetForfaitAbandon(dgv, iRow, 3, true);
                    dgv.Rows[iRow].Cells[iColPoint + iJoueur1 - 1].Value = "0";
                    dgv.Rows[iRow].Cells[iColPoint + iJoueur2 - 1].Value = "0";
                    SingletonOutils.SetWhite(dgv, iRow, 2);
                    SingletonOutils.SetWhite(dgv, iRow, 3);
                }
                else
                {
                    SingletonOutils.SetForfaitAbandon(dgv, iRow, 3, false);
                    
                    dgv.Rows[iRow].Cells[iColPoint + iJoueur2 - 1].Value = "2";
                }
            }
            else
            {
                SingletonOutils.SetForfaitAbandon(dgv, iRow, 2, false);
                SingletonOutils.SetGagnee(dgv, iRow, 2);

                if (b4)
                {
                    SingletonOutils.SetForfaitAbandon(dgv, iRow, 3, true);

                    dgv.Rows[iRow].Cells[iColPoint + iJoueur1 - 1].Value = "2";
                    dgv.Rows[iRow].Cells[iColPoint + iJoueur2 - 1].Value = "0";
                    SingletonOutils.SetPerdue(dgv, iRow, 3);
                }
                else
                {
                    // Pas de forfait
                    SingletonOutils.SetForfaitAbandon(dgv, iRow, 3, false);
                   
                    if (bFirst)
                    {
                        dgv.Rows[iRow].Cells[iColPoint + iJoueur1 - 1].Value = "2";
                        dgv.Rows[iRow].Cells[iColPoint + iJoueur2 - 1].Value = "1";
                        SingletonOutils.SetPerdue(dgv, iRow, 3);
                    }
                    else
                    {
                        SingletonOutils.SetPerdue(dgv, iRow, 2);

                        dgv.Rows[iRow].Cells[iColPoint + iJoueur1 - 1].Value = "1";
                        dgv.Rows[iRow].Cells[iColPoint + iJoueur2 - 1].Value = "2";
                        SingletonOutils.SetGagnee(dgv, iRow, 3);
                    }
                }
            }
        }

        private void btClassement_Click(object sender, EventArgs e)
        {
            btnClassementPoule1_Click(sender, e);
            btnClassementPoule2_Click(sender, e);
            btnClassementPoule3_Click(sender, e);
            btnClassementPoule4_Click(sender, e);

            bt_Arbre.Enabled = true;
        }

        private void btnClassementPoule1_Click(object sender, EventArgs e)
        {
            int j;
            int[] aClassement;

            // Initialisation des poules
            GerePoule gerePouleA = new GerePoule('A', txtRapport1, dgvPoule1);

            gerePouleA.SetPointsPartie(int.Parse(lbV11.Text), int.Parse(lbV12.Text), int.Parse(lbV13.Text), int.Parse(lbV14.Text));

            // Calcul du classement
            aClassement = gerePouleA.SetClassement();

            for (int i = 0; i < 4; i++)
            {
                // Sauvegarde pour la poule A
                iRetClassement[0,i] = SingletonOutils.GetJoueurPoule4('A')[aClassement[i]];

                switch (aClassement[i])
                {
                    case 0:
                        lbC11.Text = (i + 1).ToString();
                        break;
                    case 1:
                        lbC12.Text = (i + 1).ToString();
                        break;
                    case 2:
                        lbC13.Text = (i + 1).ToString();
                        break;
                    case 3:
                        lbC14.Text = (i + 1).ToString();
                        break;
                }
            }
            btnClassementPoule1.Enabled = (lbC11.Text.Length > 0) && (lbC12.Text.Length > 0) && (lbC13.Text.Length > 0) && (lbC14.Text.Length > 0);

            EnableClassement();
        }

        private void EnableClassement()
        {
            btClassement.Enabled = btnClassementPoule1.Enabled && btnClassementPoule2.Enabled && btnClassementPoule3.Enabled && btnClassementPoule4.Enabled;
        }

        private void btnClassementPoule2_Click(object sender, EventArgs e)
        {
            int[] aClassement;

            // Initialisation des poules
            GerePoule gerePouleB = new GerePoule('B', txtRapport2, dgvPoule2);

            gerePouleB.SetPointsPartie(int.Parse(lbV21.Text), int.Parse(lbV22.Text), int.Parse(lbV23.Text), int.Parse(lbV24.Text));

            // Calcul du classement
            aClassement = gerePouleB.SetClassement();

            for (int i = 0; i < 4; i++)
            {
                // Sauvegarde pour la poule B
                iRetClassement[1,i] = SingletonOutils.GetJoueurPoule4('B')[aClassement[i]];

                switch (aClassement[i])
                {
                    case 0:
                        lbC21.Text = (i + 1).ToString();
                        break;
                    case 1:
                        lbC22.Text = (i + 1).ToString();
                        break;
                    case 2:
                        lbC23.Text = (i + 1).ToString();
                        break;
                    case 3:
                        lbC24.Text = (i + 1).ToString();
                        break;
                }
            }
            btnClassementPoule2.Enabled = (lbC21.Text.Length > 0) && (lbC22.Text.Length > 0) && (lbC23.Text.Length > 0) && (lbC24.Text.Length > 0);

            EnableClassement();
        }

        private void btnClassementPoule3_Click(object sender, EventArgs e)
        {
            int[] aClassement;

            // Initialisation des poules
            GerePoule gerePouleC = new GerePoule('C', txtRapport3, dgvPoule3);

            gerePouleC.SetPointsPartie(int.Parse(lbV31.Text), int.Parse(lbV32.Text), int.Parse(lbV33.Text), int.Parse(lbV34.Text));

            // Calcul du classement
            aClassement = gerePouleC.SetClassement();

            for (int i = 0; i < 4; i++)
            {
                // Sauvegarde pour la poule C
                iRetClassement[2,i] = SingletonOutils.GetJoueurPoule4('C')[aClassement[i]];

                switch (aClassement[i])
                {
                    case 0:
                        lbC31.Text = (i + 1).ToString();
                        break;
                    case 1:
                        lbC32.Text = (i + 1).ToString();
                        break;
                    case 2:
                        lbC33.Text = (i + 1).ToString();
                        break;
                    case 3:
                        lbC34.Text = (i + 1).ToString();
                        break;
                }
            }

            btnClassementPoule3.Enabled = (lbC31.Text.Length > 0) && (lbC32.Text.Length > 0) && (lbC33.Text.Length > 0) && (lbC34.Text.Length > 0);

            EnableClassement();
        }

        private void btnClassementPoule4_Click(object sender, EventArgs e)
        {
            int[] aClassement;

            // Initialisation des poules
            GerePoule gerePouleD = new GerePoule('D', txtRapport4, dgvPoule4);

            gerePouleD.SetPointsPartie(int.Parse(lbV41.Text), int.Parse(lbV42.Text), int.Parse(lbV43.Text), int.Parse(lbV44.Text));

            // Calcul du classement
            aClassement = gerePouleD.SetClassement();

            for (int i = 0; i < 4; i++)
            {
                // Sauvegarde pour la poule D
                iRetClassement[3,i] = SingletonOutils.GetJoueurPoule4('D')[aClassement[i]];

                switch (aClassement[i])
                {
                    case 0:
                        lbC41.Text = (i+1).ToString();
                        break;
                    case 1:
                        lbC42.Text = (i+1).ToString();
                        break;
                    case 2:
                        lbC43.Text = (i+1).ToString();
                        break;
                    case 3:
                        lbC44.Text = (i+1).ToString();
                        break;
                }
            }

            btnClassementPoule4.Enabled= ( lbC41.Text.Length > 0 ) && ( lbC42.Text.Length > 0 ) && (lbC43.Text.Length > 0) && (lbC44.Text.Length > 0);

            EnableClassement();
        }

        private void btnRemplir_Click(object sender, EventArgs e)
        {
            /* Remplir les 4 DataGridView
             * 0 -> Joueur1 Abandon
             * 1 -> Joueur1 Abandon
             * 2 -> Score 1
             * 3 -> Score 2
             * 4 -> Score 3
             * 5 -> Score 4
             * 6 -> Score 5
             */
            int[,,] aValueGrid = {
               { { 0, 0, 4, 5, -8, -8, -10 }, { 0, 0, 3, 5, -10, 10, 99 }, { 0, 0, -9, 9, -10, 12, -15 }, { 0, 0, 4 ,7 , 9, 99, 99}, { 0, 0, -6, 9, -9, -8, 99}, { 0, 0, -9, 11, 11, -3, 8} },
               { { 0, 0, 2, 3, 4, 99, 99 },   { 0, 0, 2, 3, 4, 99, 99 },   { 0, 0, -2, -3, -4, 99, 99 },  { 0, 0, 2, 3, 4, 99, 99 }, { 0, 0, 2, 3, 4, 99, 99 },  { 0, 0, 2, 3, 4, 99, 99 } },
               { { 0, 0, 4, 5, -8, -8, -10 }, { 0, 0, 3, 5, -10, 10, 99 }, { 0, 0, -9, 9, -10, 12, -15 }, { 0, 0, 4 ,7 , 9, 99, 99}, { 0, 0, -6, 9, -9, -8, 99}, { 0, 0, -9, 11, 11, -3, 8} },
               { { 0, 0, 2, 3, 4, 99, 99 },   { 0, 0, 2, 3, 4, 99, 99 },   { 0, 0, -2, 3, -4, 9, 8 },     { 0, 0, 2, 3, 4, 99, 99 }, { 0, 0, 2, 3, 4, 99, 99 },  { 0, 0, 2, 3, 4, 99, 99 } }
            };

            DataGridView dgv;
            int iScore;
            bool bContinue;

            for(int iPoule = 0; iPoule < 4; iPoule++) 
            {
                // Pour les 4 poules
                switch(iPoule)
                {
                    case 0:
                        dgv = dgvPoule1;
                        break;

                    case 1:
                        dgv = dgvPoule2;
                        break;

                    case 2:
                        dgv = dgvPoule3;
                        break;

                    default:
                        dgv = dgvPoule4;
                        break;
                }

                // Pour chaque ligne
                for (int iRow = 0; iRow < 6; iRow++)
                {
                    bContinue = true;

                    // Forfait / Abandon
                    if (aValueGrid[ iPoule, iRow, 0] == 1)
                    {
                        // Cocher la case Abandon du joueur 1
                        dgv.Rows[iRow].Cells[1].Value = true;

                        dgv_CellClick(dgv, iRow, 1);

                        bContinue = false;
                    }

                    if (aValueGrid[ iPoule, iRow, 1] == 1)
                    {
                        // Cocher la case Abandon du joueur 2
                        dgv.Rows[iRow].Cells[4].Value = true;

                        dgv_CellClick(dgv, iRow, 4);

                        bContinue = false;
                    }

                    if (bContinue)
                    {
                        // Mise en couleur des scores
                        for (int i = 2; i < 7; i++)
                        {
                            iScore = aValueGrid[ iPoule, iRow, i];
                            if (iScore == 99)
                                dgv.Rows[iRow].Cells[i + 3].Value = "/";
                            else
                                dgv.Rows[iRow].Cells[i + 3].Value = iScore.ToString();
                        }
                        setVainqueurPartie(dgv, iRow);
                    }
                }
            }

            // Tous les boutons Classements sont actifs
            btClassement.Enabled = btnClassementPoule1.Enabled = btnClassementPoule2.Enabled = btnClassementPoule3.Enabled = btnClassementPoule4.Enabled = true;
        }

        private void bt_Arbre_Click(object sender, EventArgs e)
        {
            FormArbre frmArbre = new FormArbre(iRetClassement);
            frmArbre.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e) { Close(); }

    }
}
