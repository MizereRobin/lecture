using System;

namespace Ingatlaniroda
{
    internal class CsaladiHaz : Ingatlan
    {

        #region Mezők és Propertyk 

        private int telekszelesseg;
        private int telekhosszusag;
        private int szintek;
        //private int alapterulet;
        

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

        #region Metodusok

        public int Vetelar()
        {
            int ar = 0;

            switch (Allapot)
            {
                case EAllapot.Ujepitesu:
                    ar = Alapterulet * 650000;
                    break;
                case EAllapot.Korszerusitett:
                    ar = Alapterulet * 600000;
                    break;
                case EAllapot.Felujitott:
                    ar = Alapterulet * 550000;
                    break;
                case EAllapot.Felujitando:
                    ar = Alapterulet * 400000;
                    break;
                default:
                    throw new Exception("Valami nem jo, gatya");
            }

            ar += KertTerulete * 200000;
            

            return ar;
        }

        public override string ToString()
        {
            return $"HRSZ: {this.HelyrajziSzam} Állapot: {this.Allapot} Vételár: {this.Vetelar()}" +
                $" Telekhossz: {this.TelekHossz} Telekszélesség: {this.Telekszelesseg} Szintek: {Szintek} Kert területe: {KertTerulete}";
        }
        
        #endregion
    }
}
