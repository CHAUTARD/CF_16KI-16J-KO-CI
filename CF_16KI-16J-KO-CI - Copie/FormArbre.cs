/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
using CF_16KI_16J_KO_CI.CRUD;
using CF_16KI_16J_KO_CI.Gestion;
using CF_16KI_16J_KO_CI.Modeles;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace CF_16KI_16J_KO_CI
{
    public partial class FormArbre : Form
    {
        FormSaisieScore formSaisieScore;

        // Classement par poule
        private int[,] iRetClassement = new int[4, 4];

        // 8 + 16 + 16 + 16 + 16 = 72 -> 0 -> 71
        // Les 16 premier sont dans l'ordre du classement Poule A, 1er, 2eme, 3eme, 4eme puis Poule B ...
        //                     0  1  2  3   4   5   6   7   8   9  10  11  12  13  14  15 
        private int[] iRow = { 5, 5, 9, 13, 15, 19, 23, 23, 29, 29, 33, 37, 39, 43, 47,47, // 1/16, Barrage (16)
             11, 17, 35, 41, 11, 17, 35, 41, // 9 - 16, 1/4 (16-23)
             8, 20, 32, 44, 64, 68, 70, 74,  8, 20, 32, 44, 64, 68, 70, 74, // 9 - 12, 13 - 16, 1/2, 5-8 (24-39)
            14, 38, 51, 55, 66, 72, 81, 85, 14, 38, 51, 55, 66, 72, 81, 85, // 9-16, 1-8 (41-56)
            26, 41, 53, 57, 69, 75, 83, 87, 24, 41, 53, 57, 69, 74, 83, 87 // Classement 1er à 16éme (57-72)
        };

        private readonly string[] sTitre = {
            "1/8 Finale (Barrage)", // 0
            "Places 9 à 16 (Bas)",  // 1
            "1/4 Finale (Haut)",    // 2
            "Places 9 à 16 (Bas)",  // 3
            "1/2 Fin, 5/8 (Haut)",  // 4
            "Places 9..16 (Bas)",   // 5
            "Finale, 3..8 (Haut)",  // 6
            "Plus de partie à jouer"  // 7
        };
        private const int iColScore = 5;
        private const string sArbitre = "Arbitre : ";

        // True = Tirage par défault
        // False = Tirage inversé
        private bool bTirage = true;

        private int iPartieEnCours = 0;
        private int[] iCol = new int[72];

        // Créer une liste des classement
        List<BarragePartie> lBarragePartie = new List<BarragePartie>();

        public FormArbre(int[,] _iRetClassement)
        {
            // Classement dans les 4 poules
            iRetClassement = _iRetClassement;

            InitializeComponent();

            // Couleur sélectionnée pour le fond du formulaire
            this.BackColor = SingletonOutils.BackColor;

            #region initColumn
            iCol[1] = iCol[6] = iCol[9] = iCol[14] = SingletonOutils.ExcelColumnNameToNumber("Z");
            iCol[2] = iCol[3] = iCol[4] = iCol[5] = iCol[10] = iCol[11] = iCol[12] = iCol[13] = SingletonOutils.ExcelColumnNameToNumber("AJ");
            iCol[0] = iCol[7] = iCol[8] = iCol[15] = SingletonOutils.ExcelColumnNameToNumber("AR");

            int i;
            for (i = 16; i < 20; i++)
                iCol[i] = SingletonOutils.ExcelColumnNameToNumber("Z");

            for (; i < 24; i++)
                iCol[i] = SingletonOutils.ExcelColumnNameToNumber("AR");

            for (; i < 32; i++)
                iCol[i] = SingletonOutils.ExcelColumnNameToNumber("R");

            for (; i < 40; i++)
                iCol[i] = SingletonOutils.ExcelColumnNameToNumber("AZ");

            for (; i < 48; i++)
                iCol[i] = SingletonOutils.ExcelColumnNameToNumber("J");

            for (; i < 56; i++)
                iCol[i] = SingletonOutils.ExcelColumnNameToNumber("BH");

            for (; i < 64; i++)
                iCol[i] = SingletonOutils.ExcelColumnNameToNumber("BP");

            for (; i < 72; i++)
                iCol[i] = SingletonOutils.ExcelColumnNameToNumber("B");
            #endregion

            // 1/8 Finale
            lBarragePartie.Add(new BarragePartie( "3/4", 3, 4, 1, 21, 17));
            lBarragePartie.Add(new BarragePartie( "5/6", 5, 6, 8, 22, 18));
            lBarragePartie.Add(new BarragePartie("11/12", 11, 12, 9, 23, 19));
            lBarragePartie.Add(new BarragePartie("13/14", 13, 14, 16, 24, 20));

            // Places 9 à 16
            lBarragePartie.Add(new BarragePartie("2/3", 2, 17, 21, 25, 29));
            lBarragePartie.Add(new BarragePartie("6/7", 18, 7, 22, 26, 30));
            lBarragePartie.Add(new BarragePartie("10/11", 10, 19, 23, 27, 31));
            lBarragePartie.Add(new BarragePartie("14/15", 20, 15, 24, 28, 32));

            // 1/4 Finale
            lBarragePartie.Add(new BarragePartie("1/4", 1, 21, 2, 33, 37));
            lBarragePartie.Add(new BarragePartie("5/8", 22, 8, 7, 34, 38));
            lBarragePartie.Add(new BarragePartie("9/12", 9, 23, 10, 35, 39));
            lBarragePartie.Add(new BarragePartie("13/16", 24, 16, 15, 36, 40));

            // Places 9..12
            lBarragePartie.Add(new BarragePartie("3/6", 25, 26, 33, 41, 45));
            lBarragePartie.Add(new BarragePartie("11/14", 27, 28, 34, 42, 44));
            lBarragePartie.Add(new BarragePartie("2/7", 29, 30, 3, 45, 43));
            lBarragePartie.Add(new BarragePartie("10/15", 31, 32, 36, 46, 48));

            // 1/2 Finale
            lBarragePartie.Add(new BarragePartie("1/8", 33, 34, 17, 49, 51));
            lBarragePartie.Add(new BarragePartie("9/16", 35, 36, 18, 50, 52));
            lBarragePartie.Add(new BarragePartie("4/5", 37, 38, 19, 53, 55));
            lBarragePartie.Add(new BarragePartie("12/13", 39, 40, 29, 54, 56));

            // Place 9..16 
            lBarragePartie.Add(new BarragePartie("3/14", 41, 42, 53, 65, 66));
            lBarragePartie.Add(new BarragePartie("6/11", 43, 44, 54, 67, 68));
            lBarragePartie.Add(new BarragePartie("7/10", 45, 46, 55, 69, 70));
            lBarragePartie.Add(new BarragePartie("2/15", 47, 48, 56, 71, 72));

            // Finale
            lBarragePartie.Add(new BarragePartie("1/16", 49, 50, 29, 57, 58));
            lBarragePartie.Add(new BarragePartie("8/9", 51, 52, 30, 59, 60));
            lBarragePartie.Add(new BarragePartie("5/12", 53, 54, 31, 61, 62));
            lBarragePartie.Add(new BarragePartie("4/13", 55, 56, 32, 63, 64));

            // Mise à jour des joueurs
            SetPartie();
        }

        #region Edition
        private void FichesDePartiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sFileName = SingletonOutils.GetTempFileName("EP");

            // if you are using epplus for noncommercial purposes, see https://polyformproject.org/licenses/noncommercial/1.0.0/
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // R2 - 15 ans Messieurs - Tour 3
            string sEpreuve = SingletonOutils.competition.division.Nom + " -  Tour " + SingletonOutils.competition.Tour;

            // Heure
            string Hm = DateTime.Now.ToString("HH:mm");

            // Partie 1 .. 6
            // case 0:
            int iCol = 1;
            int iRow = 2;

            string sJ1 = string.Empty;
            string sJ2 = string.Empty;
            string sA = string.Empty;

            File.Copy(".\\Excel\\Fiches_Partie.xlsx", sFileName);

            //Open the workbook (or create it if it doesn't exist)
            using (var p = new ExcelPackage(sFileName))
            {
                // Get the Worksheet created in the previous codesample. 
                var ws = p.Workbook.Worksheets["Feuil1"];

                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 1:
                            iCol = 12;
                            break;

                        case 2:
                            iCol = 1;
                            iRow = 44;
                            break;

                        case 3:
                            iCol = 12;
                            break;

                    }
                    sJ1 = DgvPartie.Rows[i].Cells[2].Value.ToString();
                    sJ2 = DgvPartie.Rows[i].Cells[3].Value.ToString();
                    sA = DgvPartie.Rows[i].Cells[10].Value.ToString();

                    // Set the cell Value using row and column.
                    ws.Cells[iRow, iCol + 3].Value = sEpreuve;

                    //The style object is used to access most cells formatting and styles.
                    ws.Cells[iRow + 2, iCol + 3].Style.Font.Bold = true;

                    // Tableau
                    ws.Cells[iRow + 2, iCol + 3].Value = SingletonOutils.competition.categorie.Nom + " " + SingletonOutils.competition.Sexe;

                    // Titre partie
                    ws.Cells[iRow + 4, iCol + 1].Value = sTitre[iPartieEnCours] + " (" + DgvPartie.Rows[i].Cells[0].Value.ToString() + ")";

                    // Nom arbitre
                    ws.Cells[iRow + 6, iCol + 2].Value = sA;

                    // Heure
                    ws.Cells[iRow + 6, iCol + 7].Value = Hm;

                    // Nom Joueur 1
                    ws.Cells[iRow + 11, iCol].Value = ws.Cells[iRow + 26, iCol].Value = sJ1;

                    // Nom Joueur 2
                    ws.Cells[iRow + 18, iCol].Value = ws.Cells[iRow + 29, iCol].Value = sJ2;
                }

                //Save and close the package.
                p.Save();

                // Ouvrir le fichier excel
                System.Diagnostics.Process.Start(sFileName);
            }
        }

        private void ArbreDeClassementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sFileName = SingletonOutils.GetTempFileName("AR");
            string sNom;

            // if you are using epplus for noncommercial purposes, see https://polyformproject.org/licenses/noncommercial/1.0.0/
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Heure
            string dMY = DateTime.Now.ToString("dd MMM yyyy");
            int iC;

            File.Copy(".\\Excel\\Arbre_Classement.xlsx", sFileName);

            //Open the workbook (or create it if it doesn't exist)
            using (var p = new ExcelPackage(sFileName))
            {
                // Get the Worksheet created in the previous codesample. 
                var ws = p.Workbook.Worksheets["Tableau"];

                // Date du jour
                iC = SingletonOutils.ExcelColumnNameToNumber("AI");
                ws.Cells[80, iC].Value = dMY;

                // Set the cell Value using row and column.
                ws.Cells[82, iC].Value = SingletonOutils.GetCompetition();

                // Set the cell Value using row and column.
                for (int iR = 0; iR < 72; iR++)
                {
                    // @TODO revoir la valeur 51
                    sNom = SingletonOutils.GetNomExcel(51,iR + 1);
                    if (sNom.Length > 20) // Troncatrure du nom pour affichage
                        SetCellValue(ws, iR, sNom.Substring(0, 20));
                    else
                        SetCellValue(ws, iR, sNom); // */ "Zone : " + (iR+1));
                }

                //Save and close the package.
                p.Save();

                // Ouvrir le fichier excel
                System.Diagnostics.Process.Start(sFileName);
            }
        }

        private void ClassementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sFileName = SingletonOutils.GetTempFileName("CL");
            string sNom;

            // if you are using epplus for noncommercial purposes, see https://polyformproject.org/licenses/noncommercial/1.0.0/
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Heure
            string dMY = DateTime.Now.ToString("dd MMM yyyy");
            int iC;

            File.Copy(".\\Excel\\Classement.xlsx", sFileName);

            //Open the workbook (or create it if it doesn't exist)
            using (var p = new ExcelPackage(sFileName))
            {
                // Get the Worksheet created in the previous codesample. 
                var ws = p.Workbook.Worksheets["Tableau"];

                // Date du jour
                iC = SingletonOutils.ExcelColumnNameToNumber("AI");
                ws.Cells[80, iC].Value = dMY;

                // Set the cell Value using row and column.
                ws.Cells[82, iC].Value = SingletonOutils.GetCompetition();

                // Set the cell Value using row and column.
                for (int iR = 0; iR < 72; iR++)
                {
                    // @TODO revoir la valeur 51
                    sNom = SingletonOutils.GetNomExcel(51, iR + 1);
                    if (sNom.Length > 20) // Troncatrure du nom pour affichage
                        SetCellValue(ws, iR, sNom.Substring(0, 20)); // "Zone : " + iR
                    else
                        SetCellValue(ws, iR, sNom);
                }

                //Save and close the package.
                p.Save();

                // Ouvrir le fichier excel
                System.Diagnostics.Process.Start(sFileName);
            }

        }

        // Ecriture dans une zone de la feuille Excel
        private void SetCellValue(ExcelWorksheet ws, int iPos, string s)
        {
            ws.Cells[iRow[iPos], iCol[iPos]].Value = s;
        }
        #endregion

        private void RbTirageC_CheckedChanged(object sender, EventArgs e)
        {
            bTirage = RbTirageC.Checked;
            iPartieEnCours = 0;
            SetPartie();
        }

        private void RbTirageD_CheckedChanged(object sender, EventArgs e)
        {
            bTirage = RbTirageD.Checked ? false : true;
            iPartieEnCours = 0;
            SetPartie();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*--------------------------------------------------------------------------------
         * 
          --------------------------------------------------------------------------------*/
        private void SetTitre()
        {
            this.Text = "Classement - ( " + sTitre[iPartieEnCours] + " )";

            if(iPartieEnCours < sTitre.Length)
                groupBox1.Text = sTitre[iPartieEnCours + 1];
        }

        // Mise à jour des joueurs et Arbitres
        private void SetPartie()
        {
            const int POULE_A = 0;
            const int POULE_B = 1;
            const int POULE_C = 2;
            const int POULE_D = 3;

            const int _1ER = 0;
            const int _2EME = 1;
            const int _3EME = 2;
            const int _4EME = 3;

            // Mise à jour du titre de la Form et de la GroupBox
            SetTitre();

            // Vidage de la liste des parties
            DgvPartie.Rows.Clear();

            // Vidage de la lite des joueurs disponible
            dataGridViewDispo.Rows.Clear();

            switch (iPartieEnCours)
            {
                case 0:
                    #region Partie 0 en cours

                    // Initialisation des 16 premiers nom de joueurs
                    SingletonOutils.SetNomList(1, iRetClassement[POULE_A, _1ER]);
                    SingletonOutils.SetNomList(4, iRetClassement[POULE_B, _2EME]);
                    SingletonOutils.SetNomList(6, iRetClassement[POULE_B, _3EME]);
                    SingletonOutils.SetNomList(7, iRetClassement[POULE_A, _4EME]);

                    // En fonction du tirage au sort
                    if (bTirage)
                    {
                        SingletonOutils.SetNomList(2, iRetClassement[POULE_D, _4EME]);
                        SingletonOutils.SetNomList(3, iRetClassement[POULE_C, _3EME]);
                        SingletonOutils.SetNomList(5, iRetClassement[POULE_C, _2EME]);
                        SingletonOutils.SetNomList(8, iRetClassement[POULE_D, _1ER]);
                        SingletonOutils.SetNomList(9, iRetClassement[POULE_C, _1ER]);
                        SingletonOutils.SetNomList(12, iRetClassement[POULE_D, _2EME]);
                        SingletonOutils.SetNomList(14, iRetClassement[POULE_D, _3EME]);
                        SingletonOutils.SetNomList(15, iRetClassement[POULE_C, _4EME]);
                    }
                    else
                    {
                        SingletonOutils.SetNomList(2, iRetClassement[POULE_C, _4EME]);
                        SingletonOutils.SetNomList(3, iRetClassement[POULE_D, _3EME]);
                        SingletonOutils.SetNomList(5, iRetClassement[POULE_D, _2EME]);
                        SingletonOutils.SetNomList(8, iRetClassement[POULE_C, _1ER]);
                        SingletonOutils.SetNomList(9, iRetClassement[POULE_D, _1ER]);
                        SingletonOutils.SetNomList(12, iRetClassement[POULE_C, _2EME]);
                        SingletonOutils.SetNomList(14, iRetClassement[POULE_C, _3EME]);
                        SingletonOutils.SetNomList(15, iRetClassement[POULE_D, _4EME]);
                    }
                    SingletonOutils.SetNomList(10, iRetClassement[POULE_B, _4EME]);
                    SingletonOutils.SetNomList(11, iRetClassement[POULE_A, _3EME]);
                    SingletonOutils.SetNomList(13, iRetClassement[POULE_A, _2EME]);
                    SingletonOutils.SetNomList(16, iRetClassement[POULE_B, _1ER]);

                    
                    DgvRowsAdd(24,lBarragePartie[0]); // 3 contre 4     
                    DgvRowsAdd(25,lBarragePartie[1]); // 5 contre 6  
                    DgvRowsAdd(26,lBarragePartie[2]); // 11 contre 12
                    DgvRowsAdd(27,lBarragePartie[3]); // 13 contre 14

                    // Dispo - 4éme de poule
                    SetDispo( 28, new int[] { 7, 10, 15, 2 });

                    // Suivant 9 / 16 Bas
                    // 2 contre Perdant Barrage 1
                    lb_Futur1.Text = SingletonOutils.GetNomExcel(28, 2);
                    lb_Futur2.Text = "Perdant Barrage 1";
                    lbArbitre1.Text = sArbitre + "Gagnant Barrage 1";

                    // 7 contre Perdant Barrage  2
                    lb_Futur3.Text = SingletonOutils.GetNomExcel(29, 7);
                    lb_Futur4.Text = "Perdant Barrage 2";
                    lbArbitre2.Text = sArbitre + "Gagnant Barrage 2";

                    // 10 contre Perdant Barrage  3
                    lb_Futur5.Text = SingletonOutils.GetNomExcel(30, 10);
                    lb_Futur6.Text = "Perdant Barrage 3";
                    lbArbitre3.Text = sArbitre + "Gagnant Barrage 3";

                    // 15 contre Perdant Barrage  4
                    lb_Futur7.Text = SingletonOutils.GetNomExcel(31, 15);
                    lb_Futur8.Text = "Perdant Barrage 4";
                    lbArbitre4.Text = sArbitre + "Gagnant Barrage 4";

                    #endregion
                    break;

                case 1:
                    #region Partie 1 en cours

                    /* Copie des nom des joueurs dans la liste des SingletonOutils.lIdJoueurExcel
                     * Pour les vainqueur et perdant des parties précédantes
                    */

                    DgvRowsAdd(28,lBarragePartie[4]);
                    DgvRowsAdd(29,lBarragePartie[5]);
                    DgvRowsAdd(30,lBarragePartie[6]);
                    DgvRowsAdd(31,lBarragePartie[7]);

                    // Mise a jour des disponibles -  1er de poule
                    SetDispo( 32, new int[] { 1, 8, 9, 16 });

                    // Mise a jour des futur
                    lb_Futur1.Text = SingletonOutils.GetNomExcel( 32, 21);
                    lb_Futur2.Text = SingletonOutils.GetNomExcel( 32, 2);
                    lbArbitre1.Text = sArbitre + SingletonOutils.GetNomExcel(32, 2);

                    // 7 contre Perdant Barrage  2
                    lb_Futur3.Text = SingletonOutils.GetNomExcel( 33, 22);
                    lb_Futur4.Text = SingletonOutils.GetNomExcel( 33, 8);
                    lbArbitre2.Text = sArbitre + SingletonOutils.GetNomExcel( 33, 7);

                    // 10 contre Perdant Barrage  3
                    lb_Futur5.Text = SingletonOutils.GetNomExcel( 34, 9);
                    lb_Futur6.Text = SingletonOutils.GetNomExcel( 34, 23);
                    lbArbitre3.Text = sArbitre + SingletonOutils.GetNomExcel( 34, 10);

                    // 15 contre Perdant Barrage  4
                    lb_Futur7.Text = SingletonOutils.GetNomExcel( 35, 24);
                    lb_Futur8.Text = SingletonOutils.GetNomExcel( 35, 16);
                    lbArbitre4.Text = sArbitre + SingletonOutils.GetNomExcel( 35, 15);
                    #endregion
                    break;

                case 2:
                    #region Partie 2 en cours

                    // Copie des nom des joueurs dans la liste des SingletonOutils.lIdJoueurExcel
                    // pour les paties précédantes

                    /* Le joueur qui ont gagné
                    SingletonOutils.SetNom(25, 2, 29, 17, DgvPartie, 0);
                    SingletonOutils.SetNom(26, 18, 30, 7, DgvPartie, 1);
                    SingletonOutils.SetNom(27, 10, 31, 19, DgvPartie,2);
                    SingletonOutils.SetNom(28, 20, 32, 15, DgvPartie, 3);
                    */

                    DgvRowsAdd(32,lBarragePartie[8]);
                    DgvRowsAdd(33,lBarragePartie[9]);
                    DgvRowsAdd(34,lBarragePartie[10]);
                    DgvRowsAdd(35,lBarragePartie[11]);

                    // Mise a jour des disponibles - 5 à 8
                    SetDispo( 36, new int[] { 17, 18, 19, 20 });

                    // Mise a jour des futur
                    lb_Futur1.Text = SingletonOutils.GetNomExcel(36, 25);
                    lb_Futur2.Text = SingletonOutils.GetNomExcel(36, 26);
                    lbArbitre1.Text = sArbitre + SingletonOutils.GetNomExcel(36, 33);

                    // 7 contre Perdant Barrage  2
                    lb_Futur3.Text = SingletonOutils.GetNomExcel(37, 27);
                    lb_Futur4.Text = SingletonOutils.GetNomExcel(37,28);
                    lbArbitre2.Text = sArbitre + SingletonOutils.GetNomExcel(37,34);

                    // 10 contre Perdant Barrage  3
                    lb_Futur5.Text = SingletonOutils.GetNomExcel(38,29);
                    lb_Futur6.Text = SingletonOutils.GetNomExcel(38,30);
                    lbArbitre3.Text = sArbitre + SingletonOutils.GetNomExcel(38, 35);

                    // 15 contre Perdant Barrage  4
                    lb_Futur7.Text = SingletonOutils.GetNomExcel(39, 31);
                    lb_Futur8.Text = SingletonOutils.GetNomExcel(39,32);
                    lbArbitre4.Text = sArbitre + SingletonOutils.GetNomExcel(39,36);
                    #endregion
                    break;

                case 3:
                    #region Partie 3 en cours

                    // Copie des nom des joueurs dans la liste des SingletonOutils.lIdJoueurExcel
                    // pour les paties précédantes

                    /* Le joueur qui ont gagné
                    SingletonOutils.SetNom(33, 1, 37, 21, DgvPartie, 0);
                    SingletonOutils.SetNom(34, 22, 38, 8, DgvPartie, 1);
                    SingletonOutils.SetNom(35, 9, 39, 23, DgvPartie, 2);
                    SingletonOutils.SetNom(36, 24, 40, 16, DgvPartie, 3);
                    */

                    // Mise a jour de l'affichage
                    DgvRowsAdd(36,lBarragePartie[12]);
                    DgvRowsAdd(37,lBarragePartie[13]);
                    DgvRowsAdd(38,lBarragePartie[14]);
                    DgvRowsAdd(39,lBarragePartie[15]);


                    // Mise a jour des disponibles - 5 à 8
                    SetDispo( 40, new int[] { 37, 38, 39, 40 });

                    // Mise a jour des futur
                    lb_Futur1.Text = SingletonOutils.GetNomExcel(40,33);
                    lb_Futur2.Text = SingletonOutils.GetNomExcel(40,34);
                    lbArbitre1.Text = sArbitre + SingletonOutils.GetNomExcel(40,17);

                    // 7 contre Perdant Barrage  2
                    lb_Futur3.Text = SingletonOutils.GetNomExcel(41,35);
                    lb_Futur4.Text = SingletonOutils.GetNomExcel(41,36);
                    lbArbitre2.Text = sArbitre + SingletonOutils.GetNomExcel(41,18);

                    // 10 contre Perdant Barrage  3
                    lb_Futur5.Text = SingletonOutils.GetNomExcel(42,37);
                    lb_Futur6.Text = SingletonOutils.GetNomExcel(42,38);
                    lbArbitre3.Text = sArbitre + SingletonOutils.GetNomExcel(42,19);

                    // 15 contre Perdant Barrage  4
                    lb_Futur7.Text = SingletonOutils.GetNomExcel(43,39);
                    lb_Futur8.Text = SingletonOutils.GetNomExcel(43,40);
                    lbArbitre4.Text = sArbitre + SingletonOutils.GetNomExcel(43,20);

                    #endregion
                    break;

                case 4:
                    #region Partie 4 en cours

                    /* Copie des nom des joueurs dans la liste des SingletonOutils.lIdJoueurExcel
                    // pour les paties précédantes

                    // Le joueur qui ont gagné
                    SingletonOutils.SetNom(41, 25, 43, 26, DgvPartie, 0);
                    SingletonOutils.SetNom(42, 27, 44, 28, DgvPartie, 1);
                    SingletonOutils.SetNom(45, 29, 47, 30, DgvPartie, 2);
                    SingletonOutils.SetNom(46, 31, 48, 32, DgvPartie, 3);
                    */

                    // Mise a jour de l'affichage
                    DgvRowsAdd(40,lBarragePartie[16]);
                    DgvRowsAdd(41,lBarragePartie[17]);
                    DgvRowsAdd(42,lBarragePartie[18]);
                    DgvRowsAdd(43,lBarragePartie[19]);


                    // Mise a jour des disponibles - Perdant des barrages
                    SetDispo( 44, new int[] { 2, 7, 10, 15 });

                    // Mise a jour des futur
                    lb_Futur1.Text = SingletonOutils.GetNomExcel(44,41);
                    lb_Futur2.Text = SingletonOutils.GetNomExcel(44,42);
                    lbArbitre1.Text = sArbitre + SingletonOutils.GetNomExcel(44,53);

                    // 7 contre Perdant Barrage  2
                    lb_Futur3.Text = SingletonOutils.GetNomExcel(45,43);
                    lb_Futur4.Text = SingletonOutils.GetNomExcel(45,44);
                    lbArbitre2.Text = sArbitre + SingletonOutils.GetNomExcel(45,54);

                    // 10 contre Perdant Barrage  3
                    lb_Futur5.Text = SingletonOutils.GetNomExcel(46,45);
                    lb_Futur6.Text = SingletonOutils.GetNomExcel(46,46);
                    lbArbitre3.Text = sArbitre + SingletonOutils.GetNomExcel(46,55);

                    // 15 contre Perdant Barrage  4
                    lb_Futur7.Text = SingletonOutils.GetNomExcel(47,47);
                    lb_Futur8.Text = SingletonOutils.GetNomExcel(47,48);
                    lbArbitre4.Text = sArbitre + SingletonOutils.GetNomExcel(47,56);

                    #endregion
                    break;

                case 5:
                    #region Partie 5 en cours

                    /* Copie des nom des joueurs dans la liste des SingletonOutils.lIdJoueurExcel
                    // pour les paties précédantes

                    // Le joueur qui ont gagné
                    SingletonOutils.SetNom(49, 33, 51, 34, DgvPartie, 0);
                    SingletonOutils.SetNom(50, 35, 52, 36, DgvPartie, 1);
                    SingletonOutils.SetNom(53, 37, 55, 38, DgvPartie, 2);
                    SingletonOutils.SetNom(54, 39, 56, 40, DgvPartie, 3);
                    */

                    // Mise a jour de l'affichage
                    DgvRowsAdd(44,lBarragePartie[20]);
                    DgvRowsAdd(45,lBarragePartie[21]);
                    DgvRowsAdd(46,lBarragePartie[22]);
                    DgvRowsAdd(47,lBarragePartie[23]);

                    // Mise a jour des disponibles
                    // Les finalistes
                    SetDispo( 48, new int[] { 49, 50, 51, 52 });

                    // Mise a jour des futur
                    lb_Futur1.Text = SingletonOutils.GetNomExcel(48,49);
                    lb_Futur2.Text = SingletonOutils.GetNomExcel(48,50);
                    lbArbitre1.Text = sArbitre + SingletonOutils.GetNomExcel(48,43);

                    // 7 contre Perdant Barrage  2
                    lb_Futur3.Text = SingletonOutils.GetNomExcel(49,51);
                    lb_Futur4.Text = SingletonOutils.GetNomExcel(49,52);
                    lbArbitre2.Text = sArbitre + SingletonOutils.GetNomExcel(49,44);

                    // 10 contre Perdant Barrage  3
                    lb_Futur5.Text = SingletonOutils.GetNomExcel(50,53);
                    lb_Futur6.Text = SingletonOutils.GetNomExcel(50,54);
                    lbArbitre3.Text = sArbitre + SingletonOutils.GetNomExcel(50,47);

                    // 15 contre Perdant Barrage  4
                    lb_Futur7.Text = SingletonOutils.GetNomExcel(51,55);
                    lb_Futur8.Text = SingletonOutils.GetNomExcel(51,56);
                    lbArbitre4.Text = sArbitre + SingletonOutils.GetNomExcel(51,48);

                    #endregion
                    break;

                case 6:
                    #region Partie 6 en cours

                    /* Copie des nom des joueurs dans la liste des SingletonOutils.lIdJoueurExcel
                    // pour les paties précédantes
                    // Le joueur qui ont gagné
                    SingletonOutils.SetNom(65, 41, 66, 42, DgvPartie, 0);
                    SingletonOutils.SetNom(67, 43, 68, 44, DgvPartie, 1);
                    SingletonOutils.SetNom(69, 45, 70, 46, DgvPartie, 2);
                    SingletonOutils.SetNom(71, 47, 72, 48, DgvPartie, 3);
                    */

                    // Mise a jour de l'affichage
                    DgvRowsAdd(48,lBarragePartie[24]);
                    DgvRowsAdd(49,lBarragePartie[25]);
                    DgvRowsAdd(50,lBarragePartie[26]);
                    DgvRowsAdd(51,lBarragePartie[27]);

                    // Mise a jour des disponibles - Places 9 à 12
                    SetDispo( 51, new int[] { 25, 26, 27, 28 });

                    // Mise a jour des futur
                    lb_Futur7.Text = lb_Futur5.Text = lb_Futur3.Text = lb_Futur1.Text = string.Empty;
                    lb_Futur8.Text = lb_Futur6.Text = lb_Futur4.Text = lb_Futur2.Text = string.Empty;
                    lbArbitre4.Text = lbArbitre3.Text = lbArbitre2.Text = lbArbitre1.Text = string.Empty;

                    #endregion
                    break;

                case 7:
                    #region Partie 7 en cours
                    this.Text = "Classement terminé";
                    // Mise a jour du titre des parties futures
                    groupBox1.Text = "Plus de partie à jouer";

                    /* Copie des nom des joueurs dans la liste des SingletonOutils.lIdJoueurExcel
                    // pour les paties précédantes

                    // Le joueur qui ont gagné
                    SingletonOutils.SetNom(57, 49, 58, 50, DgvPartie, 0);
                    SingletonOutils.SetNom(59, 51, 60, 52, DgvPartie, 1);
                    SingletonOutils.SetNom(61, 53, 62, 54, DgvPartie, 2);
                    SingletonOutils.SetNom(63, 55, 64, 56, DgvPartie, 3);
                    */

                    // Mise a jour des futur
                    lb_Futur7.Text = lb_Futur5.Text = lb_Futur3.Text = lb_Futur1.Text = string.Empty;
                    lb_Futur8.Text = lb_Futur6.Text = lb_Futur4.Text = lb_Futur2.Text = string.Empty;
                    lbArbitre4.Text = lbArbitre3.Text = lbArbitre2.Text = lbArbitre1.Text = string.Empty;

                    // Mise a jour des disponibles
                    // Dispo
                    dataGridViewDispo.Rows.Clear();

                    Btnsuivant.Enabled = false;
                    #endregion
                    break;
            }

            Btnsuivant.Enabled = false;
        }

        private void SetDispo( int Ip, int[] aJ)
        {
            int j = 0;
            foreach (int i in aJ)
            {
                dataGridViewDispo.Rows.Add(SingletonOutils.GetNomExcel(Ip + j, i));
                j++;
            }
        }

        private void DgvRowsAdd( int Ip, BarragePartie barragePartie)
        {
            // Mise à jour des joueurs et de l'arbitre pour la partie
            CrudPartie.UpdateJoueur(
                barragePartie.sPartie, 
                SingletonOutils.lIdJoueurExcel[barragePartie.iJoueur1],
                SingletonOutils.lIdJoueurExcel[barragePartie.iJoueur2],
                SingletonOutils.lIdJoueurExcel[barragePartie.iArbitre]
            );

            // Un des 2 joueurs a t'il déjà abandonnée
            CrudPartie.PropageAbandon( 
                SingletonOutils.GetIndexPartie(barragePartie.sPartie),
                SingletonOutils.lIdJoueurExcel[barragePartie.iJoueur1],
                SingletonOutils.lIdJoueurExcel[barragePartie.iJoueur2]
            );

            Partie partie = CrudPartie.GetPartie(barragePartie.sPartie);

            DgvPartie.Rows.Add(barragePartie.sPartie, 
                partie.Abandon1, 
                SingletonOutils.GetNomExcel(Ip, barragePartie.iJoueur1), 
                SingletonOutils.GetNomExcel(Ip, barragePartie.iJoueur2), 
                partie.Abandon2, 
                partie.Score1, partie.Score2, partie.Score3, partie.Score4, partie.Score5,
                SingletonOutils.GetNomExcel(Ip, barragePartie.iArbitre)
            );

            SetVainqueurPartie(DgvPartie.Rows.Count-1);
        }   
        
        private void Btnsuivant_Click(object sender, EventArgs e)
        {
            // Plus de modification du tirage au sort
            gbTirageAuSort.Visible = false;

            // 7 Titre
            if (iPartieEnCours < sTitre.Length)
            {
                iPartieEnCours++;

                // Affichage de la partie suivat
                SetPartie();
            }
        }

        private void DgvPartie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pas de click sur le header
            if (e.RowIndex == -1) return;

            switch (e.ColumnIndex)
            {
                case 0: // Affichage de l'arbitre
                    MessageBox.Show( sArbitre + DgvPartie.Rows[e.RowIndex].Cells[10].Value.ToString(), "Partie : " + DgvPartie.Rows[e.RowIndex].Cells[0].Value.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 1:
                    Dgv_CellClick( e.RowIndex, 1);
                    break;

                case 4:
                    Dgv_CellClick( e.RowIndex, 4);
                    break;

                case iColScore:
                case iColScore + 1:
                case iColScore + 2:
                case iColScore + 3:
                case iColScore + 4:
                    // Gestion des Forfait Abandon, pas de saise de points
                    if ((bool)DgvPartie.Rows[e.RowIndex].Cells[1].Value || (bool)DgvPartie.Rows[e.RowIndex].Cells[4].Value)
                        MessageBox.Show("Pas de saisie de score pour les Forfait ou Abandon !");
                    else
                        GetScore(e.RowIndex);
                    break;
            }
        }

        private void Dgv_CellClick(int iRow, int iCol)
        {
            bool b1 = DgvPartie.Rows[iRow].Cells[1].Value == null ? true : ((bool)DgvPartie.Rows[iRow].Cells[1].Value);
            bool b4 = DgvPartie.Rows[iRow].Cells[4].Value == null ? true : ((bool)DgvPartie.Rows[iRow].Cells[4].Value);

            // Colonne Forfait, Abandon
            if (iCol == 1)
            {
                b1 = !b1;
                
                // La case Forfait / Abandon est cocher
                DgvPartie.Rows[iRow].Cells[1].Value = b1;

                // et saisir le score
                if (b1)
                    setForfaitAndVainqueur(iRow, "-00");
                else
                    setForfaitAndVainqueur(iRow, "/");
            }

            if (iCol == 4)
            {
                b4 = !b4;
                DgvPartie.Rows[iRow].Cells[4].Value = b4;

                // Cocher la case Forfait / Abandon
                DgvPartie.Rows[iRow].Cells[4].Value = b4;

                // et saisir le score
                if (b4)
                    setForfaitAndVainqueur( iRow, "00");
                else
                    setForfaitAndVainqueur( iRow, "/");
            }
        }

        private void GetScore(int iRow)
        {
            string sJoueurs = "Partie : " + DgvPartie.Rows[iRow].Cells[0].Value + Environment.NewLine +
            DgvPartie.Rows[iRow].Cells[1].Value + Environment.NewLine +
            "contre" + Environment.NewLine +
            DgvPartie.Rows[iRow].Cells[2].Value;

            string[] aScore = new string[5];
            string s;

            // Récupération des score déjà saisie
            for (int i = iColScore; i < iColScore + 5; i++)
            {
                if (DgvPartie.Rows[iRow].Cells[i].Value is null || DgvPartie.Rows[iRow].Cells[i].Value.ToString() == "/")
                    aScore[i - iColScore] = "/";
                else
                    aScore[i - iColScore] = DgvPartie.Rows[iRow].Cells[i].Value.ToString();
            }

            // Affichage de la saisie des scores
            formSaisieScore = new FormSaisieScore(sJoueurs, aScore);

            if (formSaisieScore.ShowDialog() == DialogResult.OK)
            {
                // Forfait / Abandon
                if (formSaisieScore.bAbandon1)
                {
                    // Cocher la case Forfait / Abandon
                    DgvPartie.Rows[iRow].Cells[1].Value = true;

                    Dgv_CellClick(iRow, 1);
                }

                if (formSaisieScore.bAbandon2)
                {
                    // Cocher la case Forfait / Abandon
                    DgvPartie.Rows[iRow].Cells[4].Value = true;

                    Dgv_CellClick(iRow, 4);
                }

                // Mise en couleur des scores
                for (int i = 0; i < 5; i++)
                {
                    s = formSaisieScore.aScore[i];

                    DgvPartie.Rows[iRow].Cells[i + iColScore].Value = s;
                    switch (s[0])
                    {
                        case '-':
                            DgvPartie.Rows[iRow].Cells[i + iColScore].Style.BackColor = SingletonOutils.cPerdue;
                            break;

                        case '/':
                            DgvPartie.Rows[iRow].Cells[i + iColScore].Style.BackColor = SingletonOutils.cNull;
                            break;

                        default:
                            DgvPartie.Rows[iRow].Cells[i + iColScore].Style.BackColor = SingletonOutils.cGagnee;
                            break;
                    }
                }

                SetVainqueurPartie(iRow);
            }
        }

        // Positionne le score pour le forfait ou l'abandon et met en Gras le nom du vainqueur
        private void setForfaitAndVainqueur(int iRow, string sScore)
        {
            bool b2Forfait = false;

            // Les 2 joueurs sont Forfait/Abandon
            if ((bool)DgvPartie.Rows[iRow].Cells[1].Value && (bool)DgvPartie.Rows[iRow].Cells[4].Value)
            { sScore = "/"; b2Forfait = true; }

            DgvPartie.Rows[iRow].Cells[iColScore].Value = sScore;
            DgvPartie.Rows[iRow].Cells[iColScore + 1].Value = sScore;
            DgvPartie.Rows[iRow].Cells[iColScore + 2].Value = sScore;
            DgvPartie.Rows[iRow].Cells[iColScore + 3].Value = "/";
            DgvPartie.Rows[iRow].Cells[iColScore + 4].Value = "/";

            SetVainqueurPartie(iRow, b2Forfait);
        }

        private void SetVainqueurPartie( int iRow, bool b2Forfait=false)
        {
            // Mise a jour des points partie
            string sRencontre = DgvPartie.Rows[iRow].Cells[0].Value.ToString();
            int i = 0;

            for (; i < lBarragePartie.Count(); i++)
            {
                if (lBarragePartie[i].sPartie == sRencontre)
                    break;
            }

            // Remise a blanc des cellulles
            switch (SingletonOutils.GetMancheNegative(DgvPartie, iRow, iColScore))
            {
                case 3:
                    // Partie perdu
                    // Mise en gras du vainqueur
                    SetPointPartie( iRow, lBarragePartie[i].iJoueur1, lBarragePartie[i].iJoueur2, false);
                    break;

                case 99:
                    // Supprime la couleur sur le nom
                    SetPointPartie( iRow, lBarragePartie[i].iJoueur1, lBarragePartie[i].iJoueur2, true);
                    if(b2Forfait)
                    {
                        SingletonOutils.SetColorNull(DgvPartie, iRow, 2);
                        SingletonOutils.SetColorNull(DgvPartie, iRow, 3);
                    }
                    else
                    {
                        SingletonOutils.SetColorWhite(DgvPartie, iRow, 2);
                        SingletonOutils.SetColorWhite(DgvPartie, iRow, 3);
                    }

                    break;

                default:
                    // Partie gagnée
                    // Mise en gras du vainqueur
                    SetPointPartie( iRow, lBarragePartie[i].iJoueur1, lBarragePartie[i].iJoueur2, true);
                    break;
            }

            // Copie des nom des joueurs dans la liste des SingletonOutils.lIdJoueurExcel
            // Pour les vainqueur et perdant des parties précédantes
            SingletonOutils.SetNom(lBarragePartie[i].iDestinationGagnant, lBarragePartie[i].iJoueur1, lBarragePartie[i].iDestinationPerdant, lBarragePartie[i].iJoueur2, DgvPartie, iRow);

            // Les 4 partie sont-elles jouer ?
            int iReponce = 0;
            for( i = 0; i < DgvPartie.Rows.Count; i++)
            {
                // Une des case Abandon, Forfait est cochées
                if ( DgvPartie.Rows[i].Cells[2].Style.BackColor != DgvPartie.Rows[0].Cells[0].Style.BackColor)
                    iReponce++;

            }
            // Les 4 partie sont jouées
            if (iReponce == 4)
            {
                Btnsuivant.Enabled = true;
                bt_precedent.Enabled = (iPartieEnCours > 1);
            }
        }

        /*
         * Ecriture des points partie pour la partie iRow
         * et mise à jour du score Point Partie 
         * et prise en compte des Forfaits et Abandon
         */
        private void SetPointPartie(int iRow, int iJoueur1, int iJoueur2, bool bFirst)
        {
            bool b1 = (bool)DgvPartie.Rows[iRow].Cells[1].Value;
            bool b4 = (bool)DgvPartie.Rows[iRow].Cells[4].Value;

            // Premier joueur forfait
            if (b1)
            {
                SetForfaitAbandon(DgvPartie, iRow, 2, true);
                SingletonOutils.SetColorPerdue(DgvPartie, iRow, 2);
                SingletonOutils.SetColorGagnee(DgvPartie, iRow, 3);

                // Deuxiéme joueur Forfait
                if (b4)
                {
                    SetForfaitAbandon(DgvPartie, iRow, 3, true);
                    SingletonOutils.SetColorNull(DgvPartie, iRow, 2);
                    SingletonOutils.SetColorNull(DgvPartie, iRow, 3);
                }
                else
                {
                    SetForfaitAbandon(DgvPartie, iRow, 3, false);
                }
            }
            else
            {
                SetForfaitAbandon(DgvPartie, iRow, 2, false);
                SingletonOutils.SetColorGagnee(DgvPartie, iRow, 2);

                if (b4)
                {
                    SetForfaitAbandon(DgvPartie, iRow, 3, true);
                    SingletonOutils.SetColorPerdue(DgvPartie, iRow, 3);
                }
                else
                {
                    // Pas de forfait
                    SetForfaitAbandon(DgvPartie, iRow, 3, false);

                    if (bFirst)
                    {
                        SingletonOutils.SetColorPerdue(DgvPartie, iRow, 3);
                    }
                    else
                    {
                        SingletonOutils.SetColorPerdue(DgvPartie, iRow, 2);
                        SingletonOutils.SetColorGagnee(DgvPartie, iRow, 3);
                    }
                }
            }
        }

        // Ajout du Tag (A) dernière le nom du joueur
        private void SetForfaitAbandon(DataGridView dgv, int iRow, int iCol = 2, bool bAbandon = true)
        {
            // Recherche du nom du Joueur
            string strNom = dgv.Rows[iRow].Cells[iCol].Value.ToString();
            string sPartie = dgv.Rows[iRow].Cells[0].Value.ToString();
            int i;

            // Recherche du numéro de partie

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

        private void DgvPartie_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pas de click sur le header
            if (e.RowIndex == -1) return;

            switch (e.ColumnIndex)
            {
                case 2:
                    DgvPartie.Rows[e.RowIndex].Cells[5].Value = "1";
                    DgvPartie.Rows[e.RowIndex].Cells[5].Style.BackColor = SingletonOutils.cGagnee;

                    DgvPartie.Rows[e.RowIndex].Cells[6].Value = "1";
                    DgvPartie.Rows[e.RowIndex].Cells[6].Style.BackColor = SingletonOutils.cGagnee;

                    DgvPartie.Rows[e.RowIndex].Cells[7].Value = "1";
                    DgvPartie.Rows[e.RowIndex].Cells[7].Style.BackColor = SingletonOutils.cGagnee;

                    SetVainqueurPartie(e.RowIndex);
                    break;

                case 3:
                    DgvPartie.Rows[e.RowIndex].Cells[5].Value = "-1";
                    DgvPartie.Rows[e.RowIndex].Cells[5].Style.BackColor = SingletonOutils.cPerdue;

                    DgvPartie.Rows[e.RowIndex].Cells[6].Value = "-1";
                    DgvPartie.Rows[e.RowIndex].Cells[6].Style.BackColor = SingletonOutils.cPerdue;

                    DgvPartie.Rows[e.RowIndex].Cells[7].Value = "-1";
                    DgvPartie.Rows[e.RowIndex].Cells[7].Style.BackColor = SingletonOutils.cPerdue;

                    SetVainqueurPartie(e.RowIndex);
                    break;
            }
        }
    }
}