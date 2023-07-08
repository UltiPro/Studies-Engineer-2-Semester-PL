using System;
using System.Collections.Generic;

namespace kartoteka_osoba
{
    public class Osoba
    {
        private string imie, nazwisko;
        public Osoba(string i, string n)
        {
            this.imie = i;
            this.nazwisko = n;
        }
        public string getImie()
        {
            return this.imie;
        }
        public string getNazwisko()
        {
            return this.nazwisko;
        }
    }

    namespace mockup
    {
        public class Kartoteka
        {
            public void dodaj(Osoba osoba) { }
            public void usun(Osoba osoba) { }
            public int rozmiar() { return 1; }
            public bool czyZawiera(Osoba osoba) { return true; }
            public Osoba pobierz(int index) { return new Osoba("Gall", "Anonim"); }
            public void wypisz() { Console.WriteLine("Nikt"); }
        }
    }

    namespace impl
    {
        public class Kartoteka
        {
            public static List<Osoba> kartoteka = new List<Osoba>();

            public void dodaj(Osoba osoba)
            {
                kartoteka.Add(osoba);
            }
            public void usun(Osoba osoba)
            {
                kartoteka.Remove(osoba);
            }
            public int rozmiar()
            {
                return kartoteka.Count;
            }
            public bool czyZawiera(Osoba osoba)
            {
                foreach (Osoba os in kartoteka)
                {
                    if ((os.getImie().Equals(osoba.getImie())) && (os.getNazwisko().Equals(osoba.getNazwisko())))
                    {
                        return true;
                    }
                }
                return false;
            }
            public Osoba pobierz(int index)
            {
                return kartoteka[index - 1];
            }
            public void wypisz()
            {
                int i = 1;
                foreach (Osoba os in kartoteka)
                {
                    Console.WriteLine(i + ". " + os.getImie() + " " + os.getNazwisko() + " ");
                    i++;
                }
            }
        }
    }
}