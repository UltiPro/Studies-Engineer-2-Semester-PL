using System;
using System.Collections.Generic;
using Wyjatki;

namespace _10._KOLEJKA_FIFO
{
    class Kolejka
    {
        private int max_pojemnosc;
        private List<int> kolejka = new List<int>();
        private int zakres_intow;
        public Kolejka(int m, int z)
        {
            max_pojemnosc = m;
            zakres_intow = z;
        }
        public void dodajKoniec(int n)
        {
            if (kolejka.Count == max_pojemnosc)
            {
                throw new PozaZakresem();
            }
            if (n > zakres_intow || n < 0)
            {
                throw new ZlyNumer(n);
            }
            kolejka.Add(n);
        }
        public void usunPierwszy()
        {
            if (kolejka.Count == 0)
            {
                throw new PustaKolejka();
            }
            kolejka.Remove(kolejka[0]);
        }
        public void pokaz()
        {
            foreach (int a in kolejka)
            {
                Console.WriteLine($"{a}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int kolejka_dlugosc, zakres, wybor;
            Console.WriteLine("Ile kolejka ma zawierac pól? Podaj: "); kolejka_dlugosc = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Jaki zakres ma zawierac kolejka? (od 0 do N) Podaj N:"); zakres = Convert.ToInt32(Console.ReadLine());
            Kolejka k = new Kolejka(kolejka_dlugosc, zakres);
            bool x = true;
            while (x)
            {
                Console.Clear();
                k.pokaz();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("1 - dodaj");
                Console.WriteLine("2 - usun");
                Console.WriteLine("3 - wyjdz");
                Console.ResetColor();
                Console.WriteLine("Twoj wybor: "); wybor = Convert.ToInt32(Console.ReadLine());
                switch (wybor)
                {
                    case 1:
                        Console.WriteLine("Podaj numer:");
                        wybor = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            k.dodajKoniec(wybor);
                        }
                        catch (PozaZakresem pz)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(pz);
                            Console.ResetColor();
                            x = false;
                        }
                        catch (ZlyNumer zn)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(zn + ", chciales dodac: " + zn.getNumber() + ". Liczba poza dozwolonym zakresem!");
                            Console.ResetColor();
                            x = true;
                            while (x)
                            {
                                Console.WriteLine("Podaj inny numer aby go dodac do kolejki:");
                                wybor = Convert.ToInt32(Console.ReadLine());
                                try
                                {
                                    k.dodajKoniec(wybor);
                                    x = false;
                                }
                                catch (ZlyNumer zn2)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(zn2 + ", chciales dodac: " + zn2.getNumber() + ". Liczba poza dozwolonym zakresem!");
                                    Console.ResetColor();
                                }
                            }
                            x = true;
                        }
                        break;
                    case 2:
                        try
                        {
                            k.usunPierwszy();
                        }
                        catch (PustaKolejka pk)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(pk);
                            Console.ResetColor();
                            x = false;
                        }
                        break;
                    case 3:
                        x = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Bledna wartosc RESET!!!");
                        break;
                }
            }
        }
    }
}