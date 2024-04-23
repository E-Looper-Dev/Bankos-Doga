using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Bank
    {
        public List<Szamla> Szamla { get; set; }
        public Bank() 
        {
            Szamla = new List<Szamla>();
        }
        public void UjSzamlaHozzaadasa(Szamla szamla)
        {
            Szamla.Add(szamla);
        }
        public Szamla SzamlaKeresese(string szamlaszam)
        {
            foreach (Szamla szamla in Szamla)
            {
                if (szamla.szamlaszam == szamlaszam)
                {
                    Console.WriteLine($"{szamla.Tulajdonos}, {szamla.szamlaszam}, {szamla.egyenleg}");
                    return szamla;
                }
            }
            return null;
        }
        public bool SzamlaTorlese(string szamlaszam) 
        {
            foreach (Szamla szamla in Szamla)
            {
                if (szamla.szamlaszam == szamlaszam)
                {
                    Szamla.Remove(szamla);
                    return true;
                }
            }
            return false;
        }
        public bool Utalas(string forrasSzamlaSzam, string celSzamlaSzam, int osszeg)
        {
            Szamla forrasSzamla = SzamlaKeresese(forrasSzamlaSzam);
            Szamla celSzamla = SzamlaKeresese(celSzamlaSzam);

            if (forrasSzamla == null || celSzamla == null)
            {
                Console.WriteLine("Hiba: A forrás számla vagy a cél számla nem található.");
                return false;
            }

            if (forrasSzamla.egyenleg < osszeg)
            {
                Console.WriteLine("Hiba: A forrás számlán nincs elegendő fedezet az utaláshoz.");
                return false;
            }

            forrasSzamla.Kivet(osszeg);
            celSzamla.Betet(osszeg);

            Console.WriteLine($"Sikeres utalás: {osszeg} összegű utalás {forrasSzamla.Tulajdonos} számlájáról {celSzamla.Tulajdonos} számlájára.");
            return true;
        }
        public bool SzamlaLezarasa(string szamlaszam)
        {
            Szamla szamla = SzamlaKeresese(szamlaszam);

            if (szamla == null)
            {
                Console.WriteLine("Hiba: A megadott számlaszámú számla nem található.");
                return false;
            }

            if (szamla.egyenleg != 0)
            {
                Console.WriteLine("Hiba: A számla egyenlege nem nulla, előbb ki kell egyenlíteni az egyenleget.");
                return false;
            }
            if (SzamlaTorlese(szamlaszam))
            {
                Console.WriteLine($"A számla sikeresen le lett zárva: {szamlaszam}");
                return true;
            }
            else
            {
                Console.WriteLine("Hiba: Nem sikerült a számla lezárása.");
                return false;
            }
        }
        public Szamla TobbSzamlaNyitas(string tulajdonos, string szamlatipus, int egyenleg)
        {
            Szamla ujSzamla;

            if (szamlatipus.ToLower() == "megtakarítás")
            {
                ujSzamla = new MegtakaritasSzamla(tulajdonos, GenerateSzamlaszam(), egyenleg, 3);
            }
            else if (szamlatipus.ToLower() == "folyó")
            {
                ujSzamla = new Szamla(tulajdonos, GenerateSzamlaszam(), egyenleg);
            }
            else
            {
                throw new ArgumentException("Érvénytelen számlatípus.");
            }

            Szamla.Add(ujSzamla);
            return ujSzamla;
        }
        private string GenerateSzamlaszam()
        {
            Random rnd = new Random();
            StringBuilder szamlaszamBuilder = new StringBuilder();

            // Első négy karakter: véletlenszerű számok
            for (int i = 0; i < 4; i++)
            {
                szamlaszamBuilder.Append(rnd.Next(0, 10)); // 0-9 közötti véletlenszerű szám hozzáadása
            }
            szamlaszamBuilder.Append("-");
            for (int i = 0; i < 8; i++)
            {
                szamlaszamBuilder.Append(rnd.Next(0, 10)); // 0-9 közötti véletlenszerű szám hozzáadása
            }

            return szamlaszamBuilder.ToString();
        }
    }
}
