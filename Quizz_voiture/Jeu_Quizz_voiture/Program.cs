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
                "Mercedes", "Peugeot", "Ferrari", "Volswagen", "Citroën", "BMW", "Hyundai", "Nissan", "Renault", "Audi"
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
            Console.WriteLine("- faible pour un score inférieur à 4\n");

            int points = 0;
            List<string> bonne_reponse = new List<string>();
            List<string> mauvaise_reponse = new List<string>();

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
                        bonne_reponse.Add(m);
                    }
                    else
                    {
                        Console.WriteLine("Mauvaise réponse");
                        mauvaise_reponse.Add(m);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Erreur : {e.Message}");
                }

            }

            string niveau_joueur = niveau(points);
            Console.WriteLine();

            Console.WriteLine($"Voici votre niveau : {niveau_joueur}\n");

            Console.WriteLine("Récapitulatif de votre partie : ");

            //nombre de bonne réponse et de mauvaise reponse
            int reponse_ok = check_nb_bonne_reponse(bonne_reponse);
            int reponse_mauvais = check_nb_mauvaise_reponse(mauvaise_reponse);
            Console.WriteLine($"bonne reponse : {reponse_ok}");
            Console.WriteLine($"mauvaise reponse : {reponse_mauvais}");

            // le pooint total
            Console.WriteLine($"Point total : {points}");

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

        // renvoie le nombre de bonne réponse 
        static int check_nb_bonne_reponse(List<string> bonne_reponse)
        {
            int nb_b_reponse = bonne_reponse.Count;

            return nb_b_reponse;
        }

        // renvoie le nombre de mauvaise reponse
        static int check_nb_mauvaise_reponse(List<string> mauvaise_reponse)
        {
            int nb_m_reponse = mauvaise_reponse.Count;

            return nb_m_reponse;
        }
    }
}
