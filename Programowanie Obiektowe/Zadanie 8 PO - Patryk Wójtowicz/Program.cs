using System;
using Bankowosc;

namespace _8._BANK
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Osoba os = new Osoba();
            WaznaOsoba osw = new WaznaOsoba();
            Firma firm = new Firma();
            DuzaFirma bigfirm = new DuzaFirma();

            os.dodajKonto(new Konto("1"));
            os.getKonta()[0].wplac(2.5);
            os.dodajKonto(new Konto("2"));
            osw.dodajKonto(new Konto("3"));
            osw.dodajKonto(new Konto("4"));
            osw.getKonta()[1].wplac(2000);
            osw.dodajKonto(new Konto("5"));
            osw.getKonta()[2].wplac(50);
            firm.dodajKonto(new Konto("6"));
            firm.getKonta()[0].wplac(500);
            bigfirm.dodajKonto(new Konto("7"));
            bigfirm.getKonta()[0].wplac(2000);
            bigfirm.dodajKonto(new Konto("8"));
            bigfirm.getKonta()[1].wplac(1000);
            bigfirm.dodajKonto(new Konto("9"));
            bigfirm.getKonta()[1].wplac(25);
            
            bank.dodajKlienta(os);
            bank.dodajKlienta(osw);
            bank.dodajKlienta(firm);
            bank.dodajKlienta(bigfirm);

            double suma1=0,suma2=0,suma3=0,suma4=0;

            foreach(Klient o in bank.getKlienci())
            {
                if(o is Firma) 
                {
                    foreach(Konto k in o.getKonta())
                    {
                        suma1+=k.getSaldo();
                    }
                }
                if(o is Osoba) 
                {
                    foreach(Konto k in o.getKonta())
                    {
                        suma2+=k.getSaldo();
                    }
                }
                if(o is DuzaFirma || o is WaznaOsoba) 
                {
                    foreach(Konto k in o.getKonta())
                    {
                        suma3+=k.getSaldo();
                    }
                }
                if(o is Osoba && !(o is WaznaOsoba)) 
                {
                    foreach(Konto k in o.getKonta())
                    {
                        suma4+=k.getSaldo();
                    }
                }
            }

            Console.WriteLine($"Firmy -> {suma1}\n");
            Console.WriteLine($"Osoby -> {suma2}\n");
            Console.WriteLine($"Duze firmy i wazne osoby -> {suma3}\n");
            Console.WriteLine($"zwykle osoby -> {suma4}\n");
        }
    }
}
