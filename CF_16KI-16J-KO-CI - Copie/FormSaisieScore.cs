/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
using System;
using System.Windows.Forms;

namespace CF_16KI_16J_KO_CI
{
	/// <summary>
	/// Description of FormSaisieScore.
	/// </summary>
	public partial class FormSaisieScore : Form
	{
		public string[] aScore = new string[5];
		public bool bAbandon1 = false;
		public bool bAbandon2 = false;
        public bool bForfait1 = false;
        public bool bForfait2 = false;

        private bool bClear = false;

		public FormSaisieScore(string _sTitre, string[] _aScore)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

            aScore = _aScore;    

            // Couleur sélectionnée pour le fond du formulaire
            BackColor = SingletonOutils.BackColor;

            Text = "Fiche partie ( " + SingletonOutils.GetCompetition() + " )";

            // Affichage des joueurs et de l'arbitre
            lbPartie.Text = _sTitre;

			// Centrer le texte
			lbPartie.SelectAll();
			lbPartie.SelectionAlignment = HorizontalAlignment.Center;

			rbAbandonNeant.Checked = true;
			RbForfaitNeant.Checked = true;

            // Initialisation des scores
            SetScore();
        }

        private void SetScore()
        {
            // Initialisation des scores
            tbScore1.Text = aScore[0] == "/" ? "" : aScore[0];
            tbScore2.Text = aScore[1] == "/" ? "" : aScore[1];
            tbScore3.Text = aScore[2] == "/" ? "" : aScore[2];
            tbScore4.Text = aScore[3] == "/" ? "" : aScore[3];
            tbScore5.Text = aScore[4] == "/" ? "" : aScore[4];

            tbScore1.Enabled = true;
            tbScore2.Enabled = false; 
            tbScore3.Enabled = false; 
            tbScore4.Enabled = false;
            tbScore5.Enabled = false;

            tbScore1.Focus();
        }

		void TbScore1KeyPress(object sender, KeyPressEventArgs e) { e.Handled = GoodChar(tbScore1.Text, e); }
		void TbScore2KeyPress(object sender, KeyPressEventArgs e) { e.Handled = GoodChar(tbScore2.Text, e); }
		void TbScore3KeyPress(object sender, KeyPressEventArgs e) { e.Handled = GoodChar(tbScore3.Text, e); }
		void TbScore4KeyPress(object sender, KeyPressEventArgs e) { e.Handled = GoodChar(tbScore4.Text, e); }
		void TbScore5KeyPress(object sender, KeyPressEventArgs e) { e.Handled = GoodChar(tbScore5.Text, e); }

		// Quitter la textbox
		void TbScore1Leave(object sender, EventArgs e) {
			tbScore1.Text = FormatScore(tbScore1.Text);

			tbScore2.Enabled = true;
            tbScore2.Focus();
		}

		void TbScore2Leave(object sender, EventArgs e) {
			tbScore2.Text = FormatScore(tbScore2.Text);

			tbScore3.Enabled = true;
            tbScore3.Focus();
		}

		void TbScore3Leave(object sender, EventArgs e) {
			// Aucune valeur n'est saisie
			if (tbScore3.Text.Length > 0)
			{
				tbScore3.Text = FormatScore(tbScore3.Text);

				// Si les trois sont positif alors fin de saisie
				switch (GetMancheNegative(3))
				{
					case 0:
					case 3:
						if (!bClear) Bye();
						break;

					default:
						tbScore4.Enabled = true;
						tbScore4.Focus();
						break;
				}
			}
		}

		void TbScore4Leave(object sender, EventArgs e) {
			// Aucune valeur n'est saisie
			if (tbScore4.Text.Length > 0)
			{
				tbScore4.Text = FormatScore(tbScore4.Text);

				switch (GetMancheNegative(4))
				{
					case 0:
					case 1:
					case 3:
						if (!bClear) Bye();
						break;

					default:
						tbScore5.Enabled = true;
						tbScore5.Focus();
						break;
				}
			}
		}

		void TbScore5Leave(object sender, EventArgs e) {
            // Aucune valeur n'est saisie
            if (tbScore5.Text.Length > 0)
			{
                tbScore5.Text = FormatScore(tbScore5.Text);

                Bye();
            }
        }

