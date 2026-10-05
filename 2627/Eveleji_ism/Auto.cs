using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eveleji_ism
{
    internal class Auto
    {
        public string Rendszam;
        public string Marka;
        public string Tipus;
        public int Gyartasiev; //csak évszám, amúgy DateTime lenne
        public string Uzemanyag;

        public Auto(string rendszam, string marka, string tipus, int gyartasiev, string uzemanyag)
        {
            Rendszam = rendszam;
            Marka = marka;
            Tipus = tipus;
            Gyartasiev = gyartasiev;
            Uzemanyag = uzemanyag;
        }

        public void Kiir()
        {
            Console.WriteLine($"{this.Rendszam} - {this.Marka} {this.Tipus} ({this.Gyartasiev}, {this.Uzemanyag})");
        }
    }
}
