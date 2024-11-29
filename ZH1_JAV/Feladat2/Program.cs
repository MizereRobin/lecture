using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] piros = { "kalap", "kendő", "cigi" };
            string[] kék = { "ostor", "pisztoly"};
            string[] zöld = { "nyereg", "táska", "pénzeszsák" };

            bool BenneVan(string input, string[] szin)
            {
                foreach (var item in szin)
                {
                    if (item == input)
                    {
                        return true;
                    }
                    
                }
                return false;
            }

            int akasztok = 0; //használatban lévő akasztófülek
            int pontok = 0;   //megszerzett pontok
            Random rnd = new Random();

            while (!(akasztok >= 10 || pontok >= 20))
            {
                Console.WriteLine("Mit tesz rá a csacsira?");
                string input = Console.ReadLine();
                double rand = rnd.NextDouble();
                //if (input == "kalap" || input == "kendő" || input == "cigi")
                if (BenneVan(input, piros))
                {
                    if (rand < 0.05)
                    {
                        Console.WriteLine("A csacsi lerúgta magáról a ráakasztott tárgyakat!");
                        akasztok = 0;
                        pontok = 0;
                        break;
                    }
                    else
                    {
                        akasztok++;
                        pontok++;
                    }
                }
                //else if (input == "ostor" || input == "pisztoly")
                else if (BenneVan(input, kék))
                {
                    if (rand < 0.1)
                    {
                        Console.WriteLine("A csacsi lerúgta magáról a ráakasztott tárgyakat!");
                        akasztok = 0;
                        pontok = 0;
                        break;
                    }
                    else
                    {
                        akasztok++;
                        pontok += 2;
                    }
                }
                //else if (input == "nyereg" || input == "táska" || input == "pénzeszsák")
                else if(BenneVan(input, zöld))
                {
                    if (rand < 0.15)
                    {
                        Console.WriteLine("A csacsi lerúgta magáról a ráakasztott tárgyakat!");
                        akasztok = 0;
                        pontok = 0;
                        break;
                    }
                    else
                    {
                        akasztok++;
                        pontok += 3;
                    }
                }
                else
                {
                    Console.WriteLine("Nincs ilyen tárgy!");
                }

                Console.WriteLine($"{10-akasztok} van üresen, {pontok} pont van jelenleg");

            }//while vége


            if (akasztok == 0)
            {
                Console.WriteLine("Sajnos nem nyert! Próbálja újra!");
            }
            else if (akasztok==10)
            {
                Console.WriteLine("Gratulálok! Minden akasztó megtelt!");
            }
            if (pontok>=20)
            {
                Console.WriteLine("Gratulálok! Megszerezted a szükséges pontokat!");
            }

            Console.ReadKey();
        }
    }
}
