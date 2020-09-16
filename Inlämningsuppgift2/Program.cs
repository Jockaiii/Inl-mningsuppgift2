using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Dynamic;
using System.Linq.Expressions;

namespace Inlämningsuppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount_operators = 0;
            string allowed_operators = "+-*/";
            bool b = true;

            do
            {
                try
                {
                    Console.Write("Ange hur många operatörer du vill ha: ");
                    amount_operators = Convert.ToInt32(Console.ReadLine());
                    b = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Du har anget ett felaktivt värde, vänligen försök igen");
                    b = true;
                }
            } while (b != false);
            

            string[] operators = new string[amount_operators];
            int[] values = new int[amount_operators + 1];

            //for (int i = 0; i < amount_operators; i++)
            //{
            //    operators[i] = get_input.Get_operator(operators[i]);
            //    Console.WriteLine(operators[i]);
            //}

            //for (int i = 0; i < amount_operators + 1; i++)
            //{
            //    values[i] = get_input.Get_value(values[i]);
            //    Console.WriteLine(values[i]);
            //}

            for (int i = 0; i < amount_operators; i++)
            {
                Console.Write("Ange operatör nr " + (i + 1) + ": ");
                operators[i] = Console.ReadLine();

                while (!allowed_operators.Contains(operators[i]) || operators[i].Length != 1)
                {
                    Console.Write("Du har angivit ett felaktivt värde, vänligen försök igen: ");
                    operators[i] = Console.ReadLine();
                }
            }

            for (int i = 0; i < amount_operators + 1; i++)
            {
                bool a = true;
                do
                {
                    try
                    {
                        Console.Write("Ange ett värde " + (i + 1) + ": ");
                        values[i] = Convert.ToInt32(Console.ReadLine());
                        a = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Du har anget ett felaktivt värde, vänligen försök igen:");
                        a = true;
                    }
                } while (a != false);
                               
            }
        }

        //class get_input
        //{

        //    public static string Get_operator(string text)
        //    {
        //        int amount_operators = 0;
        //        string allowed_operators = "+-*/", svar = "hej";

        //        string[] operators = new string[amount_operators];
        //        int[] values = new int[amount_operators + 1];

        //        for (int i = 0; i < amount_operators; i++)
        //        {
        //            do
        //            {
        //                try
        //                {
        //                    Console.Write("Ange operatör nr " + (i + 1) + ": ");
        //                    operators[i] = Console.ReadLine();
        //                    svar = operators[i];

        //                }
        //                catch (FormatException)
        //                {
        //                    Console.Write("Du har angivet ett felaktivt värde. Vänligen skriv in en operatör: ");
        //                    operators[i] = Console.ReadLine();
        //                    svar = operators[i];

        //                }
        //            } while (operators[i].Contains(allowed_operators) && operators[i].Length == 1);
        //        }
        //        return svar;
        //    }

        //    public static int Get_value(int nummer)
        //    {
        //        int amount_operators = 0, svar = 0;

        //        string[] operators = new string[amount_operators];
        //        int[] values = new int[amount_operators + 1];

        //        for (int i = 0; i < amount_operators + 1; i++)
        //        {
        //            try
        //            {
        //                Console.Write("Ange ett värde: ");
        //                values[i] = Convert.ToInt32(Console.ReadLine());
        //                svar = values[i];
        //            }
        //            catch (FormatException)
        //            {
        //                Console.WriteLine("Du har anget ett felaktivt värde, vänligen försök igen:");
        //                values[i] = Convert.ToInt32(Console.ReadLine());
        //                svar = values[i];
        //            }
        //        }
        //        return svar;
        //    }
        //}

        //class calculate
        //{

        //}
    }
}
