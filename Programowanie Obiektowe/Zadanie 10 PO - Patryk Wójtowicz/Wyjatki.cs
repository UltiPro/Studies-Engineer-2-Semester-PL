using System;

namespace Wyjatki
{
    class PozaZakresem : Exception
    {
        public PozaZakresem() : base("Nie ma tyle miejsca w kolejce.") { }
    }
    class ZlyNumer : Exception
    {
        private int num;
        public int getNumber()
        {
            return num;
        }
        public ZlyNumer(int n) : base("Zły Numer")
        {
            num = n;
        }
    }
    class PustaKolejka : Exception
    {
        public PustaKolejka() : base("Kolejka jest pusta.") { }
    }
}