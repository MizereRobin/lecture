using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2feladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int HanyPercVanMar = 0;
            int hanyNapVanKesz = 0;



            int[] orakSzama = new int[5];
            int[] orakSzamaDB = new int[5];

            while (hanyNapVanKesz<5)
            {
                Console.WriteLine("Adja meg a következő órát, vagy lépjen a következő napra!");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "fizika":
                        HanyPercVanMar += 60;
                        orakSzama[hanyNapVanKesz] += 60;
                        break;
                    case "kémia":
                        HanyPercVanMar += 60;
                        orakSzama[hanyNapVanKesz] += 60;
                        break;
                    case "biológia":
                        HanyPercVanMar += 60;
                        orakSzama[hanyNapVanKesz] += 60;
                        break;
                    case "programozás":
                        HanyPercVanMar += 90;
                        orakSzama[hanyNapVanKesz] += 90;
                        break;
                    case "robotika":
                        HanyPercVanMar += 90;
                        orakSzama[hanyNapVanKesz] += 90;
                        break;
                    case "történelem":
                        HanyPercVanMar += 45;
                        orakSzama[hanyNapVanKesz] += 45;
                        break;
                    case "nyelvtan":
                        HanyPercVanMar += 45;
                        orakSzama[hanyNapVanKesz] += 45;
                        break;
                    case "angol":
                        HanyPercVanMar += 45;
                        orakSzama[hanyNapVanKesz] += 45;
                        break;
                    case "német":
                        HanyPercVanMar += 45;
                        orakSzama[hanyNapVanKesz] += 45;
                        break;
                    case "következő":
                        hanyNapVanKesz++;
                        HanyPercVanMar = 0;
                        //debug
                        Console.WriteLine("NAPVÁLTÁS");
                        break;

                    default:
                        Console.WriteLine("Hibás bemenet!");
                        break;
                }

                orakSzamaDB[hanyNapVanKesz]++;

                if (HanyPercVanMar>=240)
                {
                    hanyNapVanKesz++;
                    HanyPercVanMar = 0;
                    //debug
                    Console.WriteLine("NAPVÁLTÁS ",hanyNapVanKesz.ToString());
                }


            }

            int osszorak = 0;
            int orakdb = 0;
            for (int i = 0; i < orakSzama.Length; i++)
            {
                osszorak += orakSzama[i];
                orakdb += orakSzamaDB[i];
            }
            Console.WriteLine(osszorak);
            Console.WriteLine(orakdb);

            int orak = Convert.ToInt32(osszorak/60);
            int percek = osszorak - (orak * 60);

            Console.WriteLine($"A héten {orakdb} foglalkozást tartottak, ez összesen {orak}:{percek} időt vett igénybe ");


            Console.ReadKey();
        }
    }
}
