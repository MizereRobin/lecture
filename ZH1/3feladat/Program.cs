using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asfeladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<double[]> városok = new List<double[]>();

            int varosok = 0;

            // A feladat
            while (varosok < 10 || varosok > 45)
            {
                Console.WriteLine("Kérlek add meg hány város van");
                varosok = int.Parse(Console.ReadLine());
            }

            //B feladat
            double[] toltottsegek = new double[varosok * 50];

            Random rnd = new Random();

            for (int i = 0; i < toltottsegek.Length; i++)
            {
                toltottsegek[i] = rnd.Next(301, 1001) / 10;
            }

            // C Feladat

            double HatvanAlattiSzazalekok = 0.0;
            double osszesSzazalek = 0;
            int HanyDarab = 0;

            for (int i = 0; i < toltottsegek.Length; i++)
            {
                if (toltottsegek[i] < 60)
                {
                    osszesSzazalek += toltottsegek[i];
                    HanyDarab++;
                }
            }

            HatvanAlattiSzazalekok = osszesSzazalek / HanyDarab;

            Console.WriteLine($"{Math.Round(HatvanAlattiSzazalekok, 1)}% az átlagos töltöttsége azoknak a rollereknek, melyek töl töttsége 60% alatt van");


            //D feladat
            int HarmincEgeszEgy = 0;
            int Szazszazalek = 0;

            for (int i = 0; i < toltottsegek.Length; i++)
            {
                if (toltottsegek[i] == 30.1)
                {
                    HarmincEgeszEgy++;
                }
                else if (toltottsegek[i] == 100)
                {
                    Szazszazalek++;
                }
            }

            if (HarmincEgeszEgy > Szazszazalek)
            {
                Console.WriteLine("A 30.1%-osokból van több");
            }
            else if (Szazszazalek > HarmincEgeszEgy)
            {
                Console.WriteLine("A 100%-osokból van több");
            }
            else if (Szazszazalek == HarmincEgeszEgy)
            {
                Console.WriteLine("Egyenlő darab van");
            }
            else Console.WriteLine("Valami nam jó!!!");
            Console.WriteLine($"30.1 {HarmincEgeszEgy}db 100 {Szazszazalek}db");

            // E feladat 

            double minAtlag = double.MaxValue;
            int VarosSzama = 100;

            for (int varos = 0; varos < varosok; varos++)
            {// Városhoz kapcsolódó

                double atlag = 0;
                double ossztoltottseg = 0;

                for (int roller = 0; roller < 50; roller++)
                {
                    // Aktuális Rollerhez kapcsolódó
                    double aktualisRoller = toltottsegek[varos * 50 + roller];
                    ossztoltottseg += aktualisRoller;
                }

                atlag = ossztoltottseg / 50;

                if (atlag < minAtlag)
                {
                    minAtlag = Math.Round(atlag, 1);
                    VarosSzama = varos + 1; //0 - index miatt
                }

                //Console.WriteLine($"{varos + 1} - {atlag}");
            }
            Console.WriteLine($"A legkisebb átlag töltöttség {minAtlag} Varos{VarosSzama} -ban/ben");

            // E/B feladat

            bool VanIlyen = false;

            for (int varos = 0; varos < varosok; varos++)
            {// Városhoz kapcsolódó
                bool VanNyolcvanalatt = false;

                for (int roller = 0; roller < 50; roller++)
                { // Aktuális Rollerhez kapcsolódó
                    double aktualisRoller = toltottsegek[varos * 50 + roller];

                    if (aktualisRoller < 80)
                    {
                        VanNyolcvanalatt = true;
                    }
                }

                if (!VanNyolcvanalatt)
                {
                    VanIlyen = true;
                }

            }

            if (VanIlyen)
            {
                Console.WriteLine("Van olyan város, ahol minden roller töltöttsége 80% fölött van!");
            }
            else Console.WriteLine("Nincs olyan város, ahol minden roller töltöttsége 80% fölött van!");



            // E/C Feladat

            int Hanyszor = 0;

            for (int i = 0; i < varosok; i++)
            {
                int randomRoller = rnd.Next(0, 50);
                int randomToltottseg = rnd.Next(0, 41);

                toltottsegek[i * 50 + randomRoller] -= randomToltottseg;

                if (toltottsegek[i * 50 + randomRoller] < 0)
                {
                    toltottsegek[i * 50 + randomRoller] = 0;
                }

                if (toltottsegek[i * 50 + randomRoller] < 10)
                {
                    Hanyszor++;
                }
            }

            Console.WriteLine($"{Hanyszor} esetben csökkent így a kiválasztott roller töltöttsége 10% alá");





            Console.ReadKey();
        }
    }
}
