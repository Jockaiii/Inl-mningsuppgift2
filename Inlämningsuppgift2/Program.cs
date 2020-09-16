using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Inlämningsuppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount_operators=0;

            string[] operators = new string[amount_operators];
            int[] values = new int[amount_operators + 1];

            string allowed_operators = "+-*/";

            try
            {
                Console.Write("Ange hur många operatörer du vill ha: ");
                amount_operators = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Du har anget ett felaktivt värde, vänligen försök igen:");
                Console.Write("Ange hur många operatörer du vill ha: ");
                amount_operators = Convert.ToInt32(Console.ReadLine());

            }

            for (int i = 0; i < amount_operators; i++)
            {
                if (operators[i] == allowed_operators)
                {
                    Console.Write("Ange operatör nr " + (i + 1) + ": ");
                    operators[i] = Console.ReadLine();
                }
                else
                {
                    Console.Write("Du har angivet ett felaktivt värde. Vänligen skriv in en operatör: ");
                }
            }

            for (int i = 0; i < amount_operators + 1; i++)
            {
                try
                {
                    Console.Write("Ange ett värde");
                    values[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Du har anget ett felaktivt värde, vänligen försök igen:");
                    values[i] = Convert.ToInt32(Console.ReadLine());
                }
            }

            //amount_operators[i] = get_operators();


        }

        //get_operators()
    }
}
