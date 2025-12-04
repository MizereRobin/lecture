using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helsinki
{

    public partial class Form1 : Form
    {
        private static List<Versenyzo> Versenyzok = new List<Versenyzo>();
        private static List<Versenyzo> Dontosok = new List<Versenyzo>();
        public Form1()
        {
            InitializeComponent();

            //ide

        }

        private void buttonBeolvas_Click(object sender, EventArgs e)
        {
            #region Beolvasas
            StreamReader sr = null;
            string filepath = "rovidprogram.csv";
            #region Rövidprogram
            try
            {

                sr = new StreamReader(filepath);
                sr.ReadLine(); // Fejléc miatt
                while (!sr.EndOfStream)
                {
                    try
                    {
                        Versenyzok.Add(new Versenyzo(sr.ReadLine().Split(';')));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hiba a versenyző hozzáadása során.");
                    }
                }
                MessageBox.Show($"Sikeres olvasás: {filepath}");

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Nincs ilyen file: {filepath}");
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (sr != null) sr.Close();
            }
            #endregion

            filepath = "donto.csv";
            #region Döntősök
            try
            {

                sr = new StreamReader(filepath);
                sr.ReadLine(); // Fejléc miatt
                while (!sr.EndOfStream)
                {
                    try
                    {
                        Dontosok.Add(new Versenyzo(sr.ReadLine().Split(';')));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hiba a versenyző hozzáadása során.");
                    }
                }
                MessageBox.Show($"Sikeres olvasás: {filepath}");

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Nincs ilyen file: {filepath}");
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (sr != null) sr.Close();
            }
            #endregion
            #endregion
        }

        private void button2Feladat_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += 
                $"2. Feladat\n\t" +
                    $"A rövidprogramban {Versenyzok.Count} induló volt."; 
        }

        private void button3Feladat_Click(object sender, EventArgs e)
        {
            bool vanilyen = false ;
            foreach (var item in Dontosok)
            {
                if (item.Orszag=="HUN")
                    { vanilyen = true; }
            }
            if (vanilyen)
            {
                richTextBox1.Text +=
                    "\n3. Feladat\n\t" +
                    "A magyar versenyző bejutott a kűrbe.";
            }
            else
            {
                richTextBox1.Text +=
                    "\n3. Feladat\n\t" +
                    "A magyar versenyző nem jutott be a kűrbe.";
            }

        }

        private double ÖsszPontszám(string nev)
        {
            double pontszam = 0d;  // 0d --> 0.00000000 (double-ként kezeli) 0f --> 0.0000 (float-ként kezelve)
            foreach (var versenyzo in Versenyzok)
            {
                if (versenyzo.Nev.ToLower() == nev.ToLower())
                {
                    pontszam += versenyzo.Komponens;
                    pontszam += versenyzo.Technikai;
                    pontszam -= versenyzo.Levonas;
                }
            }
            foreach (var versenyzo in Dontosok)
            {
                if (versenyzo.Nev.ToLower() == nev.ToLower())
                {
                    pontszam += versenyzo.Komponens;
                    pontszam += versenyzo.Technikai;
                    pontszam -= versenyzo.Levonas;
                }
            }
            return pontszam;
        }

        private void button5Feladat_Click(object sender, EventArgs e)
        {
            Versenyzo keresett = null;
            foreach (var item in Versenyzok)
            {
                if (item.Nev.ToLower() == textBoxNev.Text.ToLower())
                {
                    keresett = item;
                }
            }
            if (keresett != null)
            {
                richTextBox1.Text += "\n5. Feladat";
                richTextBox1.Text += $"\n\t Keresett versenyző: {keresett.Nev}";
                richTextBox1.Text += "\n6. Feladat";
                richTextBox1.Text += $"\n\tA versenyző összpontszáma: {ÖsszPontszám(keresett.Nev)}";
            }
            else 
            {
                richTextBox1.Text += "\n5. Feladat";
                richTextBox1.Text += "\n\tKeresett versenyző neve: "+textBoxNev.Text;
                richTextBox1.Text += "\n\tIlyen nevű induló nem volt";
            }
        }

        private void button7Feladat_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> orszagok = new Dictionary<string, int>();
            
            foreach (var item in Dontosok)
            {
                if (orszagok.ContainsKey(item.Orszag))
                {
                    orszagok[item.Orszag] += 1;
                }
                else 
                {
                    orszagok.Add(item.Orszag, 1);
                }

            }
            richTextBox1.Text += "\n7.feladat";
            foreach (var item in orszagok)
            {
                if (item.Value>1)
                {
                    richTextBox1.Text += $"\n\t{item.Key}: {item.Value} versenyző";
                }
            }

        }

        private void button8Feladat_Click(object sender, EventArgs e)
        {
            Dictionary<string,double> vegeredmeny_rendezettlen = new Dictionary<string,double>();

            foreach (var item in Versenyzok)
            {
                vegeredmeny_rendezettlen.Add($"{item.Nev};{item.Orszag}",ÖsszPontszám(item.Nev));
            }
        }
    }
    class Versenyzo
    {
        #region Mezők
        private string nev;
        private string orszag;
        private double technikai;
        private double komponens;
        private int levonas;
        #endregion

        #region Property-k
        public string Nev { get { return nev; } set { nev = value; } } // Hagyományosan kiírt
        public string Orszag { get => orszag; set => orszag = value; } // LAMBDA kifejezéssel
        public double Technikai { get => technikai; set => technikai = value; }
        public double Komponens { get => komponens; set => komponens = value; }
        public int Levonas { get => levonas; set => levonas = value; }
        #endregion

        #region Konstruktor
        //írd be: ctor üss két TAb-ot
        public Versenyzo(string[] adatok)
        {
            Nev = adatok[0];
            Orszag = adatok[1];
            Technikai = double.Parse(adatok[2].Replace('.', ','));
            Komponens = double.Parse(adatok[3].Replace('.', ','));
            Levonas = int.Parse(adatok[4]);
        }

        #endregion
    }
}
