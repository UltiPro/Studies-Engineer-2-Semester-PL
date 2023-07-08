using namespace std;

class Stos
{
    int ile_elementow_stosu;
    int ktory_element;
    int *stos;

public:
    Stos();
    Stos(int);
    Stos(const Stos &stos);
    ~Stos();
    void push(int l);
    void pop();
    int top();
    bool empty();
    bool full();
};