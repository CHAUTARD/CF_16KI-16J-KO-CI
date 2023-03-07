/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
using System;
using System.Windows.Forms;

namespace CF_16KI_16J_KO_CI.Gestion
{
    internal class ManchesPoints
    {
        DataGridView _dgv;
        RichTextBox _txtRapport;

        int _iPointGagneA = 0;
        int _iPointPerduA = 0;

        int _iPointGagneB = 0;
        int _iPointPerduB = 0;

        int _iPointGagneC = 0;
        int _iPointPerduC = 0;

        int _iPointGagneD = 0;
        int _iPointPerduD = 0;


        public ManchesPoints(DataGridView dgv, RichTextBox txtRapport)
        {
            _dgv = dgv;
            _txtRapport = txtRapport;
        }

        float QuotientA() { return (float)_iPointGagneA / (float)_iPointPerduA; }
        float QuotientB() { return (float)_iPointGagneB / (float)_iPointPerduB; }
        float QuotientC() { return (float)_iPointGagneC / (float)_iPointPerduC; }
        float QuotientD() { return (float)_iPointGagneD / (float)_iPointPerduD; }


        public void CalculePoints3(int iJ1, int iJ2, int iJ3)
        {
            int[,] aP = new int[2, 3];

            Clear();
            aP = CalculePoints(iJ1, iJ3);
            _iPointGagneA = aP[0, 0];
            _iPointPerduA = aP[1, 0];
            _iPointGagneC = aP[0, 2];
            _iPointPerduC = aP[1, 2];

            aP = CalculePoints(iJ2, iJ3);
            _iPointGagneB = aP[0, 1];
            _iPointPerduB = aP[1, 1];
            _iPointGagneC += aP[0, 2];
            _iPointPerduC += aP[1, 2];

            aP = CalculePoints(iJ1, iJ2);
            _iPointGagneA += aP[0, 0];
            _iPointPerduA += aP[1, 0];
            _iPointGagneB += aP[0, 1];
            _iPointPerduB += aP[1, 1];
        }

        public void ClaculePoints4(int iJ1, int iJ2, int iJ3, int iJ4)
        {
            int[,] aP = new int[2, 4];

            Clear();
            aP = CalculePoints(iJ1, iJ4);
            _iPointGagneA = aP[0, 0];
            _iPointPerduA = aP[1, 0];
            _iPointGagneD = aP[0, 2];
            _iPointPerduD = aP[1, 2];

            aP = CalculePoints(iJ2, iJ3);
            _iPointGagneB = aP[0, 1];
            _iPointPerduB = aP[1, 1];
            _iPointGagneC = aP[0, 2];
            _iPointPerduC = aP[1, 2];

            aP = CalculePoints(iJ1, iJ3);
            _iPointGagneA += aP[0, 0];
            _iPointPerduA += aP[1, 0];
            _iPointGagneC += aP[0, 2];
            _iPointPerduC += aP[1, 2];

            aP = CalculePoints(iJ2, iJ4);
            _iPointGagneB += aP[0, 0];
            _iPointPerduB += aP[1, 0];
            _iPointGagneD += aP[0, 2];
            _iPointPerduD += aP[1, 2];

            aP = CalculePoints(iJ1, iJ2);
            _iPointGagneA += aP[0, 0];
            _iPointPerduA += aP[1, 0];
            _iPointGagneB += aP[0, 1];
            _iPointPerduB += aP[1, 1];

            aP = CalculePoints(iJ2, iJ4);
            _iPointGagneB += aP[0, 0];
            _iPointPerduB += aP[1, 0];
            _iPointGagneD += aP[0, 1];
            _iPointPerduD += aP[1, 1];
        }

        private void Clear()
        {
            _iPointGagneA = 0;
            _iPointPerduA = 0;

            _iPointGagneB = 0;
            _iPointPerduB = 0;

            _iPointGagneC = 0;
            _iPointPerduC = 0;

            _iPointGagneD = 0;
            _iPointPerduD = 0;
        }

        /* Calcul le quotient des points victoire sur défaite pour deux joueurs
		 * 
		 * 	iJ1 < iJ2 ou iJ2 > iJ1
		 */
        int[,] CalculePoints(int iJ1, int iJ2)
        {
            if (iJ1 > iJ2)
                return CalculePoints41(iJ1, iJ2);

            return CalculePoints41(iJ2, iJ1);
        }

