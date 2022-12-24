using System;
using System.Threading;
using figury;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            bool turn=true;
            int sterujacy,x,y;

            Obraz obrazek = new Obraz();

            while(turn)
            {
                Console.ResetColor();

                Console.Clear();

                Console.ForegroundColor=ConsoleColor.Magenta;

                Console.WriteLine("1. Dodaj Trojkat ");
                Console.WriteLine("2. Dodaj Czworokat ");
                Console.WriteLine("3. Przesun obraz ");
                Console.WriteLine("4. Maluj obraz \n");

                Console.ForegroundColor=ConsoleColor.DarkMagenta;

                Console.WriteLine("0. Zakoncz program! ");

                Console.ForegroundColor=ConsoleColor.Cyan;

                Console.WriteLine("--------------------------------------------");

                Console.ForegroundColor=ConsoleColor.Yellow;

                Console.WriteLine("Twoj wybor: "); Console.ResetColor(); sterujacy=Convert.ToInt32(Console.ReadLine());

                switch(sterujacy)
                {
                    case 1: 
                        Console.Clear(); 
                        Console.ForegroundColor=ConsoleColor.Green;
                        Trojkat t = new Trojkat(); 
                        obrazek.dodajTrojkat(t);
                        Console.WriteLine("Nacisnij dowolny klawisz aby kontunowac ...");
                        Console.ReadKey();
                    break;
                    case 2: 
                        Console.Clear(); 
                        Console.ForegroundColor=ConsoleColor.Green;
                        Czworokat c = new Czworokat();
                        obrazek.dodajCzworokat(c);
                        Console.WriteLine("Nacisnij dowolny klawisz aby kontunowac ...");
                        Console.ReadKey();
                    break;
                    case 3: 
                        Console.ForegroundColor=ConsoleColor.Green;
                        Console.WriteLine("Podaj rozmiar x do przesuniecia: ");
                        x=Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Podaj rozmiar y do przesuniecia: ");
                        y=Convert.ToInt32(Console.ReadLine());
                        obrazek.przesun(x,y);
                        Console.WriteLine("Nacisnij dowolny klawisz aby kontunowac ...");
                        Console.ReadKey();
                    break;
                    case 4: 
                        Console.ForegroundColor=ConsoleColor.Yellow;
                        Console.WriteLine(obrazek.ToString());
                        Console.WriteLine("Nacisnij dowolny klawisz aby kontunowac ...");
                        Console.ReadKey();
                    break;
                    case 0: 
                        turn=false;
                    break;
                    default: 
                        Console.ForegroundColor=ConsoleColor.Red;
                        for(int i=3;i>0;i--)
                        {
                            Console.WriteLine("Bledna wartosc RESET!!! za "+i);
                            Thread.Sleep(1000);
                        }
                    break;
                }
            }
            Console.ResetColor();
        }
    }
}
