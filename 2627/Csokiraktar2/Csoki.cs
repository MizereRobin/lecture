using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csokiraktar2
{
    internal class Csoki
    {
        #region Mezők és Propertyk
        private string azonosito;
        private string marka;
        private bool tejcsoki;
        private string izesites;
        private DateTime szavatossag;
        private int ar;
        private int tomeg;
        private int raktaron;

        public string Azonosito {
            get => azonosito;
            set
            {
                if (value == "")
                {
                    throw new Exception("Az azonosító nem lehet üres");
                }
                azonosito = value;
            }
        }
        public string Marka { get => marka; set => marka = value; }
        public bool Tejcsoki { get => tejcsoki; set => tejcsoki = value; }
        public string Izesites { get => izesites; set => izesites = value; }
        public DateTime Szavatossag { get => szavatossag; set => szavatossag = value; }
        public int Ar { get => ar; set => ar = value; }
        public int Tomeg { get => tomeg;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("A tömeg nem lehet kisebb vagy egyenlő nullánál/val");
                }
                tomeg = value;
            }
        }
        public int Raktaron { get => raktaron; set => raktaron = value; }

        #endregion

        #region Konstruktor

        
        public Csoki(string azonosito, string marka, bool tejcsoki, string izesites, DateTime szavatossag, int ar, int tomeg, int raktaron)
        {
            Azonosito = azonosito;
            Marka = marka;
            Tejcsoki = tejcsoki;
            Izesites = izesites;
            Szavatossag = szavatossag;
            Ar = ar;
            Tomeg = tomeg;
            Raktaron = raktaron;
        }

        #endregion  

        public override string ToString()
        {
            return $"{Azonosito}: {Marka} - {Izesites} ({ (Tejcsoki==true?"tej":"ét") }) ({Szavatossag.ToString("yyyy MMMM dd")})";
        }
    }
}
