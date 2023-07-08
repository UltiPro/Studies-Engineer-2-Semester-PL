using System;
using System.Collections.Generic;

namespace figury
{
    class Punkt
    {
        private int x,y;
        public Punkt() 
        {
            x=0;
            y=0;
        }
        public Punkt(int _x,int _y)
        { 
            x=_x;
            y=_y;
        }
        public Punkt(Punkt p)
        {
            x=p.x;
            y=p.y;
        }
        public void przesun(int dx, int dy)
        {
            x+=dx;
            y+=dy;
        }
        override public string ToString()
        {
            return "("+x+","+y+")";
        }
    }
    class Linia
    {
        private Punkt p1,p2;
        public Linia() 
        {
            p1=new Punkt();
            p2=new Punkt();
        }
        public Linia(Punkt _p1,Punkt _p2)
        {
            p1=new Punkt(_p1);
            p2=new Punkt(_p2);
        }
        public Linia(Linia l)
        {
            p1=new Punkt(l.p1);
            p2=new Punkt(l.p2);
        }
        public Punkt poczatek_lini()
        {
            return p1;
        }
        public Punkt koniec_lini()
        {
            return p2;
        }
        public string poczatek_lini_str()
        {
            return p1.ToString();
        }
        public string koniec_lini_str()
        {
            return p2.ToString();
        }
        public void przesun(int dx, int dy)
        {
            p1.przesun(dx,dy);
            p2.przesun(dx,dy);
        }
        override public string ToString()
        {
            return "od "+p1.ToString()+" do "+p2.ToString()+"";
        }
    }
    class Trojkat
    {
        private Linia l1,l2,l3;
        public Trojkat() 
        {
            l1=new Linia();
            l2=new Linia();
            l3=new Linia();
        }
        public Trojkat(Punkt x,Punkt y,Punkt z)
        {
            l1=new Linia(x,y);
            l2=new Linia(y,z);
            l3=new Linia(z,x);
        }
        public Trojkat(Trojkat t)
        {
            l1=new Linia(t.l1);
            l2=new Linia(t.l2);
            l3=new Linia(t.l3);
        }
        public void przesun(int dx, int dy)
        {
            l1.przesun(dx,dy);
            l2.przesun(dx,dy);
            l3.przesun(dx,dy);
        }
        override public string ToString()
        {
            return "Linie:\n 1. "+l1.ToString()+"\n 2. "+l2.ToString()+"\n 3. "+l3.ToString();
        }
    }
    class Czworokat
    {
        private Linia l1,l2,l3,l4;
        public Czworokat() 
        {
            l1=new Linia();
            l2=new Linia();
            l3=new Linia();
            l4=new Linia();
        }
        public Czworokat(Linia x,Linia y,Punkt z)
        {
            // Zostawilem to rozwiazanie gdyz przy porwnaniu innych pomyslow 4 punktow, 3 lini, lini i 2 punktow
            // okazalo sie ze rozwiazanie z 2 liniami dla ktoryck sprawdzamy czy sie lacza w 1 punkcie i dla nich 
            // tworzymy polaczenie z punktem(czwartym wierzcholkiem) jest najlepsze bo zawsze utworzymy czworokat prawidlowy
            // a komunikat zostawilem dla programisty ze podane linie i punkt nie tworza czworokata
            l1=new Linia(x);
            if(x.poczatek_lini_str().Equals(y.poczatek_lini_str()))
            {
                l2=new Linia(y.koniec_lini(),y.poczatek_lini());
                l3=new Linia(x.koniec_lini(),z);
                l4=new Linia(z,l2.poczatek_lini());
            }
            else if(x.poczatek_lini_str().Equals(y.koniec_lini_str()))
            {
                l2=new Linia(y.poczatek_lini(),x.poczatek_lini());
                l3=new Linia(x.koniec_lini(),z);
                l4=new Linia(z,l2.poczatek_lini());
            }
            else if(x.koniec_lini_str().Equals(y.poczatek_lini_str()))
            {
                l2=new Linia(x.koniec_lini(),y.koniec_lini());
                l3=new Linia(l2.koniec_lini(),z);
                l4=new Linia(z,l1.poczatek_lini());
            }
            else if(x.koniec_lini_str().Equals(y.koniec_lini_str()))
            {
                l2=new Linia(x.koniec_lini(),y.koniec_lini());
                l3=new Linia(l2.koniec_lini(),z);
                l4=new Linia(z,l1.poczatek_lini());
            }
            else
            {
                Console.WriteLine("Programisto nie można utworzyc takiego czworokata!");
            }
        }
        public Czworokat(Czworokat c)
        {
            l1=new Linia(c.l1);
            l2=new Linia(c.l2);
            l3=new Linia(c.l3);
            l4=new Linia(c.l4);
        }
        public void przesun(int dx, int dy)
        {
            l1.przesun(dx,dy);
            l2.przesun(dx,dy);
            l3.przesun(dx,dy);
            l4.przesun(dx,dy);
        }
        override public string ToString()
        {
            return "Linie:\n 1. "+l1.ToString()+"\n 2. "+l2.ToString()+"\n 3. "+l3.ToString()+"\n 4. "+l4.ToString();
        }
    }

    class Obraz
    {
        private List<Trojkat> obraz_trojkaty = new List<Trojkat>();
        private List<Czworokat> obraz_czworokaty = new List<Czworokat>();

        public Obraz() { }
        public void dodajTrojkat(Trojkat t)
        {
            obraz_trojkaty.Add(t);
        }
        public void dodajCzworokat(Czworokat c)
        {
            obraz_czworokaty.Add(c);
        }
        public void przesun(int dx,int dy)
        {
            foreach(Trojkat t in obraz_trojkaty)
            {
                t.przesun(dx,dy);
            }
            foreach(Czworokat c in obraz_czworokaty)
            {
                c.przesun(dx,dy);
            }
        }
        override public string ToString()
        {
            string napis="";
            int i;
            for(i=0;i<obraz_trojkaty.Count;i++)
            {
                napis=napis+" "+(i+1)+". trojkat:\n"+obraz_trojkaty[i].ToString()+"\n\n";
            }
            for(int j=i;j<obraz_czworokaty.Count+i;j++)
            {
                napis=napis+" "+(j+1)+". czworokat:\n"+obraz_czworokaty[j-i].ToString()+"\n\n";
            }
            return napis;
        }
    }
}