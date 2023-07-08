using System;
using System.Collections.Generic;

namespace Bankowosc
{
    class Konto
    {
        private string nr;
        private double saldo;
        public Konto(string nr)
        {
            this.nr=nr;
            saldo=0;
        }
        public double getSaldo()
        {
            return saldo;
        }
        public string getNr()
        {
            return nr;
        }
        public void wplac(double kwota)
        {
            saldo+=kwota;
        }
        public void wyplac(double kwota)
        {
            if(saldo-kwota>=0)
            {
                saldo-=kwota;
            }
            else
            {
                Console.WriteLine("Za malo srodkow na koncie!");
            }
        }
    }
    class Klient
    {
        private List<Konto> Konta = new List<Konto>();
        /*public List<Konto> _Konta
        {
            get
            {
                return Konta;
            }
        }*/ // inna opcja rozwiązania
        public void dodajKonto(Konto k)
        {
            Konta.Add(k);
        }
        public List<Konto> getKonta()
        {
            return Konta;
        }
    }
    class Bank
    {
        private List<Klient> Klienci = new List<Klient>();
        /*public List<Klient> _Klient
        {
            get
            {
                return Klienci;
            }
        }*/ // inna opcja rozwiązania
        public void dodajKlienta(Klient k)
        {
            Klienci.Add(k);
        }
        public List<Klient> getKlienci()
        {
            return Klienci;
        }
    }
    class Osoba : Klient
    {
        private string imie,nazwisko,PESEL;
    }
    class WaznaOsoba : Osoba { }
    class Firma : Klient
    {
        private string nazwa,KRS;
    }
    class DuzaFirma : Firma { }
}