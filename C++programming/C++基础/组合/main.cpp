#include <iostream>
using namespace std;

class A{
public:
	A(int x = 0) :x(x){}
	int getx(){ return x; }
private:
	int x;
};

class B{
public:
	B(int y = 0) :y(y){}
	B(int a, int b, int y) :a(a), b(b), y(y){}
	A geta(){ return a; }
	A getb(){ return b; }
	int gety(){ return y; }
private:
	A a;
	A b;
	int y;
};

int main()
{
	B b(1,2,3);
	cout << b.geta().getx() << endl;
	cout << b.getb().getx() << endl;
	cout << b.gety()<< endl;
	return 0;
}