using System;
using System.Collections.Generic;

namespace figury
{
    class Punkt
    {
        private int x,y;
        public Punkt() 
        {
            Console.WriteLine("Wprowadz wspolrzedna x: "); 
            x=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wprowadz wspolrzedna y: "); 
            y=Convert.ToInt32(Console.ReadLine());
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
        public int punkt_x()
        {
            return x;
        }
        public int punkt_y()
        {
            return y;
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
            Console.WriteLine("Poczatek lini: ");
            p1=new Punkt();
            Console.WriteLine("Koniec lini: ");
            p2=new Punkt();
        }
        public Linia(Punkt _p1,Punkt _p2)
        {
            p1=_p1;
            p2=_p2;
        }
        public Linia(Linia l)
        {
            p1=l.p1;
            p2=l.p2;
        }
        public int Linia_poczatek_x()
        {
            return p1.punkt_x();
        }
        public int Linia_poczatek_y()
        {
            return p1.punkt_y();
        }
        public int Linia_koniec_x()
        {
            return p2.punkt_x();
        }
        public int Linia_koniec_y()
        {
            return p2.punkt_y();
        }
        public Punkt Punkt_poczatek()
        {
            return p1;
        }
        public Punkt Punkt_koniec()
        {
            return p2;
        }
        public double Dlugosc_Lini()
        {
            return Math.Sqrt(Math.Pow(Linia_poczatek_x()-Linia_koniec_x(),2)+Math.Pow(Linia_poczatek_y()-Linia_koniec_y(),2));
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
            Console.WriteLine("Tworzenie Trojkata: ");
            Console.WriteLine("Linia pierwsza: ");
            l1=new Linia();
            Console.WriteLine("Linia druga zaczyna się w punkcie ("+l1.Linia_koniec_x()+","+l1.Linia_koniec_y()+")"); 
            Console.WriteLine("Wskaz koniec lini drugiej: ");
            l2=new Linia(l1.Punkt_koniec(),new Punkt());
            l3=new Linia(l2.Punkt_koniec(),l1.Punkt_poczatek());
        }
        public Trojkat(Punkt x,Punkt y,Punkt z)
        {
            l1 = new Linia(x,y);
            l2 = new Linia(y,z);
            l3 = new Linia(z,x);
        }
        public Trojkat(Trojkat t)
        {
            l1=t.l1;
            l2=t.l2;
            l3=t.l3;
        }
        public void przesun(int dx, int dy)
        {
            l1.Punkt_poczatek().przesun(dx,dy);
            l2.Punkt_poczatek().przesun(dx,dy);
            l3.Punkt_poczatek().przesun(dx,dy);
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
            Console.WriteLine("Tworzenie czworokata: ");
            Console.WriteLine("Linia pierwsza: ");
            l1=new Linia();
            Console.WriteLine("Linia druga zaczyna się w punkcie ("+l1.Linia_koniec_x()+","+l1.Linia_koniec_y()+")"); 
            Console.WriteLine("Wskaz koniec lini drugiej: ");
            l2=new Linia(l1.Punkt_koniec(),new Punkt());
            Console.WriteLine("Linia trzecia zaczyna się w punkcie ("+l2.Linia_koniec_x()+","+l2.Linia_koniec_y()+")"); 
            Console.WriteLine("Wskaz koniec lini trzeciej: ");
            l3=new Linia(l2.Punkt_koniec(),new Punkt());
            l4=new Linia(l3.Punkt_koniec(),l1.Punkt_poczatek());
        }
        public Czworokat(Linia x,Linia y,Punkt z)
        {
            l1=x;
            if(x.Linia_poczatek_x()==y.Linia_poczatek_x()&&x.Linia_poczatek_y()==y.Linia_poczatek_y())
            {
                l2=new Linia(y.Punkt_koniec(),y.Punkt_poczatek());
                l3=new Linia(x.Punkt_koniec(),z);
                l4=new Linia(z,l2.Punkt_poczatek());
            }
            else if(x.Linia_poczatek_x()==y.Linia_koniec_x()&&x.Linia_poczatek_y()==y.Linia_koniec_y())
            {
                l2=new Linia(y.Punkt_poczatek(),x.Punkt_poczatek());
                l3=new Linia(x.Punkt_koniec(),z);
                l4=new Linia(z,l2.Punkt_poczatek());
            }
            else if(x.Linia_koniec_x()==y.Linia_poczatek_x()&&x.Linia_koniec_y()==y.Linia_poczatek_y())
            {
                l2=new Linia(x.Punkt_koniec(),y.Punkt_koniec());
                l3=new Linia(l2.Punkt_koniec(),z);
                l4=new Linia(z,l1.Punkt_poczatek());
            }
            else if(x.Linia_koniec_x()==y.Linia_koniec_x()&&x.Linia_koniec_y()==y.Linia_koniec_y())
            {
                l2=new Linia(x.Punkt_koniec(),y.Punkt_koniec());
                l3=new Linia(l2.Punkt_koniec(),z);
                l4=new Linia(z,l1.Punkt_poczatek());
            }
            else
            {
                Console.WriteLine("Nie można utworzyć Czworokata!");
            }
        }
        public Czworokat(Czworokat c)
        {
            l1=c.l1;
            l2=c.l2;
            l3=c.l3;
            l4=c.l4;
        }
        public void przesun(int dx, int dy)
        {
            l1.Punkt_poczatek().przesun(dx,dy);
            l2.Punkt_poczatek().przesun(dx,dy);
            l3.Punkt_poczatek().przesun(dx,dy);
            l4.Punkt_poczatek().przesun(dx,dy);
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