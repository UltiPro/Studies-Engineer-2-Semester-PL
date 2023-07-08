#include <iostream>
#include "stos.h"

using namespace std;

Stos::Stos(int i)
{
    stos = new int[i];
    ktory_element = -1;
    ile_elementow_stosu = i;
}

Stos::~Stos()
{
    delete[] stos;
};

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