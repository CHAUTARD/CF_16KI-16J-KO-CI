/*
 * User: CHAUTARD
 * Date: 01/03/2023
 */
using CF_16KI_16J_KO_CI.Modeles;
using System;
using System.Windows.Forms;

namespace CF_16KI_16J_KO_CI.Gestion
{
    internal class PointsParties
    {
        DataGridView dgv;
        RichTextBox txtRapport;
        char cPoule;

        // _aPointJoueur[4] => 1 = Points Partie
        private int[] aJoueurPointsParties = { 0, 0, 0, 0 };

        // Nombre de joueurs
        private int iNbJoueur = 0;

        // Indice des joueurs dans la List<Joueur>
        private int[] aListJoueurs = { 0, 0, 0, 0 };

        private int[] aJoueurClassement = { 99, 99, 99, 99};
        private int iJoueur1;
        private int iJoueur2;
        private int iJoueur3;
        private int iJoueur4;
        
        public PointsParties(char _cPoule, DataGridView _dgv, RichTextBox _txtRapport)
        {
            this.cPoule = _cPoule;
            this.dgv = _dgv ?? throw new ArgumentNullException(nameof(dgv));
            this.txtRapport = _txtRapport ?? throw new ArgumentNullException(nameof(txtRapport));

            this.txtRapport.Clear();
        }

        /* Récupération des points parties déjà calculés
         */
        public void SetPointsPartie(int _iJoueur1Points, int _iJoueur2Points, int _iJoueur3Points, int _iJoueur4Points)
        {
            aJoueurPointsParties[0] = _iJoueur1Points;
            aJoueurPointsParties[1] = _iJoueur2Points;
            aJoueurPointsParties[2] = _iJoueur3Points;
            aJoueurPointsParties[3] = _iJoueur4Points;

            aListJoueurs = SingletonOutils.GetJoueurPoule4(cPoule);

            // Ajout du nombre de joueur présent dans la poule
            for (int i = 0; i < 4; i++)
                if (SingletonOutils.lJoueurs[aListJoueurs[i]].GetNom(0).Length > 0)
                    iNbJoueur++;

            iJoueur1 = aListJoueurs[0];
            iJoueur2 = aListJoueurs[1];
            iJoueur3 = aListJoueurs[2];
            iJoueur4 = aListJoueurs[3];
        }

        /*------------------------------------------------------------------------------------------------------------------------*/

        // Classsement de 2 à 4 joueurs dans une poule
        public int[] Classement()
        {
            // 1 seul joueur
            if (iNbJoueur == 1)
            {
                AddJoueur(iJoueur1);
                return aJoueurClassement;
            }

            // Seulement 2 joueurs ( 1 - 2 )
            if (iNbJoueur == 2)
            {
                // Voir le résultat de la partie entre les deux joueurs
                if (aJoueurPointsParties[0] > aJoueurPointsParties[1])
                {
                    AddJoueur(iJoueur1);
                    AddJoueur(iJoueur2);
                }
                else
                {
                    AddJoueur(iJoueur2);
                    AddJoueur(iJoueur1);
                }
                return aJoueurClassement;
            }

            // 3 joueurs
            if (iNbJoueur == 3)
            {
                Classement3Joueur();
                return aJoueurClassement;
            }

            // 4 joueurs
            Classement4Joueur();

            return aJoueurClassement;
        }

        /*--------------------------------------------------------------------------
         * 					Classsement de 3 joueurs
         *--------------------------------------------------------------------------
         */
        void Classement3Joueur()
        {
            int[] aiEgal = { 0, 0, 0 };

            // Calcul des manches
            float[] afManche = { 0, 0, 0 };

            // Calcul des points
            float[] afPoint = { 0, 0, 0 };

            // Triple égalitée
            if (aJoueurPointsParties[0] == aJoueurPointsParties[1] && aJoueurPointsParties[1] == aJoueurPointsParties[2] )
            {
                SingletonOutils.setTextRapport(txtRapport, "Egalité Points Parties entre 1°, 2° et 3°", true);

                // Gestion des manches
                Manche manche = new Manche(dgv, txtRapport);

                manche.CalculeManche3(0, 1, 2);

                // Affichage des résultats
                manche.Dump();
            }
        }

