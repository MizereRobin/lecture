using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlaniroda
{
    internal class IngatlanIroda
    {
        #region Mezők & Property-k

        private static List<Ingatlan> ingatlanok = new List<Ingatlan>();


        public static List<Ingatlan> Ingatlanok
        {
            get { return ingatlanok; }
        }


        public List<CsaladiHaz> CsaladiHazak
        {
            get
            {
                List<CsaladiHaz> amibe_szelektalunk = new List<CsaladiHaz>();

                foreach (var item in Ingatlanok)
                {
                    if (item is CsaladiHaz)
                    {
                        amibe_szelektalunk.Add(item as CsaladiHaz);
                    }
                }
                return amibe_szelektalunk;
            }
        }

        public CsaladiHaz LegolcsobbFelujutando
        {
            get
            {
                CsaladiHaz amitKeresunk = null;

                if (CsaladiHazak.Count == 0)
                {
                    throw new Exception("Nincs Családi Ház");
                }

                foreach (var item in CsaladiHazak)
                {
                    if (item.Allapot == EAllapot.Felujitando)
                    {
                        amitKeresunk = item;
                        break;
                    }
                }
                if (amitKeresunk == null)
                {
                    return null;
                }

                foreach (var item in CsaladiHazak)
                {
                    if (item.Vetelar() < amitKeresunk.Vetelar())
                    {
                        amitKeresunk = item;
                    }
                }

                return amitKeresunk;
            }
        }


        public Ingatlan Kereso(string HRSZ)
        {
            Ingatlan amitkeresunk = null;

            foreach (var item in Ingatlanok)
            {
                if (item.HelyrajziSzam == HRSZ)
                {
                    amitkeresunk = item;
                }
            }

            return amitkeresunk;
        }


        #endregion

        #region Metódusok

        public void AddIngatlan(Ingatlan ingatlan)
        {
            if (Kereso(ingatlan.HelyrajziSzam) is null)
            {
                ingatlanok.Add(ingatlan);
            }
        }

        public List<CsaladiHaz> CsaladiHazakAdottArig(EAllapot allapot, int maxar)
        {
            List<CsaladiHaz> amiketkeresunk = new List<CsaladiHaz>();


            foreach (var item in CsaladiHazak)
            {
                if (item.Allapot == allapot && item.Vetelar() <= maxar)
                {
                    amiketkeresunk.Add(item);
                }
            }
            return amiketkeresunk;
        }


        #endregion
    }
}
