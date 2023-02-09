using CF_16KI_16J_KO_CI.Modeles;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace CF_16KI_16J_KO_CI
{
    public partial class FormSnake : Form
    {
        private List<Joueur> lJoueurs = new List<Joueur>();
        private Param mParam;
        private int iNbrMaxJoueur = 1;

        // Gestion du drag and drop dans les datagridview
        private Rectangle dragBoxFromMouseDown;
        private int iDragOrigine = 0;
        private int[] rowIndexFromMouseDown = new int[5];
        private int[] rowIndexOfItemUnderMouseToDrop = new int[5];

        public FormSnake()
        {
            InitializeComponent();
        }

        public FormSnake(List<Modeles.Joueur> _lJoueurs, Param _mParam)
        {
            InitializeComponent();

            // Copie en local de la liste des joueurs
            lJoueurs = _lJoueurs;
            mParam = _mParam;

            dgvGroupe1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGroupe1.Columns["Rang1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGroupe1.Columns["Dossard1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvGroupe1.Columns["Classement"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvGroupe2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGroupe2.Columns["Rang2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGroupe2.Columns["Dossard2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvGroupe2.Columns["Classement"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvGroupe3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGroupe3.Columns["Rang3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGroupe3.Columns["Dossard3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvGroupe3.Columns["Classement"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvGroupe4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGroupe4.Columns["Rang4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGroupe4.Columns["Dossard4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvGroupe4.Columns["Classement"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Recherche du nombre de joueur par club
            foreach (var line in lJoueurs.GroupBy(info => info.Club)
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

            dgvGroupe1.Rows.Clear();
            dgvGroupe2.Rows.Clear();
            dgvGroupe3.Rows.Clear();
            dgvGroupe4.Rows.Clear();

            // Positionnement des joueurs dans les poules
            // Rang Joueur dossard club selon l'ordre du serpent
            AddInGroupe(dgvGroupe1, "1", lJoueurs[0]);
            AddInGroupe(dgvGroupe2, "1", lJoueurs[1]);
            AddInGroupe(dgvGroupe3, "1", lJoueurs[2]);
            AddInGroupe(dgvGroupe4, "1", lJoueurs[3]);

            AddInGroupe(dgvGroupe4, "2", lJoueurs[4]);
            AddInGroupe(dgvGroupe3, "2", lJoueurs[5]);
            AddInGroupe(dgvGroupe2, "2", lJoueurs[6]);
            AddInGroupe(dgvGroupe1, "2", lJoueurs[7]);

            AddInGroupe(dgvGroupe1, "3", lJoueurs[8]);
            AddInGroupe(dgvGroupe2, "3", lJoueurs[9]);
            AddInGroupe(dgvGroupe3, "3", lJoueurs[10]);
            AddInGroupe(dgvGroupe4, "3", lJoueurs[11]);

            AddInGroupe(dgvGroupe4, "4", lJoueurs[12]);
            AddInGroupe(dgvGroupe3, "4", lJoueurs[13]);
            AddInGroupe(dgvGroupe2, "4", lJoueurs[14]);
            AddInGroupe(dgvGroupe1, "4", lJoueurs[15]);

            bRet |= RechercheDoublonClub(dgvGroupe1);
            bRet |= RechercheDoublonClub(dgvGroupe2);
            bRet |= RechercheDoublonClub(dgvGroupe3);
            bRet |= RechercheDoublonClub(dgvGroupe4);

            btnCorrection.Visible = bRet;
        }

        // Ajout d'un joueur dans un groupe
        public void AddInGroupe(DataGridView dgv, string sRang, Joueur j)
        {
            dgv.Rows.Add(sRang, j.Nom, j.Dossard, j.Club);
        }

        public bool RechercheDoublonClub(DataGridView dgv)
        {
            string Value1, Value2, Value3, Value4;
            bool bRet = false;

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
        private void btnCorrection_Click(object sender, System.EventArgs e)
        {
            // On efface les messages
            txtMessages.Text = "";

            while (DeplacementDansListe()) ;

            // Faire jouer les partie dans les premier tour

            // Afficher les modifications
            AfficheGroupe();
        }

        private bool DeplacementDansListe()
        {
            /*
             * *----*----*----*----*
             * |  0 |  1 |  2 |  3 |  -->
             * *----*----*----*----*
             * |  7 |  6 |  5 |  4 |  <--
             * *----*----*----*----*
             * |  8 |  9 | 10 | 11 |  -->
             * *----*----*----*----*
             * | 15 | 14 | 13 | 12 |  <--
             * *----*----*----*----*
             */

            // Pour les 4 premier joueurs aucun déplacement

            # region Ligne 2
            // Deuxiéme ligne 
            if (lJoueurs[4].Club == lJoueurs[3].Club)
            {
                InverserJoueur(4, 5);
                return true;
            }

            if (lJoueurs[5].Club == lJoueurs[2].Club)
            {
                InverserJoueur(5, 6);
                return true;
            }

            if (lJoueurs[6].Club == lJoueurs[1].Club)
            {
                InverserJoueur(6, 7);
                return true;
            }

            if (lJoueurs[7].Club == lJoueurs[0].Club)
            {
                InverserJoueur(7, 8);
                return true;
            }
            #endregion

            #region Ligne 3
            if (lJoueurs[8].Club == lJoueurs[0].Club || lJoueurs[8].Club == lJoueurs[7].Club)
            {
                InverserJoueur(8, 9);
                return true;
            }

            if (lJoueurs[9].Club == lJoueurs[1].Club || lJoueurs[9].Club == lJoueurs[6].Club)
            {
                InverserJoueur(9, 10);
                return true;
            }

            if (lJoueurs[10].Club == lJoueurs[2].Club || lJoueurs[10].Club == lJoueurs[5].Club)
            {
                InverserJoueur(10, 11);
                return true;
            }

            if (lJoueurs[11].Club == lJoueurs[4].Club || lJoueurs[11].Club == lJoueurs[3].Club)
            {
                InverserJoueur(11, 12);
                return true;
            }
            #endregion

            #region Ligne 4
            if (lJoueurs[12].Club == lJoueurs[11].Club || lJoueurs[12].Club == lJoueurs[4].Club || lJoueurs[12].Club == lJoueurs[3].Club)
            {
                InverserJoueur(12, 13);
                return true;
            }

            if (lJoueurs[13].Club == lJoueurs[10].Club || lJoueurs[13].Club == lJoueurs[5].Club || lJoueurs[13].Club == lJoueurs[2].Club)
            {
                InverserJoueur(13, 14);
                return true;
            }

            if (lJoueurs[14].Club == lJoueurs[9].Club || lJoueurs[14].Club == lJoueurs[6].Club || lJoueurs[14].Club == lJoueurs[1].Club)
            {
                InverserJoueur(14, 15);
                return true;
            }

            if (lJoueurs[15].Club == lJoueurs[8].Club || lJoueurs[15].Club == lJoueurs[7].Club || lJoueurs[15].Club == lJoueurs[0].Club)
            {
                InverserJoueur(15, 14);
                if (lJoueurs[14].Club == lJoueurs[9].Club || lJoueurs[14].Club == lJoueurs[6].Club || lJoueurs[14].Club == lJoueurs[1].Club)
                {
                    InverserJoueur(14, 13);
                    if (lJoueurs[13].Club == lJoueurs[10].Club || lJoueurs[13].Club == lJoueurs[5].Club || lJoueurs[13].Club == lJoueurs[2].Club)
                    {
                        InverserJoueur(13, 12);
                        if (lJoueurs[12].Club == lJoueurs[11].Club || lJoueurs[12].Club == lJoueurs[4].Club || lJoueurs[12].Club == lJoueurs[3].Club)
                        {
                            InverserJoueur(12, 15); // Position initiale, trop de jouer du même club

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
                if (lJoueurs[0].Club == lJoueurs[7].Club)
                {
                    InverserJoueur(7, 15);
                    InverserJoueur(7, 8);
                    bRet= true;
                }

                if (lJoueurs[0].Club == lJoueurs[8].Club)
                {
                    InverserJoueur(8, 15);
                    bRet= true;
                }

                if (lJoueurs[7].Club == lJoueurs[15].Club)
                {
                    InverserJoueur(8, 15);
                    bRet= true;
                }

                if (lJoueurs[7].Club == lJoueurs[8].Club)
                {
                    InverserJoueur(7, 8);
                    InverserJoueur(8, 15);
                    bRet= true;
                }

                // Groupe 2 : 1, 6,  9, 14
                if (lJoueurs[1].Club == lJoueurs[6].Club)
                {
                    InverserJoueur(6, 14);
                    InverserJoueur(6, 9);
                    bRet = true;
                }

                if (lJoueurs[1].Club == lJoueurs[9].Club)
                {
                    InverserJoueur(9, 14);
                    bRet = true;
                }

                if (lJoueurs[6].Club == lJoueurs[14].Club)
                {
                    InverserJoueur(6, 14);
                    bRet = true;
                }

                if (lJoueurs[6].Club == lJoueurs[9].Club)
                {
                    InverserJoueur(6, 9);
                    InverserJoueur(9, 14);
                    bRet = true;
                }

                // Groupe 3 : 2, 5, 10, 13
                if (lJoueurs[2].Club == lJoueurs[5].Club)
                {
                    InverserJoueur(5, 13);
                    InverserJoueur(5, 10);
                    bRet = true;
                }

                if (lJoueurs[2].Club == lJoueurs[10].Club)
                {
                    InverserJoueur(10, 13);
                    bRet = true;
                }

                if (lJoueurs[5].Club == lJoueurs[13].Club)
                {
                    InverserJoueur(10, 13);
                    bRet = true;
                }

                if (lJoueurs[5].Club == lJoueurs[10].Club)
                {
                    InverserJoueur(5, 10);
                    InverserJoueur(10, 13);
                    bRet = true;
                }

                // Groupe 4 : 3, 4, 11, 12
                if (lJoueurs[3].Club == lJoueurs[4].Club)
                {
                    InverserJoueur(4, 12);
                    InverserJoueur(4, 11);
                    bRet = true;
                }

                if (lJoueurs[3].Club == lJoueurs[11].Club)
                {
                    InverserJoueur(11, 12);
                    bRet = true;
                }

                if (lJoueurs[4].Club == lJoueurs[12].Club)
                {
                    InverserJoueur(11, 12);
                    bRet = true;
                }

                if (lJoueurs[7].Club == lJoueurs[8].Club)
                {
                    InverserJoueur(4, 11);
                    InverserJoueur(11, 12);
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
            jo = lJoueurs[i];
            lJoueurs[i] = lJoueurs[j];
            lJoueurs[j] = jo;

            txtMessages.Text += "Inversion de " + i.ToString() + " avec " + j.ToString() + "." + Environment.NewLine;
        }

        private void EditionPoule(int iPoule)
        {
            string sFileName = GetTempFileName();
            
            // if you are using epplus for noncommercial purposes, see https://polyformproject.org/licenses/noncommercial/1.0.0/
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // R2 - 15 ans Messieurs - Tour 3
            string sEpreuve = mParam.Division + " -  Tour " + mParam.Tour;

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

            switch (iPoule)
            {
                case 1:
                    iGroupe = new int[] { 0, 7, 8, 15 };
                    break;

                case 2:
                    iGroupe = new int[] { 1, 6, 9, 14 };
                    break;

                case 3:
                    iGroupe = new int[] { 2, 5, 10, 13 };
                    break;

                case 4:
                    iGroupe = new int[] { 3, 4, 11, 12 };
                    break;
            }


            // Le nom du 3 éme joueur est vide
            // 2 joueurs
            if (lJoueurs[iGroupe[2]].Nom.Length == 0)
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
                if (lJoueurs[15].Nom.Length == 0)
                {
                    iMax = 3;
                    iJoueur1 = new int[] { iGroupe[0], iGroupe[1], iGroupe[0] };
                    iJoueur2 = new int[] { iGroupe[2], iGroupe[2], iGroupe[1] };
                    iJoueurR = new int[] { iGroupe[1], iGroupe[0], iGroupe[2] };

                    File.Copy(".\\Excel\\Fiches_Partie_Poule_3.xlsx", sFileName);
                }
                else
                {
                    iJoueur1 = new int[] { iGroupe[0], iGroupe[1], iGroupe[0], iGroupe[1], iGroupe[0], iGroupe[2] };
                    iJoueur2 = new int[] { iGroupe[3], iGroupe[2], iGroupe[2], iGroupe[3], iGroupe[1], iGroupe[3] };
                    iJoueurR = new int[] { iGroupe[2], iGroupe[3], iGroupe[1], iGroupe[0], iGroupe[2], iGroupe[1] };

                    File.Copy(".\\Excel\\Fiches_Partie_Poule.xlsx", sFileName);
                }
            }

            var outputFile = new FileInfo(sFileName);

            //Open the workbook (or create it if it doesn't exist)
            using (var p = new ExcelPackage(sFileName))
            {
                // Get the Worksheet created in the previous codesample. 
                var ws = p.Workbook.Worksheets["Feuil1"];

                for (int i = 0; i < iMax; i++)
                {
                    // Set the cell value using row and column.
                    ws.Cells[iLignes[i], iColon[i]].Value = sEpreuve;

                    //The style object is used to access most cells formatting and styles.
                    ws.Cells[iLignes[i], iColon[i]].Style.Font.Bold = true;

                    // Tableau
                    ws.Cells[iLignes[i]+1, iColon[i]].Value = "Tableau : " + mParam.Categorie + " " + mParam.Sexe;

                    // Heure
                    ws.Cells[iLignes[i]+1, iColon[i] + 3].Value = "Heure : " + Hm;

                    // Poule
                    ws.Cells[iLignes[i]+2, iColon[i] + 5].Value = iPoule.ToString();

                    // Nom arbitre
                    ws.Cells[iLignes[i] + 3, iColon[i]].Value = "Arbitre : " + lJoueurs[iJoueurR[i]].Nom.ToString();

                    // Nom Joueur 1
                    ws.Cells[iLignes[i] + 7, iColon[i]].Value = lJoueurs[iJoueur1[i]].Nom.ToString();
                    ws.Cells[iLignes[i] + 11, iColon[i]].Value = lJoueurs[iJoueur1[i]].Nom.ToString();

                    // Nom Joueur 2
                    ws.Cells[iLignes[i] + 9, iColon[i]].Value = lJoueurs[iJoueur2[i]].Nom.ToString();
                    ws.Cells[iLignes[i] + 12, iColon[i]].Value = lJoueurs[iJoueur2[i]].Nom.ToString();
                }

                //Save and close the package.
                p.Save();

                // Ouvrir le fichier excel
                System.Diagnostics.Process.Start(sFileName);
            }
        }

        // Génération d'un nom de fichier commencant par ## dans le répertoire de l'application
        public static string GetTempFileName()
        {
            string fileName = "##"  +Path.GetRandomFileName();
            fileName = Path.ChangeExtension(fileName, "xlsx");
            return Path.Combine(".", fileName);
        }

        private void poule1Edition_Click(object sender, EventArgs e)
        {
            EditionPoule(1);
        }

        private void poule2Edition_Click(object sender, EventArgs e)
        {
            EditionPoule(2);
        }

        private void poule3Edition_Click(object sender, EventArgs e)
        {
            EditionPoule(3);
        }

        private void poule4Edition_Click(object sender, EventArgs e)
        {
            EditionPoule(4);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
                    DragDropEffects dropEffect = dgvGroupe1.DoDragDrop(dgvGroupe1.Rows[rowIndexFromMouseDown[1]], DragDropEffects.Move);
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
        private void dgvGroupe1_MouseMove(object sender, MouseEventArgs e)
        {
            DgvMouseMove( dgvGroupe1, 1, e);
        }

        private void dgvGroupe1_MouseDown(object sender, MouseEventArgs e)
        {
            DgvMouseDown(dgvGroupe1, 1, e);
        }

        private void dgvGroupe1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvGroupe1_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dgvGroupe1.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop[1] = dgvGroupe1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

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
        private void dgvGroupe2_MouseMove(object sender, MouseEventArgs e)
        {
            DgvMouseMove(dgvGroupe2, 2, e);
        }

        private void dgvGroupe2_MouseDown(object sender, MouseEventArgs e)
        {
            DgvMouseDown(dgvGroupe2, 2, e);
        }

        private void dgvGroupe2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvGroupe2_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dgvGroupe2.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop[2] = dgvGroupe2.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

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
        private void dgvGroupe3_MouseMove(object sender, MouseEventArgs e)
        {
            DgvMouseMove(dgvGroupe3, 3, e);
        }

        private void dgvGroupe3_MouseDown(object sender, MouseEventArgs e)
        {
            DgvMouseDown(dgvGroupe3, 3, e);
        }

        private void dgvGroupe3_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvGroupe3_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dgvGroupe3.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop[3] = dgvGroupe3.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

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
        private void dgvGroupe4_MouseMove(object sender, MouseEventArgs e)
        {
            DgvMouseMove(dgvGroupe4, 4, e);
        }

        private void dgvGroupe4_MouseDown(object sender, MouseEventArgs e)
        {
            DgvMouseDown(dgvGroupe4, 4, e);
        }

        private void dgvGroupe4_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvGroupe4_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dgvGroupe4.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop[4] = dgvGroupe3.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

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

    }
}
