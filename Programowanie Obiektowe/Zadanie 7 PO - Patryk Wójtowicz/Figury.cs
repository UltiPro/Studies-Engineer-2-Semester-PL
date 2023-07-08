using System;
using System.Collections.Generic;

namespace Figury
{
    class Punkt
    {
        private int x, y;
        public Punkt()
        {
            x = 0;
            y = 0;
        }
        public Punkt(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public Punkt(Punkt p)
        {
            x = p.x;
            y = p.y;
        }
        public void przesun(int dx, int dy)
        {
            x += dx;
            y += dy;
        }
        public int ZwrocX()
        {
            return x;
        }
        public int ZwrocY()
        {
            return y;
        }
        override public string ToString()
        {
            return $"({x},{y})";
        }
    }
    class Linia
    {
        private Punkt p1, p2;
        public Linia()
        {
            p1 = new Punkt();
            p2 = new Punkt();
        }
        public Linia(Punkt _p1, Punkt _p2)
        {
            p1 = new Punkt(_p1);
            p2 = new Punkt(_p2);
        }
        public Linia(Linia l)
        {
            p1 = new Punkt(l.p1);
            p2 = new Punkt(l.p2);
        }
        public void przesun(int dx, int dy)
        {
            p1.przesun(dx, dy);
            p2.przesun(dx, dy);
        }
        override public string ToString()
        {
            return $"od {p1} do {p2}";
        }
    }
    class Figura
    {
        protected string kolor;
        public Figura()
        {
            kolor = "white";
        }
        public Figura(String kolor)
        {
            setKolor(kolor);
        }
        public string getKolor()
        {
            return kolor;
        }
        public void setKolor(String kolor)
        {
            this.kolor = kolor;
        }
    }
    class Trojkat : Figura
    {
        protected Linia l1, l2, l3;
        public Trojkat() : base()
        {
            l1 = new Linia();
            l2 = new Linia();
            l3 = new Linia();
        }
        public Trojkat(Punkt x, Punkt y, Punkt z) : base()
        {
            l1 = new Linia(x, y);
            l2 = new Linia(y, z);
            l3 = new Linia(z, x);
        }
        public Trojkat(string kolor, Punkt x, Punkt y, Punkt z) : base(kolor)
        {
            l1 = new Linia(x, y);
            l2 = new Linia(y, z);
            l3 = new Linia(z, x);
        }
        public Trojkat(Trojkat t) : base(t.getKolor())
        {
            l1 = new Linia(t.l1);
            l2 = new Linia(t.l2);
            l3 = new Linia(t.l3);
        }
        public void przesun(int dx, int dy)
        {
            l1.przesun(dx, dy);
            l2.przesun(dx, dy);
            l3.przesun(dx, dy);
        }
        override public string ToString()
        {
            return $"Linie:\n 1. {l1}\n 2. {l2}\n 3. {l3}\n kolor: {kolor}";
        }
    }
    class Czworokat : Figura
    {
        protected Linia l1, l2, l3, l4;
        public Czworokat() : base()
        {
            l1 = new Linia();
            l2 = new Linia();
            l3 = new Linia();
            l4 = new Linia();
        }
        public Czworokat(Punkt x, Punkt y, Punkt z, Punkt c) : base()
        {
            l1 = new Linia(x, y);
            l2 = new Linia(y, z);
            l3 = new Linia(z, c);
            l4 = new Linia(c, x);
        }
        public Czworokat(String kolor, Punkt p1, Punkt p2, Punkt p3, Punkt p4) : base(kolor)
        {
            l1 = new Linia(p1, p2);
            l2 = new Linia(p2, p3);
            l3 = new Linia(p3, p4);
            l4 = new Linia(p4, p1);
        }
        public Czworokat(Czworokat c) : base(c.getKolor())
        {
            l1 = new Linia(c.l1);
            l2 = new Linia(c.l2);
            l3 = new Linia(c.l3);
            l4 = new Linia(c.l4);
        }
        public void przesun(int dx, int dy)
        {
            l1.przesun(dx, dy);
            l2.przesun(dx, dy);
            l3.przesun(dx, dy);
            l4.przesun(dx, dy);
        }
        override public string ToString()
        {
            return $"Linie:\n 1. {l1}\n 2. {l2}\n 3. {l3}\n 4. {l4} kolor: {kolor}";
        }
    }