        #region CalculePoints31
        /* Calcul le quotient des points victoire sur défaite pour deux joueurs dans une poule de trois joueurs, 1 ou 3 qualifiés
		 * 
		 * 	iJ1 < iJ2 ou iJ2 > iJ1
		 */
        /*
        int[,] CalculePoints31(int iJ1, int iJ2)
        {
            int[] aiRet = new int[] { 0, 0, 0, 0, 0 };

            int igA = 0, igB = 0, igC = 0;
            int ipA = 0, ipB = 0, ipC = 0;

            switch (iJ1 * 10 + iJ2)
            {
                case 13: // 1 - 3
                    aiRet = ScorePoint(0);
                    igA += aiRet[0];
                    ipA += aiRet[1];

                    igC += aiRet[2];
                    ipC += aiRet[3];
                    break;

                case 31: // 3 - 1
                    aiRet = ScorePoint(0);
                    igC += aiRet[0];
                    ipC += aiRet[1];

                    igA += aiRet[2];
                    ipA += aiRet[3];
                    break;

                case 23: // 2 - 3
                    aiRet = ScorePoint(1);
                    igB += aiRet[0];
                    ipB += aiRet[1];

                    igC += aiRet[2];
                    ipC += aiRet[3];
                    break;

                case 32: // 3 - 2
                    aiRet = ScorePoint(1);
                    igC += aiRet[0];
                    ipC += aiRet[1];

                    igB += aiRet[2];
                    ipB += aiRet[3];
                    break;

                case 12: // 1 - 2
                    aiRet = ScorePoint(2);
                    igA += aiRet[0];
                    ipA += aiRet[1];

                    igB += aiRet[2];
                    ipB += aiRet[3];
                    break;

                case 21: // 2 - 1
                    aiRet = ScorePoint(2);
                    igB += aiRet[0];
                    ipB += aiRet[1];

                    igA += aiRet[2];
                    ipA += aiRet[3];
                    break;
            }

            return new int[,] { { igA, igB, igC }, { ipA, ipB, ipC } };
        }
        */
        #endregion

        /* Calcul le quotient des points victoire sur défaite pour deux joueurs dans une poule de quatres joueurs 1 ou 3 qualifiés
		 * 
		 * 	iJ1 < iJ2 ou iJ2 > iJ1
		 */
        int[,] CalculePoints41(int iJ1, int iJ2)
        {
            int[] aiRet = new int[] { 0, 0, 0, 0 };

            int igA = 0, igB = 0, igC = 0, igD = 0;
            int ipA = 0, ipB = 0, ipC = 0, ipD = 0;

            switch (iJ1 * 10 + iJ2)
            {
                case 14: // 1 - 4
                    aiRet = ScorePoint(0);
                    igA += aiRet[0];
                    ipA += aiRet[1];

                    igD += aiRet[2];
                    ipD += aiRet[3];
                    break;

                case 41: // 4 - 1
                    aiRet = ScorePoint(0);
                    igD += aiRet[0];
                    ipD += aiRet[1];

                    igA += aiRet[2];
                    ipA += aiRet[3];
                    break;

                case 23: // 2 - 3
                    aiRet = ScorePoint(1);
                    igB += aiRet[0];
                    ipB += aiRet[1];

                    igC += aiRet[2];
                    ipC += aiRet[3];
                    break;

                case 32: // 3 - 2
                    aiRet = ScorePoint(1);
                    igC += aiRet[0];
                    ipC += aiRet[1];

                    igB += aiRet[2];
                    ipB += aiRet[3];
                    break;

                case 13: // 1 - 3
                    aiRet = ScorePoint(2);
                    igA += aiRet[0];
                    ipA += aiRet[1];

                    igC += aiRet[2];
                    ipC += aiRet[3];
                    break;

                case 31: // 3 - 1
                    aiRet = ScorePoint(2);
                    igC += aiRet[0];
                    ipC += aiRet[1];

                    igA += aiRet[2];
                    ipA += aiRet[3];
                    break;

                case 24: // 2 - 4
                    aiRet = ScorePoint(3);
                    igB += aiRet[0];
                    ipB += aiRet[1];

                    igD += aiRet[2];
                    ipD += aiRet[3];
                    break;

                case 42: // 4 - 2
                    aiRet = ScorePoint(3);
                    igD += aiRet[0];
                    ipD += aiRet[1];

                    igB += aiRet[2];
                    ipB += aiRet[3];
                    break;

                case 12: // 1 - 2
                    aiRet = ScorePoint(4);
                    igA += aiRet[0];
                    ipA += aiRet[1];

                    igB += aiRet[2];
                    ipB += aiRet[3];
                    break;

                case 21: // 2 - 1
                    aiRet = ScorePoint(4);
                    igB += aiRet[0];
                    ipB += aiRet[1];

                    igA += aiRet[2];
                    ipA += aiRet[3];
                    break;

                case 34: // 3 - 4
                    aiRet = ScorePoint(5);
                    igC += aiRet[0];
                    ipC += aiRet[1];

                    igD += aiRet[2];
                    ipD += aiRet[3];
                    break;

                case 43: // 4 - 3
                    aiRet = ScorePoint(5);
                    igD += aiRet[0];
                    ipD += aiRet[1];

                    igC += aiRet[2];
                    ipC += aiRet[3];
                    break;
            }

            return new int[,] { { igA, igB, igC, igD }, { ipA, ipB, ipC, ipD } };
        }

