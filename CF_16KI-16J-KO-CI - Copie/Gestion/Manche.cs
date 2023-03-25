/*
 * Created by SharpDevelop.
 * User: CHAUTARD
 * Date: 18/11/2019
 * Time: 08:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CF_16KI_16J_KO_CI
{
	/// <summary>
	/// Description of Manche.
	/// </summary>
	public class Manche
	{
		DataGridView dgv;
		RichTextBox txtRapport;
		
		private int iMancheGagneA = 0;
		private int iManchePerduA = 0;

		private int iMancheGagneB = 0;
		private int iManchePerduB = 0;

		private int iMancheGagneC = 0;
		private int iManchePerduC = 0;

		private int iMancheGagneD = 0;
		private int iManchePerduD = 0;
		
		public Manche( DataGridView _dgv, RichTextBox _txtRapport)
		{
			dgv = _dgv;
			txtRapport = _txtRapport;
		}
		
		public int getMancheGagneA() { return iMancheGagneA; }
		public int getMancheGagneB() { return iMancheGagneB; }
		public int getMancheGagneC() { return iMancheGagneC; }
		public int getMancheGagneD() { return iMancheGagneD; }
		
		public int getManchePerduA() { return iManchePerduA; }
		public int getManchePerduB() { return iManchePerduB; }
		public int getManchePerduC() { return iManchePerduC; }
		public int getManchePerduD() { return iManchePerduD; }
		
		/*
		 * Calcul le quotient victoire sur défaite pour quatres joueurs
		 */
		public void CalculeManche4(int iA, int iB, int iC, int iD)
		{
			Clear();
			
			CalculeManche( iA, iD);
			CalculeManche( iB, iC);
			CalculeManche( iA, iC);
			CalculeManche( iB, iD);
			CalculeManche( iA, iB);
			CalculeManche( iC, iD);
		}	

		string GetLettre( int a, int b, int c, int d) { return string.Format("{0}{1}{2}{3}", 65+a, 65+b, 65+c, 65+d); }
		
		/* 
		 * Calcul le quotient victoire sur défaite pour trois joueurs
		 * 1 -3, 2 - 3, 1 - 2
		 */
		public void CalculeManche3(int iA, int iB, int iC)
		{
			Clear();
			
			CalculeManche( iA, iC);
			CalculeManche( iB, iC);
			CalculeManche( iA, iB);
		}
		
		/*
		 * Quotient entre trois joueurs
		 */
		public string Quotient3(int iA, int iB, int iC)
		{
			float f1 = 0;
			float f2 = 0;
			float f3 = 0;
			
			switch( iA )
			{
				case 1:
					f1 = (float) ( iMancheGagneA ) / (float) ( iManchePerduA );
					break;
					
				case 2:
					f1 = (float) ( iMancheGagneB ) / (float) ( iManchePerduB );
					break;
					
				case 3:
					f1 =  (float) ( iMancheGagneC ) / (float) ( iManchePerduC );
					break;
			}
			
			switch( iB )
			{
				case 1:
					f2 = (float) ( iMancheGagneA ) / (float) ( iManchePerduA );
					break;
					
				case 2:
					f2 = (float) ( iMancheGagneB ) / (float) ( iManchePerduB );
					break;
					
				case 3:
					f2 =  (float) ( iMancheGagneC ) / (float) ( iManchePerduC );
					break;
			}
						
			switch( iC )
			{
				case 1:
					f3 = (float) ( iMancheGagneA ) / (float) ( iManchePerduA );
					break;
					
				case 2:
					f3 = (float) ( iMancheGagneB ) / (float) ( iManchePerduB );
					break;
					
				case 3:
					f3 =  (float) ( iMancheGagneC ) / (float) ( iManchePerduC );
					break;
			}
												
			if( f1 == f2 && f1 == f3 )
				return "===";
			
			if( f1 == f2)
			{
				if(f3 > f2)
					return "==C";
				
				return "C==";
			}
			
			if( f1 > f2)
			{
				if(f2 > f3)
					return "ABC";
				
				return "ACB";
			}
			
			if( f1 == f3)
			{
				if( f2 > f3)
					return "B==";
				
				return "==B";
			}
			
			if( f2 == f3)
			{
				if(f1 > f3)
					return "A==";
				
				return "==A";
			}
			
			if( f1 > f3)
			{
				if( f2 > f3)
					return "BAC";
				
				return "CBA";
			}
			else
			{
				if( f2 > f3)
					return "BCA";
				
				return "CAB";
			}
		}

		public void CalculeManche3(int iA, int iB)
		{
			int[] aiRet = new int[] { 0, 0 };

			switch (iA * 10 + iB)
			{
                case 13: // 1 - 3
                    aiRet = ScoreManche(0);
                    iMancheGagneA += aiRet[0];
                    iManchePerduA += aiRet[1];

                    iMancheGagneC += aiRet[1];
                    iManchePerduC += aiRet[0];
                    break;

                case 23: // 2 - 3
                    aiRet = ScoreManche(1);
                    iMancheGagneB += aiRet[0];
                    iManchePerduB += aiRet[1];

                    iMancheGagneC += aiRet[1];
                    iManchePerduC += aiRet[0];
                    break;

                case 12: // 1 - 2
                    aiRet = ScoreManche(2);
                    iMancheGagneA += aiRet[0];
                    iManchePerduA += aiRet[1];

                    iMancheGagneB += aiRet[1];
                    iManchePerduB += aiRet[0];
                    break;

                default:
                    throw new System.ArgumentException("Erreur dans le paramètre de CalculeManche !");
            }
		}

		/* Calcul le quotient victoire sur défaite pour deux joueurs dans une poule de 4 joueurs avec 1 ou 3 qualifiés
		 * 
		 * 	iA < iB ou iB > iA
		 */
		public void CalculeManche(int iA, int iB)
		{
			int [] aiRet = new int[] { 0, 0};
			
			switch( iA * 10 + iB ) {
				case 14 : // 1 - 4
				case 41 :
					aiRet = ScoreManche( 0 );
					iMancheGagneA += aiRet[0];
					iManchePerduA += aiRet[1];
					
					iMancheGagneD += aiRet[1];
					iManchePerduD += aiRet[0];
					break;
										
				case 23 : // 2 - 3
				case 32 :
					aiRet = ScoreManche( 1 );
					iMancheGagneB += aiRet[0];
					iManchePerduB += aiRet[1];
					
					iMancheGagneC += aiRet[1];
					iManchePerduC += aiRet[0];
					break;
										
				case 13 : // 1 - 3
				case 31 :
					aiRet = ScoreManche( 2 );
					iMancheGagneA += aiRet[0];
					iManchePerduA += aiRet[1];
					
					iMancheGagneC += aiRet[1];
					iManchePerduC += aiRet[0];
					break;
										
				case 24 : // 2 - 4
				case 42 :
					aiRet = ScoreManche( 3 );
					iMancheGagneB += aiRet[0];
					iManchePerduB += aiRet[1];
					
					iMancheGagneD += aiRet[1];
					iManchePerduD += aiRet[0];
					break;
										
				case 12 : // 1 - 2
				case 21 :
					aiRet = ScoreManche( 4 );
					iMancheGagneA += aiRet[0];
					iManchePerduA += aiRet[1];
					
					iMancheGagneB += aiRet[1];
					iManchePerduB += aiRet[0];
					break;
										
				case 34: // 3 - 4
				case 43 :
					aiRet = ScoreManche( 5 );
					iMancheGagneC += aiRet[0];
					iManchePerduC += aiRet[1];
					
					iMancheGagneD += aiRet[1];
					iManchePerduD += aiRet[0];
					break;
					
				default:
					throw new System.ArgumentException("Erreur dans le paramètre de CalculeManche !");
			}
		}
		
		/*
		 * Remise à zéro de tous les compteurs
		 */
		void Clear()
		{
			iMancheGagneA = iManchePerduA = 0;
			iMancheGagneB = iManchePerduB = 0;
			iMancheGagneC = iManchePerduC = 0;
			iMancheGagneD = iManchePerduD = 0;
		}
		
		// Recherche du nombre de manche de gagné et perdu
		int[] ScoreManche( int iRow )
		{
			int g = 0, p = 0;
			string s;
			
			for(int iCol = 5; iCol < 10; iCol++)
			{
				s = dgv.Rows[iRow].Cells[iCol].Value.ToString();
				
				// "/" cellule vide
				if( s.CompareTo("/") != 0)
				{
					// Le score commence pas un '-'
					if (s[0] == '-')
						p++;
					else
						g++;
				}
			}
			return new int[] { g, p };
		}
		
		// Affiche le rapport du traitement
		void setTextRapport( string sText, bool bold = false) { SingletonOutils.setTextRapport( txtRapport, sText, bold); }
		
		// Affichage des résultats
		public void Dump()
		{
			setTextRapport( "MANCHES", true);
			setTextRapport( "+---+-----+-----+--------+");
			setTextRapport( "|   |Gagné|Perdu|Quotient|");
			setTextRapport( "+---+-----+-----+--------+");
			setTextRapport( "| A | " + string.Format("{0:000} | {1:000} | {2:n4} |", iMancheGagneA, iManchePerduA, (float) ( iMancheGagneA ) / (float) ( iManchePerduA )) );
			setTextRapport( "+---+-----+-----+--------+");
			setTextRapport( "| B | " + string.Format("{0:000} | {1:000} | {2:n4} |", iMancheGagneB, iManchePerduB, (float) ( iMancheGagneB ) / (float) ( iManchePerduB )) );
			setTextRapport( "+---+-----+-----+--------+");
			setTextRapport( "| C | " + string.Format("{0:000} | {1:000} | {2:n4} |", iMancheGagneC, iManchePerduC, (float) ( iMancheGagneC ) / (float) ( iManchePerduC )) );
			setTextRapport( "+---+-----+-----+--------+");
			setTextRapport( "| D | " + string.Format("{0:000} | {1:000} | {2:n4} |", iMancheGagneC, iManchePerduC, (float) ( iMancheGagneC ) / (float) ( iManchePerduC )) );
			setTextRapport( "+---+-----+-----+--------+");
		}

        public void Dump3()
        {
            setTextRapport("MANCHES", true);
            setTextRapport("+---+-----+-----+--------+");
            setTextRapport("|   |Gagné|Perdu|Quotient|");
            setTextRapport("+---+-----+-----+--------+");
            setTextRapport("| A | " + string.Format("{0:000} | {1:000} | {2:n4} |", iMancheGagneA, iManchePerduA, (float)(iMancheGagneA) / (float)(iManchePerduA)));
            setTextRapport("+---+-----+-----+--------+");
            setTextRapport("| B | " + string.Format("{0:000} | {1:000} | {2:n4} |", iMancheGagneB, iManchePerduB, (float)(iMancheGagneB) / (float)(iManchePerduB)));
            setTextRapport("+---+-----+-----+--------+");
            setTextRapport("| C | " + string.Format("{0:000} | {1:000} | {2:n4} |", iMancheGagneC, iManchePerduC, (float)(iMancheGagneC) / (float)(iManchePerduC)));
            setTextRapport("+---+-----+-----+--------+");
        }
    }
}
