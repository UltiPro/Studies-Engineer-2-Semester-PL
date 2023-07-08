using System;

namespace Figury
{
    class Punkt
    {
        private float x, y;
        public Punkt()
        {
            x = 0;
            y = 0;
        }
        public Punkt(float _x,float _y)
        {
            x = _x;
            y = _y;
        }
        public void przesun(float dx, float dy)
        {
            x += dx;
            y += dy;
        }
        public float ZwrocX()
        {
            return x;
        }
        public float ZwrocY()
        {
            return y;
        }
        override public string ToString()
        {
            return $"({x},{y})";
        }
    }
    class Figura
    {
        protected Punkt srodek;
        public Figura()
        {
            srodek = new Punkt();
        }
        public Figura(Punkt p)
        {
            srodek = p;
        }
        public virtual void przesun(int x,int y) { srodek.przesun(x,y); }
        public virtual void skaluj(float skala) {}
        public virtual float pole() { return -1; }
        public virtual float obwod() { return -1; }

        public override string ToString()
        {
            return "Figura";
        }
    }
    class Kolo : Figura
    {
        float r;
        public Kolo() : base() { r=1; }
        public Kolo(Punkt p,float _r) : base(p) { r=_r; }
        public override void skaluj(float skala)
        {
            r*=skala;
        }
        public override float pole()
        {
            return (float)Math.PI*r*r;
        }
        public override float obwod()
        {
            return 2*(float)Math.PI*r;
        }
        public override string ToString()
        {
            return $"Kolo o srodku {srodek}, promieniu {r}";
        }
    }
    class Kwadrat : Figura
    {
        float a;
        public Kwadrat() : base() 
        {
            a=1;
        }
        public Kwadrat(Punkt srodek,float a) : base(srodek)
        {
            this.a=a;
        }
        public override void skaluj(float skala)
        {
            a*=skala;
        }
        public float dlugosc_boku()
        {
            return a;
        }
        public override float pole()
        {
            return (float)Math.Pow(a,2);
        }
        public override float obwod()
        {
            return dlugosc_boku()*4;
        }
        public override string ToString()
        {
            return $"Czworokat o srodku {srodek}, i dlugosci boku {a}";
        }
    }
}