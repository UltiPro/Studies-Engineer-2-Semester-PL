#include <iostream>
#include <windows.h>
#include "stos.cpp"

using namespace std;

//Obiekt poprzez funkcje f zostaje skopiowany "powielony", nie działamy na oryginale.

void f(Stos s, int a) {
     s.push(a);
     
}

main() {
    Stos s;
    s.push(0);
    f(s, 1);
    f(s, 2); 
    while(!s.empty()) {
        cout << 
        s.top();
        s.pop();
    }
}

// Sprawdzanie punktu 1 oraz innych funkcjonalnosci
/*
void d(Stos s)
{
    cout<<s.top()<<endl;
}

int main()
{
    Stos stosik;

    Stos stosik2(10);

    stosik2.push(10);
    stosik2.push(9);
    stosik2.push(8);
    stosik2.push(7);
    stosik2.push(6);
    stosik2.push(5);
    stosik2.push(4);

    d(stosik2);

    return 0;
}
*/


