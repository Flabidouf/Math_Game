using System;

namespace Math_Game
{
    class Program
    {
        enum e_Operator
        {
            ADDITION = 1,
            MULTIPLICATION = 2,
            SOUSTRACTION = 3
        }


        static bool AskQuestion(int min, int max) // min et max lié aux paramètres de la fonction dans Main
        {  
            // Randow number generator
            Random rand = new Random();
           
            int answerInt = 0;           
            while (true)
            {
                int a = rand.Next(min, max + 1);
                int b = rand.Next(min, max + 1);
                e_Operator o = (e_Operator)rand.Next(1, 4); // le "e_Operator"
                int awaitedResult;
                // o => 1 ou 2
                //      1 -> addition
                //      2 -> multiplication


                if (o == e_Operator.ADDITION)
                {
                    Console.WriteLine(a + " + " + b + " = ");
                    awaitedResult = a + b;
                }
                else if (o == e_Operator.MULTIPLICATION)
                {
                    Console.WriteLine(a + " x " + b + " = ");
                    awaitedResult = a * b;
                }
                else if (o == e_Operator.SOUSTRACTION)
                {
                    Console.WriteLine(a + " - " + b + " = ");
                    awaitedResult = a - b;
                }else
                {
                    Console.WriteLine("Error, operator unknown");
                    return false;
                }


               
                string response = Console.ReadLine();

                try
                {
                    answerInt = int.Parse(response);
                    if (answerInt == awaitedResult) // To match the new operators' results with user answers.
                    {
                        return true;
                    }

                    return false;
                }
                catch
                {
                    Console.WriteLine("Error, you have to enter a number");
                }
            }



        }

        static void Main(string[] args)
        {

            const int MIN = 1;
            const int MAX = 10;
            int NB_QUESTIONS = 10;

            int points = 0;

            for (int i = 0; i < NB_QUESTIONS; i++)
            {
                Console.WriteLine("Question n°" + (i+1) + " / " + NB_QUESTIONS);
                Console.WriteLine();
                bool goodAnswer = AskQuestion(MIN, MAX);

                if (goodAnswer)
                {
                    Console.WriteLine("Correct anwser");
                    points++; // On ajoute 1 point par bonne réponse.
                }
                else
                {
                    Console.WriteLine("Wrong answer");
                }
                Console.WriteLine();
                
            }

            Console.WriteLine("Number of points : " + points + "/" + NB_QUESTIONS);
            // On affiche le nombre de points une fois la boucle terminée.
         
            int average = NB_QUESTIONS / 2;

            if (points == NB_QUESTIONS)
            {
                Console.WriteLine("Excellent !");
            }
            else if (points == 0)
            {
                Console.WriteLine("Better luck next time");
            }
            else if (points > average)
            {
                Console.WriteLine("You can do better but you did good");
            }
            else
            {
                Console.WriteLine("Surely this is not your best");
            }
            
        }
    }
}

