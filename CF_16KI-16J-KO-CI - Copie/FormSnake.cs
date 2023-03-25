/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
using CF_16KI_16J_KO_CI.Modeles;

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

// The following to two namespace contains
// the functions for manipulating the
// Excel file 
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;
using System.Data.SQLite;
using CF_16KI_16J_KO_CI.CRUD;

namespace CF_16KI_16J_KO_CI
{
    public partial class FormSnake : Form
    {
        private int iNbrMaxJoueur = 1;

        // Gestion du drag and drop dans les datagridview
        private Rectangle dragBoxFromMouseDown;
        private int iDragOrigine = 0;
        private int[] rowIndexFromMouseDown = new int[5];
        private int[] rowIndexOfItemUnderMouseToDrop = new int[5];

        public FormSnake()
        {
            InitializeComponent();

            // Couleur sélectionnée pour le fond du formulaire
            this.BackColor = SingletonOutils.BackColor;

            Text = "Mise en poule ( " + SingletonOutils.GetCompetition() + " )";

            txtMessages.Clear();

            // Recherche du nombre de joueur par club
            foreach (var line in SingletonOutils.lJoueurs.GroupBy(info => info.Club)
                        .Select(group => new {
                            Metric = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Metric))
            {
                switch(line.Count) 
                {
                    case 1:
                    case 2:
                    case 3:
                        break;

                    case 4:
                        txtMessages.Text = "Club : " + line.Metric + " -> 4 joueurs donc un par poule." + Environment.NewLine ;
                        iNbrMaxJoueur = 4;
                        break;

                    case 5:
                    case 6: 
                    case 7: 
                    case 8:
                        iNbrMaxJoueur = line.Count;
                        txtMessages.Text = "Club : " + line.Metric + " -> plus 4 joueurs donc une ou plusieurs poules avec 2 joueurs." + Environment.NewLine;
                        break;

                    case 9:
                    case 10:
                    case 11:
                    case 12:
                        iNbrMaxJoueur = line.Count;
                        txtMessages.Text = "Club : " + line.Metric + " -> plus de 8 joueurs donc deux par poule." + Environment.NewLine;
                        break;

                    case 13:
                    case 14:
                    case 15:
                    case 16:
                        iNbrMaxJoueur = line.Count;
                        txtMessages.Text = "Club : " + line.Metric + " -> beaucoup trop de joueur du même club vérifier le fichier en entré." + Environment.NewLine;
                        break;

                }
            }

            // Affichage des groupes non modifié
            AfficheGroupe();
        }

        private void AfficheGroupe()
        {
            bool bRet = false;

            DgvGroupe1.Rows.Clear();
            DgvGroupe2.Rows.Clear();
            DgvGroupe3.Rows.Clear();
            DgvGroupe4.Rows.Clear();

            // Positionnement des joueurs dans les poules
            // Rang Joueur dossard club selon l'ordre du serpent

            AddInGroupe(DgvGroupe1, "1", 1, 'A', 1);
            AddInGroupe(DgvGroupe2, "1", 2, 'B', 1);
            AddInGroupe(DgvGroupe3, "1", 3, 'C', 1);
            AddInGroupe(DgvGroupe4, "1", 4, 'D', 1);
           /*-------------------------------------------------------*/
            AddInGroupe(DgvGroupe4, "2", 5, 'D', 2);
            AddInGroupe(DgvGroupe3, "2", 6, 'C', 2);
            AddInGroupe(DgvGroupe2, "2", 7, 'B', 2);
            AddInGroupe(DgvGroupe1, "2", 8, 'A', 2);
            /*-------------------------------------------------------*/
            AddInGroupe(DgvGroupe1, "3", 9, 'A', 3);
            AddInGroupe(DgvGroupe2, "3", 10, 'B', 3);
            AddInGroupe(DgvGroupe3, "3", 11, 'C', 3);
            AddInGroupe(DgvGroupe4, "3", 12, 'D', 3);
            /*-------------------------------------------------------*/
            AddInGroupe(DgvGroupe4, "4", 13, 'D', 4);
            AddInGroupe(DgvGroupe3, "4", 14, 'C', 4);
            AddInGroupe(DgvGroupe2, "4", 15, 'B', 4);
            AddInGroupe(DgvGroupe1, "4", 16, 'A', 4);

            bRet |= RechercheDoublonClub(DgvGroupe1);
            bRet |= RechercheDoublonClub(DgvGroupe2);
            bRet |= RechercheDoublonClub(DgvGroupe3);
            bRet |= RechercheDoublonClub(DgvGroupe4);

            BtnCorrige.Enabled = bRet;
        }

        // Ajout d'un joueur dans un groupe
        public void AddInGroupe(DataGridView dgv, string sRang, int j,  char cPoule, int iNumInPoule) 
        { 
            dgv.Rows.Add(sRang, SingletonOutils.lJoueurs[j].GetNom(0), SingletonOutils.lJoueurs[j].Dossard, SingletonOutils.lJoueurs[j].Club);
            SingletonOutils.lJoueurs[j].Poule = cPoule;
            SingletonOutils.lJoueurs[j].NumInPoule = iNumInPoule;
        }

        public bool RechercheDoublonClub(DataGridView dgv)
        {
            string Value1, Value2, Value3, Value4;
            bool bRet = false;

            // Nom du Club
            Value1 = dgv.Rows[0].Cells[3].Value.ToString();
            Value2 = dgv.Rows[1].Cells[3].Value.ToString();
            Value3 = dgv.Rows[2].Cells[3].Value.ToString();
            Value4 = dgv.Rows[3].Cells[3].Value.ToString();

            // Si même club 1 et 2 
            if (Value1 == Value2 && Value1.Length > 0)
            {
                CellRed(dgv, 0, 1);
                bRet |= true;
            }
            // Si même club 1 et 3
            if (Value1 == Value3 && Value1.Length > 0)
            {
                CellRed(dgv, 0, 2);
                bRet |= true;
            }
            // Si même club 1 et 4
            if (Value1 == Value4 && Value1.Length > 0)
            {
                CellRed(dgv, 0, 3);
                bRet |= true;
            }
            // Si même club 2 et 3
            if (Value2 == Value3 && Value2.Length > 0)
            {
                CellRed(dgv, 1, 2);
                bRet |= true;
            }
            // Si même club 2 et 4
            if (Value2 == Value4 && Value2.Length > 0)
            {
                CellRed(dgv, 1, 3);
                bRet |= true;
            }
            // Si même club 3 et 4 
            if (Value3 == Value4 && Value3.Length > 0)
            {
                CellRed(dgv, 2, 3);
                bRet |= true;
            }

            return bRet;
        }

        public void CellRed(DataGridView dgv, int i, int j)
        {
            dgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            dgv.Rows[j].DefaultCellStyle.BackColor = Color.Red;
        }

        // Correction du serpent
        private void BtnCorrige_Click(object sender, EventArgs e)
        {
            // On efface les messages
            txtMessages.Text = "";

            int iNbr = SingletonOutils.NbrLJoueur();

            while (DeplacementDansListe(iNbr)) ;

            // Mise a jour de la table joueur avec la poule et le numéro dans la poule
            // a partir du numéro de dossard colonne 3
            for (int i = 0; i < DgvGroupe1.Rows.Count; i++)
                CrudJoueur.UpdatePouleNum('A', i + 1, (int)DgvGroupe1.Rows[i].Cells[2].Value);

            for (int i = 0; i < DgvGroupe2.Rows.Count; i++)
                CrudJoueur.UpdatePouleNum('B', i + 1, (int)DgvGroupe2.Rows[i].Cells[2].Value);


            for (int i = 0; i < DgvGroupe3.Rows.Count; i++)
                CrudJoueur.UpdatePouleNum('C', i + 1, (int)DgvGroupe3.Rows[i].Cells[2].Value);

            for (int i = 0; i < DgvGroupe4.Rows.Count; i++)
                CrudJoueur.UpdatePouleNum('D', i + 1, (int)DgvGroupe4.Rows[i].Cells[2].Value);

            // Faire jouer les partie dans les premier tour

            // Afficher les modifications
            AfficheGroupe();
        }

        private bool DeplacementDansListe(int iNbr)
        {
            /*
             * *----*----*----*----*
             * |  1 |  2 |  3 |  4 |  -->
             * *----*----*----*----*
             * |  8 |  7 |  6 |  5 |  <--
             * *----*----*----*----*
             * |  9 | 10 | 11 | 12 |  -->
             * *----*----*----*----*
             * | 16 | 15 | 14 | 13 |  <--
             * *----*----*----*----*
             */

            // Pour les 4 premier joueurs aucun déplacement

            # region Ligne 2
            // Deuxiéme ligne 
            if (SingletonOutils.lJoueurs[5].Club == SingletonOutils.lJoueurs[4].Club)
            {
                InverserJoueur(5, 6);
                return true;
            }

            if (SingletonOutils.lJoueurs[6].Club == SingletonOutils.lJoueurs[3].Club)
            {
                InverserJoueur(6, 7);
                return true;
            }

            if (SingletonOutils.lJoueurs[7].Club == SingletonOutils.lJoueurs[2].Club)
            {
                InverserJoueur(7, 8);
                return true;
            }

            if (SingletonOutils.lJoueurs[8].Club == SingletonOutils.lJoueurs[1].Club)
            {
                InverserJoueur(8, 9);
                return true;
            }
            #endregion

            #region Ligne 3
            if (SingletonOutils.lJoueurs[9].Club == SingletonOutils.lJoueurs[1].Club || SingletonOutils.lJoueurs[9].Club == SingletonOutils.lJoueurs[8].Club)
            {
                InverserJoueur(9, 10);
                return true;
            }

            if (SingletonOutils.lJoueurs[10].Club == SingletonOutils.lJoueurs[2].Club || SingletonOutils.lJoueurs[10].Club == SingletonOutils.lJoueurs[7].Club)
            {
                InverserJoueur(10, 11);
                return true;
            }

            if (SingletonOutils.lJoueurs[11].Club == SingletonOutils.lJoueurs[3].Club || SingletonOutils.lJoueurs[11].Club == SingletonOutils.lJoueurs[6].Club)
            {
                InverserJoueur(11, 12);
                return true;
            }

            if (SingletonOutils.lJoueurs[12].Club == SingletonOutils.lJoueurs[5].Club || SingletonOutils.lJoueurs[12].Club == SingletonOutils.lJoueurs[4].Club)
            {
                InverserJoueur(12, 13);
                return true;
            }
            #endregion

            #region Ligne 4
            if (SingletonOutils.lJoueurs[13].Club == SingletonOutils.lJoueurs[12].Club || 
                SingletonOutils.lJoueurs[13].Club == SingletonOutils.lJoueurs[5].Club || 
                SingletonOutils.lJoueurs[13].Club == SingletonOutils.lJoueurs[4].Club)
            {
                InverserJoueur(13, 14);
                return true;
            }

            if (SingletonOutils.lJoueurs[14].Club == SingletonOutils.lJoueurs[11].Club || 
                SingletonOutils.lJoueurs[14].Club == SingletonOutils.lJoueurs[6].Club || 
                SingletonOutils.lJoueurs[14].Club == SingletonOutils.lJoueurs[3].Club)
            {
                InverserJoueur(14, 15);
                return true;
            }

            if (SingletonOutils.lJoueurs[15].Club == SingletonOutils.lJoueurs[10].Club ||
                SingletonOutils.lJoueurs[15].Club == SingletonOutils.lJoueurs[7].Club || 
                SingletonOutils.lJoueurs[15].Club == SingletonOutils.lJoueurs[2].Club)
            {
                InverserJoueur(15, 16);
                return true;
            }

            if (SingletonOutils.lJoueurs[16].Club == SingletonOutils.lJoueurs[9].Club || 
                SingletonOutils.lJoueurs[16].Club == SingletonOutils.lJoueurs[8].Club || 
                SingletonOutils.lJoueurs[16].Club == SingletonOutils.lJoueurs[1].Club)
            {
                InverserJoueur(15, 16);
                if (SingletonOutils.lJoueurs[15].Club == SingletonOutils.lJoueurs[10].Club || 
                    SingletonOutils.lJoueurs[15].Club == SingletonOutils.lJoueurs[7].Club || 
                    SingletonOutils.lJoueurs[15].Club == SingletonOutils.lJoueurs[2].Club)
                {
                    InverserJoueur(14, 15);
                    if (SingletonOutils.lJoueurs[14].Club == SingletonOutils.lJoueurs[11].Club || 
                        SingletonOutils.lJoueurs[14].Club == SingletonOutils.lJoueurs[6].Club || 
                        SingletonOutils.lJoueurs[14].Club == SingletonOutils.lJoueurs[3].Club)
                    {
                        InverserJoueur(13, 14);
                        if (SingletonOutils.lJoueurs[13].Club == SingletonOutils.lJoueurs[12].Club || 
                            SingletonOutils.lJoueurs[13].Club == SingletonOutils.lJoueurs[5].Club ||
                            SingletonOutils.lJoueurs[13].Club == SingletonOutils.lJoueurs[4].Club)
                        {
                            InverserJoueur(13, 16); // Position initiale, trop de jouer du même club

                            return false;
                        }
                    }

                    return true;
                }
            }
            #endregion

            #region Colonne
            /* Si plus de 4 joueurs du même club alors
             * 2 joueurs du même club dans la même poule, 
             * les faire jouer le plus tôt possible
             */
            if(iNbrMaxJoueur > 4)
            {
                bool bRet = false;

                // Parcourir les 4 poules
                // Recherche des joueurs en double
                /* Modifier leur position
                 *  +---+---+  +---+---+   +---+---+   +---+---+  
                 *  | A | A |  | A | A |   | A | A |   | A | A |
                 *  +---+---+  +---+---+   +---+---+   +---+---+ 
                 *  | A | C |  | B | B |   | B | B |   | B | C |
                 *  +---+---+  +---+---+   +---+---+   +---+---+ 
                 *  | C | D |  | A | D |   | C | D |   | C | C |
                 *  +---+---+  +---+---+   +---+---+   +---+---+
                 *  | D | A |  | D | A |   | B | C |   | C | B |
                 *  +---+---+  +---+---+   +---+---+   +---+---+ 
                 *  
                 *  Groupe 1 : 0, 7,  8, 15
                 *  Groupe 2 : 1, 6,  9, 14
                 *  Groupe 3 : 2, 5, 10, 13
                 *  Groupe 4 : 3, 4, 11, 12
                 */
                if (SingletonOutils.lJoueurs[1].Club == SingletonOutils.lJoueurs[8].Club)
                {
                    InverserJoueur(8, 16);
                    InverserJoueur(8, 9);
                    bRet= true;
                }

                if (SingletonOutils.lJoueurs[1].Club == SingletonOutils.lJoueurs[9].Club)
                {
                    InverserJoueur(9, 16);
                    bRet= true;
                }

                if (SingletonOutils.lJoueurs[8].Club == SingletonOutils.lJoueurs[16].Club)
                {
                    InverserJoueur(9, 16);
                    bRet= true;
                }

                if (SingletonOutils.lJoueurs[8].Club == SingletonOutils.lJoueurs[9].Club)
                {
                    InverserJoueur(8, 9);
                    InverserJoueur(9, 16);
                    bRet= true;
                }

                // Groupe 2 : 1, 6,  9, 14
                if (SingletonOutils.lJoueurs[2].Club == SingletonOutils.lJoueurs[7].Club)
                {
                    InverserJoueur(7, 15);
                    InverserJoueur(7, 10);
                    bRet = true;
                }

                if (SingletonOutils.lJoueurs[2].Club == SingletonOutils.lJoueurs[10].Club)
                {
                    InverserJoueur(10, 15);
                    bRet = true;
                }

                if (SingletonOutils.lJoueurs[7].Club == SingletonOutils.lJoueurs[15].Club)
                {
                    InverserJoueur(7, 15);
                    bRet = true;
                }

                if (SingletonOutils.lJoueurs[7].Club == SingletonOutils.lJoueurs[10].Club)
                {
                    InverserJoueur(7, 10);
                    InverserJoueur(10, 15);
                    bRet = true;
                }

                // Groupe 3 : 2, 5, 10, 13
                if (SingletonOutils.lJoueurs[3].Club == SingletonOutils.lJoueurs[6].Club)
                {
                    InverserJoueur(6, 14);
                    InverserJoueur(6, 11);
                    bRet = true;
                }

                if (SingletonOutils.lJoueurs[3].Club == SingletonOutils.lJoueurs[11].Club)
                {
                    InverserJoueur(11, 14);
                    bRet = true;
                }

                if (SingletonOutils.lJoueurs[6].Club == SingletonOutils.lJoueurs[14].Club)
                {
                    InverserJoueur(11, 14);
                    bRet = true;
                }

                if (SingletonOutils.lJoueurs[6].Club == SingletonOutils.lJoueurs[11].Club)
                {
                    InverserJoueur(6, 11);
                    InverserJoueur(11, 14);
                    bRet = true;
                }

                // Groupe 4 : 3, 4, 11, 12
                if (SingletonOutils.lJoueurs[4].Club == SingletonOutils.lJoueurs[5].Club)
                {
                    InverserJoueur(5, 13);
                    InverserJoueur(5, 12);
                    bRet = true;
                }

                if (SingletonOutils.lJoueurs[4].Club == SingletonOutils.lJoueurs[12].Club)
                {
                    InverserJoueur(12, 13);
                    bRet = true;
                }

                if (SingletonOutils.lJoueurs[5].Club == SingletonOutils.lJoueurs[13].Club)
                {
                    InverserJoueur(12, 13);
                    bRet = true;
                }

                if (SingletonOutils.lJoueurs[8].Club == SingletonOutils.lJoueurs[9].Club)
                {
                    InverserJoueur(5, 12);
                    InverserJoueur(12, 13);
                    bRet = true;
                }

                return bRet;

            }
            #endregion

            return false;
        }

        private void InverserJoueur(int i, int j)
        {
            Joueur jo;
            jo = SingletonOutils.lJoueurs[i];
            SingletonOutils.lJoueurs[i] = SingletonOutils.lJoueurs[j];
            SingletonOutils.lJoueurs[j] = jo;

            txtMessages.Text += "Inversion de " + i.ToString() + " avec " + j.ToString() + "." + Environment.NewLine;
        }

        private void EditionPoule(char cPoule)
        {
            string sFileName = SingletonOutils.GetTempFileName("EP");
            
            // if you are using epplus for noncommercial purposes, see https://polyformproject.org/licenses/noncommercial/1.0.0/
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // R2 - 15 ans Messieurs - Tour 3
            string sEpreuve = SingletonOutils.competition.division.Nom + " -  Tour " + SingletonOutils.competition.Tour;

            // Heure
            string Hm = DateTime.Now.ToString("HH:mm");

            // Partie 1 .. 6
            int[] iColon = { 1, 8, 1, 8, 14, 21 };
            int[] iLignes = { 2, 2, 18, 18, 2, 2 };

            // Nombre de partie
            int iMax = 6;

            /*
             *  Groupe 1 : 0, 7,  8, 15
             *  Groupe 2 : 1, 6,  9, 14
             *  Groupe 3 : 2, 5, 10, 13
             *  Groupe 4 : 3, 4, 11, 12
             */
            int[] iGroupe = new int[4];

            int[] iJoueur1 = new int[6];
            int[] iJoueur2 = new int[6];
            int[] iJoueurR = new int[6];

            iGroupe = SingletonOutils.GetJoueurPoule4(cPoule);

            // Le nom du 3 éme joueur est vide
            // 2 joueurs
            if (SingletonOutils.lJoueurs[iGroupe[2]].GetNom(0).Length == 0)
            {
                iMax = 1;
                iJoueur1 = new int[] { iGroupe[0] };
                iJoueur2 = new int[] { iGroupe[1] };
                iJoueurR = new int[] { 16 };

                File.Copy(".\\Excel\\Fiches_Partie_Poule_1.xlsx", sFileName);
            }
            else
            {
                // 3 Joueurs
                // 1-3, 2-3, 1-2
                if (SingletonOutils.lJoueurs[16].GetNom(0).Length == 0)
                {
                    iMax = 3;
                    iJoueur1 = new int[] { iGroupe[0], iGroupe[1], iGroupe[0] };
                    iJoueur2 = new int[] { iGroupe[2], iGroupe[2], iGroupe[1] };
                    iJoueurR = new int[] { iGroupe[1], iGroupe[0], iGroupe[2] };

                    File.Copy(".\\Excel\\Fiches_Partie_Poule_3.xlsx", sFileName);
                }
                else
                {
                    // 4 joueurs
                    iJoueur1 = new int[] { iGroupe[0], iGroupe[1], iGroupe[0], iGroupe[1], iGroupe[0], iGroupe[2] };
                    iJoueur2 = new int[] { iGroupe[3], iGroupe[2], iGroupe[2], iGroupe[3], iGroupe[1], iGroupe[3] };
                    iJoueurR = new int[] { iGroupe[2], iGroupe[3], iGroupe[1], iGroupe[0], iGroupe[2], iGroupe[1] };

                    File.Copy(".\\Excel\\Fiches_Partie_Poule.xlsx", sFileName);
                }
            }

            //Open the workbook (or create it if it doesn't exist)
            using (var p = new ExcelPackage(sFileName))
            {
                // Get the Worksheet created in the previous codesample. 
                var ws = p.Workbook.Worksheets["Feuil1"];

                for (int i = 0; i < iMax; i++)
                {
                    // Set the cell Value using row and column.
                    ws.Cells[iLignes[i], iColon[i]].Value = sEpreuve;

                    //The style object is used to access most cells formatting and styles.
                    ws.Cells[iLignes[i], iColon[i]].Style.Font.Bold = true;

                    // Tableau
                    ws.Cells[iLignes[i]+1, iColon[i]].Value = "Tableau : " + SingletonOutils.competition.categorie.NomCourt + " " + SingletonOutils.competition.Sexe;

                    // Table
                    ws.Cells[iLignes[i] + 1, iColon[i] + 4].Value = (SingletonOutils.competition.Table + i).ToString();

                    // Heure
                    ws.Cells[iLignes[i]+1, iColon[i] + 3].Value = "Heure : " + Hm;

                    // Poule
                    ws.Cells[iLignes[i]+2, iColon[i] + 5].Value = (cPoule-64).ToString() + " ( " + cPoule.ToString() + " )";

                    // Nom arbitre
                    ws.Cells[iLignes[i] + 3, iColon[i]].Value = "Arbitre : " + SingletonOutils.lJoueurs[iJoueurR[i]].Nom;

                    // Nom Joueur 1
                    ws.Cells[iLignes[i] + 7, iColon[i]].Value = SingletonOutils.lJoueurs[iJoueur1[i]].Nom;
                    ws.Cells[iLignes[i] + 11, iColon[i]].Value = SingletonOutils.lJoueurs[iJoueur1[i]].Nom;

                    // Nom Joueur 2
                    ws.Cells[iLignes[i] + 9, iColon[i]].Value = SingletonOutils.lJoueurs[iJoueur2[i]].Nom;
                    ws.Cells[iLignes[i] + 12, iColon[i]].Value = SingletonOutils.lJoueurs[iJoueur2[i]].Nom;
                }

                //Save and close the package.
                p.Save();

                // Ouvrir le fichier excel
                System.Diagnostics.Process.Start(sFileName);
            }
        }

        private void Poule1Edition_Click(object sender, EventArgs e)
        {
            EditionPoule('A');
        }

        private void Poule2Edition_Click(object sender, EventArgs e)
        {
            EditionPoule('B');
        }

        private void Poule3Edition_Click(object sender, EventArgs e)
        {
            EditionPoule('C');
        }

        private void Poule4Edition_Click(object sender, EventArgs e)
        {
            EditionPoule('D');
        }

        #region DragDrop

        private void DgvMouseMove(DataGridView dgv, int iPoule, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = DgvGroupe1.DoDragDrop(DgvGroupe1.Rows[rowIndexFromMouseDown[1]], DragDropEffects.Move);
                }
            }
        }

