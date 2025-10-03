using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlaniroda
{
    internal class Ingatlan
    {
        #region Mezők és Propertyk

        private string helyrajziSzam;
        private int szelesseg;
        private bool szelessegBeallitva = false;
        private int hossz;
        private bool hosszBeallitva = false;
        private EAllapot allapot;

        //

        string elfogadottKarekterek = "0123456789/";

        public string HelyrajziSzam
        {
            get
            {
                return helyrajziSzam;
            }

            private set
            {
                if (value != null && value != "") // ellenőrizzük, hogy null vagy üres string-e
                {
                    //ha nem akkor megnézzük a 0. indexen lévő karaktert
                    if (value[0] == '0' ||
                        value[0] == '/')
                    {
                        throw new Exception("Nem jó az első karakter!");
                    }
                    //ha az előbb nem volt hibás, megnézzük az utolsót is
                    else if (value[-1] == '/')
                    {
                        throw new Exception("Nem jó az utolsó karakter!");
                    }

                    //Ha az utolsó is jó, akkor a köztes karaktereket ellenőrizzük le
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!elfogadottKarekterek.Contains(value[i]))
                        {
                            throw new Exception($"Ez a karakter nem elfogadott! ({value[i]})");
                        }
                    }

                    // Ha minden jó, akkor értéket beállít
                    helyrajziSzam = value;
                }
                else
                {
                    throw new Exception("A helyrajzi szám nem lehet null vagy üres!");
                }

            }
        }

        public int Szelesseg
        {
            get
            {
                return szelesseg;
            }
            private set
            {
                if (value >= 4 &&
                    value <= 20 &&
                    szelessegBeallitva == false)
                {
                    szelesseg = value;
                    szelessegBeallitva = true;
                }
                else
                {
                    throw new Exception("A szélesség nem megfelelő vagy már be van állítva!");
                }
            }
        }

        private void SetHossz(int value)
        {
            if (value >= 4 &&
                value <= 20 &&
                hosszBeallitva == false)
            {
                hossz = value;

                hosszBeallitva = true;
            }

            else
            {
                throw new Exception("A hossz nem megfelelő vagy már be van állítva!");
            }
        }

        public int GetHossz()
        {
            return hossz;
        }

        public EAllapot Allapot
        {
            get => allapot;
            set
            {
                if (value is EAllapot)
                {
                    allapot = value;
                }
                else
                {
                    throw new Exception("A megadott állapot nem értelmezhető");
                }
            }
        }

        public int Alapterület
        {
            get => hossz * szelesseg;
        }
        #endregion

        #region Konstruktorok

        public Ingatlan(
            string helyrajziSzam,
            int szelesseg,
            int hossz,
            EAllapot allapot)
        {
            this.Szelesseg = szelesseg;
            this.SetHossz(hossz);
            this.HelyrajziSzam = helyrajziSzam;
            this.Allapot = allapot;
        }

        public Ingatlan(string helyrajziSzam,
            int szelesseg,
            int hossz)
        {
            new Ingatlan(helyrajziSzam, szelesseg, hossz, EAllapot.Ujepitesu);
        }

        #endregion

        #region Metodusok

        int Vetelar()
        {
            int vetelar = 0;

            switch (this.Allapot)
            {
                case EAllapot.Ujepitesu:
                    vetelar = this.Alapterület * 600000;
                    break;
                case EAllapot.Korszerusitett:
                    vetelar = this.Alapterület * 500000;
                    break;
                case EAllapot.Felujitott:
                    vetelar = this.Alapterület * 450000;
                    break;
                case EAllapot.Felujitando:
                    vetelar = this.Alapterület * 300000;
                    break;
                default:
                    throw new Exception("Valami nem jo");

            }
            return vetelar;
        }

        public override string ToString()
        {
            return $"HRSZ: {this.HelyrajziSzam} Állapot: {this.Allapot} Vételár: {this.Vetelar()} Hossz: {this.GetHossz()} Szélesség: {this.Szelesseg}";
        }

        public override bool Equals(object obj)
        {
            Ingatlan masik = obj as Ingatlan;

            if (this.helyrajziSzam == masik.helyrajziSzam)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion
    }
}