        #region CalculePoints42
        /* Calcul le quotient des points victoire sur défaite pour deux joueurs dans une poule de quatres joueurs 2 qualifiés
		 * 
		 * 	iJ1 < iJ2 ou iJ2 > iJ1
		 */

        /*
        int[,] CalculePoints42(int iJ1, int iJ2)
        {
            int[] aiRet = new int[] { 0, 0, 0, 0 };

            int igA = 0, igB = 0, igC = 0, igD = 0;
            int ipA = 0, ipB = 0, ipC = 0, ipD = 0;

            switch (iJ1 * 10 + iJ2)
            {
                case 13: // 1 - 3
                    aiRet = ScorePoint(0);
                    igA += aiRet[0];
                    ipA += aiRet[1];

                    igC += aiRet[2];
                    ipC += aiRet[3];
                    break;

                case 31: // 3 - 1
                    aiRet = ScorePoint(0);
                    igC += aiRet[0];
                    ipC += aiRet[1];

                    igA += aiRet[2];
                    ipA += aiRet[3];
                    break;

                case 24: // 2 - 4
                    aiRet = ScorePoint(1);
                    igB += aiRet[0];
                    ipB += aiRet[1];

                    igD += aiRet[2];
                    ipD += aiRet[3];
                    break;

                case 42: // 4 - 2
                    aiRet = ScorePoint(1);
                    igD += aiRet[0];
                    ipD += aiRet[1];

                    igB += aiRet[2];
                    ipB += aiRet[3];
                    break;

                case 12: // 1 - 2
                    aiRet = ScorePoint(2);
                    igA += aiRet[0];
                    ipA += aiRet[1];

                    igB += aiRet[2];
                    ipB += aiRet[3];
                    break;

                case 21: // 2 - 1
                    aiRet = ScorePoint(2);
                    igB += aiRet[0];
                    ipB += aiRet[1];

                    igA += aiRet[2];
                    ipA += aiRet[3];
                    break;

                case 34: // 3 - 4
                    aiRet = ScorePoint(3);
                    igC += aiRet[0];
                    ipC += aiRet[1];

                    igD += aiRet[2];
                    ipD += aiRet[3];
                    break;

                case 43: // 4 - 3
                    aiRet = ScorePoint(3);
                    igD += aiRet[0];
                    ipD += aiRet[1];

                    igC += aiRet[2];
                    ipC += aiRet[3];
                    break;

                case 14: // 1 - 4
                    aiRet = ScorePoint(4);
                    igA += aiRet[0];
                    ipA += aiRet[1];

                    igD += aiRet[2];
                    ipD += aiRet[3];
                    break;

                case 41: // 4 - 1
                    aiRet = ScorePoint(4);
                    igD += aiRet[0];
                    ipD += aiRet[1];

                    igA += aiRet[2];
                    ipA += aiRet[3];
                    break;

                case 23: // 2 - 3
                    aiRet = ScorePoint(5);
                    igB += aiRet[0];
                    ipB += aiRet[1];

                    igC += aiRet[2];
                    ipC += aiRet[3];
                    break;

                case 32: // 3 - 2
                    aiRet = ScorePoint(5);
                    igC += aiRet[0];
                    ipC += aiRet[1];

                    igB += aiRet[2];
                    ipB += aiRet[3];
                    break;

                default:
                    throw new System.ArgumentException("Erreur dans le paramètre de CalculePoints42 !");
            }

            return new int[,] { { igA, igB, igC, igD }, { ipA, ipB, ipC, ipD } };
        }
        */
        #endregion

