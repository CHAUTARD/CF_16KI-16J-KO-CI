using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace CF_16KI_16J_KO_CI
{
    public partial class FormMain : Form
    {
        SQLiteConnection sqliteConn;
        Modeles.Param mParam;
        List<Modeles.Joueur> lJoueurs = new List<Modeles.Joueur>();
        
        public FormMain()
        {
            InitializeComponent();

            // Titre de la fenétre
            Text = "Critérium Fédéral : 16 joueurs en 4 poules classement intégral. - Version : " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();


            sqliteConn = CreateConnection();
        }

        static SQLiteConnection CreateConnection()
        { 
            SQLiteConnection conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True;");

            try
            {
                conn.Open();
            }
            catch 
            { 
            }

            return conn;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            
            RemplirDivison(sqliteConn, cmbDivision);

            cmbSexe.SelectedItem = "Messieurs";
            cmbTour.SelectedItem = "1";
            cmbGroupe.SelectedItem = "1";

            RemplirCategorie(sqliteConn, cmbCategorie);

            sqliteConn.Close();

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Dossard"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Licence"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Classement"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        static void RemplirDivison(SQLiteConnection conn, ComboBox cmb)
        {
            SQLiteDataAdapter sQLiteDataAdapter;
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();

            SQLiteCommand cmd = conn.CreateCommand();

            sQLiteDataAdapter = new SQLiteDataAdapter("SELECT Nom FROM Divisions ORDER BY Ord;", conn);
            dataSet.Reset();
            sQLiteDataAdapter.Fill(dataSet);
            dataTable = dataSet.Tables[0];

            cmb.DataSource = dataTable;
            cmb.DisplayMember= "Nom";
        }

        static void RemplirCategorie(SQLiteConnection conn, ComboBox cmb)
        {
            SQLiteDataAdapter sQLiteDataAdapter;
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();

            SQLiteCommand cmd = conn.CreateCommand();

            sQLiteDataAdapter = new SQLiteDataAdapter("SELECT Nom FROM Categories ORDER BY Ord DESC;", conn);
            dataSet.Reset();
            sQLiteDataAdapter.Fill(dataSet);
            dataTable = dataSet.Tables[0];

            cmb.DataSource = dataTable;
            cmb.DisplayMember = "Nom";
        }

        private void btnExcelQualifies_Click(object sender, System.EventArgs e)
        {
            // Recherche du fichier excel des qualifié(e)s
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Vidage de la grid
                dataGridView1.Rows.Clear();

                // Chargement de la grid
                using (var stream = File.Open(openFileDialog1.FileNames[0], FileMode.Open, FileAccess.Read))
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

                        for(int i = 2; i < result.Tables[0].Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();

                            // Xslx
                            // Licence	Nom - Prénom	Naissance	Club	Cat.	Cat. Sportive	Classement	Total
                            // DataGrid
                            // Pointage, Dossard,  Nom, Licence, Classement, Club
                            // Colonne, Row

                            dataGridView1[1, (i - 2)].Value = i - 1;
                            dataGridView1[2, (i - 2)].Value = dt.Rows[i][1].ToString();
                            dataGridView1[3, (i - 2)].Value = dt.Rows[i][0].ToString();
                            dataGridView1[4, (i - 2)].Value = dt.Rows[i][6].ToString();
                            dataGridView1[5, (i - 2)].Value = dt.Rows[i][3].ToString();
                        }

                        // The result of each spreadsheet is in result.Tables
                        //5. Free resources (IExcelDataReader is IDisposable)
                        excelReader.Close();

                        bntSnake.Enabled = true;
                    }
                }
            }
        }

        private void bntSnake_Click(object sender, EventArgs e)
        {
            // Vidage de la liste
            lJoueurs.Clear();

            // Present, Dossard, Nom, Licence, Classement, Club
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                lJoueurs.Add(new Modeles.Joueur(
                    Convert.ToInt32(dr.Cells[1].Value),
                    Convert.ToString(dr.Cells[2].Value),
                    Convert.ToInt32(dr.Cells[3].Value),
                    Convert.ToInt32(dr.Cells[4].Value),
                    Convert.ToString(dr.Cells[5].Value)
                ));
            }

            // Compléter à 16
            // Le 16 éme reste toujours vide
            int i = dataGridView1.Rows.Count;
            for(;i<=16;i++)
                lJoueurs.Add(new Modeles.Joueur( 0, "", 0, 500, ""  ));


            mParam = new Modeles.Param(
                cmbDivision.Text,
                cmbTour.Text,
                cmbSexe.Text,
                cmbGroupe.Text,
                cmbCategorie.Text
            );

            FormSnake frmSnake = new FormSnake(lJoueurs, mParam);
            frmSnake.ShowDialog();
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
                File.Delete(file.Name);
            }
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 1 && e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["Pointage"].Value))
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout();
            frm.ShowDialog();
        }
    }
}