        /*--------------------------------------------------------------------------
         * 					Classsement de 4 joueurs
         *--------------------------------------------------------------------------
         */
        void Classement4Joueur()
        {
            int[] aiEgal = { 0, 0, 0 };

            // Calcul des manches
            float[] afManche = { 0, 0, 0, 0 };

            // Calcul des points
            float[] afPoint = { 0, 0, 0, 0 };

            bool bouclePartie = true;

            /* Quadruple égalitée, le cas n'existe pas pour moi
             * a vérifier
             */
            if ( ( aJoueurPointsParties[0] == aJoueurPointsParties[1] ) && 
                ( aJoueurPointsParties[1] == aJoueurPointsParties[2]  ) && 
                ( aJoueurPointsParties[2] == aJoueurPointsParties[3]) )
            {
                SingletonOutils.setTextRapport(  txtRapport, "Egalité Points Parties entre 1, 2, 3 et 4", true);

                // Gestion des manches
                Manche manche = new Manche(dgv, txtRapport);

                manche.CalculeManche4(0, 1, 2, 3);

                // Affichage des résultats
                manche.Dump();

                // Affichage des résultat
                bouclePartie = false;
            }

            /*
             *  Est-il possible de ranger des joueurs dans le classement
             *  24  possibilités d'arrangement des 4 joueurs
             */
            for (int i = 0; i < 24 && bouclePartie; i++)
            {
                // Numero des joueurs
                iJoueur1 = SingletonOutils.aPossibleClassement[i, 0] - 1;
                iJoueur2 = SingletonOutils.aPossibleClassement[i, 1] - 1;
                iJoueur3 = SingletonOutils.aPossibleClassement[i, 2] - 1;
                iJoueur4 = SingletonOutils.aPossibleClassement[i, 3] - 1;

                // Tous les points sont différant
                if ((aJoueurPointsParties[iJoueur1] > aJoueurPointsParties[iJoueur2]) &&
                   (aJoueurPointsParties[iJoueur2] > aJoueurPointsParties[iJoueur3]) &&
                   (aJoueurPointsParties[iJoueur3] > aJoueurPointsParties[iJoueur4]))
                {
                    SingletonOutils.setTextRapport(txtRapport, (iJoueur1 + 1) + " > " + (iJoueur2 + 1) + " > " + (iJoueur3 + 1) + " > " + (iJoueur4 + 1), true);

                    AddJoueur(iJoueur1);
                    AddJoueur(iJoueur2);
                    AddJoueur(iJoueur3);
                    AddJoueur(iJoueur4);

                    bouclePartie = false; // Pas d'autre test
                    break; // Fin de boucle i
                }

                // Double égalité  1 = 2 et 3 = 4
                if (bouclePartie && (aJoueurPointsParties[iJoueur1] == aJoueurPointsParties[iJoueur2]) &&
                  (aJoueurPointsParties[iJoueur3] == aJoueurPointsParties[iJoueur4]))
                {
                    SingletonOutils.setTextRapport(txtRapport, "Egalité " + iJoueur1 + " et " + iJoueur2, true);
                    SingletonOutils.setTextRapport(txtRapport, "Egalité " + iJoueur3 + " et " + iJoueur4, true);

                    if (aJoueurPointsParties[0] > aJoueurPointsParties[2])
                    {
                        // QuiGagnePartie l'autre
                        if (SingletonOutils.QuiGagnePartie(dgv, iJoueur1, iJoueur2))
                        {
                            AddJoueur(iJoueur1);
                            AddJoueur(iJoueur2);
                        }
                        else
                        {
                            AddJoueur(iJoueur2);
                            AddJoueur(iJoueur1);
                        }

                        if (SingletonOutils.QuiGagnePartie(dgv, iJoueur3, iJoueur4))
                        {
                            AddJoueur(iJoueur3);
                            AddJoueur(iJoueur4);
                        }
                        else
                        {
                            AddJoueur(iJoueur4);
                            AddJoueur(iJoueur3);
                        }
                    }
                    else
                    {
                        if (SingletonOutils.QuiGagnePartie(dgv, iJoueur3, iJoueur4))
                        {
                            AddJoueur(iJoueur3);
                            AddJoueur(iJoueur4);
                        }
                        else
                        {
                            AddJoueur(iJoueur4);
                            AddJoueur(iJoueur3);
                        }

                        // QuiGagnePartie l'autre
                        if (SingletonOutils.QuiGagnePartie(dgv, iJoueur1, iJoueur2))
                        {
                            AddJoueur(iJoueur1);
                            AddJoueur(iJoueur2);
                        }
                        else
                        {
                            AddJoueur(iJoueur2);
                            AddJoueur(iJoueur1);
                        }
                    }

                    bouclePartie = false; // Pas d'autre test
                    break; // Fin de boucle i
                }

                // Double égalité  1 = 3 et 2 = 4
                if (bouclePartie && (aJoueurPointsParties[iJoueur1] == aJoueurPointsParties[iJoueur3]) &&
                    (aJoueurPointsParties[iJoueur2] == aJoueurPointsParties[iJoueur4]))
                {
                    SingletonOutils.setTextRapport(txtRapport, "Egalité " + iJoueur1 + " et " + iJoueur3, true);
                    SingletonOutils.setTextRapport(txtRapport, "Egalité " + iJoueur2 + " et " + iJoueur4, true);

                    if (aJoueurPointsParties[0] > aJoueurPointsParties[1])
                    {
                        // QuiGagnePartie l'autre
                        if (SingletonOutils.QuiGagnePartie(dgv, iJoueur1, iJoueur3))
                        {
                            AddJoueur(iJoueur1);
                            AddJoueur(iJoueur3);
                        }
                        else
                        {
                            AddJoueur(iJoueur3);
                            AddJoueur(iJoueur1);
                        }

                        if (SingletonOutils.QuiGagnePartie(dgv, iJoueur2, iJoueur4))
                        {
                            AddJoueur(iJoueur2);
                            AddJoueur(iJoueur4);
                        }
                        else
                        {
                            AddJoueur(iJoueur4);
                            AddJoueur(iJoueur2);
                        }
                    }
                    else
                    {
                        if (SingletonOutils.QuiGagnePartie(dgv, iJoueur2, iJoueur4))
                        {
                            AddJoueur(iJoueur2);
                            AddJoueur(iJoueur4);
                        }
                        else
                        {
                            AddJoueur(iJoueur4);
                            AddJoueur(iJoueur2);
                        }

                        // QuiGagnePartie l'autre
                        if (SingletonOutils.QuiGagnePartie(dgv, iJoueur1, iJoueur3))
                        {
                            AddJoueur(iJoueur1);
                            AddJoueur(iJoueur3);
                        }
                        else
                        {
                            AddJoueur(iJoueur3);
                            AddJoueur(iJoueur1);
                        }

                    }

                    bouclePartie = false; // Pas d'autre test
                    break; // Fin de boucle i
                }

                // Egalite sur les deux premiers
                if (bouclePartie && (aJoueurPointsParties[iJoueur1] == aJoueurPointsParties[iJoueur2]) &&
                   (aJoueurPointsParties[iJoueur2] > aJoueurPointsParties[iJoueur3]) &&
                   (aJoueurPointsParties[iJoueur3] > aJoueurPointsParties[iJoueur4]))
                {
                    SingletonOutils.setTextRapport(txtRapport, "Egalité " + iJoueur1 + " et " + iJoueur2, true);

                    // Recherche du résultat entre les deux
                    if (SingletonOutils.QuiGagnePartie(dgv, iJoueur1, iJoueur2))
                    {
                        AddJoueur(iJoueur1);
                        AddJoueur(iJoueur2);
                    }
                    else
                    {
                        AddJoueur(iJoueur2);
                        AddJoueur(iJoueur1);
                    }

                    AddJoueur(iJoueur3);
                    AddJoueur(iJoueur4);

                    bouclePartie = false; // Pas d'autre test
                    break; // Fin de boucle i
                }

                // Egalite sur les deux du milieu
                if (bouclePartie && (aJoueurPointsParties[iJoueur1] > aJoueurPointsParties[iJoueur2]) &&
                   (aJoueurPointsParties[iJoueur2] == aJoueurPointsParties[iJoueur3]) &&
                   (aJoueurPointsParties[iJoueur3] > aJoueurPointsParties[iJoueur4]))
                {
                    SingletonOutils.setTextRapport(txtRapport, "Egalité " + iJoueur2 + " et " + iJoueur3, true);

                    AddJoueur(iJoueur1);

                    // Recherche du résultat entre les deux
                    if (SingletonOutils.QuiGagnePartie(dgv, iJoueur2, iJoueur3))
                    {
                        AddJoueur(iJoueur2);
                        AddJoueur(iJoueur3);
                    }
                    else
                    {
                        AddJoueur(iJoueur3);
                        AddJoueur(iJoueur2);
                    }

                    AddJoueur(iJoueur4);

                    bouclePartie = false; // Pas d'autre test
                    break; // Fin de boucle i
                }

                // Egalite sur les deux de la fin
                if (bouclePartie && (aJoueurPointsParties[iJoueur1] > aJoueurPointsParties[iJoueur2]) &&
                   (aJoueurPointsParties[iJoueur2] > aJoueurPointsParties[iJoueur3]) &&
                   (aJoueurPointsParties[iJoueur3] == aJoueurPointsParties[iJoueur4]))
                {
                    SingletonOutils.setTextRapport(txtRapport, "Egalité " + iJoueur3 + " et " + iJoueur4, true);

                    AddJoueur(iJoueur1);
                    AddJoueur(iJoueur2);

                    // Recherche du résultat entre les deux
                    if (SingletonOutils.QuiGagnePartie(dgv, iJoueur3, iJoueur4))
                    {
                        AddJoueur(iJoueur3);
                        AddJoueur(iJoueur4);
                    }
                    else
                    {
                        AddJoueur(iJoueur4);
                        AddJoueur(iJoueur3);
                    }

                    bouclePartie = false; // Pas d'autre test
                    break;
                }


                /* Gestion des trois égalitées.
                 * 
                 *      1 = 2 = 3
                 * 		1 = 3 = 4
                 * 		1 = 2 = 4
                 * 		2 = 3 = 4
                 */
                if (bouclePartie && (aJoueurPointsParties[iJoueur1] == aJoueurPointsParties[iJoueur2]) &&
                   (aJoueurPointsParties[iJoueur2] == aJoueurPointsParties[iJoueur3]) &&
                   (aJoueurPointsParties[iJoueur3] < aJoueurPointsParties[iJoueur4]))
                {
                    AddJoueur(iJoueur4);

                    // Egalité des points partie
                    TroisEgal(iJoueur1, iJoueur2, iJoueur3);

                    bouclePartie = false; // Pas d'autre test
                }

                if (bouclePartie && (aJoueurPointsParties[iJoueur1] == aJoueurPointsParties[iJoueur2]) &&
                   (aJoueurPointsParties[iJoueur2] == aJoueurPointsParties[iJoueur3]) &&
                   (aJoueurPointsParties[iJoueur3] > aJoueurPointsParties[iJoueur4]))
                {
                    AddJoueur( 4,iJoueur4);

                    // Egalité des points partie
                    TroisEgal(iJoueur1, iJoueur2, iJoueur3);

                    bouclePartie = false; // Pas d'autre test
                }
            }


            // Affiche classement
            DumpClassement();
        }


