using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlaniroda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IngatlanIroda A_MI_INGATLANIRODÁNK = new IngatlanIroda();

            StreamReader sr = new StreamReader("ingatlanok.csv");

            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');

                if (sor[0] == "I")
                {
                    Ingatlan uj = new Ingatlan(sor[1], int.Parse(sor[2]), int.Parse(sor[3]), (EAllapot)Enum.Parse(typeof(EAllapot), sor[4]));
                    A_MI_INGATLANIRODÁNK.AddIngatlan(uj);
                }
                else if (sor[0] == "CS") 
                {
                    CsaladiHaz uj = new CsaladiHaz(sor[1], int.Parse(sor[2]), int.Parse(sor[3]), (EAllapot)Enum.Parse(typeof(EAllapot), sor[4]), int.Parse(sor[5]), int.Parse(sor[6]), int.Parse(sor[7]));
                    A_MI_INGATLANIRODÁNK.AddIngatlan(uj);
                
                }
                
            }

            Console.WriteLine($"Családi házak száma: {A_MI_INGATLANIRODÁNK.CsaladiHazak.Count} \n" +
                $"Legolcsóbb felújítandó: {A_MI_INGATLANIRODÁNK.LegolcsobbFelujutando}\n");

            Console.Write("\n\nAdj meg egy árat: ");
            int ar = int.Parse(Console.ReadLine());
            Console.WriteLine("\nCsaládi házak az adott árig:");
            foreach (var item in A_MI_INGATLANIRODÁNK.CsaladiHazakAdottArig(EAllapot.Ujepitesu,ar))
            {
                Console.WriteLine(item);
            }
            foreach (var item in A_MI_INGATLANIRODÁNK.CsaladiHazakAdottArig(EAllapot.Korszerusitett, ar))
            {
                Console.WriteLine(item);
            }
            foreach (var item in A_MI_INGATLANIRODÁNK.CsaladiHazakAdottArig(EAllapot.Felujitott, ar))
            {
                Console.WriteLine(item);
            }
            foreach (var item in A_MI_INGATLANIRODÁNK.CsaladiHazakAdottArig(EAllapot.Felujitando, ar))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
