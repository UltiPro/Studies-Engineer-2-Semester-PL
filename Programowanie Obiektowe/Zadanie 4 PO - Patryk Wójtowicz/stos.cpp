#include <iostream>
#include "stos.h"

using namespace std;

Stos::Stos() // Konstruktor bez prarametrowy
{
    stos = new int[10];
    ktory_element = -1;
    ile_elementow_stosu = 10;
    cout << "Tworzymy bez parametrowo, konsturktor " << this << " stos: " << stos << endl;
}

Stos::Stos(int i) // Konstruktor z 1 parametrem
{
    stos = new int[i];
    ktory_element = -1;
    ile_elementow_stosu = i;
    cout << "Tworzymy z 1 parametrem, konsturktor " << this << " stos: " << stos << endl;
}

Stos::Stos(const Stos &stos_copy) // Konstruktor kopiujący
{
    this->stos = new int[stos_copy.ile_elementow_stosu];
    for (int i = 0; i < stos_copy.ile_elementow_stosu; i++)
    {
        this->stos[i] = stos_copy.stos[i];
    }
    this->ile_elementow_stosu = stos_copy.ile_elementow_stosu;
    this->ktory_element = stos_copy.ktory_element;
    cout << "Konstruktor kopiujacy " << this << " stos: " << stos << endl;
}

Stos::~Stos() // Destruktor (może być tylko 1)
{
    cout << "Niszczymy obiekt " << this << " stos: " << stos << endl;
    delete[] stos;
}

void Stos::push(int l)
{
    if (full())
    {
        cout << "Nie ma miejsca na stosie" << endl;
    }
    else
    {
        ktory_element++;
        stos[ktory_element] = l;
    }
}

void Stos::pop()
{
    if (empty())
    {
        cout << "Nie ma liczb do usunieaca" << endl;
    }
    else
    {
        stos[ktory_element] == 0;
        ktory_element--;
    }
}

int Stos::top()
{
    return stos[ktory_element];
}

bool Stos::empty()
{
    if (ktory_element == -1)
    {
        return true;
    }
    else
    {
        return false;
    }
}

bool Stos::full()
{
    if ((ktory_element + 1) == ile_elementow_stosu)
    {
        return true;
    }
    else
    {
        return false;
    }
}