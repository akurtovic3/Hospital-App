using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using klinika;

namespace klinika_forma
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<klinika.Doktor> doktor17831 = new List<klinika.Doktor>();
            List<Ordinacija> ordinacija17831 = new List<Ordinacija>();
            List<klinika.Pacijent> pacijent17831 = new List<klinika.Pacijent>();
            List<Ostali> ostali = new List<Ostali>();
            HitanSlucaj pacijenthitni17831_1;// = new HitanSlucaj();
            Normalni pacijentnormalni17831_1;// = new Normalni();
            Ordinacija ordinacija17831_1 = new Ordinacija("Ortopedska ordinacija", true, true);
            ordinacija17831.Add(ordinacija17831_1);
            Ordinacija ordinacija17831_2 = new Ordinacija("Opsta medicina", true, true);
            ordinacija17831.Add(ordinacija17831_2);
            Ordinacija ordinacija17831_3 = new Ordinacija("Dermatoloska ordinacija", true, false);
            ordinacija17831.Add(ordinacija17831_3);
            Ordinacija ordinacija17831_4 = new Ordinacija("Otorinolaringologija", true, false);
            ordinacija17831.Add(ordinacija17831_4);
            Ordinacija ordinacija17831_5 = new Ordinacija("Stomatologija", true, true);
            ordinacija17831.Add(ordinacija17831_5);
            klinika.Doktor doktor17831_1 = new klinika.Doktor("Azra", "Ibric", "azra", "azra", "hirurg", ordinacija17831_1);
            doktor17831.Add(doktor17831_1);
            klinika.Doktor doktor17831_2 = new klinika.Doktor("Emina", "Zaimovic", "emina", "emina", "otorinolaringolog", ordinacija17831_4);
            doktor17831.Add(doktor17831_2);
            klinika.Doktor doktor17831_3 = new klinika.Doktor("Edina", "Pedljak", "edina", "edina", "Oftamolog", ordinacija17831_2);
            doktor17831.Add(doktor17831_3);
            klinika.Doktor doktor17831_4 = new klinika.Doktor("Zerina", "Sabotic", "zerina", "zerina", "Endokrinolog", ordinacija17831_3);
            doktor17831.Add(doktor17831_4);
            klinika.Medicinski_tehnicar doktor17831_5 = new klinika.Medicinski_tehnicar("Amina", "Kurtovic", "a", "a");
            ostali.Add(doktor17831_5);
            Klinika klinika17831 = new Klinika(pacijent17831, ordinacija17831, doktor17831, ostali);
           
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(klinika17831));
        }
    }
}
