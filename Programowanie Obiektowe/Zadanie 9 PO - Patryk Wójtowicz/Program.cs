using System;
using System.Collections.Generic;
using Figury;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Figura> figury_lista = new List<Figura>();

            Random rnd = new Random();

            int i; 
            for(i=0;i<10;i++)
            {
                switch(rnd.Next(3))
                {
                    case 0:
                        figury_lista.Add(new Figura());
                    break;
                    case 1:
                        figury_lista.Add(new Kolo());
                    break;
                    case 2:
                        figury_lista.Add(new Kwadrat());
                    break;
                }
            }

            i=1;
            foreach(Figura fi in figury_lista)
            {
                Console.WriteLine($"{i}.{fi}\n");
                i++;
            }

            float c_pole=0;
            float c_obwod=0;
            foreach(Figura fi in figury_lista)
            {
                c_pole+=fi.pole();
                c_obwod+=fi.obwod();
            }

            Console.WriteLine($"pole 1: {c_pole}");
            Console.WriteLine($"obwod 1: {c_obwod}");

            c_pole=0;
            c_obwod=0;
            foreach(Figura fi in figury_lista)
            {
                fi.przesun(5,5);
                c_pole+=fi.pole();
                c_obwod+=fi.obwod();
            }

            Console.WriteLine($"pole 2: {c_pole}");
            Console.WriteLine($"obwod 2: {c_obwod}");

            c_pole=0;
            c_obwod=0;
            foreach(Figura fi in figury_lista)
            {
                fi.skaluj(2);
                c_pole+=fi.pole();
                c_obwod+=fi.obwod();
            }

            Console.WriteLine($"pole 3: {c_pole}");
            Console.WriteLine($"obwod 3: {c_obwod}");
        }
    }
}
