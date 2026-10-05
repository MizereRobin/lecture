using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csokiraktar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = null;
            List<Csoki> csokiraktar = new List<Csoki>();

            #region Beolvasas
            try
            {
                sr = new StreamReader("csokiraktar.csv");
                Console.WriteLine("File megtalálva");

                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] sor = sr.ReadLine().Split(';');
                        csokiraktar.Add(new Csoki(sor[0], sor[1], sor[2] == "tej" ? true : false, sor[3],
                            DateTime.Parse(sor[4]), int.Parse(sor[5]), int.Parse(sor[6]), int.Parse(sor[7])));

                    }
                    catch (Exception ex) { Console.WriteLine("Hibás sor: " + ex.Message); }

                }
            }
            catch (Exception ex) { Console.WriteLine("Hiba: " + ex.Message); }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }

            #endregion

            #region 2.Feladat 
            int tomeg = 0;

            foreach (var item in csokiraktar)
            {       /// Szavatosság nem járt le                     ÉS  van raktáron
                if (item.Szavatossag < DateTime.Parse("2022.12.12") && item.Raktar > 0)
                {
                    Console.WriteLine(item);
                    tomeg += item.Tomeg;
                }
            }
            Console.WriteLine($"Ezek megsemmisítésével {(tomeg/1000.0).ToString()} kg csokoládé kerül ki a raktárból.\r\n");

            #endregion
            bool F3_vanilyen(List<Csoki> lista, string gyarto, string izesites)
            {
                bool valasz = false;

                foreach (var item in lista)
                {
                    if (item.Marka == gyarto && item.Izesites == izesites)
                    {
                        valasz = true;
                        break;
                    }
                }
                return valasz;
            }
            Console.WriteLine("Adja meg a Márkát!");
            string gyartobe = Console.ReadLine();

            Console.WriteLine("Adja meg az Ízesítést!");
            string izbe = Console.ReadLine();

            if (F3_vanilyen(csokiraktar,gyartobe,izbe))
            {
                Console.WriteLine("Van ilyen csoki a raktárban");
            }
            else
            {
                Console.WriteLine("Nincs ilyen csoki a raktárban");
            }

        }
    }
}
