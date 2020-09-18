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
            bool a = true;

            do
            {
                try
                {
                    Console.Write("Ange hur många operatörer du vill ha: ");
                    amount_operators = Convert.ToInt32(Console.ReadLine());
                    a = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Du har anget ett felaktivt värde, vänligen försök igen");
                    a = true;
                }
            } while (a != false);

            //amount_operators = get_input.operator_quantity(0);

            string[] operators = new string[amount_operators];
            int[] values = new int[amount_operators + 1];

            for (int i = 0; i < amount_operators; i++)
            {
                Console.Write("Ange operatör nr " + count + ": ");
                operators[i] = get_input.Get_operator("Hej");
                Console.WriteLine(operators[i]);
                count++;
            }
            for (int i = 0; i < amount_operators + 1; i++)
            {
                Console.Write("ange värde " + count2 + ": ");
                values[i] = get_input.Get_value(amount_operators);
                Console.WriteLine(values[i]);
                count2++;
            }
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

                        if (!allowed_operators.Contains(svar) || svar.Length != 1)
                        {
                            Console.Write("Du har angivit ett felaktivt värde, vänligen försök igen: ");
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
                            Console.Write("du har anget ett felaktivt värde, vänligen försök igen:");
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
