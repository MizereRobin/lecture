using System;

namespace Feladat1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Menüt? (I/N)");

            bool menu = Console.ReadLine().ToLower() == "i" ? true : false;
            string melyikMenu = "";
            bool leves = false;
            bool foetel = false;
            bool savanyusag = false;
            int desszert = -1;
            bool kupon = false;

            if (menu)
            {
                while (!(melyikMenu == "a" || melyikMenu == "b" || melyikMenu == "c" || melyikMenu == "vega")) //AltGr + W
                {
                    Console.WriteLine("Melyiket? (A, B, C, Vega)");
                    melyikMenu = Console.ReadLine().ToLower();
                }
            }
            else
            {
                Console.WriteLine("Levest? (I/N)");
                leves = Console.ReadLine().ToLower() == "i" ? true : false;
                Console.WriteLine("Főetelt? (I/N)");
                foetel = Console.ReadLine().ToLower() == "i" ? true : false;
            }

            Console.WriteLine("Savanyúságot? (I/N)");
            savanyusag = Console.ReadLine().ToLower() == "i" ? true : false;

            while (desszert < 0 || desszert > 5)
            {
                Console.WriteLine("Mennyi desszertet kér? (0-5)");
                desszert = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Kupon?");
            kupon = Console.ReadLine().ToLower() == "i" ? true : false;

            int fizetendo = 0;

            if (menu)
            {
                switch (melyikMenu)
                {
                    case "a":
                        fizetendo += 1850;
                        break;
                    case "b":
                        fizetendo += 2100;
                        break;
                    case "c":
                        fizetendo += 1750;
                        break;
                    case "vega":
                        fizetendo += 1950;
                        break;
                    default:
                        Console.WriteLine("Valami nem jó");
                        break;
                }
            }
            else
            {
                fizetendo += leves ? 650 : 0;
                fizetendo += foetel ? 1450 : 0;
            }
            fizetendo += savanyusag ? 600 : 0;
            fizetendo += desszert * 750;

            fizetendo = kupon ? Convert.ToInt32(fizetendo * 0.87) : 1;

            Console.WriteLine("A végösszeg: "+fizetendo+"Ft lesz!");
            Console.ReadKey();
        }
    }
}