namespace Csokiraktar2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Csoki> raktar = new List<Csoki>();

            StreamReader sr = null;

            #region 1.Feladat
            try
            {
                sr = new StreamReader("csokiraktar.csv");
                sr.ReadLine(); //Fejlécsor miatt kell
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] sor = sr.ReadLine().Split(';');
                        raktar.Add(
                            new Csoki(
                                sor[0],
                                sor[1],
                                sor[2] == "tej" ? true : false,
                                sor[3],
                                DateTime.Parse(sor[4]),
                                int.Parse(sor[5]),
                                int.Parse(sor[6]),
                                int.Parse(sor[7])
                                )
                            );
                    }

                    catch (Exception ex) { Console.WriteLine("Hibás sor:\n" + ex.Message); }
                }

            }
            catch (Exception ex) { Console.WriteLine("Hiba a fájlbeolvasásban!\n" + ex.Message); }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
            #endregion
            #region 2.Feladat
            double megsemmisites = 0.0;

            foreach (var aktualis in raktar)
            {
                if (
                        aktualis.Szavatossag > DateTime.Parse("2022.12.12")
                        &&
                        aktualis.Raktaron > 0
                    )
                {
                    megsemmisites += aktualis.Tomeg / 1000.0;
                    Console.WriteLine(aktualis);
                }
            }
            Console.WriteLine($"Ezek megsemmisítésével {Math.Round(megsemmisites, 2)} kg csokoládé kerül ki a raktárból");
            Console.WriteLine("☻");
            #endregion

            #region 3.Feladat
            bool F3_VanIlyen(List<Csoki> lista, string gyártó, string izesites)
            {
                foreach (var item in lista)
                {
                    if (item.Marka == gyártó && item.Izesites == izesites)
                    {
                        return true;
                    }
                }
                return false;
            }
            #endregion

            #region 4.Feladat
            Console.WriteLine("Adjon meg egy márkát!");
            string marka = Console.ReadLine();

            Console.WriteLine("Adjon meg egy ízesítést!");
            string izesites = Console.ReadLine();

            if (F3_VanIlyen(raktar, marka, izesites))
            {
                foreach (var item in raktar)
                {
                    if (item.Marka == marka && item.Izesites == izesites)
                    {
                        Console.WriteLine($"{item.Azonosito} {item.Ar} {(item.Raktaron > 0 ? "Van" : "Nincs")} raktáron");
                    }
                }
            }
            else
            {
                Console.WriteLine("Sajnos nincs ilyen csokoládé a raktárban");
            }
            #endregion

            #region 5.Feladat
            
            void F5_Premium(List<Csoki> összes, List<Csoki> ide, int arhatar)
            {
                ide.Clear();
                foreach (var aktualis in összes)
                {
                    if (aktualis.Ar >= arhatar)
                    {
                        ide.Add(aktualis);
                    }
                }
            }
            #endregion


            #region 6.Feladat
            int F6_Akcio(Csoki csoki)
            {
                int ujAr = csoki.Ar;

                if (csoki.Szavatossag < DateTime.Parse("2022.12.12"))
                {
                    return 0;
                }
                else if (csoki.Tejcsoki)
                {
                    ujAr = Convert.ToInt32(ujAr * 0.75);
                }
                else if (!csoki.Tejcsoki)
                {
                    ujAr = Convert.ToInt32(ujAr * 0.70);
                }
                if (csoki.Raktaron >= 60)
                {
                    ujAr = Convert.ToInt32(ujAr * 0.94);
                }
                return ujAr;
            }

            #endregion

            #region 7.Feladat
            List<Csoki> premium = new List<Csoki>();

            F5_Premium(raktar, premium, 650);
            Console.WriteLine("7. feladat");

            foreach (var item in premium)
            {
                if (item.Szavatossag>DateTime.Parse("2022.12.12."))
                {
                    Console.WriteLine($"{item.Azonosito}: {item.Marka} ({item.Izesites}) Ár: {item.Ar} Ft, Akciós ár: {F6_Akcio(item)} Ft");
                }
            }


            #endregion

            #region 8. Feladat

            foreach (var item in raktar)
            {
                if (item.Azonosito == "NBKL5NQ")
                {
                    //Console.WriteLine(item); //Debug sor
                    raktar.Remove(item);
                    break;
                }
            }



            #endregion
        }
    }
}
