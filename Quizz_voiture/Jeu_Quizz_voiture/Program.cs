using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_Quizz_voiture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> marque = new List<string>()
            {
                "Mercedes", "BMW", "Volswagen", "Audi", "Peugeot", "Renault", "Citroën", "Hyundai", "Nissan", "Ferrari"
            };

            List<string> pays = new List<string>()
            {
                "ALLEMAGNE", "FRANCE", "ITALIE", "CORRE DU SUD", "JAPON"
            };

            Console.WriteLine("Bonjour ceci est un jeu de quizz sur les voitures\n");
            Console.WriteLine("Le but du jeu est le suivant : ");
            Console.WriteLine("- Une marque de voiture va apparaître et vous devrez taper dans la console au pays auquel il appartient en majuscule (les accents ne sont pas pris en compte)");
            Console.WriteLine("- Si vous avez une bonne réponse vous aurez 1 point sinon 0");
            Console.WriteLine("- Par rapport au nombre de point que vous aurez accumulez, un niveau vous sera attribuer\n");
            Console.WriteLine("Les niveaux sont :");
            Console.WriteLine("- expert pour un score de 10 points");
            Console.WriteLine("- bon niveau pour un score entre 7 et 9");
            Console.WriteLine("- moyen pour un score entre 4 et 6");
            Console.WriteLine("- faible pour un score inférieur à 4");

            int points = 0;

            // Poser la question
            foreach(var m in marque)
            {
                try
                {
                    Console.Write($"A quelle pays appartient {m} : ");
                    // stocker la réponse
                    string reponse = Console.ReadLine();

                    // check si le pays correspond à la voiture
                    bool check = check_m_p(m, reponse);

                    if (check)
                    {
                        points++;
                    }
                    else
                    {
                        Console.WriteLine("Mauvaise réponse");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Erreur : {e.Message}");
                }

            }

            string niveau_joueur = niveau(points);

            Console.WriteLine($"Voici votre niveau : {niveau_joueur}");

            Console.WriteLine("Récapitulatif de votre partie");
            /*
             * ici dans le récapitulatif ajouter le nombre de bonne réponse le nombres de mauvaise réponse
             * le point total
             * afficher les bonne réponse et les mauvaises réponse ( idée = stocker dans une liste les bonne réponse et les mauvaises réponse par rapport à check faire deux liste bonne et mauvaise et stocker par rapport à check
             * afficher la correction pour les mauvaises réponses ( voir pour methode)
             */

        }

        // check si le pays correspond à la marque de la voiture
        static bool check_m_p(string marque, string pays)
        {
            bool compatible = false;
            
            if (marque == "Mercedes" || marque == "BMW" || marque == "Audi" || marque == "Volswagen")
            {
                if (pays == "ALLEMAGNE")
                {
                    compatible = true;
                }
            }
            else if (marque == "Peugeot" || marque == "Citroën" || marque == "Renault")
            {
                if (pays == "FRANCE")
                {
                    compatible = true;
                }
            }
            else if (marque == "Hyundai")
            {
                if(pays == "CORRE DU SUD")
                {
                    compatible = true;
                }
            }
            else if(marque == "Nissan")
            {
                if (pays == "JAPON")
                {
                    compatible = true;
                }
            }
            else if(marque == "Ferrari")
            {
                if(pays == "ITALIE")
                {
                    compatible = true;
                }
            }
            return compatible;
        }

        // renvoie le niveau du joueur par rapport aux nombres de points accumulés
        static string niveau(int pts)
        {
            string niveaux = "";
            if (pts < 4)
            {
                niveaux = "faible";
            }
            else if (pts >= 4 && pts <= 6)
            {
                niveaux = "moyen";
            }
            else if (pts >7 && pts <= 9)
            {
                niveaux = "bon";
            }
            else
            {
                niveaux = "expert";
            }

            return niveaux;
        }
    }
}
