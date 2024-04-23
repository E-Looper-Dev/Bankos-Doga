using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Szamla elsoSzamla = new Szamla("Lajos", "21435345-32356554", 2000000);
            Szamla masodikSzamla = new Szamla("Péter", "12345678-87654321", 3000000);
            bank.UjSzamlaHozzaadasa(elsoSzamla);
            bank.UjSzamlaHozzaadasa(masodikSzamla);

            bank.Utalas("21435345-32356554", "12345678-87654321", 100000);
            string elsoSzamlaSzam = elsoSzamla.szamlaszam;
            bank.SzamlaLezarasa(elsoSzamlaSzam);
            elsoSzamla.EgyenlegRiasztas(500);
            elsoSzamla.HozzaadTranzakcio("2024.04.20 - 10:00 - Betét - 5000 Ft");
            elsoSzamla.HozzaadTranzakcio("2024.04.21 - 14:30 - Kivét - 2000 Ft");
            elsoSzamla.Betet(500);
            elsoSzamla.Kivet(200);
            elsoSzamla.Betet(1000);
            elsoSzamla.TranzakcioElőzmények();
            bank.TobbSzamlaNyitas("Lajos", "folyó", 2000000);
            bank.TobbSzamlaNyitas("Lajos", "megtakarítás", 500000);
        }
    }
}
