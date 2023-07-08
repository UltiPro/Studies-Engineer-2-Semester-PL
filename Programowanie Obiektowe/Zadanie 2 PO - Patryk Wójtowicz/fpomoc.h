#include <iostream>
#include <string>
#include <fstream>

using namespace std;

float sprawdz_skutecznosc(string p)
{
    float naj_skutecznosc;

    fstream plik;
    plik.open(p, ios::in | ios::out | ios::app);

    if (plik.good() == 0)
    {
        cout << "Blad otwarcia pliku w funkcji sprawdz_skutecznosc!";
        return 0;
    }

    while (!plik.eof())
    {
        string bufor;
        float skutecznosc;

        plik >> bufor >> bufor >> bufor >> skutecznosc;

        if (skutecznosc > naj_skutecznosc)
        {
            naj_skutecznosc = skutecznosc;
        }
    }

    plik.close();

    return naj_skutecznosc;
}

bool sprawdz_nazwisko(string nazwisko)
{
    int ile = nazwisko.length();

    if ((nazwisko[ile - 1] == 'i') && (nazwisko[ile - 2] == 'k') && (nazwisko[ile - 3] == 's'))
    {
        return true;
    }

    return false;
}

string wypisz_anonim(string s)
{
    for (int i = 1; i <= s.length() - 4; i++)
    {
        s[i] = '*';
    }

    return s;
}