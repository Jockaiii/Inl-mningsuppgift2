using System;
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
                if (operators[j].Contains("*"))
                    keep_calc[j] = Calculate.Check_multiplier(values[j], values[j + 1]);
            }
            for (int j = 0; j < amount_operators; j++)
            {
                if(operators[j].Contains("/"))
                keep_calc[j] = Calculate.Check_division(operators, values, keep_calc, j);
            }
            for (int j = 0; j < amount_operators; j++)
            {
                if (operators[j].Contains("+"))
                    keep_calc[j] = Calculate.Check_addition(operators[j], values[j], values[j + 1], j);
            }
            for (int j = 0; j < amount_operators; j++)
            {
                if (operators[j].Contains("-"))
                    keep_calc[j] = Calculate.Check_subtraktion(operators[j], values[j], values[j + 1], j);
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
        public static double Check_multiplier(int värde1, int värde2)
        {
            double svar;
            svar = värde1 * värde2;
            return svar;
        }

        public static double Check_division(string[] operators, int[] values, double[] keep_calc, int j)
        {
            double svar = 0;
            try
            {
                if (operators[j].Contains("/") && operators[j - 1].Contains("*") && operators[j + 1].Contains("*"))
                {
                    keep_calc[j - 1] /= values[j + 1];
                    keep_calc[j - 1] *= keep_calc[j + 1];
                    keep_calc[j + 1] = 0;
                }
                else if (operators[j].Contains("/") && operators[j - 1].Contains("*"))
                {
                    keep_calc[j - 1] /= values[j + 1];
                }               
            }
            catch (IndexOutOfRangeException)
            {
               if (operators[j].Contains("/") && operators[j + 1].Contains("*"))
                {
                    keep_calc[j + 1] = values[j] / keep_calc[j +1];
                }
                else
                {
                    svar = values[j] / values[j + 1];
                }
            }               
            return svar;
        }

        public static double Check_addition(string operator_pos, int värde1, int värde2, int i)
        {
            double svar = 0;
            return svar;
        }

        public static double Check_subtraktion(string operator_pos, int värde1, int värde2, int i)
        {
            double svar = 0;
            return svar;
        }
    }
}
