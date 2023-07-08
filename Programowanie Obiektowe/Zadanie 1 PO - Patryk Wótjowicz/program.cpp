#include <iostream>
#include <windows.h>
#include "stos.cpp"
#include "menu.h"

using namespace std;

int main()
{
    int rozmiar;
    cout << "Podaj rozmiar stosu: ";
    cin >> rozmiar;
    Stos stosik(rozmiar);

    stosik.show();

    menu(stosik);

    return 0;
}