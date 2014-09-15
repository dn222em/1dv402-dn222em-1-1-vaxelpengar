using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaxel_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double total = 0d;
            int cash = 0;
            uint subtotal = 0;
            double roundingOfAmount = 0d;
            double toPay = 0;
            int change = 0;


            while (true)
            {
                try
                {
                    Console.Write("Ange totalsumma      :  ");
                    total = double.Parse(Console.ReadLine());
                    break;
                }
                catch
                {

                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("FEL! Totalsumma felaktig.");
                    Console.ResetColor();

                }
            }

            subtotal = (uint)Math.Round(total);

            roundingOfAmount = -(total - subtotal);
            toPay = total - (-roundingOfAmount);

            if (toPay < 1d)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras.");
                Console.ResetColor();
            }
            else
            {

                while (true)
                {
                    try
                    {
                        Console.Write("Ange erhållet belopp :  ");
                        cash = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch
                    {

                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("FEL! Erhållet belop felaktig.");
                        Console.ResetColor();
                    }
                }

                change = (int)(cash - total - roundingOfAmount);

                if (cash < toPay)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Erhållet belopp är för liten. Köpet kunde inte genomföras.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("                       ");
                    Console.WriteLine("KVITTO                 ");
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Totalt          |{0, 15:c}", total);
                    Console.WriteLine("Öresavrundning  |{0, 15:c}", roundingOfAmount);
                    Console.WriteLine("Att betala      |{0, 15:c}", toPay);
                    Console.WriteLine("Kontant         |{0, 15:c}", cash);
                    Console.WriteLine("Tillbaka        |{0, 15:c}", change);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("");

                    int fiveHundread = change / 500;
                    int oneHundread = (change % 500) / 100;
                    int fifty = ((change % 500) % 100) / 50;
                    int twenty = ((change % 500) % 100) % 50 / 20;
                    int ten = (((change % 500) % 100) % 50) % 20 / 10;
                    int five = ((((change % 500) % 100) % 50) % 20) % 10 / 5;
                    int one = (((((change % 500) % 100) % 50) % 20) % 10) % 5 / 1;

                    if (fiveHundread > 0)
                    {
                        Console.WriteLine("500-lappar  |{0, 3}", change / 500);
                    }
                    if (oneHundread > 0)
                    {
                        Console.WriteLine("100-lappar  |{0, 3}", (change % 500) / 100);
                    }
                    if (fifty > 0)
                    {
                        Console.WriteLine(" 50-lappar  |{0, 3}", ((change % 500) % 100) / 50);
                    }
                    if (twenty > 0)
                    {
                        Console.WriteLine(" 20-kronor  |{0, 3}", ((change % 500) % 100) % 50 / 20);
                    }
                    if (ten > 0)
                    {
                        Console.WriteLine(" 10-kronor  |{0, 3}", (((change % 500) % 100) % 50) % 20 / 10);
                    }
                    if (five > 0)
                    {
                        Console.WriteLine("  5-kronor  |{0, 3}", ((((change % 500) % 100) % 50) % 20) % 10 / 5);
                    }
                    if (one > 0)
                    {
                        Console.WriteLine("  1-kronor  |{0, 3}", (((((change % 500) % 100) % 50) % 20) % 10) % 5 / 1);
                    }
                }
            }
        }
    }
}
