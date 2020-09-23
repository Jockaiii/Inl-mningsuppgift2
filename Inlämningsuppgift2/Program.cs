using System;
using System.Diagnostics.SymbolStore;
using System.Runtime.ExceptionServices;

namespace Inlämningsuppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            double svar = 0;
            int amount_operators, count = 1, count2 = 1;

            amount_operators = Get_input.Operator_quantity();

            string[] operators = new string[amount_operators];
            int[] values = new int[amount_operators + 1];
            double[] keep_calc = new double[amount_operators];

            for (int i = 0; i < amount_operators; i++)
            {
                Console.Write("Ange operatör nr " + count + ": ");
                operators[i] = Get_input.Get_operator();
                count++;
            }
            for (int i = 0; i < amount_operators + 1; i++)
            {
                Console.Write("Ange värde " + count2 + ": ");
                values[i] = Get_input.Get_value();
                count2++;
            }

            for (int j = 0; j < amount_operators; j++)
            {
                if (operators[j].Contains("/") || operators[j].Contains("*"))
                    keep_calc[j] = Calculate.Multiplication_Division (operators, values, keep_calc, j);
            }
            for (int j = 0; j < amount_operators; j++)
            {
                if (operators[j].Contains("+") || operators[j].Contains("-"))
                    keep_calc[j] = Calculate.Addition_Subtraction(operators, values, keep_calc, j);
            }

            for (int i = 0; i < keep_calc.Length; i++)
            {
                svar += keep_calc[i];
            }
            Console.Write("svaret är = " + svar);
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
                    Console.Write("Du har anget ett felaktivt värde, vänligen försök igen:");
                    a = true;
                }
            } while (a != false);
            return svar;
        }
    }
    class Calculate
    {
        public static int check_amount_of_operators_in_a_row(string[]operators, int j)
        {
            int svar = 1, count = 1;
            try
            {
                while (operators[j - count].Contains("*") || operators[j - count].Contains("/"))
                {
                    svar += 1;
                    count++;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return svar;
            }                                                
            return svar;
        }
        public static double Multiplication_Division(string[] operators, int[] values, double[] keep_calc, int j)
        {
            double svar = 0;
            try
            {
                if (operators[j].Contains("*") && operators[j - 1].Contains("*"))
                {
                    keep_calc[j - check_amount_of_operators_in_a_row(operators, j) + 1 ] *= values[j + 1];
                }
                else if (operators[j].Contains("*") && operators[j - 1].Contains("/"))
                {
                    keep_calc[j - check_amount_of_operators_in_a_row(operators, j) + 1 ] *= values[j + 1];
                }
                else if (operators[j].Contains("/") && operators[j - 1].Contains("/"))
                {
                    keep_calc[j - check_amount_of_operators_in_a_row(operators, j) + 1 ] /= values[j + 1];
                }
                else if (operators[j].Contains("/") && operators[j - 1].Contains("*"))
                {
                    keep_calc[j - check_amount_of_operators_in_a_row(operators, j) + 1] /= values[j + 1];
                }                           
            }
            catch (IndexOutOfRangeException)
            {
                if(operators[j].Contains("/"))
                {
                    svar = values[j] / values[j + 1];
                }
                else if (operators[j].Contains("*"))
                {
                    svar = values[j] * values[j + 1];
                }
            }
            return svar;
        }
        public static double Addition_Subtraction(string[] operators, int[] values, double[] keep_calc, int j)
        {
            double svar = 0;

            return svar;
        }
    }
}
