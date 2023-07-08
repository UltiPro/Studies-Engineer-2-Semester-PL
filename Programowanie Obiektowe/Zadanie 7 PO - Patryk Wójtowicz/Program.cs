using System;
using Figury;

namespace _7._FIGURY
{
    class Program
    {
        static void Main(string[] args)
        {
            // Aby wykonać testy nie trzeba dużo robić, ponieważ wystarczy sprawdzić klasę kwadrat
            // jest to spowodowane tym ,że Kwadrat odziedzicza metody i pola z Prostokątu a Prostokąt z Czworokąta więc 
            // sprawność kwadratu zapewnia nam sprawność prostokąta i czworokąta jak i klasy figura 
            // Linia i punkt były sprawdzone na poprzednim zadaniu 
            // Klasa trókąt tak samo jedynie co dodaliśmy to że dziedziczy ona składowe z Figury ale to zostało tak samo zaimplementowane 
            // jak dla czworokąta a jest to już sprawdzone w kwadracie przez co wiemy że wszystko wyżej działa
                // testy

                Punkt x = new Punkt(0,0);
                Punkt y = new Punkt(5,5);

                Kwadrat t1 = new Kwadrat(); // konstrukotr bezparametrowy 
                Console.WriteLine(t1);

                Kwadrat t2 = new Kwadrat(x,5); // konstrukotr 2 parametrowy, który przybiera domyślny kolor z klasy Figura
                Console.WriteLine(t2);

                Kwadrat t3 = new Kwadrat("czerwony",x,5); // konstruktor 3 parametrowy z wpisanym kolorem
                Console.WriteLine(t3);

                Kwadrat t4 = new Kwadrat(t3); // konstruktor kopiujący 
                Console.WriteLine(t4);

                t1.przesun(5,5); // wywołanie przesunięć z metod odziedziczonych 

                Console.WriteLine(t1); // sprawdzenie poprawności użytej metody 

                //koniec testów
        }
    }
}