        private void DgvMouseDown(DataGridView dgv, int iPoule, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown[iPoule] = dgv.HitTest(e.X, e.Y).RowIndex;

            // Pas de déplacement pour la premiére ligne
            if (rowIndexFromMouseDown[iPoule] > 0)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);

                iDragOrigine = iPoule;
            }
            else
            {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
                iDragOrigine = 0;
            }
        }

        /*
         * Groupe 1
         */
        private void DgvGroupe1_MouseMove(object sender, MouseEventArgs e)
        {
            DgvMouseMove( DgvGroupe1, 1, e);
        }

        private void DgvGroupe1_MouseDown(object sender, MouseEventArgs e)
        {
            DgvMouseDown(DgvGroupe1, 1, e);
        }

        private void DgvGroupe1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DgvGroupe1_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = DgvGroupe1.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop[1] = DgvGroupe1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // Pas de déplacement pour la premiére ligne 
            if (rowIndexOfItemUnderMouseToDrop[1]  > 0 && iDragOrigine == 1)
            {
                // If the drag operation was a move then remove and insert the row.
                if (e.Effect == DragDropEffects.Move)
                {
                    /* Poule 1
                     * Groupe 1 : 0, 7,  8, 15
                     * Groupe 2 : 1, 6,  9, 14
                     * Groupe 3 : 2, 5, 10, 13
                     * Groupe 4 : 3, 4, 11, 12
                     */
                    switch (rowIndexFromMouseDown[1])
                    {
                        case 1:
                            if(rowIndexOfItemUnderMouseToDrop[1] == 2)
                                InverserJoueur(7, 8);
                            else // 4
                                InverserJoueur(7, 15);

                            AfficheGroupe();
                            break;
                        case 2:
                            if (rowIndexOfItemUnderMouseToDrop[1] == 1)
                                InverserJoueur(8, 7);
                            else // 4
                                InverserJoueur(8, 15);

                            AfficheGroupe();
                            break;
                        case 3:
                            if (rowIndexOfItemUnderMouseToDrop[1] == 1)
                                InverserJoueur(15, 7);
                            else // 3
                                InverserJoueur(15, 8);

                            AfficheGroupe();
                            break;
                    }
                }
            }
        }

        /*
         * Groupe 2
         */
        private void DgvGroupe2_MouseMove(object sender, MouseEventArgs e)
        {
            DgvMouseMove(DgvGroupe2, 2, e);
        }

        private void DgvGroupe2_MouseDown(object sender, MouseEventArgs e)
        {
            DgvMouseDown(DgvGroupe2, 2, e);
        }

        private void DgvGroupe2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DgvGroupe2_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = DgvGroupe2.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop[2] = DgvGroupe2.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // Pas de déplacement pour la premiére ligne 
            if (rowIndexOfItemUnderMouseToDrop[2] > 0 && iDragOrigine == 2)
            {
                // If the drag operation was a move then remove and insert the row.
                if (e.Effect == DragDropEffects.Move)
                {
                    /* Poule 2
                     * Groupe 2 : 1, 6,  9, 14
                     */
                    switch (rowIndexFromMouseDown[2])
                    {
                        case 1:
                            if (rowIndexOfItemUnderMouseToDrop[2] == 2)
                                InverserJoueur(6, 9);
                            else // 4
                                InverserJoueur(6, 14);

                            AfficheGroupe();
                            break;
                        case 2:
                            if (rowIndexOfItemUnderMouseToDrop[2] == 1)
                                InverserJoueur(9, 6);
                            else // 4
                                InverserJoueur(9, 14);

                            AfficheGroupe();
                            break;
                        case 3:
                            if (rowIndexOfItemUnderMouseToDrop[2] == 1)
                                InverserJoueur(14, 6);
                            else // 3
                                InverserJoueur(14, 9);

                            AfficheGroupe();
                            break;
                    }
                }
            }

        }

        /*
         * Groupe 3
         */
        private void DgvGroupe3_MouseMove(object sender, MouseEventArgs e)
        {
            DgvMouseMove(DgvGroupe3, 3, e);
        }

        private void DgvGroupe3_MouseDown(object sender, MouseEventArgs e)
        {
            DgvMouseDown(DgvGroupe3, 3, e);
        }

        private void DgvGroupe3_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DgvGroupe3_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = DgvGroupe3.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop[3] = DgvGroupe3.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // Pas de déplacement pour la premiére ligne 
            if (rowIndexOfItemUnderMouseToDrop[3] > 0 && iDragOrigine == 3)
            {
                // If the drag operation was a move then remove and insert the row.
                if (e.Effect == DragDropEffects.Move)
                {
                    /* Poule 3
                     * Groupe 3 : 2, 5, 10, 13
                     */
                    switch (rowIndexFromMouseDown[3])
                    {
                        case 1:
                            if (rowIndexOfItemUnderMouseToDrop[3] == 2)
                                InverserJoueur(5, 10);
                            else // 4
                                InverserJoueur(5, 13);

                            AfficheGroupe();
                            break;
                        case 2:
                            if (rowIndexOfItemUnderMouseToDrop[3] == 1)
                                InverserJoueur(10, 6);
                            else // 4
                                InverserJoueur(10, 13);

                            AfficheGroupe();
                            break;
                        case 3:
                            if (rowIndexOfItemUnderMouseToDrop[3] == 1)
                                InverserJoueur(13, 5);
                            else // 3
                                InverserJoueur(13, 10);

                            AfficheGroupe();
                            break;
                    }
                }
            }
        }

        /*
         * Groupe 4
         */
        private void DgvGroupe4_MouseMove(object sender, MouseEventArgs e)
        {
            DgvMouseMove(DgvGroupe4, 4, e);
        }

        private void DgvGroupe4_MouseDown(object sender, MouseEventArgs e)
        {
            DgvMouseDown(DgvGroupe4, 4, e);
        }

        private void DgvGroupe4_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DgvGroupe4_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = DgvGroupe4.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop[4] = DgvGroupe3.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // Pas de déplacement pour la premiére ligne 
            if (rowIndexOfItemUnderMouseToDrop[4] > 0 && iDragOrigine == 4)
            {
                // If the drag operation was a move then remove and insert the row.
                if (e.Effect == DragDropEffects.Move)
                {
                    /* Poule 4
                     * Groupe 4 : 3, 4, 11, 12
                     */
                    switch (rowIndexFromMouseDown[4])
                    {
                        case 1:
                            if (rowIndexOfItemUnderMouseToDrop[4] == 2)
                                InverserJoueur(4, 11);
                            else // 4
                                InverserJoueur(4, 12);

                            AfficheGroupe();
                            break;
                        case 2:
                            if (rowIndexOfItemUnderMouseToDrop[4] == 1)
                                InverserJoueur(11, 6);
                            else // 4
                                InverserJoueur(11, 12);

                            AfficheGroupe();
                            break;
                        case 3:
                            if (rowIndexOfItemUnderMouseToDrop[4] == 1)
                                InverserJoueur(12, 4);
                            else // 3
                                InverserJoueur(12, 11);

                            AfficheGroupe();
                            break;
                    }
                }
            }

        }
        #endregion

        private void BtnPoules_Click(object sender, EventArgs e)
        {
            FormPoule frmPoule = new FormPoule();
            frmPoule.ShowDialog();
        }

        private void FicheDesPoulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sFileName = SingletonOutils.GetTempFileName("FP");

            // if you are using epplus for noncommercial purposes, see https://polyformproject.org/licenses/noncommercial/1.0.0/
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Heure
            string Hm = DateTime.Now.ToString("HH:mm");

            File.Copy(".\\Excel\\Fiches_des_poules.xlsx", sFileName);

            using (ExcelPackage p = new ExcelPackage(new FileInfo(sFileName)))
            {
                // Get the Worksheet created in the previous codesample. 
                var ws = p.Workbook.Worksheets["Feuil1"];

                // Set the cell Value using row and column.
                ws.Cells[1, 1].Value = SingletonOutils.GetCompetition();

                //The style object is used to access most cells formatting and styles.
                ws.Cells[1, 1].Style.Font.Bold = true;

                int iLigne = 0;

                // Nom	Dossard	N°Licence	Points	Club
                for (int i = 1; i < 5; i++)
                {
                    iLigne = i * 7;
                    foreach (int iJ in SingletonOutils.GetJoueurPoule4(Convert.ToChar(i + 64)))
                    {
                        ws.Cells[iLigne, 2].Value = SingletonOutils.lJoueurs[iJ].GetNom(0);
                        ws.Cells[iLigne, 3].Value = int.Parse(SingletonOutils.lJoueurs[iJ].Dossard.ToString());
                        ws.Cells[iLigne, 4].Value = int.Parse(SingletonOutils.lJoueurs[iJ].IdJoueur.ToString());
                        ws.Cells[iLigne, 5].Value = int.Parse(SingletonOutils.lJoueurs[iJ].Classement.ToString());
                        ws.Cells[iLigne, 6].Value = SingletonOutils.lJoueurs[iJ].Club.ToString();

                        iLigne++;
                    }
                }

                //Save and close the package.
                p.Save();

                // Ouvrir le fichier excel
                System.Diagnostics.Process.Start(sFileName);
            }

        }

        private void FeuilleDePouleEdition_Click(object sender, EventArgs e)
        {
            string sFileName = SingletonOutils.GetTempFileName("PF");

            // if you are using epplus for noncommercial purposes, see https://polyformproject.org/licenses/noncommercial/1.0.0/
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Heure
            string Hm = DateTime.Now.ToString("HH:mm");

            File.Copy(".\\Excel\\Feuille_de_poule.xlsx", sFileName);

            int iR = 0, iC = 0;
            int iR2 = 0;
            int iPos;
            int iJoueur1, iJoueur2;
            string s;

            //Open the workbook (or create it if it doesn't exist)
            using (var p = new ExcelPackage(sFileName))
            {
                // Get the Worksheet created in the previous codesample. 
                var ws = p.Workbook.Worksheets["Feuil1"];

                // Set the cell Value using row and column.
                ws.Cells[3, 3].Value = ws.Cells[3, 16].Value = ws.Cells[25, 3].Value = ws.Cells[25, 16].Value = SingletonOutils.competition.division.Nom;

                ws.Cells[3, 12].Value= ws.Cells[3, 25].Value = ws.Cells[25, 12].Value = ws.Cells[25, 25].Value = SingletonOutils.competition.Tour;

                
                string dateFormatted = DateTime.Now.ToString("dd/MM/yyyy");

                ws.Cells[4, 3].Value= ws.Cells[4, 16].Value = ws.Cells[26, 3].Value = ws.Cells[26, 16].Value = dateFormatted;

                ws.Cells[4, 6].Value = ws.Cells[4, 19].Value = ws.Cells[26, 6].Value = ws.Cells[26, 19].Value = SingletonOutils.competition.Sexe;

                ws.Cells[4, 12].Value = ws.Cells[4, 25].Value = ws.Cells[26, 12].Value = ws.Cells[26, 25].Value = SingletonOutils.competition.NumGroupe;

                ws.Cells[5, 6].Value = ws.Cells[5, 19].Value = ws.Cells[27, 6].Value = ws.Cells[27, 19].Value = SingletonOutils.competition.categorie.NomCourt;

                //The style object is used to access most cells formatting and styles.
                ws.Cells[1, 1].Style.Font.Bold = true;

                // Boucle sur les poules
                // Nom	Dossard	N°Licence	Points	Club
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            // Poule A
                            iR = 7;
                            iC = 1;
                            break; 

                        case 1:
                            // Poule B
                            iR = 7;
                            iC = 14;
                            break;

                        case 2:
                            // Poule C
                            iR = 29;
                            iC = 1;
                            break; 
                            
                        case 3:
                            // Poule C
                            iR = 29;
                            iC = 14;
                            break;

                    }

                    // Convertion 0 -> char 'A', 1 -> char 'B'
                    foreach (int iJ in SingletonOutils.GetJoueurPoule4(Convert.ToChar(i + 65)))
                    {
                        switch (iJ)
                        {
                            // Poule A
                            case 0:
                                iR2 = iR;
                                break;

                            case 7:
                                iR2 = iR + 1;
                                break;

                            case 8:
                                iR2 = iR + 2;
                                break;

                            case 15:
                                iR2 = iR + 3;
                                break;

                            // Poule B
                            case 1:
                                iR2 = iR;
                                break;

                            case 6:
                                iR2 = iR + 1;
                                break;

                            case 9:
                                iR2 = iR + 2;
                                break;

                            case 14:
                                iR2 = iR + 3;
                                break;

                            // Poule C
                            case 2:
                                iR2 = iR;
                                break;

                            case 5:
                                iR2 = iR + 1;
                                break;

                            case 10:
                                iR2 = iR + 2;
                                break;

                            case 13:
                                iR2 = iR + 3;
                                break;

                            // Poule D
                            case 3:
                                iR2 = iR;
                                break;  

                            case 4:
                                iR2 = iR + 1;
                                break;   

                            case 11:
                                iR2 = iR + 2;
                                break;

                            case 12:
                                iR2 = iR + 3;
                                break;
                        }

                        // Ecriture du cartouche
                        ws.Cells[iR2, iC].Value = int.Parse(SingletonOutils.lJoueurs[iJ].Dossard.ToString());
                        ws.Cells[iR2, iC + 1].Value = SingletonOutils.lJoueurs[iJ].GetNom(0);
                        ws.Cells[iR2, iC + 3].Value = int.Parse(SingletonOutils.lJoueurs[iJ].IdJoueur.ToString());
                        ws.Cells[iR2, iC + 6].Value = int.Parse(SingletonOutils.lJoueurs[iJ].Classement.ToString());
                        ws.Cells[iR2, iC + 8].Value = SingletonOutils.lJoueurs[iJ].Club.ToString();
                    }

                    // Recherche des parties
                    for (int j = 0; j < 6; j++)
                    {
                        iJoueur1 = SingletonOutils.aPartie4[j, 0];
                        iJoueur2 = SingletonOutils.aPartie4[j, 1];

                        // Ecriture des parties
                        // 1 / 4, 1 / 3, 1 / 2
                        s = iJoueur1.ToString() + "/" + iJoueur2.ToString();
                        ws.Cells[iR + j + 6, iC].Value = s;
                        ws.Cells[iR + j + 6, iC].Value = s;
                        ws.Cells[iR + j + 6, iC].Value = s;
                        ws.Cells[iR + j + 6, iC].Value = s;

                        // Joueur Contre Joueur
                        iPos = SingletonOutils.GetJoueurPoule4(Convert.ToChar(i + 65))[iJoueur1 - 1];
                        ws.Cells[iR + j + 6, iC + 1].Value = SingletonOutils.lJoueurs[iPos].GetNom(0);

                        iPos = SingletonOutils.GetJoueurPoule4(Convert.ToChar(i + 65))[iJoueur2 - 1];
                        ws.Cells[iR + j + 6, iC + 2].Value = SingletonOutils.lJoueurs[iPos].GetNom(0);
                    }
                }

                //Save and close the package.
                p.Save();

                // Ouvrir le fichier excel
                System.Diagnostics.Process.Start(sFileName);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) { Close(); }
    }
}
