/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
using CF_16KI_16J_KO_CI.Gestion;
using System.Windows.Forms;

namespace CF_16KI_16J_KO_CI.Modeles
{
    internal class GerePoule
    {
        DataGridView dgv;
        PointsParties pointsParties;

        public GerePoule(char _cPoule, RichTextBox _txtRapport, DataGridView _dgv)
        {
            dgv = _dgv;
            pointsParties = new PointsParties(_cPoule, _dgv, _txtRapport);
        }

        /* Récupération des points partie déjà calculés
         * */
        public void SetPointsPartie(int iJoueur1Points, int iJoueur2Points, int iJoueur3Points, int iJoueur4Points)
        {
            pointsParties.SetPointsPartie( iJoueur1Points, iJoueur2Points, iJoueur3Points, iJoueur4Points);
        }

        public int[] SetClassement()
        {
            return pointsParties.Classement();
        }
     }
}
