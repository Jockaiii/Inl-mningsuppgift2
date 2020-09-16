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

            try
            {
                Console.Write("Ange hur många operatörer du vill ha: ");
                amount_operators = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Du har anget ett felaktivt värde, vänligen försök igen");
                Console.Write("Ange hur många operatörer du vill ha: ");
                amount_operators = Convert.ToInt32(Console.ReadLine());

            }

            string[] operators = new string[amount_operators];
            int[] values = new int[amount_operators + 1];

            //get_input.Get_operator("Hej");
            //get_input.Get_value(1);

            for (int i = 0; i < amount_operators; i++)
            {
                do
                {
                    try
                    {
                        Console.Write("Ange operatör nr " + (i + 1) + ": ");
                        operators[i] = Console.ReadLine();

                    }
                    catch (FormatException)
                    {
                        Console.Write("Du har angivet ett felaktivt värde. Vänligen skriv in en operatör: ");
                        operators[i] = Console.ReadLine();
                    }
                } while (operators[i].Contains(allowed_operators) && operators[i].Length == 1);
            }

            for (int i = 0; i < amount_operators + 1; i++)
            {
                try
                {
                    Console.Write("Ange ett värde: ");
                    values[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Du har anget ett felaktivt värde, vänligen försök igen:");
                    values[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        //class get_input
        //{

        //    public static string Get_operator(string text)
        //    {
        //        int amount_operators = 0;
        //        string allowed_operators = "+-*/", svar="hej";

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
        //                catch (Exception)
        //                {
        //                    Console.Write("Du har angivet ett felaktivt värde. Vänligen skriv in en operatör: ");
        //                    operators[i] = Console.ReadLine();
        //                    svar = operators[i];

        //                }
        //            } while (operators[i] != allowed_operators && operators[i].Length != 1);
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
        //                Console.Write("Ange ett värde");
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
