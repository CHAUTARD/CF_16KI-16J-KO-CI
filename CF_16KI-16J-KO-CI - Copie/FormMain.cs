/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
using CF_16KI_16J_KO_CI.CRUD;
using CF_16KI_16J_KO_CI.Modeles;
using CF_16KI_16J_KO_CI.Orm;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CF_16KI_16J_KO_CI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            // Titre de la fenétre
            Text = "Critérium Fédéral : 16 joueurs en 4 poules classement intégral. - Version : " + Assembly.GetEntryAssembly().GetName().Version.ToString();

            if( ! SingletonOutils.Init() )
                Close();

            // Lecture de la couleur de fond
            string sColor = CrudParametre.Read(1);
            Match m = Regex.Match( sColor, @"A=(?<Alpha>\d+),\s*R=(?<Red>\d+),\s*G=(?<Green>\d+),\s*B=(?<Blue>\d+)");
            if (m.Success)
            {
                int alpha = int.Parse(m.Groups["Alpha"].Value);
                int red = int.Parse(m.Groups["Red"].Value);
                int green = int.Parse(m.Groups["Green"].Value);
                int blue = int.Parse(m.Groups["Blue"].Value);

                BackColor = SingletonOutils.BackColor = Color.FromArgb(alpha, red, green, blue);
            }

            // 1 Seule épreuve est géré actuellement
            // Mise à jour dans SingletonOutils.Competition
            SingletonOutils.competition.epreuve = CrudEpreuve.GetEpreuve();

            // RemplirDivison
            SingletonOutils.lDivisions = CrudDivision.GetAllDivisions();

            for (int i = 0; i < SingletonOutils.lDivisions.Count; i++)
                CmbDivision.Items.Add(SingletonOutils.lDivisions[i].Nom);

            // RemplirCategorie(CmbCategorie);
            SingletonOutils.lCategories = CrudCategorie.GetAllCategories();

            for (int i = 0; i < SingletonOutils.lDivisions.Count; i++)
                CmbCategorie.Items.Add(SingletonOutils.lCategories[i].Nom);

            // Displays the MessageBox.
            GetCompetition();

            CmbCategorie.SelectedIndex = SingletonOutils.lCategories.FindIndex(x => x.IdCategorie == SingletonOutils.competition.categorie.IdCategorie);
            CmbDivision.SelectedIndex = SingletonOutils.lDivisions.FindIndex(x => x.IdDivision == SingletonOutils.competition.division.IdDivision); ;
            CmbGroupe.SelectedItem = SingletonOutils.competition.NumGroupe.ToString();
            CmbSexe.SelectedItem = SingletonOutils.competition.Sexe;
            CmbTable.Text = SingletonOutils.competition.Table.ToString();
            CmbTour.Text = SingletonOutils.competition.Tour.ToString();

            DataGridView1.Rows.Clear();

            // En ajoutant un élément l'index correspond au numéro
            SingletonOutils.ListJoueurClear();

            // Remplir la liste des joueurs à partir de la table
            List<Joueur> lJoueurs = CrudJoueur.GetAllJoueurs();
            int iPresent = 0;

            foreach(Joueur J in lJoueurs)
            {
                if (J.IdJoueur != 0)
                {
                    SingletonOutils.lJoueurs.Add(J);

                    /* Pointage, Dossard,  Nom, Licence, Classement, Club */
                    DataGridView1.Rows.Add(J.IsPresent, J.Dossard, J.Nom, J.IdJoueur, J.Classement, J.Club);

                    // Mise en couleur de la ligne
                    if (J.IsPresent)
                    {
                        iPresent++;
                        DataGridView1.Rows[DataGridView1.Rows.Count - 2].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                }
            }

            // Minimum 8 joueurs présent
            if(iPresent >= 8)
                BntSnake.Enabled = true;
        }

        static void GetCompetition()
        {
            SingletonOutils.competition = CrudCompetition.GetCompetition();

            // Remplir Categorie
            SingletonOutils.competition.categorie = CrudCategorie.GetCategorie(SingletonOutils.competition.IdCategorie);

            // Remplir Division
            SingletonOutils.competition.division = CrudDivision.GetDivision(SingletonOutils.competition.IdDivision);
        }

        private void BtnExcelQualifies_Click(object sender, System.EventArgs e)
        {
            var filePath = string.Empty;
            int i = 0;

            // Vidage de la grid
            DataGridView1.Rows.Clear();

            Joueur joueur;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ".";
                openFileDialog.Filter = "Excel xlsx (*.xlsx)|*.xslx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
                else
                    return;
            }

            // En ajoutant un élément l'index correspond au numéro
            SingletonOutils.ListJoueurClear();
            CrudJoueur.Clear();

            // Chargement de la grid
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                //1.2 Reading from a OpenXml Excel file (2007 format; *.xlsx)
                using (var excelReader = ExcelReaderFactory.CreateReader(stream))
                {
                    // 2. Use the AsDataSet extension method
                    var result = excelReader.AsDataSet();

                    DataTable dt = result.Tables[0];
                    Categorie categorie = new Categorie();
                    int iPresent = 0;

                    for (i = 2; i < result.Tables[0].Rows.Count; i++)
                    {
                        joueur = new Joueur(dt.Rows[i], i-1);

                        SingletonOutils.lJoueurs.Add(joueur);

                        // Xslx
                        // Licence	Nom - Prénom	Naissance	Club	Cat.	Cat. Sportive	Classement	Total
                        // DataGrid
                        // Pointage, Dossard,  Nom, Licence, Classement, Club
                        // Colonne, Row
                        DataGridView1.Rows.Add(
                            joueur.IsPresent, 
                            joueur.Dossard,                          
                            joueur.Nom,
                            joueur.IdJoueur,
                            joueur.Classement,
                            joueur.Club
                        );

                        CrudJoueur.InsertJoueur(joueur);

                        if(joueur.IsPresent)
                            iPresent++;
                    }

                    // The result of each spreadsheet is in result.Tables
                    //5. Free resources (IExcelDataReader is IDisposable)
                    excelReader.Close();

                    if(iPresent >= 8)
                        BntSnake.Enabled = true;
                }
            }
        }


        private void BntSnake_Click(object sender, EventArgs e)
        {
            // Trier le grid sur le numéro de dossard en croissant
            DataGridView1.Sort(DataGridView1.Columns["Dossard"], ListSortDirection.Ascending);

            // Compléter à 16
            // Le 16 éme reste toujours vide
            int i = DataGridView1.Rows.Count;
            for(;i<=16;i++)
                SingletonOutils.lJoueurs.Add(new Joueur( 0, "( Vide )", "01/01/2023", 16, 500, false, i, string.Empty, 'E', 1));

            this.Hide();

            // Ouverture de la fenêtre suivante
            FormSnake frmSnake = new FormSnake();
            frmSnake.ShowDialog();

            this.Close();
        }

        // Supprission d'une ligne
         private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int iNbr = DataGridView1.SelectedRows.Count;
                if(iNbr == 1)
                {
                    int index = DataGridView1.SelectedRows[0].Index;
                    DataGridView1.Rows.RemoveAt(index);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            // Suppression de tous les fichiers commencant par ## dans le répertoire de l'application
            var dir = new DirectoryInfo(".");
            foreach (var file in dir.EnumerateFiles("##*.xlsx"))
            {
                try { file.Delete(); } catch { }
            }
            Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bool bEtat = false;

            if ((DataGridView1.Rows.Count > 1) && (e.ColumnIndex == 0) && (e.RowIndex < 16))
            {
                if (Convert.ToBoolean(DataGridView1.Rows[e.RowIndex].Cells["Pointage"].Value))
                {
                    DataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    SingletonOutils.lJoueurs[e.RowIndex+1].IsPresent = true;
                    bEtat = true;
                }
                else
                {
                    DataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    SingletonOutils.lJoueurs[e.RowIndex+1].IsPresent = false;
                }
                // Mettre à jour la table
                // DataGrid 0 = Pointage, 3 = N° Licence
                CrudJoueur.SetPresent( SingletonOutils.lJoueurs[e.RowIndex + 1].IdJoueur, bEtat);
            }
        }

        private void AProposDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout();
            frm.ShowDialog();
        }

        private void ParamétresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();

            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;

            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;

            // Sets the initial color select to the current text color.
            MyDialog.Color = this.ForeColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                SingletonOutils.BackColor = BackColor = MyDialog.Color;
                CrudParametre.Save(1, BackColor.ToString());
            }
        }

        // Inversion de tous les états présents Vrai en Faux et Faux en Vrai
        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Click dans le header de la colonne pointage
            // Inverse l'état en fonction de l'etat de la première ligne
            if( (e.ColumnIndex == 0) && (e.RowIndex==-1) && (DataGridView1.Rows.Count > 0))
            {
                bool bEtat = ! (bool) DataGridView1.Rows[0].Cells[0].Value;

                for(int iRow = 0; iRow < DataGridView1.Rows.Count; iRow++)
                {
                    DataGridView1.Rows[iRow].Cells[0].Value = bEtat;
                    SingletonOutils.lJoueurs[iRow].IsPresent = bEtat;
                }
            }
        }

        // Sauvegarde du choix fait
        private void CmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            SingletonOutils.competition.IdDivision = OrmDivision.FindIdByNom( CmbDivision.Text );
            CrudCompetition.UpdateSingleCompetition(SingletonOutils.competition);
        }

        private void CmbTour_SelectedIndexChanged(object sender, EventArgs e)
        {
            SingletonOutils.competition.Tour = int.Parse(CmbTour.Text);
            CrudCompetition.UpdateSingleCompetition(SingletonOutils.competition);
        }

        private void CmbSexe_SelectedIndexChanged(object sender, EventArgs e)
        {
            SingletonOutils.competition.Sexe = CmbSexe.Text;
            CrudCompetition.UpdateSingleCompetition(SingletonOutils.competition);
        }

        private void CmbGroupe_SelectedIndexChanged(object sender, EventArgs e)
        {
            SingletonOutils.competition.NumGroupe = int.Parse(CmbGroupe.Text);
            CrudCompetition.UpdateSingleCompetition(SingletonOutils.competition);
        }

        private void CmbCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            SingletonOutils.competition.IdCategorie = OrmCategorie.FindIdByNom(CmbCategorie.Text);
            CrudCompetition.UpdateSingleCompetition(SingletonOutils.competition);
        }

        private void CmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            SingletonOutils.competition.Table = int.Parse(CmbTable.Text);
            CrudCompetition.UpdateSingleCompetition(SingletonOutils.competition);
        }
    }
}
