#include <iostream>
#include <windows.h>
#include "stos.cpp"

using namespace std;

int main()
{
    int liczba;
    Stos stosik(10);
    Stos stosik2(10);

    for (int i = 0; i < 10; i++)
    {
        cout << "Podaj " << i + 1 << " liczbe: ";
        cin >> liczba;
        stosik.push(liczba);
    }

    while (!stosik.empty())
    {
        stosik2.push(stosik.top());
        cout << stosik.top() << endl;
        stosik.pop();
    }

    while (!stosik2.empty())
    {
        stosik.push(stosik2.top());
        stosik2.pop();
    }

    return 0;
}