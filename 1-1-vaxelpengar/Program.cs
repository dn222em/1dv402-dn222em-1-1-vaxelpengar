using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_1_vaxelpengar
{
    ///<summary>
    //Aplikationen beräknar och presenterar växeln som ska returneras efter ett kontantköp,
    //samt ett kvitto skrivs ut.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Startpunkt för applikationen.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Deklarerar lokala variabel och initierar processen.
            double total = 0d;
            int cash = 0;
            uint subtotal = 0;
            double roundingOfAmount = 0d;
            double toPay = 0;
            int change = 0;

            //Läser in och returnerar värden för totalkostnader samt erhållet belopp.
            //While loop och try catch används för hantering av icke-nuemriskt inmattning.
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

            //Totalkostnadens öresavrundning.
            subtotal = (uint)Math.Round(total);

            roundingOfAmount = subtotal - total;
            toPay = total + roundingOfAmount;

            //Programmet avslutas om de inmattade värden betraktas som orimliga i förhållande till varandra. 
            //Kostnaden mindre än 0,51 krona avlsutar programmet.
            if (toPay < 1d)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras.");
                Console.ResetColor();
                return;
            }

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

            //Beräknar växeln efter öresavrundning.
            change = (int)(cash - total - roundingOfAmount);

            if (cash < toPay)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Erhållet belopp är för liten. Köpet kunde inte genomföras.");
                Console.ResetColor();
                return;
            }

            ///Presenterar resultatet.
            // Presenterar ett Kvittot som ska skrivas ut.
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

            //Deklarerar nya lokala variabler.
            //Svenska valuta-enheter...
            int fiveHundread = change / 500;
            change %= 500;

            int oneHundread = change / 100;
            change %= 100;

            int fifty = change / 50;
            change %= 50;

            int twenty = change/ 20;
            change %= 20;

            int ten = change / 10;
            change %= 10;

            int five = change / 5;
            change %= 5;

            //Går igenom alla valuta- enheter och...
            //presenterar,returnerar växeln som ska lämnas till kunden...
            if (fiveHundread > 0)
            {
                Console.WriteLine("500-lappar  |{0, 3}", fiveHundread);
            }
            if (oneHundread > 0)
            {
                Console.WriteLine("100-lappar  |{0, 3}", oneHundread);
            }
            if (fifty > 0)
            {
                Console.WriteLine(" 50-lappar  |{0, 3}", fifty);
            }
            if (twenty > 0)
            {
                Console.WriteLine(" 20-kronor  |{0, 3}", twenty);
            }
            if (ten > 0)
            {
                Console.WriteLine(" 10-kronor  |{0, 3}", ten);
            }
            if (five > 0)
            {
                Console.WriteLine("  5-kronor  |{0, 3}", five);
            }
            if (change > 0)
            {
                Console.WriteLine("  1-kronor  |{0, 3}", change);
            }
        }
    }
}