    class Prostokat : Czworokat
    {
        public Prostokat() : base() { }
        public Prostokat(Punkt p1, Punkt p2) : base(p1, new Punkt(p1.ZwrocX(), p2.ZwrocY()), p2, new Punkt(p2.ZwrocX(), p1.ZwrocY())) { }
        public Prostokat(String kolor, Punkt p1, Punkt p2) : base(kolor, p1, new Punkt(p1.ZwrocX(), p2.ZwrocY()), p2, new Punkt(p2.ZwrocX(), p1.ZwrocY())) { }
        public Prostokat(Prostokat p) : base(p) { }

        override public string ToString()
        {
            return $"Linie:\n 1. {l1}\n 2. {l2}\n 3. {l3}\n 4. {l4} kolor: {kolor}";
        } // ta metoda nie jest tutaj potrzebna ,gdyż taka sama metoda jest odziediczana z Czworokąta (ale z powodu treści zadania została tutaj dodana)
    }

    class Kwadrat : Prostokat
    {
        public Kwadrat() : base() { }
        public Kwadrat(Punkt p, int bok) : base(p, new Punkt(p.ZwrocX() + bok, p.ZwrocY() + bok)) { }
        public Kwadrat(String kolor, Punkt p, int bok) : base(kolor, p, new Punkt(p.ZwrocX() + bok, p.ZwrocY() + bok)) { }
        public Kwadrat(Kwadrat k) : base(k) { }

        override public string ToString()
        {
            return $"Linie:\n 1. {l1}\n 2. {l2}\n 3. {l3}\n 4. {l4} kolor: {kolor}";
        } // ta metoda nie jest tutaj potrzebna ,gdyż taka sama metoda jest odziediczana z Prostokąta a wcześniej z Czworokąta (ale z powodu treści zadania została tutaj dodana)
    }

    class Obraz
    {
        private List<Trojkat> obraz_trojkaty = new List<Trojkat>();
        private List<Czworokat> obraz_czworokaty = new List<Czworokat>();
        private List<Prostokat> obraz_prostokaty = new List<Prostokat>();
        private List<Kwadrat> obraz_kwadraty = new List<Kwadrat>();

        public Obraz() { }
        public void dodajTrojkat(Trojkat t)
        {
            obraz_trojkaty.Add(t);
        }
        public void dodajCzworokat(Czworokat c)
        {
            obraz_czworokaty.Add(c);
        }
        public void dodajProstokat(Prostokat p)
        {
            obraz_prostokaty.Add(p);
        }
        public void dodajKwadrat(Kwadrat k)
        {
            obraz_kwadraty.Add(k);
        }
        public void przesun(int dx, int dy)
        {
            foreach (Trojkat t in obraz_trojkaty)
            {
                t.przesun(dx, dy);
            }
            foreach (Czworokat c in obraz_czworokaty)
            {
                c.przesun(dx, dy);
            }
            foreach (Prostokat p in obraz_prostokaty)
            {
                p.przesun(dx, dy);
            }
            foreach (Kwadrat k in obraz_kwadraty)
            {
                k.przesun(dx, dy);
            }
        }
        override public string ToString()
        {
            string napis = "";
            int i;
            for (i = 0; i < obraz_trojkaty.Count; i++)
            {
                napis = napis + " " + (i + 1) + ". trojkat:\n" + obraz_trojkaty[i] + "\n\n";
            }
            for (int j = i; j < obraz_czworokaty.Count + i; j++)
            {
                napis = napis + " " + (j + 1) + ". czworokat:\n" + obraz_czworokaty[j - i] + "\n\n";
            }
            for (int j = i; j < obraz_prostokaty.Count + i; j++)
            {
                napis = napis + " " + (j + 1) + ". prostokat:\n" + obraz_prostokaty[j - i] + "\n\n";
            }
            for (int j = i; j < obraz_kwadraty.Count + i; j++)
            {
                napis = napis + " " + (j + 1) + ". kwadrat:\n" + obraz_kwadraty[j - i] + "\n\n";
            }
            return napis;
        }
    }
}