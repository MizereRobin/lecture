using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlaniroda
{
    internal class CsaladiHaz : Ingatlan
    {

        #region Mezők és Propertyk 

        private int telekszelesseg;
        private int telekhosszusag;
        private int szintek;
        //private int alapterulet;
        private int kertTerulet;

        public int Telekszelesseg
        {
            get => telekszelesseg;
            private set
            {
                if (value < 10 || value > 100)
                {
                    throw new Exception();
                }
                else if (value < base.Szelesseg)
                {
                    throw new Exception();
                }
                telekszelesseg = value;
            }
        }
        public int TelekHossz
        {
            get => telekhosszusag;
            private set
            {
                if (value < 10 || value > 100)
                {
                    throw new Exception();
                }
                else if (value < base.GetHossz())
                {
                    throw new Exception();
                }
                telekhosszusag = value;
            }
        }
        public int Szintek
        {
            get => szintek;
            set
            {
                if (value < 1 || value > 3)
                {
                    throw new Exception();
                }
                szintek = value;
            }
        }

        public int Alapterulet
        {
            get => base.Alapterület * Szintek;
        }

        public int KertTerulete
        {
            get => (telekhosszusag * telekszelesseg) - base.Alapterület;
            //  Kert =     Telek területe          -    Ház területe 
        }


        #endregion

        #region Konstruktorok

        public CsaladiHaz(
            string helyrajziSzam, int szelesseg,
            int hossz, EAllapot allapot,
            int telekszelesseg, int telekhossz, int szintek
            )
            :
            base(helyrajziSzam, szelesseg, hossz, allapot)
        {
            this.Telekszelesseg = telekszelesseg;
            this.TelekHossz = telekhossz;
            this.Szintek = szintek;
        }

        public CsaladiHaz(
            string helyrajziSzam, int szelesseg,
            int hossz,
            int telekszelesseg, int telekhossz
            )
            :
            base(helyrajziSzam, szelesseg, hossz, EAllapot.Ujepitesu)
        
        {
            new CsaladiHaz(helyrajziSzam, szelesseg, hossz, EAllapot.Ujepitesu, telekszelesseg, telekhossz, 1);
        }



        #endregion
    }
}
