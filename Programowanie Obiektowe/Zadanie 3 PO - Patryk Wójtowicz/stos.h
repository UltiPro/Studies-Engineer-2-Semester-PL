class Stos
{
    int ile_elementow_stosu;
    int ktory_element;
    int *stos;

public:
    Stos(int = 1);
    ~Stos();
    void push(int l);
    void pop();
    int top();
    bool empty();
    bool full();
};