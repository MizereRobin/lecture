using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Eveleji_ism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] szamok_tomb = new int[32];
            Random rnd = new Random();

            #region Ciklusok és egyebek


            ////foreach (int aktualis_szam in szamok_tomb)
            ////{
            ////    aktualis_szam = rnd.Next();
            ////}

            //#region FOR

            ////for (int i = 0; i < szamok_tomb.Length; i++)
            ////{
            ////    // aktuális --> szamok_tomb[i]

            ////    szamok_tomb[i] = rnd.Next(int.MinValue, int.MaxValue);
            ////}
            //#endregion


            //#region WHILE

            //byte counter = 0;


            //while (counter < szamok_tomb.Length)
            //{
            //    int randomszam = rnd.Next(33);
            //    while (szamok_tomb.Contains(randomszam))
            //    {
            //        randomszam = rnd.Next(33);
            //    }
            //    szamok_tomb[counter] = randomszam;

            //    counter++;
            //}


            //#endregion



            //#region Kiírás
            //foreach (var item in szamok_tomb)
            //{
            //    Console.WriteLine(item);    
            //}
            //#endregion


            //#region MIN

            //int legkisebb = szamok_tomb[0];

            //foreach (var item in szamok_tomb)
            //{
            //    if (item < legkisebb)
            //    {
            //        legkisebb = item;
            //    }
            //}

            //Console.WriteLine("Legkisebb: "+legkisebb);
            //#endregion

            //#region MAX

            //int legnagyobb = szamok_tomb[0];

            //foreach (var item in szamok_tomb)
            //{
            //    if (item > legnagyobb)
            //    {
            //        legnagyobb = item;
            //    }
            //}

            //Console.WriteLine("Legnagyobb: " + legnagyobb);
            //#endregion


            #endregion

            /* Beolvasás
             * 
             * 1. StreamReader és file neve
             * 2. Soronként olvasás
             * 3. Adatfeldolgozás
             * 4. StreamReader bezárása
             */

            //StreamReader sr = new StreamReader("FILE_PATH");
            //while (!sr.EndOfStream)
            //{
            //    szamoklista.Add(int.Parse(sr.ReadLine()));
            //    Convert.ToInt32(sr.ReadLine());
            //}

            //sr.Close();

            List<Auto> autok = new List<Auto>();

            autok.Add(new Auto("AABB123", "Audi", "A3", 2024, "benzin"));
            string[] sor = sr.Readline().Split(';');
            autok.Add(new Auto(sor[0], sor[1], sor[2], int.Parse(sor[3]), sor[4]));

            autok[0].Kiir();

        }
    }
}
