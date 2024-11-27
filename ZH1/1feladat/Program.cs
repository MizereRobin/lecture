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


            // B) alfeladat
            if (korlatlanHivas)
            {
                
                
                while (!(mobilnet==6 || mobilnet == 15))
                {
                    Console.WriteLine("Becslése szerint hány GB adatforgalomra lesz szüksége? (6 vagy 15)");
                    mobilnet=int.Parse(Console.ReadLine());
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


            // d) alfeladat

            if (ajanlas == "mini" || ajanlas == "normal")
            {
                Console.WriteLine("Szeretne-e plusz 1,5GB adatforgalmat mindössze havi 1600Ft plusz költségért? (I/N)");
                input1 = Console.ReadLine();
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
            }

            // E) alfeladat

            Random rnd = new Random(); //Random hívása
            
            int percek = rnd.Next(0,360);
            int sms = rnd.Next(0,100);
            double adat =  rnd.NextDouble() * (7.5d - 0d); 
                        // rnd.Next(0, 75) /10

            if (ajanlas=="mini" && !pluszMasfelGiga)
            {
                int mobilnetdíj = 0;
                if (adat>1)
                {
                    mobilnetdíj += Convert.ToInt32(adat - 1 * 1250);
                }

                Console.WriteLine($"A havidíj {4990 + percek*25 + sms*25+ mobilnetdíj} forint lesz"); 
            }
            else if(ajanlas == "mini" && pluszMasfelGiga)
            {
                int mobilnetdíj = 1600;
                if (adat > 2.51)
                {
                    mobilnetdíj += Convert.ToInt32(adat - 2.5 * 1250);
                }
                Console.WriteLine($"A havidíj {4990 + percek * 25 + sms * 25 + mobilnetdíj} forint lesz");
            }
            else if (ajanlas=="normal" && !pluszMasfelGiga)
            {
                int mobilnetdíj = 0;
                if (adat > 6)
                {
                    mobilnetdíj = Convert.ToInt32(adat - 6 * 1050);
                }
                Console.WriteLine($"A havidíj {8590 + sms * 20 + mobilnetdíj} forint lesz"); 
            }
            else if (ajanlas == "normal" && pluszMasfelGiga)
            {
                int mobilnetdíj = 1600;
                if (adat > 7.5)
                {
                    mobilnetdíj = Convert.ToInt32(adat - 7.5 * 1050);
                }
                Console.WriteLine($"A havidíj {8590 + sms * 20 + mobilnetdíj} forint lesz");
            }
            else if (ajanlas == "fullos")
            {
                int mobilnetdíj = 0;
                if (adat > 15)
                {
                    mobilnetdíj = Convert.ToInt32(adat - 15 * 900);
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
