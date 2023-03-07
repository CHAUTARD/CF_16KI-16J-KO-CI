/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
using CF_16KI_16J_KO_CI.Gestion;
using CF_16KI_16J_KO_CI.Modeles;
using Criterium_16_4;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CF_16KI_16J_KO_CI
{
    public partial class FormMain : Form
    {
        private const string _sFileName = "CF_16KI_16J_KO_CI.ini";

        // Sauvegarde des choix des combobox
        private IniFile iniFile;

        public FormMain(bool bNew)
        {
            InitializeComponent();

            // Titre de la fenétre
            Text = "Critérium Fédéral : 16 joueurs en 4 poules classement intégral. - Version : " + Assembly.GetEntryAssembly().GetName().Version.ToString();

            if( ! SingletonOutils.Init() )
                Close();

            RemplirEpreuve();

            RemplirDivison(cmbDivision);

            RemplirCategorie(cmbCategorie);

            iniFile = new IniFile(_sFileName);

            // Displays the MessageBox.
            if ( ! bNew)
            {
                // Restaure les valeurs sauvegardées dans le fichier ini
                SingletonOutils.bRestaure = true;

                GetCompetition();

                cmbCategorie.SelectedIndex = SingletonOutils.lCategories.FindIndex(x => x.IdCategorie == SingletonOutils.Competition.categorie.IdCategorie);
                cmbDivision.SelectedIndex = SingletonOutils.lDivisions.FindIndex(x => x.IdDivision == SingletonOutils.Competition.division.IdDivision); ;
                cmbGroupe.SelectedItem = SingletonOutils.Competition.NumGroupe.ToString();
                cmbSexe.SelectedItem = SingletonOutils.Competition.Sexe;
                cmbTable.Text = SingletonOutils.Competition.Table.ToString();
                cmbTour.Text = SingletonOutils.Competition.Tour.ToString();

                dataGridView1.Rows.Clear();

                // En ajoutant un élément l'index correspond au numéro
                SingletonOutils.lJoueurs.Clear();
                SingletonOutils.lJoueurs.Add(new Joueur(0, "( Vide )", "01/01/2023", "Poussin", 500, false, 0, string.Empty, 'E', 1));

                // Remplir la liste des joueurs à partir de la table
                // Lecture de Joueurs
                SQLiteCommand sqlCommand = SingletonOutils.sqliteConn.CreateCommand();
                sqlCommand.CommandText = "SELECT IdJoueur, Nom, DatNais, IdCategorie, Classement, IsPresent, Dossard, Club, Poule, NumInPoule FROM Joueurs ORDER BY Dossard;";

                var reader = sqlCommand.ExecuteReader();
                Joueur joueur;
                while (reader.Read())
                {
                    joueur = new Joueur(reader);

                    SingletonOutils.lJoueurs.Add(joueur);

                    /* Pointage, Dossard,  Nom, Licence, Classement, Club */
                    dataGridView1.Rows.Add(
                        joueur.IsPresent,
                        joueur.Dossard,
                        joueur.Nom,
                        joueur.Licence,
                        joueur.Classement,
                        joueur.Club
                    );

                    Console.WriteLine(dataGridView1.Rows.Count);
                    // Mise en couleur de la ligne
                    if (joueur.IsPresent)
                        dataGridView1.Rows[dataGridView1.Rows.Count-2].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
                reader.Close();

                bntSnake.Enabled = true;
            }
            else
            {
                cmbCategorie.SelectedIndex = 0;
                cmbDivision.SelectedIndex = 0;
                cmbGroupe.SelectedItem = "1";
                cmbSexe.SelectedItem = "Messieurs";
                cmbTable.SelectedItem = "10";
                cmbTour.SelectedItem = "1";
            }
        }

        // 1 Seule épreuve est géré actuellement
        // Mise à jour dans SingletonOutils.Competition
        static void RemplirEpreuve()
        {
            SingletonOutils.Competition.epreuve.IdEpreuve = 8984;
            SingletonOutils.Competition.epreuve.Libelle = "Critérium Fédéral";
            SingletonOutils.Competition.epreuve.libelleCourt = "Crit";
        }

        static void RemplirDivison(ComboBox cmb)
        {
            SQLiteCommand sqlCommand = SingletonOutils.sqliteConn.CreateCommand();

            sqlCommand.CommandText = "SELECT IdDivision, Nom, NomCourt, Niveau, Ord FROM Divisions ORDER BY Ord;";
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                // Copie de la table dans la liste
                SingletonOutils.lDivisions.Add(new Division(
                    reader.GetInt32(0), 
                    reader.GetString(1), 
                    reader.GetString(2), 
                    reader.GetString(3),
                    reader.GetInt16(4)
                ));

                cmb.Items.Add(new ComboboxItem(reader.GetInt16(0), reader.GetString(1)));
            }
            reader.Close();
        }

        static void RemplirCategorie(ComboBox cmb)
        {
            SQLiteCommand sqlCommand = SingletonOutils.sqliteConn.CreateCommand();

            sqlCommand.CommandText = "SELECT IdCategorie, Nom, NomCourt, Parent, Ord FROM Categories ORDER BY Ord DESC;";
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                cmb.Items.Add(new ComboboxItem(reader.GetInt16(0), reader.GetString(1)));

                // Copie de la table dans la liste
                SingletonOutils.lCategories.Add(new Categorie(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetInt16(4)
                ));
            }
        }

        static void GetCompetition()
        {
            using (var sqlCommand = SingletonOutils.sqliteConn.CreateCommand())
            {
                int iCategorie;
                int iDivision;
                sqlCommand.CommandText = "SELECT `IdCategorie`, `IdDivision`, `Tour`, `NumGroupe`, `Table` FROM Competitions";
                var reader = sqlCommand.ExecuteReader();
                if(reader.Read())
                {
                    iCategorie = reader.GetInt16(0);
                    iDivision = reader.GetInt16(1);
                    SingletonOutils.Competition.Tour = reader.GetInt16(2);
                    SingletonOutils.Competition.NumGroupe = reader.GetInt16(3);
                    SingletonOutils.Competition.Table = reader.GetInt16(4);

                    reader.Close();

                    // Remplir Categorie
                    SingletonOutils.Competition.categorie = SingletonOutils.FindCategorieById(iCategorie);

                    // Remplir Division
                    SingletonOutils.Competition.division = SingletonOutils.FindDivisionById(iDivision);
                }
            }
        }

        private void btnExcelQualifies_Click(object sender, System.EventArgs e)
        {
            var filePath = string.Empty;
            int i = 0;
            SQLiteDataReader reader;
            SQLiteCommand sqlCommand = SingletonOutils.sqliteConn.CreateCommand();

            // Vidage de la grid
            dataGridView1.Rows.Clear();

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

            // Suppression de CompetitionsJoueurs, joueurs, parties
            // Recherche des joueurs de la compétition
            // Recherche des parties du joueur
            // Récupération des données à partir de la table Compétition et Joueurs

            // Lecture des informations sur la compétition
            List<double> lIdJoueur = new List<double>();
            sqlCommand.CommandText = "SELECT DISTINCT IdJoueur1 FROM Parties";
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
                lIdJoueur.Add(reader.GetDouble(0));

            reader.Close();

            sqlCommand.CommandText = "SELECT DISTINCT IdJoueur2 FROM Parties";
            reader = sqlCommand.ExecuteReader();

            // Ajout de IdJoueur s'il n'est pas dans la liste
            while (reader.Read())
                if ( ! lIdJoueur.Contains(reader.GetDouble(0)) )
                    lIdJoueur.Add(reader.GetDouble(0));

            reader.Close();

            // Trier la liste
            lIdJoueur.Sort();

            for (int index =  0; index < lIdJoueur.Count; index++)
            { 
                sqlCommand.CommandText = "DELETE FROM Parties WHERE IdJoueur1 = " + lIdJoueur[index].ToString();
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "DELETE FROM Parties WHERE IdJoueur2 = " + lIdJoueur[index].ToString();
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "DELETE FROM Joueurs WHERE IdJoueur = " + lIdJoueur[index].ToString();
                sqlCommand.ExecuteNonQuery();
            }

            // Un seul enregistrement dans Competition
            sqlCommand.CommandText = "DELETE FROM Competitions";
            sqlCommand.ExecuteNonQuery();     

            // Création de Compétitions et CompétitionsJoueurs
            sqlCommand = new SQLiteCommand("INSERT INTO `competitions` ( `IdCompetition`, `IdEpreuve`, `IdCategorie`, `IdDivision`, `Tour`, `NumGroupe`, `Table`) VALUES ( 1, 8984, @IdCategorie, @IdDivision, @Tour, @NumGroupe, @Table);", SingletonOutils.sqliteConn);
            sqlCommand.Parameters.AddWithValue("@IdCategorie", Convert.ToInt32((cmbCategorie.SelectedItem as ComboboxItem).Key));
            sqlCommand.Parameters.AddWithValue("@IdDivision", Convert.ToInt32((cmbDivision.SelectedItem as ComboboxItem).Key));
            sqlCommand.Parameters.AddWithValue("@Tour", cmbTour.Text);
            sqlCommand.Parameters.AddWithValue("@NumGroupe", int.Parse(cmbGroupe.Text));
            sqlCommand.Parameters.AddWithValue("@Table", int.Parse(cmbTable.Text));
            sqlCommand.Prepare();
            sqlCommand.ExecuteNonQuery();

            // En ajoutant un élément l'index correspond au numéro
            SingletonOutils.lJoueurs.Clear();
            SingletonOutils.lJoueurs.Add(new Joueur(0, "( Vide )", "01/01/2023", "Poussin", 500, false, 0, string.Empty, 'E', 1));

            // Insertion d'un joueur
            string insertJ = "INSERT INTO Joueurs (`IdJoueur`,`Nom`,`Dossard`,`DatNais`,`Classement`,`Club`,`IdCategorie` ) VALUES (@IdJoueur, @Nom, @Dossard, @DatNais, @Classement, @Club, @IdCategorie)";

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

                    for (i = 2; i < result.Tables[0].Rows.Count; i++)
                    {
                        joueur = new Joueur(dt.Rows[i], i-1);

                        SingletonOutils.lJoueurs.Add(joueur);

                        // Xslx
                        // Licence	Nom - Prénom	Naissance	Club	Cat.	Cat. Sportive	Classement	Total
                        // DataGrid
                        // Pointage, Dossard,  Nom, Licence, Classement, Club
                        // Colonne, Row
                        dataGridView1.Rows.Add(
                            joueur.IsPresent, 
                            joueur.Dossard,                          
                            joueur.Nom,
                            joueur.Licence,
                            joueur.Classement,
                            joueur.Club
                        );

                        sqlCommand = new SQLiteCommand(insertJ, SingletonOutils.sqliteConn);

                        // @IdJoueur,@Nom, @IsPresent,@Dossard,@DatNais,@Classement, @Poule,@NumInPoule
                        sqlCommand.Parameters.AddWithValue("@IdJoueur", joueur.Licence);
                        sqlCommand.Parameters.AddWithValue("@Nom", joueur.Nom);
                        sqlCommand.Parameters.AddWithValue("@IsPresent", joueur.IsPresent);
                        sqlCommand.Parameters.AddWithValue("@Dossard", joueur.Dossard);
                        sqlCommand.Parameters.AddWithValue("@DatNais", joueur.DatNais);
                        sqlCommand.Parameters.AddWithValue("@Classement", joueur.Classement);
                        sqlCommand.Parameters.AddWithValue("@Club", joueur.Club);
                        sqlCommand.Parameters.AddWithValue("@IdCategorie", joueur.categorie.IdCategorie);
                        sqlCommand.Prepare();
                        sqlCommand.ExecuteNonQuery();
                    }

                    // The result of each spreadsheet is in result.Tables
                    //5. Free resources (IExcelDataReader is IDisposable)
                    excelReader.Close();

                    bntSnake.Enabled = true;
                }
            }
        }


        private void bntSnake_Click(object sender, EventArgs e)
        {
            // Trier le grid sur le numéro de dossard en croissant
            dataGridView1.Sort(dataGridView1.Columns["Dossard"], ListSortDirection.Ascending);

            // Compléter à 16
            // Le 16 éme reste toujours vide
            int i = dataGridView1.Rows.Count;
            for(;i<=16;i++)
                SingletonOutils.lJoueurs.Add(new Joueur( 0, "( Vide )", "01/01/2023", "Poussin", 500, false, i, string.Empty, 'E', 1));

            // Sauvegarde des informations
            SingletonOutils.Competition.division.IdDivision = Convert.ToInt32( (cmbDivision.SelectedItem as ComboboxItem).Key );
            SingletonOutils.Competition.Tour = Convert.ToInt32(cmbTour.Text);
            SingletonOutils.Competition.Sexe = cmbSexe.Text;
            SingletonOutils.Competition.NumGroupe = Convert.ToInt32(cmbGroupe.Text);
            SingletonOutils.Competition.categorie.IdCategorie = Convert.ToInt32( (cmbCategorie.SelectedItem as ComboboxItem).Key );
            SingletonOutils.Competition.Table = Convert.ToInt32(cmbTable.Text);

            this.Hide();

            // Ouverture de la fenêtre suivante
            FormSnake frmSnake = new FormSnake();
            frmSnake.ShowDialog();

            this.Close();
        }

        // Supprission d'une ligne
         private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int iNbr = dataGridView1.SelectedRows.Count;
                if(iNbr == 1)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    dataGridView1.Rows.RemoveAt(index);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Suppression de tous les fichiers commencant par ## dans le répertoire de l'application
            var dir = new DirectoryInfo(".");
            foreach (var file in dir.EnumerateFiles("##*.xlsx"))
            {
                try { file.Delete(); } catch { }
            }
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bool bEtat = false;

            if ((dataGridView1.Rows.Count > 1) && (e.ColumnIndex == 0) && (e.RowIndex < 16))
            {
                if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["Pointage"].Value))
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    SingletonOutils.lJoueurs[e.RowIndex+1].IsPresent = true;
                    bEtat = true;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    SingletonOutils.lJoueurs[e.RowIndex+1].IsPresent = false;
                }
                // Mettre à jour la table
                // DataGrid 0 = Pointage, 3 = N° Licence
                SQLiteCommand sqlCommand = new SQLiteCommand("UPDATE joueurs SET `IsPresent` = " + bEtat.ToString() + " WHERE IdJoueur=" + SingletonOutils.lJoueurs[e.RowIndex + 1].IdJoueur.ToString(), SingletonOutils.sqliteConn);
                sqlCommand.ExecuteNonQuery();
            }
        }

        private void aProposDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout();
            frm.ShowDialog();
        }

        private void paramétresToolStripMenuItem_Click(object sender, EventArgs e)
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
                SingletonOutils.BackColor = this.BackColor = MyDialog.Color;
            }
        }

        // Inversion de tous les états présents Vrai en Faux et Faux en Vrai
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Click dans le header de la colonne pointage
            // Inverse l'état en fonction de l'etat de la première ligne
            if( (e.ColumnIndex == 0) && (e.RowIndex==-1) && (dataGridView1.Rows.Count > 0))
            {
                bool bEtat = ! (bool) dataGridView1.Rows[0].Cells[0].Value;

                for(int iRow = 0; iRow < dataGridView1.Rows.Count; iRow++)
                {
                    dataGridView1.Rows[iRow].Cells[0].Value = bEtat;
                    SingletonOutils.lJoueurs[iRow].IsPresent = bEtat;
                }
            }
        }
    }
}
