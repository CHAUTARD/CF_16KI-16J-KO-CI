using System;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CF_16KI_16J_KO_CI
{
    public partial class FormOpen : Form
    {
        public FormOpen()
        {
            TimeSpan Ts;

            InitializeComponent();

            TreeNode nodJourj = new TreeNode("Aujourd'hui");
            TreeNode nodJour7 = new TreeNode("Cette semaine");
            TreeNode nodJourM = new TreeNode("Ce mois - ci");
            TreeNode nodJourOld = new TreeNode("Plus ancien");

            treeViewCompetition.Nodes.Add(nodJourj);
            treeViewCompetition.Nodes.Add(nodJour7);
            treeViewCompetition.Nodes.Add(nodJourM);
            treeViewCompetition.Nodes.Add(nodJourOld);

            var filePaths = Directory.GetFiles(@".\DataBases\", "*.db")
                .OrderByDescending(d => new FileInfo(d).CreationTime);

            foreach (string filePath in filePaths)
            {
                var newDate = DateTime.ParseExact(filePath.Substring(12, 8), "yyyyMMdd", CultureInfo.InvariantCulture);
                Ts = DateTime.Now - newDate;

                switch((int)Ts.TotalDays)
                {
                    case 0:
                        nodJourj.Nodes.Add(filePath.Substring(12));
                        break;

                    case int n when (n >= 1 && n <= 7):
                        nodJour7.Nodes.Add(filePath.Substring(12));
                        break;

                    case int n when (n >= 8 && n <= 31):
                        nodJourM.Nodes.Add(filePath.Substring(12));
                        break;

                    default:
                        nodJourOld.Nodes.Add(filePath.Substring(12));
                        break;
                }
            }

            treeViewCompetition.ExpandAll();
        }

        private void btClose_Click(object sender, EventArgs e) { Close(); }

        private void treeViewCompetition_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Console.WriteLine(treeViewCompetition.SelectedNode.Text);
            // Sauvegarde du nom de la base pour utilisation
            SingletonOutils.sFileDatabaseName = ".\\DataBases\\" + treeViewCompetition.SelectedNode.Text;

            this.Hide();

            FormMain formMain = new FormMain(false);
            formMain.ShowDialog();

            this.Close();
        }

        private void btnCreer_Click(object sender, EventArgs e)
        {
            // Nom de la database avec la date du jour
            string sFileName = DateTime.Now.ToString("yyyyMMddHHmm") + "_database.db";

            // Création d'une nouvelle compétiton
            File.Copy( ".\\DataBases\\database.new", ".\\DataBases\\" + sFileName);

            // Affichage du nom du nouveau fichier
            MessageBox.Show("Le fichier est créé et ouvert : " + sFileName, "Création du fichier", MessageBoxButtons.OK);

            // Sauvegarde du nom de la base pour utilisation
            SingletonOutils.sFileDatabaseName = ".\\DataBases\\" + sFileName;

            this.Hide();

            FormMain formMain = new FormMain(true);
            formMain.ShowDialog();

            this.Close();
        }
    }
}