		// Compte le nombre de manche négative, perdu
		// i représente la zone de saisie en cours
		public int GetMancheNegative(int i=3)
		{
			// Nombre de valeur négative
			int iN = 0;

			if (tbScore1.Text.Length > 0 && tbScore1.Text[0] == '-') iN++;
			if (tbScore2.Text.Length > 0 && tbScore2.Text[0] == '-') iN++;
			try
			{
				if (tbScore3.Text.Length > 0 && tbScore3.Text[0] == '-') iN++;
				if (tbScore4.Text.Length > 0 && tbScore4.Text[0] == '-' && i >= 4) iN++;
				if (tbScore5.Text.Length > 0 && tbScore5.Text[0] == '-' && i >= 5) iN++;
			}
			catch
			{ }

			return iN;
		}

		/* Le moins en première position
		 * 
		 * retourne false si le caractère est authorisé.
		 */
		bool GoodChar(string str, KeyPressEventArgs e) {
			// Remplace la touche [Enter] par une tabulation
			if (e.KeyChar == (char)13)
			{
				SendKeys.Send("{TAB}");
				return true;
			}

            if (str.Length == 0 && e.KeyChar == '-')
				return false;

			return (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
		}

		// Mise en forme du résultat sur deux caractères
		string FormatScore(string str) {
			int s;

			if (str.Length == 0)
				return "";

			// Un score supérieur à 31 est trés rare !
			s = int.Parse(str);
			if (s > 31 || s < -31)
				MessageBox.Show("Le score me semble élevé !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning );

			if(str == "-0" || str == "-00") return "-00";
			return String.Format("{0:00}", s);
		}
	
		void BtClearClick(object sender, EventArgs e) { 
			// Désactive les contrôles
			bClear = true;  
			SetScore(); 
			bClear = false;
		}

        void Bye()
		{
            // Remplir les colonnes dans joueur pour la partie
            // Modification de la table arbitrage
            aScore[0] = tbScore1.Text.Length == 0 ? "/" : tbScore1.Text;
            aScore[1] = tbScore2.Text.Length == 0 ? "/" : tbScore2.Text;
            aScore[2] = tbScore3.Text.Length == 0 ? "/" : tbScore3.Text;
            aScore[3] = tbScore4.Text.Length == 0 ? "/" : tbScore4.Text;
            aScore[4] = tbScore5.Text.Length == 0 ? "/" : tbScore5.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

		void BtCancelClick(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel; 
			Close(); 
		}

        private void RbForfaitJoueur1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton chk = (RadioButton)sender;
			SetForfait(chk.Checked, "-00");
            bForfait1 = chk.Checked;

			if (chk.Checked)
				Bye();
        }

        private void RbForfaitJoueur2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton chk = (RadioButton)sender;
            SetForfait(chk.Checked, "00");
            bForfait2 = chk.Checked;

			if (chk.Checked)
				Bye();
        }

        private void RbAbandonJoueur1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton chk = (RadioButton)sender;
            SetForfait(chk.Checked, "-00");
			bAbandon1 = chk.Checked;

			if(chk.Checked)
				Bye();
        }

        private void RbAbandonJoueur2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton chk = (RadioButton)sender;
            SetForfait(chk.Checked, "00");
			bAbandon2 = chk.Checked;

			if(chk.Checked)
				Bye();
        }

        private void RbForfaitLes2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton chk = (RadioButton)sender;
            SetForfait(chk.Checked, "/");
            bForfait1 = bForfait2 = true;
			Bye();
        }

        private void RbAbandonLes2_CheckedChanged(object sender, EventArgs e)
        {
            bAbandon1 = bAbandon2 = true;
			Bye();
        }

        private void SetForfait(bool bChecked, string sValue)
		{
            if (bChecked)
            {
                // Forfait du joueur1, il perd les matchs restant à 0 ou -0
                if (tbScore1.Text == "")
                    tbScore1.Text = tbScore2.Text = tbScore3.Text = sValue;
                else
                {
                    if (tbScore2.Text == "")
                        tbScore2.Text = tbScore3.Text = tbScore4.Text = sValue;
                    else
                    {
                        if (tbScore3.Text == "")
                            tbScore3.Text = sValue;

                        tbScore4.Text = sValue;
                        tbScore5.Text = sValue;
                    }
                }
            }
        }
    }
}