        // Recherche du nombre de points de gagné et perdu
        private int[] ScorePoint(int iRow)
        {
            int g1 = 0, p1 = 0, g2 = 0, p2 = 0;
            string s;
            int m;

            for (int iCol = 5; iCol < 10; iCol++)
            {
                s = _dgv.Rows[iRow].Cells[iCol].Value.ToString();

                // "/" cellule vide
                if (s.CompareTo("/") != 0)
                {
                    m = Int32.Parse(s);

                    // Score positif
                    if (m >= 0)
                    {
                        p1 += m;
                        g2 += m;

                        if (m < 10)
                        {
                            g1 += 11;
                            p2 += 11;
                        }
                        else
                        {
                            g1 += m + 2;
                            p2 += m + 2;
                        }
                    }
                    else
                    {
                        g1 += Math.Abs(m);
                        p2 += Math.Abs(m);

                        if (Math.Abs(m) < 10)
                        {
                            g2 += 11;
                            p1 += 11;
                        }
                        else
                        {
                            g2 += Math.Abs(m) + 2;
                            p1 += Math.Abs(m) + 2;
                        }
                    }
                }
            }

            return new int[] { g1, p1, g2, p2 };
        }

        /*
		 * Quotient entre trois joueurs
		 */
        public string Quotient3(int iA, int iB, int iC)
        {
            float f1 = 0;
            float f2 = 0;
            float f3 = 0;

            switch (iA)
            {
                case 1:
                    f1 = QuotientA();
                    break;

                case 2:
                    f1 = QuotientB();
                    break;

                case 3:
                    f1 = QuotientC();
                    break;

                case 4:
                    f1 = QuotientD();
                    break;
            }

            switch (iB)
            {
                case 1:
                    f2 = QuotientA();
                    break;

                case 2:
                    f2 = QuotientB();
                    break;

                case 3:
                    f2 = QuotientC();
                    break;

                case 4:
                    f2 = QuotientD();
                    break;
            }

            switch (iC)
            {
                case 1:
                    f3 = QuotientA();
                    break;

                case 2:
                    f3 = QuotientB();
                    break;

                case 3:
                    f3 = QuotientC();
                    break;

                case 4:
                    f3 = QuotientD();
                    break;
            }

            if (f1 == f2 && f1 == f3)
                return "===";

            if (f1 == f2)
            {
                if (f3 > f2)
                    return "==C";

                return "C==";
            }

            if (f1 > f2)
            {
                if (f2 > f3)
                    return "ABC";

                return "ACB";
            }

            if (f1 == f3)
            {
                if (f2 > f3)
                    return "B==";

                return "==B";
            }

            if (f2 == f3)
            {
                if (f1 > f3)
                    return "A==";

                return "==A";
            }

            if (f1 > f3)
            {
                if (f2 > f3)
                    return "BAC";

                return "CBA";
            }
            else
            {
                if (f2 > f3)
                    return "BCA";

                return "CAB";
            }
        }

        // Affiche le rapport du traitement
        void setTextRapport(string sText, bool bold = false) { SingletonOutils.setTextRapport(_txtRapport, sText, bold); }

        // Affichage des résultats
        public void Dump(int iA, int iB, int iC)
        {
            setTextRapport("MANCHES POINTS", true);
            setTextRapport("+---+-----+-----+--------+");
            setTextRapport("|   |Gagné|Perdu|Quotient|");
            setTextRapport("+---+-----+-----+--------+");
            if (iA == 1 || iB == 1 || iC == 1)
            {
                setTextRapport("| A | " + string.Format("{0:000} | {1:000} | {2:n4} |", _iPointGagneA, _iPointPerduA, QuotientA()));
                setTextRapport("+---+-----+-----+--------+");
            }
            if (iA == 2 || iB == 2 || iC == 2)
            {
                setTextRapport("| B | " + string.Format("{0:000} | {1:000} | {2:n4} |", _iPointGagneB, _iPointPerduB, QuotientB()));
                setTextRapport("+---+-----+-----+--------+");
            }
            if (iA == 3 || iB == 3 || iC == 3)
            {
                setTextRapport("| C | " + string.Format("{0:000} | {1:000} | {2:n4} |", _iPointGagneC, _iPointPerduC, QuotientC()));
                setTextRapport("+---+-----+-----+--------+");
            }
            if (iA == 4 || iB == 4 || iC == 4)
            {
                setTextRapport("| D | " + string.Format("{0:000} | {1:000} | {2:n4} |", _iPointGagneD, _iPointPerduD, QuotientD()));
                setTextRapport("+---+-----+-----+--------+");
            }
        }

    }
}
