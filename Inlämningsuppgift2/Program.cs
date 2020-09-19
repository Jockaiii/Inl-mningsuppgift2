using Microsoft.VisualBasic.CompilerServices;
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
            int amount_operators, count=1, count2 = 1;

            amount_operators = Get_input.Operator_quantity();

            string[] operators = new string[amount_operators];
            int[] values = new int[amount_operators + 1];

            for (int i = 0; i < amount_operators; i++)
            {
                Console.Write("Ange operatör nr " + count + ": ");
                operators[i] = Get_input.Get_operator();
                Console.WriteLine(operators[i]);
                count++;
            }
            for (int i = 0; i < amount_operators + 1; i++)
            {
                Console.Write("ange värde " + count2 + ": ");
                values[i] = Get_input.Get_value();
                Console.WriteLine(values[i]);
                count2++;
            }                       
        }
    }
    class Get_input
    {
        public static int Operator_quantity()
        {
            int svar = 0;
            bool a;

            do
            {
                try
                {
                    Console.Write("Ange hur många operatörer du vill ha: ");
                    svar = Convert.ToInt32(Console.ReadLine());
                    a = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Du har anget ett felaktivt värde, vänligen försök igen");
                    a = true;
                }
            } while (a != false);
            return svar;
        }
        public static string Get_operator()
        {
            string allowed_operators = "+-*/", svar;
            bool a;

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
        public static int Get_value()
        {
            int svar = 0;
            bool a;

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
    class Calculate
    {
        public static int get_order(string svar)
        {
            switch (svar)
            {
                case "x":
                    return 1;
                case "/":
                    return 2;
                case "+":
                    return 3;
                case "-":
                    return 4;
                default:
                    return 0;
            }
        }

        //public static double calc(int order)
        //{
        //    if (order == 1)
        //    {

        //    }
        //    else if (order == 2)
        //    {

        //    }
        //    else if (order == 3)
        //    {

        //    }
        //    else if (order == 4)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}
    }
}
