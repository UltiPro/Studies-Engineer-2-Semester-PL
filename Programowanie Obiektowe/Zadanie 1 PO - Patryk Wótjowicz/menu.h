void pasek()
{
    cout<<"-------------------------"<<endl;
}

void menu(Stos &s)
{
    int wybor,liczba;

    s.show();
    cout<<"-------------------------"<<endl;
    cout<<"Stos o rozmiarze: ";s.show_rozmiar();cout<<"!"<<endl;
    cout<<"1. Push"<<endl;
    cout<<"2. Pop"<<endl;
    cout<<"3. Top"<<endl;
    cout<<"4. Empty"<<endl;
    cout<<"5. Full"<<endl;
    cout<<"6. WYLACZ"<<endl;
    cout<<"-------------------------"<<endl;
    cout<<"Wybor: "; cin>>wybor;

    switch(wybor)
    {
        case 1: 
        if(s.full())
        {
            system("cls");  cout<<"Stos pelen! "<<endl; pasek();
        } 
        else
        {
            cout<<"Podaj liczbe: "; cin>>liczba; s.push(liczba); system("cls");
        } menu(s); break;
        case 2: system("cls"); s.pop(); menu(s); break;
        case 3: system("cls");
        if(s.empty())
        {
            cout<<"Stos jest pusty nie ma liczby na stosie!"<<endl;
        }
        else
        {
            cout<<"Liczba na szczycie stosu: "<<s.top()<<endl;
        } pasek(); menu(s); break;
        case 4: system("cls"); 
        if(s.empty())
        {
            cout<<"Stos jest pusty."<<endl; pasek();
        }
        else
        {
            cout<<"Stos nie jest pusty."<<endl; pasek();
        } menu(s); break;
        case 5: system("cls"); 
        if(s.full())
        {
            cout<<"Stos jest pelny."<<endl; pasek();
        }
        else
        {
            cout<<"Stos nie jest pelny."<<endl; pasek();
        } menu(s); break;
        case 6: break;
        default: system("cls"); cout<<"Zla wartosc!!!"<<endl; pasek(); menu(s); break;
    }
}