        /*
         * Egalité des points partie entre les trois Joueurs
         * 
         * iA, iB, iC = Indice dans le tableau aPointJoueur ( 0, 1, 2, 3 )
         * 
         * Recalculer les points partie entre les trois joueurs.
         */
        void TroisEgal(int iA, int iB, int iC)
        {
            int iAPoints = 0;
            int iBPoints = 0;
            int iCPoints = 0;

            // Valeur 0..2 -> 1..3
            int iA2 = iA + 1; 
            int iB2 = iB + 1; 
            int iC2 = iC + 1;

            if (SingletonOutils.QuiGagnePartie(dgv, iA2, iB2)) { iAPoints += 2; iBPoints++; } else { iAPoints++; iBPoints += 2; }
            if (SingletonOutils.QuiGagnePartie(dgv, iA2, iC2)) { iAPoints += 2; iCPoints++; } else { iAPoints++; iCPoints += 2; }
            if (SingletonOutils.QuiGagnePartie(dgv, iB2, iC2)) { iBPoints += 2; iCPoints++; } else { iBPoints++; iCPoints += 2; }

            string sOrdonne;

            /* Retourne une chaine en fonction de l'ordre des joueurs
		     * 
		     * 				ABC, ACB, BAC, CBA, BCA, CAB
		     * 				A==, ==A, B==, ==B, C==, ==C => Egalité pour les deux autres
		     * 				=== => Egalité pour les trois
		     */
            if (iAPoints == iBPoints && iAPoints == iCPoints)
                sOrdonne = "===";
            else
            {
                if (iAPoints == iBPoints)
                {
                    if (SingletonOutils.QuiGagnePartie(dgv, iA2, iB2))
                    {
                        if (iCPoints > iAPoints)
                            sOrdonne = "CAB";
                        else
                            sOrdonne = "ABC";
                    }
                    else
                    {
                        if (iCPoints > iAPoints)
                            sOrdonne = "CBA";
                        else
                            sOrdonne = "BAC";
                    }
                }
                else
                {
                    if (iAPoints > iBPoints)
                    {
                        if (iBPoints > iCPoints)
                            sOrdonne = "ABC";
                        else
                            sOrdonne = "ACB";
                    }
                    else
                    {
                        if (iBPoints > iCPoints)
                            sOrdonne = "BAC";
                        else
                            sOrdonne = "BAC";
                    }

                    if (iAPoints == iCPoints)
                    {
                        if (iBPoints > iCPoints)
                            sOrdonne = "B==";

                        sOrdonne = "==B";
                    }

                    if (iAPoints == iCPoints)
                    {
                        if (iAPoints > iCPoints)
                            sOrdonne = "A==";

                        sOrdonne = "==A";
                    }

                    if (iAPoints > iCPoints)
                    {
                        if (iBPoints > iCPoints)
                            sOrdonne = "BAC";

                        sOrdonne = "CBA";
                    }
                    else
                    {
                        if (iBPoints > iCPoints)
                            sOrdonne = "BCA";

                        sOrdonne = "CAB";
                    }
                }
            }

            /*
             * sOrdonne = Ordonne3(iA2, iB2, iC2);
             */
            switch (sOrdonne)
            {
                case "===":
                    // Si égalité dans les points partie
                    // Calcul du quotient Manches gagnées / Manches Perdues

                    // Gestion des manches
                    Manche manche = new Manche(dgv, txtRapport);

                    manche.CalculeManche3(iA2, iB2, iC2);

                    // Affichage des résultats
                    manche.Dump3();

                    sOrdonne = manche.Quotient3(iA2, iB2, iC2);
                    switch (sOrdonne)
                    {
                        case "===":
                            // Calcul des points entre les trois joueurs
                            ManchesPoints manchePoints = new ManchesPoints(dgv, txtRapport);

                            manchePoints.CalculePoints3(iA2, iB2, iC2);

                            // Affichage des résultats
                            manchePoints.Dump(iA2, iB2, iC2);

                            sOrdonne = manchePoints.Quotient3(iA2, iB2, iC2);
                            switch (sOrdonne)
                            {
                                case "===":
                                    // Tirage au sort du gagnant
                                    Random random = new Random();

                                    int r1 = 0;
                                    int r2 = 0;
                                    int r3 = 0;
                                    int[] aRandom = new int[3];

                                    while (r1 == r2 || r2 == r3 || r1 == r3)
                                    {
                                        r1 = random.Next(1, 1000);
                                        r2 = random.Next(0, 1000);
                                        r3 = random.Next(0, 1000);
                                    }

                                    DumpSort3( r1, r2, r3);

                                    aRandom[0] = r1;
                                    aRandom[1] = r2;
                                    aRandom[2] = r3;

                                    // Trie le tableau en croissant
                                    Array.Sort(aRandom);

                                    if (aRandom[0] == r1)
                                        AddJoueur(iA);
                                    else
                                    {
                                        if (aRandom[0] == r2)
                                            AddJoueur(iB);
                                        else
                                            AddJoueur(iC);
                                    }

                                    if (aRandom[1] == r1)
                                        AddJoueur(iA);
                                    else
                                    {
                                        if (aRandom[1] == r2)
                                            AddJoueur(iB);
                                        else
                                            AddJoueur(iC);
                                    }

                                    if (aRandom[2] == r1)
                                        AddJoueur(iA);
                                    else
                                    {
                                        if (aRandom[2] == r2)
                                            AddJoueur(iB);
                                        else
                                            AddJoueur(iC);
                                    }

                                    break;

                                case "A==":
                                case "==A":
                                case "B==":
                                case "==B":
                                case "C==":
                                case "==C":
                                case "ABC":
                                case "ACB":
                                case "BAC":
                                case "BCA":
                                case "CAB":
                                case "CBA":
                                    Traite( sOrdonne, iA2, iB2, iC2);
                                    break;
                            }
                            break;

                        case "A==":
                        case "==A":
                        case "B==":
                        case "==B":
                        case "C==":
                        case "==C":
                        case "ABC":
                        case "ACB":
                        case "BAC":
                        case "BCA":
                        case "CAB":
                        case "CBA":
                            Traite(sOrdonne, iA2, iB2, iC2);
                            break;
                    }

                    break;

                case "A==":
                case "==A":
                case "B==":
                case "==B":
                case "C==":
                case "==C":
                case "ABC":
                case "ACB":
                case "BAC":
                case "BCA":
                case "CAB":
                case "CBA":
                    Traite( sOrdonne, iA2, iB2, iC2);
                    break;
            }
        }

