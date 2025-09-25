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
        private string helyrajziSzam;
        private int szelesseg;
        private bool szelessegBeallitva = false;
        private int hossz;
        private bool hosszBeallitva = false;
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

        /* ////////////////////////////////////////////////////////////////////////////
        
        ÁLLAPOT KÖVETKEZIK

        /////////////////////////////////////////////////////////////////////////////// */
    }
}

