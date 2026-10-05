using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csokiraktar
{
    internal class Csoki
    {
        private string azonosito;
        private string marka;
        private bool tej;
        private string izesites;
        private DateTime szavatossag;
        private int ar;
        private int tomeg;
        private int raktar;

        public Csoki(string azonosito, string marka, bool tej, string izesites, DateTime szavatossag, int ar, int tomeg, int raktar)
        {
            Azonosito = azonosito;
            Marka = marka;
            Tej = tej;
            Izesites = izesites;
            Szavatossag = szavatossag;
            Ar = ar;
            Tomeg = tomeg;
            Raktar = raktar;
        }

        public string Azonosito { get => azonosito; set => azonosito = value; }
        public string Marka { get => marka; set => marka = value; }
        public bool Tej { get => tej; set => tej = value; }
        public string Izesites { get => izesites; set => izesites = value; }
        public DateTime Szavatossag { get => szavatossag; set => szavatossag = value; }
        public int Ar
        {
            get => ar;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Az Ár nem lehet negatív szám");
                }
                ar = value;
            }
        }
        public int Tomeg
        {
            get => tomeg; set
            {
                if (value < 0)
                {
                    throw new Exception("Az Tomeg nem lehet negatív szám");
                }
                tomeg = value;
            }
        }
        public int Raktar
        {
            get => raktar;
            set
            {
                if (!(value is int))
                {
                    throw new Exception("A raktármennyiség csak szám lehet");
                }
                else if (value < 0)
                {
                    throw new Exception("A raktármennyiség nem lehet negatív szám");
                }
                raktar = value;
            }
        }

        public override string ToString()
        {
            return $"{Azonosito}: {Marka}-{Izesites} ("+(Tej?"Tej":"Ét")+$") ({Szavatossag.ToString("yyyy MMMM dd")})";
        }
    }
}