        /*
         * Les différantes fonction possible pour classement des joueurs
         */
        void Traite(string sOrdonne, int _iA, int _iB, int _iC)
        {
            // Gestion 0..3 au lieu 1..4
            int iA = _iA -1;
            int iB = _iB -1;
            int iC = _iC -1;

            switch (sOrdonne[0])
            {
                case 'A':
                    AddJoueur(iA);
                    if (sOrdonne[2] == 'C')
                    {
                        AddJoueur(iB);
                        AddJoueur(iC);
                    }
                    else if (sOrdonne[2] == 'B')
                    {
                        AddJoueur(iC);
                        AddJoueur(iB);
                    }
                    else
                    {
                        if (SingletonOutils.ChercheVainqueur(dgv, iB, iC))
                        {
                            AddJoueur(iB);
                            AddJoueur(iC);
                        }
                        else
                        {
                            AddJoueur(iC);
                            AddJoueur(iB);
                        }
                    }
                    break;

                case 'B':
                    AddJoueur(iB);
                    if (sOrdonne[2] == 'C')
                    {
                        AddJoueur(iA);
                        AddJoueur(iC);
                    }
                    else if (sOrdonne[2] == 'A')
                    {
                        AddJoueur(iC);
                        AddJoueur(iA);
                    }
                    else
                    {
                        if (SingletonOutils.ChercheVainqueur(dgv, iA, iC))
                        {
                            AddJoueur(iA);
                            AddJoueur(iC);
                        }
                        else
                        {
                            AddJoueur(iC);
                            AddJoueur(iA);
                        }
                    }
                    break;

                case 'C':
                    AddJoueur(iC);
                    if (sOrdonne[2] == 'B')
                    {
                        AddJoueur(iA);
                        AddJoueur(iB);
                    }
                    else if (sOrdonne[2] == 'A')
                    {
                        AddJoueur(iB);
                        AddJoueur(iA);
                    }
                    else
                    {
                        if (SingletonOutils.ChercheVainqueur(dgv, iA, iB))
                        {
                            AddJoueur(iA);
                            AddJoueur(iB);
                        }
                        else
                        {
                            AddJoueur(iB);
                            AddJoueur(iA);
                        }
                    }
                    break;

                case '=':
                    if (sOrdonne[2] == 'A')
                    {
                        if (SingletonOutils.ChercheVainqueur(dgv, iB, iC))
                        {
                            AddJoueur(iB);
                            AddJoueur(iC);
                        }
                        else
                        {
                            AddJoueur(iC);
                            AddJoueur(iB);
                        }
                        AddJoueur(iA);
                    }
                    else if (sOrdonne[2] == 'B')
                    {
                        if (SingletonOutils.ChercheVainqueur(dgv, iA, iC))
                        {
                            AddJoueur(iA);
                            AddJoueur(iC);
                        }
                        else
                        {
                            AddJoueur(iC);
                            AddJoueur(iA);
                        }
                        AddJoueur(iB);
                    }
                    else if (sOrdonne[2] == 'C')
                    {
                        if (SingletonOutils.ChercheVainqueur(dgv, iA, iB))
                        {
                            AddJoueur(iA);
                            AddJoueur(iB);
                        }
                        else
                        {
                            AddJoueur(iB);
                            AddJoueur(iA);
                        }
                        AddJoueur(iC);
                    }
                    break;
            }
        }


