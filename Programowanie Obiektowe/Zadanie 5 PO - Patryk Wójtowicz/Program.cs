using System;
using System.Threading;
using kartoteka_osoba;
using kartoteka_osoba.impl;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            bool turn = true;
            int sterujacy, index;
            string imie, nazwisko;

            Kartoteka k1 = new Kartoteka();

            while (turn)
            {
                Console.ResetColor();

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine("1. Dodaj do kartoteki ");
                Console.WriteLine("2. Usun z kartoteki ");
                Console.WriteLine("3. Rozmiar kartoteki ");
                Console.WriteLine("4. Czy dana osoba znajduje sie w kartotece? ");
                Console.WriteLine("5. Wypisz osobe po indexie ");
                Console.WriteLine("6. Wypisz wszystkich z kartoteki \n");

                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                Console.WriteLine("0. Zakoncz program! ");

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("--------------------------------------------");

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Twoj wybor: "); Console.ResetColor(); sterujacy = Convert.ToInt32(Console.ReadLine());

                switch (sterujacy)
                {
                    case 1:
                        Console.Clear(); Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Podaj Imie: "); Console.ResetColor(); imie = Console.ReadLine(); Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Podaj Nazwisko: "); Console.ResetColor(); nazwisko = Console.ReadLine();
                        k1.dodaj(new Osoba(imie, nazwisko));
                        break;
                    case 2:
                        Console.Clear(); Console.ForegroundColor = ConsoleColor.Green;
                        k1.wypisz(); Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Podaj index osoby do usuniecia: "); Console.ResetColor(); index = Convert.ToInt32(Console.ReadLine()); Console.Clear();
                        k1.usun(k1.pobierz(index));
                        break;
                    case 3:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Rozmiar kartoteki to: " + k1.rozmiar()); Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Nacisnij dowolny klawisz aby kontunowac ...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Podaj imie osoby do wyszukania: "); Console.ResetColor(); imie = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Podaj nazwisko osoby do wyszukania: "); Console.ResetColor(); nazwisko = Console.ReadLine();
                        if (k1.czyZawiera(new Osoba(imie, nazwisko)))
                        {
                            Console.WriteLine("Kartoteka zawiera osobe o imieniu " + imie + " i nazwisku " + nazwisko + " w swoim spisie");
                        }
                        else
                        {
                            Console.WriteLine("Kartoteka nie zawiera osoby o imieniu " + imie + " i nazwisku " + nazwisko);
                        }
                        Console.WriteLine("Nacisnij dowolny klawisz aby kontunowac ...");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Podaj numer indeksu z ktorego chcesz pobrac informacje o osobe"); Console.ResetColor();
                        index = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        var os = k1.pobierz(index);
                        Console.WriteLine("Osoba o indexie " + index + " ma na imie " + os.getImie() + " i nazwisko " + os.getNazwisko());
                        Console.WriteLine("Nacisnij dowolny klawisz aby kontunowac ...");
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        k1.wypisz();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Nacisnij dowolny klawisz aby kontunowac ...");
                        Console.ReadKey();
                        break;
                    case 0:
                        turn = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 3; i > 0; i--)
                        {
                            Console.WriteLine("Bledna wartosc RESET!!! za " + i);
                            Thread.Sleep(1000);
                        }
                        break;
                }
            }
            Console.ResetColor();
        }
    }
}