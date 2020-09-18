using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Dynamic;
using System.Linq.Expressions;
using System.Threading;

namespace Inlämningsuppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount_operators = 0, count=1, count2 = 1;
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

            //amount_operators = get_input.operator_quantity(0);

            string[] operators = new string[amount_operators];
            int[] values = new int[amount_operators + 1];

            for (int i = 0; i < amount_operators; i++)
            {
                Console.Write("Ange operatör nr " + count + ": ");
                operators[i] = get_input.Get_operator("amount_operators");
                Console.WriteLine(operators[i]);
                count++;
            }
            for (int i = 0; i < amount_operators + 1; i++)
            {
                Console.Write("ange ett värde " + count2 + ": ");
                values[i] = get_input.Get_value(amount_operators);
                Console.WriteLine(values[i]);
                count2++;
            }

            //    for (int i = 0; i < amount_operators; i++)
            //    {
            //        Console.Write("Ange operatör nr " + (i + 1) + ": ");
            //        operators[i] = Console.ReadLine();

            //        while (!allowed_operators.Contains(operators[i]) || operators[i].Length != 1)
            //        {
            //            Console.Write("Du har angivit ett felaktivt värde, vänligen försök igen: ");
            //            operators[i] = Console.ReadLine();
            //        }
            //    }

            //    for (int i = 0; i < amount_operators + 1; i++)
            //    {
            //        bool a = true;
            //        do
            //        {
            //            try
            //            {
            //                Console.Write("Ange ett värde " + (i + 1) + ": ");
            //                values[i] = Convert.ToInt32(Console.ReadLine());
            //                a = false;
            //            }
            //            catch (FormatException)
            //            {
            //                Console.WriteLine("Du har anget ett felaktivt värde, vänligen försök igen:");
            //                a = true;
            //            }
            //        } while (a != false);

            //    }
            }

            class get_input
        {
            public static string Get_operator(string text)
            {
                string allowed_operators = "+-*/", svar = "hej";
                bool a = true;

                do
                {
                    svar = Console.ReadLine();
                    a = false;

                    while (!allowed_operators.Contains(svar) || svar.Length != 1)
                    {
                        Console.Write("Du har angivit ett felaktivt värde, vänligen försök igen: ");
                        svar = Console.ReadLine();
                        a = true;
                    }
                } while (a != false);                
                return svar;
            }

            public static int Get_value(int amount_operators)
            {
                int svar = 0;
                bool a = true;

                do
                {
                    try
                    {
                        svar = Convert.ToInt32(Console.ReadLine());
                        a = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("du har anget ett felaktivt värde, vänligen försök igen:");
                        a = true;
                    }
                } while (a != false);
                return svar;
            }
        }
        class calculate
        {

        }
    }
}
