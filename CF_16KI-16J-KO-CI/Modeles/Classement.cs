/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF_16KI_16J_KO_CI.Modeles
{
    public class Classement
    {
        int iJoueur { get; set; }
        string[] sPartie1 { get; set; }
        string[] sPartie2 { get; set; }
        string[] sPartie3 { get; set; }

        int iMancheGagne { get; set; }
        int iManchePerdu { get; set; }

        int iPartieGagne { get; set; }
        int iPartiePerdu { get; set; }

        int iPointGagne { get; set; }
        int iPointPerdu { get; set; }

        int iPointsParties { get; set; }

        float iQuotientManches { get; set; }

        float iQuotientPoints { get; set; }

        public Classement(int _iJoueur)
        {
            iJoueur = _iJoueur;

            // "//" partie non jouée
            sPartie1 = new string[] { "//", "//", "//", "//", "//" };
            sPartie2 = new string[] { "//", "//", "//", "//", "//" };
            sPartie3 = new string[] { "//", "//", "//", "//", "//" };

            iPartieGagne = 0;
            iPartiePerdu = 0;

            iMancheGagne = 0;
            iManchePerdu = 0;

            iPointGagne = 0;
            iPointPerdu = 0;

            iPointsParties = 0;
            iQuotientManches = 0;
            iQuotientPoints = 0;
        }

        public void SetPartie1(bool bFirst, string sScore1, string sScore2, string sScore3, string sScore4, string sScore5)
        {
            if(bFirst)
                sPartie1 = new string[] { sScore1, sScore2, sScore3, sScore4, sScore5 };
            else
                sPartie1 = new string [] { 
                    sScore1[0] == '-' ? sScore1.Substring(1) : "-" + sScore1,
                    sScore2[0] == '-' ? sScore2.Substring(1) : "-" + sScore2,
                    sScore3[0] == '-' ? sScore3.Substring(1) : "-" + sScore3,
                    sScore4[0] == '-' ? sScore4.Substring(1) : "-" + sScore4,
                    sScore5[0] == '-' ? sScore5.Substring(1) : "-" + sScore5  };
        }

        public void SetPartie2(bool bFirst, string sScore1, string sScore2, string sScore3, string sScore4, string sScore5)
        {
            if (bFirst)
                sPartie2 = new string[] { sScore1, sScore2, sScore3, sScore4, sScore5 };
            else
                sPartie2 = new string[] {
                    sScore1[0] == '-' ? sScore1.Substring(1) : "-" + sScore1,
                    sScore2[0] == '-' ? sScore2.Substring(1) : "-" + sScore2,
                    sScore3[0] == '-' ? sScore3.Substring(1) : "-" + sScore3,
                    sScore4[0] == '-' ? sScore4.Substring(1) : "-" + sScore4,
                    sScore5[0] == '-' ? sScore5.Substring(1) : "-" + sScore5  };
        }

        public void SetPartie3(bool bFirst, string sScore1, string sScore2, string sScore3, string sScore4, string sScore5)
        {
            if (bFirst)
                sPartie3 = new string[] { sScore1, sScore2, sScore3, sScore4, sScore5 };
            else
                sPartie3 = new string[] {
                    sScore1[0] == '-' ? sScore1.Substring(1) : "-" + sScore1,
                    sScore2[0] == '-' ? sScore2.Substring(1) : "-" + sScore2,
                    sScore3[0] == '-' ? sScore3.Substring(1) : "-" + sScore3,
                    sScore4[0] == '-' ? sScore4.Substring(1) : "-" + sScore4,
                    sScore5[0] == '-' ? sScore5.Substring(1) : "-" + sScore5  };
        }

        public void Calcule()
        {
            iPartieGagne = 0;
            iPartiePerdu = 0;

            iMancheGagne = 0;
            iManchePerdu = 0;

            iPointGagne = 0;
            iPointPerdu = 0;

            iPointsParties = 0;
            iQuotientManches = 0;
            iQuotientPoints = 0;


            for (int i = 0; i < 5; i++)
            {
                if (sPartie1[i] != "//")
                {
                    if (sPartie1[i][i] == '-')
                    {
                        iManchePerdu++;
                        iPointPerdu += int.Parse(sPartie1[i].Substring(1));
                    }
                    else
                    {
                        iMancheGagne++;
                        iPointGagne += int.Parse(sPartie1[i]);
                    }
                }

                if (iMancheGagne == 3)
                {
                    iPointsParties += 2;
                    iPartieGagne++;
                }
                else
                {
                    iPointsParties++;
                    iPartiePerdu++;
                }
            }

            // Calcul des quotients
            if (sPartie1[0] != "//") 
            {
                iQuotientManches = iMancheGagne / iManchePerdu;
                iQuotientPoints = iPointGagne / iPointPerdu;
            }
        }
    }
}
