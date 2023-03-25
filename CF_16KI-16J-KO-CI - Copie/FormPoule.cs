/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
using CF_16KI_16J_KO_CI.CRUD;
using CF_16KI_16J_KO_CI.Modeles;
using CF_16KI_16J_KO_CI.Orm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CF_16KI_16J_KO_CI
{
    public partial class FormPoule : Form
    {
        FormSaisieScore formSaisieScore;

        // Classement par poule
        // A1,A2,A3,A4,B1,B2,B3,B4,C1,C2,C3,C4,D1,D2,D3,D4
        private int[,] iRetClassement = new int[4, 4];

        // Calcul des points partie de tous les joueurs
        int[] iPointsParties = { 0, 0, 0, 0 };

        const int iColScore = 5;
        const int iColPoint = 10;

        public FormPoule()
        {
            InitializeComponent();

            // Couleur sélectionnée pour le fond du formulaire
            this.BackColor = SingletonOutils.BackColor;

            Text = "Saisie des poules ( " + SingletonOutils.GetCompetition() + " )";

            // Affichage du bouton en Mode Debug
            if (System.Diagnostics.Debugger.IsAttached)
                BtnRemplir.Visible = true;
        }

        private void FormPoule_Load(object sender, EventArgs e)
        {
            int iNbr = SingletonOutils.NbrLJoueur();

            switch (iNbr)
            {
                /*
                case 8: // 2 joueurs par poule
                    Init2Dgv(DgvPoule1);
                    Init2Dgv(DgvPoule2);
                    Init2Dgv(DgvPoule3);
                    Init2Dgv(DgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule2(DgvPoule1, 'A');
                    AddInPoule3(DgvPoule2, 'B');
                    AddInPoule2(DgvPoule3, 'C');
                    AddInPoule2(DgvPoule4, 'D');
                    break;

                case 9:
                    Init3Dgv(DgvPoule1);
                    Init2Dgv(DgvPoule2);
                    Init2Dgv(DgvPoule3);
                    Init2Dgv(DgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(DgvPoule1, 'A');
                    AddInPoule2(DgvPoule2, 'B');
                    AddInPoule2(DgvPoule3, 'C');
                    AddInPoule2(DgvPoule4, 'D');
                    break;

                case 10:
                    Init3Dgv(DgvPoule1);
                    Init3Dgv(DgvPoule2);
                    Init2Dgv(DgvPoule3);
                    Init2Dgv(DgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(DgvPoule1, 'A');
                    AddInPoule3(DgvPoule2, 'B');
                    AddInPoule2(DgvPoule3, 'C');
                    AddInPoule2(DgvPoule4, 'D');
                    break;

                case 11:
                    Init3Dgv(DgvPoule1);
                    Init3Dgv(DgvPoule2);
                    Init3Dgv(DgvPoule3);
                    Init2Dgv(DgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(DgvPoule1, 'A');
                    AddInPoule3(DgvPoule2, 'B');
                    AddInPoule3(DgvPoule3, 'C');
                    AddInPoule2(DgvPoule4, 'D');
                    break;

                case 12:
                    Init3Dgv(DgvPoule1);
                    Init3Dgv(DgvPoule2);
                    Init3Dgv(DgvPoule3);
                    Init3Dgv(DgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(DgvPoule1, 'A');
                    AddInPoule3(DgvPoule2, 'B');
                    AddInPoule3(DgvPoule3, 'C');
                    AddInPoule3(DgvPoule4, 'D');
                    break;

                case 13:
                    Init3Dgv(DgvPoule1);
                    Init3Dgv(DgvPoule2);
                    Init3Dgv(DgvPoule3);
                    Init4Dgv(DgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(DgvPoule1, 'A');
                    AddInPoule3(DgvPoule2, 'B');
                    AddInPoule3(DgvPoule3, 'C');
                    AddInPoule4(DgvPoule4, 'D');
                    break;

                case 14:
                    Init3Dgv(DgvPoule1);
                    Init3Dgv(DgvPoule2);
                    Init4Dgv(DgvPoule3);
                    Init4Dgv(DgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(DgvPoule1, 'A');
                    AddInPoule3(DgvPoule2, 'B');
                    AddInPoule4(DgvPoule3, 'C');
                    AddInPoule4(DgvPoule4, 'D');
                    break;

                case 15:
                    Init3Dgv(DgvPoule1);
                    Init4Dgv(DgvPoule2);
                    Init4Dgv(DgvPoule3);
                    Init4Dgv(DgvPoule4);

                    // Positionnement des joueurs dans les poules
                    AddInPoule3(DgvPoule1, 'A');
                    AddInPoule4(DgvPoule2, 'B');
                    AddInPoule4(DgvPoule3, 'C');
                    AddInPoule4(DgvPoule4, 'D');
                    break;
                */
                case 16:
                    // Positionnement des joueurs dans les poules
                    AddInPoule4(DgvPoule1, 'A');
                    AddInPoule4(DgvPoule2, 'B');
                    AddInPoule4(DgvPoule3, 'C');
                    AddInPoule4(DgvPoule4, 'D');
                    break;

                default:
                    MessageBox.Show("Le logiciel ne sait pas gérer des poules avec 1 seul joueur.");
                    Close();
                    break;
            }
        }

        /* Ajout d'un joueur dans un groupe
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
        */

        /*
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
        */

        public void AddInPoule4(DataGridView dgv, char cPoule)
        {
            // ( 1, 8, 9, 16) ( 2, 7, 10, 15) ( 3, 6, 11, 14) ( 4, 5, 12, 13)
            int[] INumJ = SingletonOutils.GetJoueurPoule4(cPoule);

            // Numero des joueurs dans la liste 1..16
            int iJoueur1, iJoueur2, ijoueurA;

            // Recontre Joueur 1, Joueur 2, Joueur Arbitre
            int[,] aPosition = { { 1, 4, 3 }, { 2, 3, 4 }, { 1, 3, 2 }, { 2, 4, 1 }, { 1, 2, 3 }, { 3, 4, 2 } };

            // Disponible
            int[,] aPosition2 = { { 2, 3 }, { 1, 4 }, { 2, 4 }, { 1, 3 }, { 3, 4 }, { 1, 2 } };

            Partie partie;
            string sPartie;

            // Les partie pour les barrages
            for (int i = 0; i < 6; i++)
            {
                iJoueur1 = INumJ[aPosition[i, 0] - 1];
                iJoueur2 = INumJ[aPosition[i, 1] - 1];
                ijoueurA = INumJ[aPosition[i, 2] - 1];

                int IPartieEnCours = ((cPoule - 'A') * 6) + i;
                sPartie = SingletonOutils.GetsPartie4(IPartieEnCours);

                partie = CrudPartie.GetPartie(sPartie);
                if (partie.IdJoueur1 == 0)
                    CrudPartie.UpdateJoueur(sPartie, SingletonOutils.lJoueurs[iJoueur1].IdJoueur, SingletonOutils.lJoueurs[iJoueur2].IdJoueur, SingletonOutils.lJoueurs[ijoueurA].IdJoueur);

                dgv.Rows.Add(sPartie.Substring(3),
                    partie.Abandon1, SingletonOutils.lJoueurs[iJoueur1].GetNom(IPartieEnCours), SingletonOutils.lJoueurs[iJoueur2].GetNom(IPartieEnCours), partie.Abandon2,
                    partie.Score1, partie.Score2, partie.Score3, partie.Score4, partie.Score5, 0, 0, 0, 0, SingletonOutils.lJoueurs[ijoueurA].GetNom(IPartieEnCours));

                dgv.Rows[i].Cells[aPosition2[i, 0] + iColPoint - 1].Style.BackColor = Color.Black;
                dgv.Rows[i].Cells[aPosition2[i, 1] + iColPoint - 1].Style.BackColor = Color.Black;

                SetVainqueurPartie(dgv, i);
            }
        }

        /*
        private void Init2Dgv(DataGridView dgv)
        {
            // ( 1/2 )
            dgv.Rows.Add("1/2", false, "", "", false, "/", "/", "/", "/", "/");
            dgv.Rows[0].Cells[iColPoint + 2].Style.BackColor = Color.Black;
            dgv.Rows[0].Cells[iColPoint + 3].Style.BackColor = Color.Black;
        }
        */

        /*
        private void Init3Dgv(DataGridView dgv)
        {
            // { 1, 3 }, { 2, 3 }, { 1, 2 }
            dgv.Rows.Add("1/3", false, "", "", false, "/", "/", "/", "/", "/");
            dgv.Rows[0].Cells[1 + iColPoint].Style.BackColor = Color.Black;

            dgv.Rows.Add("2/3", false, "", "", false, "/", "/", "/", "/", "/");
            dgv.Rows[0].Cells[iColPoint].Style.BackColor = Color.Black;

            dgv.Rows.Add("1/2", false, "", "", false, "/", "/", "/", "/", "/");
            dgv.Rows[0].Cells[2 + iColPoint].Style.BackColor = Color.Black;
        }
        */

        /*
        // Creation des enregistrements partie 4 joueurs
        private void Init4Dgv(DataGridView dgv) { }
        */

        private void DgvPoule1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Dgv_CellClick(DgvPoule1, sender, e);
        }

        private void DgvPoule2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Dgv_CellClick(DgvPoule2, sender, e);
        }

        private void DgvPoule3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Dgv_CellClick(DgvPoule3, sender, e);
        }

        private void DgvPoule4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Dgv_CellClick(DgvPoule4, sender, e);
        }

        private void Dgv_CellClick(DataGridView dgv, object sender, DataGridViewCellEventArgs e)
        {
            // Pas de click sur le header
            if (e.RowIndex == -1) return;

            switch (e.ColumnIndex)
            {
                case 0:
                    MessageBox.Show(dgv.Rows[e.RowIndex].Cells[14].Value.ToString(), "Arbitrage de la partie");
                    break;

                case 1:
                    Dgv_CellClick(dgv, e.RowIndex, 1);
                    break;

                case 4:
                    Dgv_CellClick(dgv, e.RowIndex, 4);
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
        private void Dgv_CellClick(DataGridView dgv, int iRow, int iCol)
        {
            char c;
            bool b1 = dgv.Rows[iRow].Cells[1].Value == null ? true : ((bool)dgv.Rows[iRow].Cells[1].Value);
            bool b4 = dgv.Rows[iRow].Cells[4].Value == null ? true : ((bool)dgv.Rows[iRow].Cells[4].Value);
            string sPoule;
            Joueur joueur;
            int IndexPartie;

            // Colonne Forfait, Abandon
            if (iCol == 1)
            {
                // Recherche du numero dans la poule du joueur
                c = dgv.Rows[iRow].Cells[0].Value.ToString()[0];

                // Recherche si abandon dans les partie précédante
                for (int i = 0; i < iRow; i++)
                {
                    switch (dgv.Rows[i].Cells[0].Value.ToString().IndexOf(c))
                    {
                        case 0:
                            if ((bool)dgv.Rows[i].Cells[1].Value)
                            {
                                MessageBox.Show("Impossible le joueur à déjà abandonné !");
                                return;
                            }
                            break;

                        case 2:
                            if ((bool)dgv.Rows[i].Cells[4].Value)
                            {
                                MessageBox.Show("Impossible le joueur à déjà abandonné !");
                                return;
                            }
                            break;

                    }
                }

                // Inversion de l'état
                b1 = !b1;

                // Sauvegarde de l'état
                sPoule = SingletonOutils.GetStringPartiePoule(dgv, iRow);
                IndexPartie = b1 ? SingletonOutils.GetIndexPartie(sPoule) : 99;
                joueur = OrmJoueur.FindByNom(dgv.Rows[iRow].Cells[2].Value.ToString());
                CrudJoueur.UpdateAbandon(IndexPartie, joueur.IdJoueur);
                CrudPartie.SaveAbandon1(sPoule, b1);

                // Remplir les scores avec 0 ou -0 sur toutes les partie concernées
                for (int i = iRow; i < 6; i++)
                {
                    switch (dgv.Rows[i].Cells[0].Value.ToString().IndexOf(c))
                    {
                        case 0:
                            // La case Forfait / Abandon est cocher
                            dgv.Rows[i].Cells[1].Value = b1;

                            sPoule = SingletonOutils.GetStringPartiePoule(dgv, i);
                            CrudPartie.SaveAbandon1(sPoule, b1);

                            // Completer le score
                            if (b1)
                                SetScoreAndVainqueur(dgv, i, "-00");
                            else
                                SetScoreAndVainqueur(dgv, i, "/");
                            break;

                        case 2:
                            // La case Forfait / Abandon est coché
                            dgv.Rows[i].Cells[4].Value = b1;

                            sPoule = SingletonOutils.GetStringPartiePoule(dgv, i);
                            CrudPartie.SaveAbandon2(sPoule, b1);

                            // et saisir le score
                            if (b1)
                                SetScoreAndVainqueur(dgv, i, "00");
                            else
                                SetScoreAndVainqueur(dgv, i, "/");
                            break;
                    }
                }
            }

            if (iCol == 4)
            {
                // Recherche du numero du joueur
                c = dgv.Rows[iRow].Cells[0].Value.ToString()[2];

                // Recherche si abandon dans les partie précédante
                for (int i = 0; i < iRow; i++)
                {
                    switch (dgv.Rows[i].Cells[0].Value.ToString().IndexOf(c))
                    {
                        case 0:
                            if ((bool)dgv.Rows[i].Cells[1].Value)
                            {
                                MessageBox.Show("Impossible le joueur à déjà abandonné !");
                                return;
                            }
                            break;
                        case 2:
                            if ((bool)dgv.Rows[i].Cells[4].Value)
                            {
                                MessageBox.Show("Impossible le joueur à déjà abandonné !");
                                return;
                            }
                            break;
                    }
                }

                // Inversion de l'état
                b4 = !b4;

                // Sauvegarde de l'état
                sPoule = SingletonOutils.GetStringPartiePoule(dgv, iRow);
                IndexPartie = b4 ? SingletonOutils.GetIndexPartie(sPoule) : 99;
                joueur = OrmJoueur.FindByNom(dgv.Rows[iRow].Cells[3].Value.ToString());
                CrudJoueur.UpdateAbandon(IndexPartie, joueur.IdJoueur);
                CrudPartie.SaveAbandon2(sPoule, b4);

                // Reste t'il des parties pour ce joueur
                for (int i = iRow; i < 6; i++)
                {
                    switch (dgv.Rows[i].Cells[0].Value.ToString().IndexOf(c))
                    {
                        case 0: // "1-4"
                                // Cocher la case Forfait / Abandon
                            dgv.Rows[i].Cells[1].Value = b4;

                            sPoule = SingletonOutils.GetStringPartiePoule(dgv, i);
                            CrudPartie.SaveAbandon1(sPoule, b4);

                            // et saisir le score
                            if (b4)
                                SetScoreAndVainqueur(dgv, i, "-00");
                            else
                                SetScoreAndVainqueur(dgv, i, "/");
                            break;

                        case 2: // "1-4"
                                // Cocher la case Forfait / Abandon
                            dgv.Rows[i].Cells[4].Value = b4;

                            sPoule = SingletonOutils.GetStringPartiePoule(dgv, i);
                            CrudPartie.SaveAbandon2(sPoule, b4);

                            // et saisir le score
                            if (b4)
                                SetScoreAndVainqueur(dgv, i, "00");
                            else
                                SetScoreAndVainqueur(dgv, i, "/");
                            break;
                    }
                }
            }
        }

        // Positionne le score pour le forfait ou l'abandon et met en Gras le nom du vainqueur
        private void SetScoreAndVainqueur(DataGridView dgv, int iRow, string sScore)
        {
            string[] aScore = new string[5];

            // Les 2 joueurs sont Forfait/Abandon
            if ((bool)dgv.Rows[iRow].Cells[1].Value && (bool)dgv.Rows[iRow].Cells[4].Value)
                aScore = new string[] { "/", "/", "/", "/", "/" };
            else
                aScore = new string[] { sScore, sScore, sScore, "/", "/" };

            SetScoreAndVainqueur(dgv, iRow, aScore);
        }

        private void SetScoreAndVainqueur(DataGridView dgv, int iRow, string[] sScore)
        {
            SetScoreAndColor(dgv, iRow, iColScore, sScore[0]);
            SetScoreAndColor(dgv, iRow, iColScore + 1, sScore[1]);
            SetScoreAndColor(dgv, iRow, iColScore + 2, sScore[2]);

            try { SetScoreAndColor(dgv, iRow, iColScore + 3, sScore[3]); }
            catch { SetScoreAndColor(dgv, iRow, iColScore + 3, "/"); }

            try { SetScoreAndColor(dgv, iRow, iColScore + 4, sScore[4]); }
            catch { SetScoreAndColor(dgv, iRow, iColScore + 4, "/"); }

            // Sauvegarde des scores
            string sPoule = SingletonOutils.GetStringPartiePoule(dgv, iRow);
            CrudPartie.SaveScore( sPoule, sScore[0], sScore[1], sScore[2], sScore[3], sScore[4]);

            SetVainqueurPartie(dgv, iRow);
        }


        private void SetScoreAndColor(DataGridView dgv, int iRow, int iCol, string sScore)
        {
            dgv.Rows[iRow].Cells[iCol].Value = sScore;
            if (sScore == "/")
                SingletonOutils.SetColorWhite(dgv, iRow, iCol);
            else
                if (sScore[0] == '-')
                SingletonOutils.SetColorPerdue(dgv, iRow, iCol);
            else
                SingletonOutils.SetColorGagnee(dgv, iRow, iCol);

        }

        // Saisie du scores
        private void GetScore(DataGridView dgv, int iRow)
        {
            string sPartie = dgv.Rows[iRow].Cells[0].Value.ToString();
            string sTitre = "Partie : " + sPartie + Environment.NewLine +
            dgv.Rows[iRow].Cells[1].Value + Environment.NewLine +
            "contre" + Environment.NewLine +
            dgv.Rows[iRow].Cells[2].Value;

            string[] aScore = new string[7];
            string s;

            // Récupération des score déjà saisie
            for (int i = iColScore; i < iColScore + 5; i++)
            {
                if (dgv.Rows[iRow].Cells[i].Value is null || dgv.Rows[iRow].Cells[i].Value.ToString() == "/")
                    aScore[i - iColScore] = "/";
                else
                    aScore[i - iColScore] = dgv.Rows[iRow].Cells[i].Value.ToString();
            }

            formSaisieScore = new FormSaisieScore(sTitre, aScore);

            if (formSaisieScore.ShowDialog() == DialogResult.OK)
            {
                // Recherche de la poule en cours
                String sPoule = SingletonOutils.GetStringPartiePoule(dgv, iRow);

                // Forfait / Abandon
                if (formSaisieScore.bAbandon1 || formSaisieScore.bForfait1)
                {
                    // Cocher la case Forfait / Abandon
                    dgv.Rows[iRow].Cells[1].Value = true;

                    CrudPartie.SaveAbandon1(sPoule, formSaisieScore.bAbandon1 || formSaisieScore.bForfait1);

                    Dgv_CellClick(dgv, iRow, 1);
                }

                if (formSaisieScore.bAbandon2 || formSaisieScore.bForfait2)
                {
                    // Cocher la case Forfait / Abandon
                    dgv.Rows[iRow].Cells[4].Value = true;

                    CrudPartie.SaveAbandon2(sPoule, formSaisieScore.bAbandon2 || formSaisieScore.bForfait2);

                    Dgv_CellClick(dgv, iRow, 4);
                }

                CrudPartie.SaveScore(sPoule, formSaisieScore.aScore[0], formSaisieScore.aScore[1], formSaisieScore.aScore[2], formSaisieScore.aScore[3], formSaisieScore.aScore[4]);

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

                SetVainqueurPartie(dgv, iRow);
            }
        }

        private void SetVainqueurPartie(DataGridView dgv, int iRow)
        {
            // Mise a jour des points partie
            string sRencontre = dgv.Rows[iRow].Cells[0].Value.ToString();
            int iJoueur1 = sRencontre[0] - '0';
            int iJoueur2 = sRencontre[2] - '0';

            // Partie perdu => 3 ou gagnée +> 0, 1, 2, 99
            switch (SingletonOutils.GetMancheNegative(dgv, iRow, iColScore))
            {
                case 99: // Pas de score
                    SingletonOutils.SetColorWhite(dgv, iRow, 2);
                    dgv.Rows[iRow].Cells[iColPoint + iJoueur1 - 1].Value = "0";
                    dgv.Rows[iRow].Cells[iColPoint + iJoueur2 - 1].Value = "0";
                    SingletonOutils.SetColorWhite(dgv, iRow, 3);
                    SetForfaitAbandon(dgv, iRow, 2, false);
                    SetForfaitAbandon(dgv, iRow, 3, false);
                    break;

                case 3: // Perdu, b2Gagne = false
                    SetPointPartie(dgv, iRow, iJoueur1, iJoueur2, false);
                    break;

                default: // Gagnée, b2Gagne = true
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
                case "DgvPoule1":
                    lbV11.Text = iTotal[0].ToString();
                    lbV12.Text = iTotal[1].ToString();
                    lbV13.Text = iTotal[2].ToString();
                    lbV14.Text = iTotal[3].ToString();
                    break;

                case "DgvPoule2":
                    lbV21.Text = iTotal[0].ToString();
                    lbV22.Text = iTotal[1].ToString();
                    lbV23.Text = iTotal[2].ToString();
                    lbV24.Text = iTotal[3].ToString();
                    break;

                case "DgvPoule3":
                    lbV31.Text = iTotal[0].ToString();
                    lbV32.Text = iTotal[1].ToString();
                    lbV33.Text = iTotal[2].ToString();
                    lbV34.Text = iTotal[3].ToString();
                    break;

                case "DgvPoule4":
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
         * bFirst = True si la partie est gagnée pour le joueur 2 et perdu pour le 3
         */
        private void SetPointPartie(DataGridView dgv, int iRow, int iJoueur1, int iJoueur2, bool b2Gagne)
        {
            // Joueur1 = Abandon / Forfait
            bool b1 = (bool)dgv.Rows[iRow].Cells[1].Value;
            // Joueur2 = Abandon / Forfait
            bool b4 = (bool)dgv.Rows[iRow].Cells[4].Value;

            // Joueur1 = Abandon / Forfait
            if (b1)
            {
                SetForfaitAbandon(dgv, iRow, 2, true);
                dgv.Rows[iRow].Cells[iColPoint + iJoueur1 - 1].Value = "0";
                SingletonOutils.SetColorPerdue(dgv, iRow, 2);
                SingletonOutils.SetColorGagnee(dgv, iRow, 3);

                // Deuxiéme joueur Forfait
                if (b4)
                {
                    SetForfaitAbandon(dgv, iRow, 3, true);
                    dgv.Rows[iRow].Cells[iColPoint + iJoueur2 - 1].Value = "0";
                    SingletonOutils.SetColorWhite(dgv, iRow, 2);
                    SingletonOutils.SetColorWhite(dgv, iRow, 3);
                }
                else
                {
                    SetForfaitAbandon(dgv, iRow, 3, false);
                    dgv.Rows[iRow].Cells[iColPoint + iJoueur2 - 1].Value = "2";
                }
            }
            else
            {
                SetForfaitAbandon(dgv, iRow, 2, false);
                SingletonOutils.SetColorGagnee(dgv, iRow, 2);
                SingletonOutils.SetColorPerdue(dgv, iRow, 3);

                if (b4)
                {
                    SetForfaitAbandon(dgv, iRow, 3, true);
                    dgv.Rows[iRow].Cells[iColPoint + iJoueur1 - 1].Value = "2";
                    dgv.Rows[iRow].Cells[iColPoint + iJoueur2 - 1].Value = "0";
                }
                else
                {
                    // Pas de forfait
                    SetForfaitAbandon(dgv, iRow, 3, false);

                    if (b2Gagne)
                    {
                        dgv.Rows[iRow].Cells[iColPoint + iJoueur1 - 1].Value = "2";
                        dgv.Rows[iRow].Cells[iColPoint + iJoueur2 - 1].Value = "1";
                    }
                    else
                    {
                        SingletonOutils.SetColorPerdue(dgv, iRow, 2);
                        dgv.Rows[iRow].Cells[iColPoint + iJoueur1 - 1].Value = "1";
                        dgv.Rows[iRow].Cells[iColPoint + iJoueur2 - 1].Value = "2";
                        SingletonOutils.SetColorGagnee(dgv, iRow, 3);
                    }
                }
            }
        }

        private void BtnClassement_Click(object sender, EventArgs e) { ClassementAll(); }

        private void ClassementAll()
        {
            ClassementPoule1();
            ClassementPoule2();
            ClassementPoule3();
            ClassementPoule4();

            BtnArbre.Enabled = true;
        }

        private void BtnClassementPoule1_Click(object sender, EventArgs e) { ClassementPoule1(); }

        private void ClassementPoule1()
        {
            int[] aClassement;

            // Initialisation des poules
            GerePoule gerePouleA = new GerePoule('A', txtRapport1, DgvPoule1);

            gerePouleA.SetPointsPartie(int.Parse(lbV11.Text), int.Parse(lbV12.Text), int.Parse(lbV13.Text), int.Parse(lbV14.Text));

            // Calcul du classement
            aClassement = gerePouleA.SetClassement();

            for (int i = 0; i < 4; i++)
            {
                // Sauvegarde pour la poule A
                iRetClassement[0, i] = SingletonOutils.GetJoueurPoule4('A')[aClassement[i]];

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
            BtnClassementPoule1.Enabled = (lbC11.Text.Length > 0) && (lbC12.Text.Length > 0) && (lbC13.Text.Length > 0) && (lbC14.Text.Length > 0);

            EnableClassement();
        }

        private void EnableClassement()
        {
            BtnClassement.Enabled = BtnClassementPoule1.Enabled && BtnClassementPoule2.Enabled && BtnClassementPoule3.Enabled && BtnClassementPoule4.Enabled;
        }

        private void BtnClassementPoule2_Click(object sender, EventArgs e) { ClassementPoule2(); }

        private void ClassementPoule2()
        {
            int[] aClassement;

            // Initialisation des poules
            GerePoule gerePouleB = new GerePoule('B', txtRapport2, DgvPoule2);

            gerePouleB.SetPointsPartie(int.Parse(lbV21.Text), int.Parse(lbV22.Text), int.Parse(lbV23.Text), int.Parse(lbV24.Text));

            // Calcul du classement
            aClassement = gerePouleB.SetClassement();

            for (int i = 0; i < 4; i++)
            {
                // Sauvegarde pour la poule B
                iRetClassement[1, i] = SingletonOutils.GetJoueurPoule4('B')[aClassement[i]];

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
            BtnClassementPoule2.Enabled = (lbC21.Text.Length > 0) && (lbC22.Text.Length > 0) && (lbC23.Text.Length > 0) && (lbC24.Text.Length > 0);

            EnableClassement();
        }

        private void BtnClassementPoule3_Click(object sender, EventArgs e) { ClassementPoule3(); }

        private void ClassementPoule3()
        {
            int[] aClassement;

            // Initialisation des poules
            GerePoule gerePouleC = new GerePoule('C', txtRapport3, DgvPoule3);

            gerePouleC.SetPointsPartie(int.Parse(lbV31.Text), int.Parse(lbV32.Text), int.Parse(lbV33.Text), int.Parse(lbV34.Text));

            // Calcul du classement
            aClassement = gerePouleC.SetClassement();

            for (int i = 0; i < 4; i++)
            {
                // Sauvegarde pour la poule C
                iRetClassement[2, i] = SingletonOutils.GetJoueurPoule4('C')[aClassement[i]];

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

            BtnClassementPoule3.Enabled = (lbC31.Text.Length > 0) && (lbC32.Text.Length > 0) && (lbC33.Text.Length > 0) && (lbC34.Text.Length > 0);

            EnableClassement();
        }

        private void BtnClassementPoule4_Click(object sender, EventArgs e) { ClassementPoule4(); }

        private void ClassementPoule4()
        {
            int[] aClassement;

            // Initialisation des poules
            GerePoule gerePouleD = new GerePoule('D', txtRapport4, DgvPoule4);

            gerePouleD.SetPointsPartie(int.Parse(lbV41.Text), int.Parse(lbV42.Text), int.Parse(lbV43.Text), int.Parse(lbV44.Text));

            // Calcul du classement
            aClassement = gerePouleD.SetClassement();

            for (int i = 0; i < 4; i++)
            {
                // Sauvegarde pour la poule D
                iRetClassement[3, i] = SingletonOutils.GetJoueurPoule4('D')[aClassement[i]];

                switch (aClassement[i])
                {
                    case 0:
                        lbC41.Text = (i + 1).ToString();
                        break;
                    case 1:
                        lbC42.Text = (i + 1).ToString();
                        break;
                    case 2:
                        lbC43.Text = (i + 1).ToString();
                        break;
                    case 3:
                        lbC44.Text = (i + 1).ToString();
                        break;
                }
            }

            BtnClassementPoule4.Enabled = (lbC41.Text.Length > 0) && (lbC42.Text.Length > 0) && (lbC43.Text.Length > 0) && (lbC44.Text.Length > 0);

            EnableClassement();
        }

        private void BtnRemplir_Click(object sender, EventArgs e)
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
            string[,,] aValueGrid = {
               { { "0", "0", "4", "5", "-8", "-8", "-10" }, { "0", "0", "3", "5", "-10", "10", "/" }, { "0", "0", "-9", "9", "-10", "12", "-15" }, { "0", "0", "4" ,"7" , "9", "/", "/"}, { "0", "0", "-6", "9", "-9", "-8", "/"}, { "0", "0", "-9", "11", "11", "-3", "8"} },
               { { "0", "0", "2", "3", "4", "/", "/" },     { "0", "0", "-0", "-0", "-0", "/", "/" }, { "0", "0", "0", "0", "0", "/", "/" },       { "0", "0", "2","3", "4", "/", "/" },  { "0", "0", "2", "3", "4", "/", "/" },   { "0", "0", "2", "3", "4", "/", "/" } },
               { { "0", "0", "4", "5", "-8", "-8", "-10" }, { "0", "0", "0", "0", "0", "/", "/" },    { "0", "0", "-9", "9", "-10", "12", "-15" }, { "0", "0", "4" ,"7" , "9", "/", "/"}, { "0", "0", "-6", "9", "-9", "-8", "/"}, { "0", "0", "-9", "11", "11", "-3", "8"} },
               { { "0", "0", "3", "5", "4", "/", "/" },     { "0", "0", "3", "5", "4", "/", "/" },    { "0", "0", "-2", "3", "-4", "9", "8" },     { "0", "0", "2", "3", "4", "/", "/" }, { "0", "0", "2", "3", "4", "/", "/" },   { "0", "0", "2", "3", "4", "/", "/" } }
            };

            DataGridView dgv;
            string sPoule;

            for (int iPoule = 0; iPoule < 4; iPoule++)
            {
                // Pour les 4 poules
                switch (iPoule)
                {
                    case 0:
                        dgv = DgvPoule1;
                        sPoule = "PA:";
                        break;

                    case 1:
                        dgv = DgvPoule2;
                        sPoule = "PB:";
                        break;

                    case 2:
                        dgv = DgvPoule3;
                        sPoule = "PC:";
                        break;

                    default:
                        dgv = DgvPoule4;
                        sPoule = "PD:";
                        break;
                }

                // Pour chaque ligne
                for (int iRow = 0; iRow < 6; iRow++)
                {
                    // Forfait / Abandon
                    dgv.Rows[iRow].Cells[1].Value = aValueGrid[iPoule, iRow, 0] == "1";

                    if (aValueGrid[iPoule, iRow, 0] == "1")
                    {
                        // Cocher la case Abandon du joueur 1
                        Dgv_CellClick(dgv, iRow, 1);
                    }

                    dgv.Rows[iRow].Cells[4].Value = aValueGrid[iPoule, iRow, 1] == "1";
                    if (aValueGrid[iPoule, iRow, 1] == "1")
                    {
                        // Cocher la case Abandon du joueur 2
                        Dgv_CellClick(dgv, iRow, 4);
                    }

                    // Mise en couleur des scores
                    for (int i = 2; i < 7; i++)
                    {
                        if (aValueGrid[iPoule, iRow, i] == "/")
                            dgv.Rows[iRow].Cells[i + 3].Value = "/";
                        else
                            dgv.Rows[iRow].Cells[i + 3].Value = aValueGrid[iPoule, iRow, i];
                    }

                    CrudPartie.SaveScore(sPoule + dgv.Rows[iRow].Cells[0], 
                        aValueGrid[iPoule, iRow, 3],
                        aValueGrid[iPoule, iRow, 4],
                        aValueGrid[iPoule, iRow, 5],
                        aValueGrid[iPoule, iRow, 6],
                        aValueGrid[iPoule, iRow, 7]
                    );

                    SetVainqueurPartie(dgv, iRow);
                }
            }

            // Tous les boutons Classements sont actifs
            BtnClassement.Enabled = BtnClassementPoule1.Enabled = BtnClassementPoule2.Enabled = BtnClassementPoule3.Enabled = BtnClassementPoule4.Enabled = true;

            // Classement de toutes les poules
            ClassementAll();
        }

        // Ajout du Tag (A) dernière le nom du joueur
        private void SetForfaitAbandon(DataGridView dgv, int iRow, int iCol = 2, bool bAbandon = true)
        {
            // Recherche du nom du Joueur
            string strNom = dgv.Rows[iRow].Cells[iCol].Value.ToString();
            string sPartie = dgv.Rows[iRow].Cells[0].Value.ToString();
            int i;

            // Recherche d'un joueur dans la liste à partir du Nom
            if (strNom.Contains("  ("))
            {
                if (!bAbandon)
                {
                    strNom = strNom.Substring(0, strNom.Length - 5);
                    i = SingletonOutils.lJoueurs.FindIndex(x => x.Nom == strNom); ;
                    dgv.Rows[iRow].Cells[iCol].Value = SingletonOutils.lJoueurs[i].GetNom(sPartie);
                }
            }
            else
            {
                if (bAbandon)
                {
                    i = SingletonOutils.lJoueurs.FindIndex(x => x.Nom == strNom);
                    dgv.Rows[iRow].Cells[iCol].Value = SingletonOutils.lJoueurs[i].GetNom(sPartie, true);
                }
            }
        }

        private void BtnArbre_Click(object sender, EventArgs e)
        {
            FormArbre frmArbre = new FormArbre(iRetClassement);
            frmArbre.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e) { Close(); }
    }
}