        /*-----------------------------------------------------------------------------------------------------------
         *   Fonctions outils
         *----------------------------------------------------------------------------------------------------------*/

        /* Ajouter un joueur a la position donnée en paramètre
         * iPos = Position dans le classement ( 1, 2, 3, 4)
         * i = Numero du joueur dans la poule ( 1, 2, 3, 4 )
         */
        void AddJoueur(int iPos, int iJoueur)
        {
            aJoueurClassement[iPos - 1] = iJoueur;
        }

        /* Ajouter un joueur à la première place disponible
         * i = Numero du joueur dans la poule ( 1, 2, 3, 4 )
         */
        void AddJoueur(int iJoueur)
        {
            if (aJoueurClassement[0] == 99)
                AddJoueur(1, iJoueur);
            else if (aJoueurClassement[1] == 99)
                AddJoueur(2, iJoueur);
            else if (aJoueurClassement[2] == 99)
                AddJoueur(3, iJoueur);
            else
                AddJoueur(4, iJoueur);
        }

        /* Gestion des manches
         * Mise en couleur des manches gagnées
         * 
         * retourne le nombre de manche gagné pour J1
         *
        int[] GetMancheJoueur(int iRow)
        {
            int iMancheGagne = 0;
            int iManchePerdu = 0;
            string str;

            for (int iCol = 5; iCol < 10 && iMancheGagne < 3; iCol++)
            {
                str = dgv.Rows[iRow].Cells[iCol].Value.ToString();
                if (str[0] == '-')
                    iManchePerdu++;
                else

                    iMancheGagne++;
            }

            return new int[] { iMancheGagne, iManchePerdu };
        }
        */


