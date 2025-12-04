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
                    "$\"3. Feladat\n\t" +
                    "$\"A magyar versenyző bejutott a kűrbe.";
            }
            else
            {
                richTextBox1.Text +=
                    "$\"3. Feladat\n\t" +
                    "$\"A magyar versenyző nem jutott be a kűrbe.";
            }

        }

        private double ÖsszPontszám()
        {
            return 0d;
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
