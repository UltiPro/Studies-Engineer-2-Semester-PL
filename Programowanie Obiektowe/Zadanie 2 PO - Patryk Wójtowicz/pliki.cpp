#include <iostream>
#include <string>
#include <fstream>
#include "fpomoc.h"

using namespace std;

int main()
{
    string nazwa_pliku;
    cout<<"Podaj nazwe pliku tekstowego do obslugi (bez rozszerzenia): "; cin>>nazwa_pliku;
    string nazwa_plik1=nazwa_pliku+".txt";
    string nazwa_plik2=nazwa_pliku+".max";

    fstream plik1;
    plik1.open(nazwa_plik1, ios::in | ios::out | ios::app);

    if(plik1.good()==0)
    {
        cout<<"Plik nie istnieje lub nie mozna go otworzyc!";
        return 0;
    }

    fstream plik2;
    plik2.open(nazwa_plik2, ios::in | ios::out | ios::app);

    if(plik2.good()==0)
    {
        cout<<"Blad utworzenia/otwarcia pliku!";
        return 0;
    }

    float naj_skutecznosc=sprawdz_skutecznosc(nazwa_plik1);

    while(!plik1.eof())
    {
        string imie;
        string nazwisko;
        int wiek;
        float skutecznosc;

        plik1>>imie;
        plik1>>nazwisko;
        plik1>>wiek;
        plik1>>skutecznosc;

        if((imie.length()>3)&&(sprawdz_nazwisko(nazwisko))&&(naj_skutecznosc==skutecznosc))
        { 
            plik2<<wypisz_anonim(imie)<<" "<<wypisz_anonim(nazwisko)<<" "<<wiek<<endl;
        }
    }
    
    plik1.close();
    plik2.close();
    
    return 0;
}