        void DumpClassement()
        {
            int j;

            SingletonOutils.setTextRapport(txtRapport, "Classement", true);
            SingletonOutils.setTextRapport(txtRapport, "+---+------+----------------------------------------------------+");
            SingletonOutils.setTextRapport(txtRapport, "|Cls| N°/P |   Nom et Prénom                                    |");
            SingletonOutils.setTextRapport(txtRapport, "+---+------+----------------------------------------------------+");

            for (int i = 0; i < 4; i++)
            {
                j = aJoueurClassement[i];

                if (j < 99)
                { 
                    SingletonOutils.setTextRapport(txtRapport, string.Format("| {0} |   {1}  | {2} |", i + 1, 
                        SingletonOutils.lJoueurs[aListJoueurs[j]].NumInPoule, 
                        SingletonOutils.lJoueurs[aListJoueurs[j]].GetNom(0).PadRight(50)));
                    SingletonOutils.setTextRapport(txtRapport, "+---+------+----------------------------------------------------+");

                    // Mise a jour des informations sur le joueur
                    SingletonOutils.lJoueurs[aListJoueurs[j]].Poule = cPoule;
                    SingletonOutils.lJoueurs[aListJoueurs[j]].PouleClassement = i + 1;
                }
            }
        }

        void DumpSort3(int r1, int r2, int r3)
        {
            SingletonOutils.setTextRapport(txtRapport, "TIRAGE AU SORT", true);
            SingletonOutils.setTextRapport(txtRapport, "+---+----------+");
            SingletonOutils.setTextRapport(txtRapport, "|   |  Valeur  |");
            SingletonOutils.setTextRapport(txtRapport, "+---+----------+");
            SingletonOutils.setTextRapport(txtRapport, "| A |   " + string.Format("{0:0000}   |", r1));
            SingletonOutils.setTextRapport(txtRapport, "+---+----------+");
            SingletonOutils.setTextRapport(txtRapport, "| B |   " + string.Format("{0:0000}   |", r2));
            SingletonOutils.setTextRapport(txtRapport, "+---+----------+");
            SingletonOutils.setTextRapport(txtRapport, "| C |   " + string.Format("{0:0000}   |", r3));
            SingletonOutils.setTextRapport(txtRapport, "+---+----------+");
        }

        void showEgalite(int i, int j, int k)
        {
            int i1 = aJoueurClassement[i];
            int j1 = aJoueurClassement[j];
            int k1 = aJoueurClassement[k];

            SingletonOutils.setTextRapport(txtRapport, String.Format("Egalité {0}°, {1}° et {2}°", 
                SingletonOutils.lJoueurs[aListJoueurs[i1]].NumInPoule, 
                SingletonOutils.lJoueurs[aListJoueurs[j1]].NumInPoule, 
                SingletonOutils.lJoueurs[aListJoueurs[k1]].NumInPoule, true));
        }
    }
}
