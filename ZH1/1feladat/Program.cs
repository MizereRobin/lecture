using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Feladat


            //fontos adatok
            bool korlatlanHivas = false;
            int mobilnet = 0;
            string ajanlas = "";
            bool pluszMasfelGiga = false;


            //  a) alfeladat

            Console.WriteLine("Szeretne-e korlátlan hálózaton belüli és EU-s hívást? (I/N)");
            string input1 = Console.ReadLine();


            korlatlanHivas = input1.ToLower() == "i" ? true : false;

            /* MÁSIK OPCIÓ
            if (input1.ToLower() == "i")
            {
                korlatlanHivas = true;
            }
            else if (input1.ToLower() == "n")
            {
                korlatlanHivas = false;
            }
            else
            {
                Console.WriteLine("Nem jól kezeltem le valamit...");
            }
            */

            // B) alfeladat

            if (korlatlanHivas)
            {
                while (!(mobilnet == 6 || mobilnet == 15))
                {
                    Console.WriteLine("Becslése szerint hány GB adatforgalomra lesz szüksége? (6 vagy 15)");
                    mobilnet = int.Parse(Console.ReadLine());
                }
            }

            // C) alfeladat

            if (korlatlanHivas && mobilnet == 6)
            {
                Console.WriteLine("Önnek a Normál csomagra van szüksége!");
                ajanlas = "normal";
            }
            else if (korlatlanHivas && mobilnet == 15)
            {
                Console.WriteLine("önnek a Fullo$ csomagra van szüksége!");
                ajanlas = "fullos";
            }
            else if (!korlatlanHivas)
            {
                Console.WriteLine("Önnek a Mini csomagra van szüksége!");
                ajanlas = "mini";
            }
            else
            {
                Console.WriteLine("Valami megin nem jó");
            }


            // D) alfeladat

            if (ajanlas == "mini" || ajanlas == "normal")
            {
                Console.WriteLine("Szeretne-e plusz 1,5GB adatforgalmat mindössze havi 1600Ft plusz költségért? (I/N)");
                input1 = Console.ReadLine();


                pluszMasfelGiga = input1.ToLower() == "i" ? true : false;

                /* VAGY ÍGY
                if (input1.ToLower() == "i")
                {
                    pluszMasfelGiga = true;
                }
                else if (input1.ToLower() == "n")
                {
                    pluszMasfelGiga = false;
                }
                else
                {
                    Console.WriteLine("Nem jól kezeltem le valamit...");
                }
                */
            }

            // E) alfeladat

            Random rnd = new Random(); //Random hívása

            int percek = rnd.Next(0, 360);
            int sms = rnd.Next(0, 100);
            double adat = rnd.NextDouble() * (7.5d - 0d);
                       // rnd.Next(0, 75) /10
            if (ajanlas == "mini")
            {
                int mobilnetdíj = 0;
                double netalap = 1;

                if (pluszMasfelGiga)
                {
                    mobilnetdíj = 1600;
                    netalap = 2.5;
                }

                if (adat > netalap)
                {
                    adat = Math.Ceiling(adat - netalap);
                    mobilnetdíj += Convert.ToInt32(adat - 1 * 1250);
                }

                Console.WriteLine($"A havidíj {4990 + percek * 25 + sms * 25 + mobilnetdíj} forint lesz");
            }

            else if (ajanlas == "normal")
            {
                int mobilnetdíj = 0;
                double netalap = 6;

                if (pluszMasfelGiga)
                {
                    mobilnetdíj = 1600;
                    netalap = 7.5;
                }
                if (adat > netalap)
                {
                    adat = Math.Ceiling(adat - netalap);
                    mobilnetdíj += Convert.ToInt32(adat * 1050);
                }
                Console.WriteLine($"A havidíj {8590 + sms * 20 + mobilnetdíj} forint lesz");
            }
            else if (ajanlas == "fullos")
            {
                int mobilnetdíj = 0;
                if (adat > 15)
                {
                    adat = Math.Ceiling(adat - 15);
                    mobilnetdíj = Convert.ToInt32(adat * 900);
                }
                Console.WriteLine($"A havidíj {13990 + mobilnetdíj} forint lesz");
            }
            else
            {
                Console.WriteLine("Hiba");
            }
            //main vége
            Console.ReadKey();
        }
    }
}
