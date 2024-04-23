using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{

    internal class Szamla
    {
        private List<string> tranzakciok = new List<string>();
        public string Tulajdonos { get; set; }
        public string szamlaszam { get; set; }
        public int egyenleg { get; set; }
        public Szamla(string tulajdonos, string szamlaszam, int egyenleg) 
        { 
            this.Tulajdonos = tulajdonos;
            this.szamlaszam = szamlaszam;
            this.egyenleg = egyenleg;
        }

        public void Betet(int osszeg) 
        { 
            egyenleg += osszeg;
            Console.WriteLine($"Számládra utalás érkezett. Új egyenleg: {egyenleg}");
        }
        public void Kivet(int osszeg)
        {
            egyenleg -= osszeg;
            Console.WriteLine($"Számládra terhelés érkezett. Új egyenleg: {egyenleg}");
        }
        public void Lekerdez()
        {
            Console.WriteLine($"Számlád aktuális egyenlege: {egyenleg}");
        }
        public void EgyenlegRiasztas(int kuszob)
        {
            if (egyenleg < kuszob)
            {
                Console.WriteLine($"Figyelem! Az egyenleg alacsonyabb, mint a megadott küszöbérték ({kuszob}).");
            }
        }

        public void Betetel(int osszeg)
        {
            egyenleg += osszeg;
            string tranzakcio = $"Betét - {DateTime.Now} - {osszeg} Ft";
            HozzaadTranzakcio(tranzakcio);
            Console.WriteLine($"Számlára utalás érkezett. Új egyenleg: {egyenleg}");
        }

        public void Kivetel(int osszeg)
        {
            if (egyenleg >= osszeg)
            {
                egyenleg -= osszeg;
                string tranzakcio = $"Kivét - {DateTime.Now} - {osszeg} Ft";
                HozzaadTranzakcio(tranzakcio);
                Console.WriteLine($"Számláról terhelés történt. Új egyenleg: {egyenleg}");
            }
            else
            {
                Console.WriteLine("Nincs elegendő fedezet a kivételhez.");
            }
        }
        public void TranzakcioElőzmények()
        {
            Console.WriteLine("Tranzakciók előzményei:");

            if (tranzakciok.Count == 0)
            {
                Console.WriteLine("Nincs elérhető tranzakció előzmény.");
                return;
            }

            foreach (string tranzakcio in tranzakciok)
            {
                Console.WriteLine(tranzakcio);
            }
        }

        public void HozzaadTranzakcio(string tranzakcio)
        {
            tranzakciok.Add(tranzakcio);
        }

    }
}
