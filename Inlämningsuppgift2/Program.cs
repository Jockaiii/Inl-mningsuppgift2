using System;
using System.Diagnostics.SymbolStore;
using System.Runtime.ExceptionServices;

namespace Inlämningsuppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Allmän deklarering
            double svar = 0;
            int amount_operators, count = 1, count2 = 1;

            //Hämtar input för amount_operators genom att kalla på metoden Operator_quantity
            amount_operators = Get_input.Operator_quantity();

            //Skapar arrayer för att lagra inputs frpn användaren och även lagra delberäkningar
            string[] operators = new string[amount_operators];
            double[] values = new double[amount_operators + 1];
            double[] keep_calc = new double[amount_operators];

            //Loopar igenom elementen inom operators[] och values[] och tillger dem sedan ett värde genom att tillkalla metoden Get_operator() och Get_values()
            for (int i = 0; i < amount_operators; i++)
            {
                Console.Write("Ange operatör nr " + count + ": ");
                operators[i] = Get_input.Get_operator();
                count++;
            }                                                   //Använder alldeles för många for loopar. Kan nog ha en metod med for loop i sig och tillkalla den för att minska kod. Dock är inte alla for loopar 
            for (int i = 0; i < amount_operators + 1; i++)      // lika tyvärr så måste hitta en smart lösning.
            {
                Console.Write("Ange värde " + count2 + ": ");
                values[i] = Get_input.Get_values();
                count2++;
            }

            //Börjar uträkningen av alla operatörer och värden genom att dela upp dem i delberäkningar så att jag kan prioritera multiplikation och division över addition och subtraktion.
            //Loopar igenom alla element i keep_calc och lagarar dem i keep calc_ samt tillger dem ett värde genom antigen metoden Multiplication_divsion() eller Addition_subtraction() beronde på operatör.
            for (int j = 0; j < amount_operators; j++)
            {
                if (operators[j].Contains("/") || operators[j].Contains("*"))
                    keep_calc[j] = Calculate.Multiplication_Division(operators, values, keep_calc, j);
            }
            for (int j = 0; j < amount_operators; j++)
            {
                if (operators[j].Contains("+") || operators[j].Contains("-"))
                    keep_calc[j] = Calculate.Addition_Subtraction(operators, values, keep_calc, j);
            }

            //loopar igenom alla element inom keep_calc och lägger ihop deluträkningarna till ett helt svar. som sedan skrivs ut i konsolen. 
            for (int i = 0; i < keep_calc.Length; i++)
            {
                svar += keep_calc[i];
            }
            Console.Write("svaret är = " + svar);
        }
    }
    class Get_input
    {
        //Metod Operator_quantity() har till uppgift att ta in input av avändaren och lagra det i variablen amount_operators. Men också att felhantera input tills att användaren anger ett godkänt värde.
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
        //Metoden Get_operator() har till uppgift att hämta input till alla element i operators[] men också felhantera inputs av användaren.
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
        //Metoden Get_values() har till uppgift att hämta input till alla element i values[] men också felhantera inputs av användaren.
        public static int Get_values()
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
        //Metod check_amount_of_operators_in_a_row har ett väldigt långt namn och räknar helt enkelt antalt operatörer innan ett * eller / för att relativt till den nuvarande operatörens position ändra ett 
        //lagrat värde i keep_calc. (Metoden tillkallas i Multiplikation_Divison())
        public static int check_amount_of_operators_in_a_row(string[] operators, int j)
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
        //Multiplication_divison() kollar ifall element "j" i operators[] innehåller * eller / samt kollar operatörer före och efter. Beroende på vad som finns omkring så kommer antigen ett nytt element lagras
        // i keep_ calc eller så kommer ett redan lagrat element skrivas över
        public static double Multiplication_Division(string[] operators, double[] values, double[] keep_calc, int j)
        {
            double svar = 0;
            string prio_operators = "*/";
            try
            {
                if (operators[j].Contains("*") && prio_operators.Contains(operators[j - 1]))
                {
                    keep_calc[j - check_amount_of_operators_in_a_row(operators, j) + 1] *= values[j + 1];
                }
                else if (operators[j].Contains("/") && prio_operators.Contains(operators[j - 1]))
                {
                    keep_calc[j - check_amount_of_operators_in_a_row(operators, j) + 1] /= values[j + 1];
                }
                else if (operators[j].Contains("/")) //Kanske kan bara ta bort dessa ur tryen? och bara ha kvar dem i catchen.
                {
                    svar = values[j] / values[j + 1];
                }
                else if (operators[j].Contains("*")) // ^
                {
                    svar = values[j] * values[j + 1];
                }
            }
            catch (IndexOutOfRangeException)    // Ifall jag kollar efter en operatör ett steg bakåt och det är det element på position {0} så kommer index out of range kastas och då vet jag att det är det första
            {                                   // elementet och det ända jag kan göra är att lagra en uträkning i keep_calc och sedan kolla nästa operatör för sig. Skulle också kunna kolla frammåt men det är inte
                if (operators[j].Contains("/"))  // nödvändigt. dock skulle jag kunna göra om koden så att jag alltid koller frammåt. så slipper applikationen slösa tid och resures för att kolla om och om och 
                {                               // göra om en redan lagrad element. Dvs kan nog göra koden mer efficient.
                    svar = values[j] / values[j + 1];
                }
                else if (operators[j].Contains("*"))
                {
                    svar = values[j] * values[j + 1];
                }
            }
            return svar;
        }
        //Addition_Subtraction() kollar ifall element "j" i operators[] innehåller + eller - samt kollar operatörer före och efter. Beroende på vad som finns omkring så kommer antigen ett nytt element lagras
        // i keep_ calc eller så kommer ett redan lagrat element skrivas över
        public static double Addition_Subtraction(string[] operators, double[] values, double[] keep_calc, int j)
        {
            double svar = 0;
            string allowed_operators = "*/+-", prio_operators = "*/";
            try // kollar ifall + eller - är emellan två st * eller / då ska jag ändra keep_calc[j-1] och ta bort keep_calc[j+1]
            {
                if (operators[j].Contains("+") && operators[j - 1].Contains("*") && operators[j + 1].Contains("*"))
                {
                    svar = 0;
                }
                else if (operators[j].Contains("+") && operators[j - 1].Contains("/") && operators[j + 1].Contains("/"))
                {
                    svar = 0;
                }
                else if (operators[j].Contains("-") && operators[j - 1].Contains("*") && operators[j + 1].Contains("*"))
                {
                    keep_calc[j - 1] = keep_calc[j - 1] - keep_calc[j + 1];
                    keep_calc[j + 1] = 0;
                }
                else if (operators[j].Contains("-") && operators[j - 1].Contains("/") && operators[j + 1].Contains("/"))
                {
                    keep_calc[j - 1] = keep_calc[j - 1] - keep_calc[j + 1];
                    keep_calc[j + 1] = 0;
                }
                else if (operators[j].Contains("+") && prio_operators.Contains(operators[j + 1]))
                {
                    operators[j + 1] = operators[j + 1];
                }
                else if (operators[j].Contains("-") && prio_operators.Contains(operators[j + 1]))
                {
                    keep_calc[j + 1] = keep_calc[j + 1] * -1;
                }
                else if (operators[j].Contains("+") && allowed_operators.Contains(operators[j - 1]))
                {
                    svar += values[j + 1];
                }
                else if (operators[j].Contains("-") && allowed_operators.Contains(operators[j - 1]))
                {
                    svar -= values[j + 1];
                }
            }
            catch (IndexOutOfRangeException)
            {
                try
                {
                    if (operators[j].Contains("+") && allowed_operators.Contains(operators[j - 1]))
                    {
                        svar += values[j + 1];
                    }
                    else if (operators[j].Contains("-") && allowed_operators.Contains(operators[j - 1]))
                    {
                        svar -= values[j + 1];
                    }
                }

                catch (IndexOutOfRangeException) // Återigen om det är det första elementet i arrayen kommer index out of range kastas och då vet jag att jag bara ska kolla på operatören framför. 
                {
                    try
                    {
                        if (operators[j].Contains("+") && prio_operators.Contains(operators[j + 1]))
                        {
                            svar += values[j];
                        }
                        else if (operators[j].Contains("-") && prio_operators.Contains(operators[j + 1]))
                        {
                            keep_calc[j + 1] = keep_calc[j + 1] * -1;
                            svar += values[j];
                        }
                        else if (operators[j].Contains("+"))
                        {
                            svar = values[j] + values[j + 1];
                        }
                        else if (operators[j].Contains("-"))
                        {
                            svar = values[j] - values[j + 1];
                        }
                    }
                    catch (IndexOutOfRangeException) //Lite fult gjort med om det heller inte finns någon operatör framför j så är det antigen x + y eller x - y och då sker ett udantag där jag lagrar
                    {                                // + eller - med 2 värden i keep_calc
                        if (operators[j].Contains("+"))
                        {
                            svar = values[j] + values[j + 1];
                        }
                        else if (operators[j].Contains("-"))
                        {
                            svar = values[j] - values[j + 1];
                        }
                    }
                }
            }
            return svar;
        }
    }
}